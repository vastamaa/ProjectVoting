using AutoMapper;
using ProjectVoting.ApplicationCore.DTOs;
using ProjectVoting.Infrastructure.Persistence.Models;
using System.Diagnostics.CodeAnalysis;

namespace ProjectVoting.ApplicationCore.Mappings
{
    [ExcludeFromCodeCoverage]
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<UserRegistration, User>()
                .ForMember(user => user.UserName, options => options.MapFrom(x => x.Email));
        }
    }
}
