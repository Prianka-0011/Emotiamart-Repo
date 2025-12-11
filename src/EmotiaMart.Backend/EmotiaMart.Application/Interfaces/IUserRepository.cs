using EmotiaMart.Domain.Entities;
namespace EmotiaMart.Application.Interfaces;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User> GetByEmailAsync(string email);
    Task<IReadOnlyList<User>> GetAllAsync();
    Task<User> AddAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<bool> DeleteAsync(Guid id);
}