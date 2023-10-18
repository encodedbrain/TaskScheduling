using TaskScheduling.Interfaces;

namespace TaskScheduling.Models;

public class UserModel
{
    public UserModel(string nickname, string email, string password)
    {
        Nickname = nickname;
        Email = email;
        Password = password;
    }

    public UserModel()
    {

    }

    public int  Id { get; set; }
    public string? Nickname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public virtual IEnumerable<TaskModel> Tasks { get; set; }
}