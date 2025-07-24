using AutoMapper;
using TaskMail.DataModels;
using TaskMail.ViewModels;
 
namespace TaskMailcommon.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TM_LoginVM, TM_LoginDM>();
            CreateMap<TM_LoginDM, TM_LoginVM>();
        }
    }
}