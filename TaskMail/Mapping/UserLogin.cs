using AutoMapper;
using TaskMail.DataModels;
using TaskMail.ViewModels;

namespace TaskMail.Mapping
{
    public class UserLogin:Profile
    {
        public UserLogin()
        {
            CreateMap<UserDetailsDM, UserDetails>() .ForMember(dest => dest.UsersId, opt => opt.MapFrom(src => src.UsersPk))
                                                    .ReverseMap();
        }
    }
}
