using EmotiaMart.Application.Interfaces;
using EmotiaMart.Application.Users.ViewModels;
using EmotiaMart.Domain.Entities;
using MediatR;
namespace EmotiaMart.Application.Users.Commands;

public class DeleteUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public class Handler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            return await _userRepository.DeleteAsync(request.Id);
        }
    }
}