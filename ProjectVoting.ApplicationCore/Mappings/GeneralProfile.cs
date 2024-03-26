using AutoMapper;
using ProjectVoting.ApplicationCore.DTOs;
using ProjectVoting.Infrastructure.Persistence.Models;

namespace ProjectVoting.ApplicationCore.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<UserRegistration, User>()
                .ForMember(user => user.UserName, options => options.MapFrom(x => x.Email));
        }
    }
}
