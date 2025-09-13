using MediatR;
using Microsoft.EntityFrameworkCore;
using EmotiaMart.Application.Interfaces;
using EmotiaMart.Application.Users.ViewModels;
namespace EmotiaMart.Application.Users.Queries;

public class GetUsersQuery : IRequest<List<UserVm>>
{
    public class Handler : IRequestHandler<GetUsersQuery, List<UserVm>>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserVm>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserVm
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsActive = user.IsActive
            }).ToList();
        }
    }
}

