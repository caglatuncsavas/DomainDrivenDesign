using AutoMapper;
using DomainDrivenDesign.Application.Features.Auth;
using DomainDrivenDesign.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Profiles;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterCommand, CreateUserDto>();
    }
}
