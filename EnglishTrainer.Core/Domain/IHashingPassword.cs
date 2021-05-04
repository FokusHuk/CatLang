namespace EnglishTrainer.Core.Domain
{
    public interface IHashingPassword
    {
        string HashPassword(string password);
        bool Verify(string password, string hashedPassword);
    }
}
