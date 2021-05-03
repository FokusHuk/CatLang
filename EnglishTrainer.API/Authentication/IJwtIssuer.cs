using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.API.Authentication
{
    public interface IJwtIssuer
    {
        string GenerateToken(User user);
    }
}