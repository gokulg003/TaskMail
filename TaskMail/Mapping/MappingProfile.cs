using AutoMapper;
using TaskMail.DataModels;
using TaskMail.ViewModels;
 
namespace TaskMailcommon.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Login, LoginDM>();
            CreateMap<LoginDM, Login>();
        }
    }
}