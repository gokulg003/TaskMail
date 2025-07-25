using AutoMapper;
using TaskMail.DataModels;
using TaskMail.ViewModels;
 
namespace TaskMailcommon.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Login, TM_LoginDM>();
            CreateMap<TM_LoginDM, Login>();
        }
    }
}