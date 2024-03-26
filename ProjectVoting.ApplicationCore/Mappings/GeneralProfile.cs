using AutoMapper;
using ProjectVoting.ApplicationCore.DTOs;

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
