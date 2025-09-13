using EmotiaMart.Application.Interfaces;
using EmotiaMart.Domain.Entities;

namespace EmotiaMart.API.GraphQL.Mutations;

public partial class UserMutation
{
    public async Task<User> AddUser(User user, [Service] IUserRepository repository)
    {
        return await repository.AddAsync(user);
    }

    public async Task<User> UpdateUser(User user, [Service] IUserRepository repository)
    {
        return await repository.UpdateAsync(user);
    }

    public async Task<bool> DeleteUser(Guid id, [Service] IUserRepository repository)
    {
        return await repository.DeleteAsync(id);
    }
}