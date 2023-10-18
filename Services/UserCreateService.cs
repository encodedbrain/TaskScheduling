using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using TaskScheduling.Data;
using TaskScheduling.Interfaces;
using TaskScheduling.Models;
using TaskScheduling.Schemas;

namespace TaskScheduling.Services;

public class UserCreateService : IUser
{
    public async Task<object> UserCreate(SchemaPost prop)
    {
        if (!ValidateNickname(prop.Nickname)) return false;
        if (!VaLidateEmail(prop.Email)) return false;
        if (!ValidatePassword(prop.Password)) return false;

        using (var context = new TaskSchedulingDb())
        {
            var user = new UserModel()
            {
                Nickname = prop.Nickname,
                Email = prop.Email,
                Password = EncryptingPassword(prop.Password)
            };


            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            var token = new TokenService().GenerateToken(user);
            user.Password = string.Empty;            
            return  new
            {
                user,token
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