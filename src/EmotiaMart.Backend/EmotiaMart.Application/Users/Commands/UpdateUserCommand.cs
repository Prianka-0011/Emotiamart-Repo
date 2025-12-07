using EmotiaMart.Application.Interfaces;
using EmotiaMart.Application.Users.ViewModels;
using EmotiaMart.Domain.Entities;
using MediatR;

namespace EmotiaMart.Application.Users.Commands;

public class UpdateUserCommand : IRequest<User>
{
    public UserVm UserVm { get; set; } = null!;

    public class Handler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserVm.Id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            user.FirstName = request.UserVm.FirstName;
            user.LastName = request.UserVm.LastName;
            user.Email = request.UserVm.Email;
            user.IsActive = request.UserVm.IsActive;

            return await _userRepository.UpdateAsync(user);
        }
    }
}