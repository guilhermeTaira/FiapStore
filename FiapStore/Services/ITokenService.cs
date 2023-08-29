using FiapStore.Entities;

namespace FiapStore.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
