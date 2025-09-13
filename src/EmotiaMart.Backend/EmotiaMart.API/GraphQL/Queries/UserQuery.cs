using MediatR;
using EmotiaMart.Application.Interfaces;
using EmotiaMart.Application.Users.ViewModels;
using EmotiaMart.Application.Users.Queries;
using HotChocolate;

namespace EmotiaMart.API.GraphQL.Queries;

public partial class Query
{
    public async Task<List<UserVm>> GetUsers([Service] IMediator mediator)
    {
        return await mediator.Send(new GetUsersQuery());
    }
}