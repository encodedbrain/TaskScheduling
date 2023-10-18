using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using TaskScheduling.Data;
using TaskScheduling.Interfaces;
using TaskScheduling.Schemas;

namespace TaskScheduling.Services;

public class UserGetService 
{
    public async Task<object> UserGet(SchemaUserGet prop)
    {
        if (!VaLidateEmail(prop.Email)) return false;
        if (!ValidatePassword(prop.Password)) return "operation not performed";

        using (var context = new TaskSchedulingDb())
        {
            var user = context.Users.FirstOrDefault(user =>
                user.Email == prop.Email && user.Password == EncryptingPassword(prop.Password));

            if (user is null) return false;

            user.Password = string.Empty;

            var token = new TokenService().GenerateToken(user);

            return new
            {
                user, token
            };
        }
    }


    public bool VaLidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;

        var pattern = "^\\S+@\\S+\\.\\S+$";
        var rgx = new Regex(pattern);

        return rgx.IsMatch(email);
    }

    public bool ValidateNickname(string name)
    {
        if (string.IsNullOrEmpty(name)) return false;

        if (name.Length > 30) return false;

        return true;
    }

    public bool ValidatePassword(string password)
    {
        var regex = new Regex(
            "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"
        );

        if (string.IsNullOrEmpty(password) || !regex.IsMatch(password))
            return false;
        else
            return true;
    }

    public string EncryptingPassword(string password)
    {
        var hash = SHA1.Create();
        var encoding = new ASCIIEncoding();
        var arrayBytes = encoding.GetBytes(password);

        arrayBytes = hash.ComputeHash(arrayBytes);

        var strHex = new StringBuilder();

        foreach (var value in arrayBytes) strHex.Append(value.ToString("x2"));

        return strHex.ToString();
    }
}