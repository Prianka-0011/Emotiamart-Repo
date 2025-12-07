using EmotiaMart.Application.Interfaces;
using EmotiaMart.Domain.Entities;
using MediatR;
using EmotiaMart.Application.Users.Commands;
using EmotiaMart.Application.Users.ViewModels;
using EmotiaMart.Application.Users.InputModels;
using HotChocolate;

namespace EmotiaMart.API.GraphQL.Mutations;

public partial class Mutation
{
    public async Task<UserVm> Register([Service] IMediator mediator, UserInput userVm)
    {
        return await mediator.Send(new CreateUserCommand { UserInput = userVm });
    }
    
     public async Task<UserVm> Login([Service] IMediator mediator, UserInput userVm)
    {
         return await mediator.Send(new CreateUserCommand { UserInput = userVm });
    }

    public async Task<User> UpdateUser([Service] IMediator mediator, UserVm userVm)
    {
        return await mediator.Send(new UpdateUserCommand { UserVm = userVm });
    }

    public async Task<bool> DeleteUser([Service] IMediator mediator, Guid id)
    {
        return await mediator.Send(new DeleteUserCommand { Id = id });
    }
}