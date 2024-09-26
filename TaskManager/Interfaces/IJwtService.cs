using TaskManager.Enums;

namespace TaskManager.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string userId, Role role);
        void AddTokenToBlacklist(string token);
        bool IsTokenBlacklisted(string token);
        string? GetUserIdFromToken(string token);
    }
}