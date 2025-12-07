using MediatR;
using Microsoft.EntityFrameworkCore;
using EmotiaMart.Application.Interfaces;
using EmotiaMart.Application.Users.ViewModels;
namespace EmotiaMart.Application.Users.Queries;
public class GetUserByIdQuery : IRequest<UserVm>
{
    public Guid Id { get; set; }

    public class Handler : IRequestHandler<GetUserByIdQuery, UserVm>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserVm> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {request.Id} not found.");
            }

            return new UserVm
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsActive = user.IsActive
            };
        }
    }
}