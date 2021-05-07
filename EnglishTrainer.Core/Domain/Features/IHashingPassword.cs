namespace EnglishTrainer.Core.Domain.Features
{
    public interface IHashingPassword
    {
        string HashPassword(string password);
        bool Verify(string password, string hashedPassword);
    }
}
