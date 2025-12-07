
using MediatR;
using EmotiaMart.Application.Interfaces;
using EmotiaMart.Application.Users.ViewModels;
using EmotiaMart.Application.Users.InputModels;
using EmotiaMart.Domain.Entities;
using AutoMapper;
namespace EmotiaMart.Application.Users.Commands;

public class LoginCommand : IRequest<LoginVm>
{
    public LoginInput LoginInput { get; set; } = null!;

    public class Handler : IRequestHandler<LoginCommand, LoginVm>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public Handler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<LoginVm> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // var user = _mapper.Map<User>(request.UserVm);
            // user.CreatedDate = DateTime.UtcNow;
            // user.CreatedById = Guid.NewGuid();

            // await _userRepository.GetByEmailAsync(request.LoginInput.Email);
            

            return new LoginVm
            {
                Id = Guid.NewGuid(),
                IsSuccess = true
            };
        }
    }
}