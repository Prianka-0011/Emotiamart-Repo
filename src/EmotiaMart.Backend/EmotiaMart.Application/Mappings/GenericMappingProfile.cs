
using AutoMapper;
namespace EmotiaMart.Application.Mappings;

public class GenericMappingProfile<TSource, TDestination> : Profile
{
    public GenericMappingProfile()
    {
        CreateMap<TSource, TDestination>();
    }
}
