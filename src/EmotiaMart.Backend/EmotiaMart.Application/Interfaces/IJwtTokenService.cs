namespace EmotiaMart.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(string userId);
    }
};