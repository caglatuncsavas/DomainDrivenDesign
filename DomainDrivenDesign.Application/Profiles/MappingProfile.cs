using AutoMapper;
using DomainDrivenDesign.Application.Features.Auth;
using DomainDrivenDesign.Domain.Users;

namespace DomainDrivenDesign.Application.Profiles;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterCommand, CreateUserDto>();
    }
}
