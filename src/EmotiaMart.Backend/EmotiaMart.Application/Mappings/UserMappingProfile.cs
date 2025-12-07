using AutoMapper;
using EmotiaMart.Domain.Entities;
using EmotiaMart.Application.Users.ViewModels;
using EmotiaMart.Application.Users.InputModels;

namespace EmotiaMart.Application.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserInput, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); 

        CreateMap<User, UserVm>();
    }
}
