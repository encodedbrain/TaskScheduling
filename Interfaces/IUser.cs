namespace TaskScheduling.Interfaces;

public interface IUser
{
    public bool VaLidateEmail(string email);

    public bool ValidateNickname(string name);

    public bool ValidatePassword(string password);

    public string EncryptingPassword(string password);
}