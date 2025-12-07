
using MediatR;
using EmotiaMart.Application.Interfaces;
using EmotiaMart.Application.Users.ViewModels;
using EmotiaMart.Application.Users.InputModels;
using EmotiaMart.Domain.Entities;
using EmotiaMart.Application.Common.Interfaces;
using AutoMapper;
using System.Security.Cryptography;

namespace EmotiaMart.Application.Users.Commands;

public class CreateUserCommand : IRequest<UserVm>
{
    public UserInput UserInput { get; set; } = null!;

    public class Handler : IRequestHandler<CreateUserCommand, UserVm>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationSettings _appSettings;

        public Handler(IUserRepository userRepository, IMapper mapper, IApplicationSettings appSettings)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = appSettings;
        }

        public async Task<UserVm> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.UserInput);

            user.PasswordHash = HashNewPassword(request.UserInput.Password, out byte[] newSalt);
            user.PasswordSalt = Convert.ToHexString(newSalt);

            user.CreatedDate = DateTime.UtcNow;
            user.CreatedById = Guid.NewGuid();

            await _userRepository.AddAsync(user);

            return _mapper.Map<UserVm>(user);
        }
        private string HashNewPassword(string password, out byte[] salt)
        {
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            salt = new byte[_appSettings.SaltSize];
            randomNumberGenerator.GetBytes(salt);

            using var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                _appSettings.HashIterations,
                new HashAlgorithmName(_appSettings.HashAlgorithm)
            );

            var hashToStore = pbkdf2.GetBytes(32);
            return Convert.ToHexString(hashToStore);
        }
    }
}