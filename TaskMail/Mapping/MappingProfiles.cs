using AutoMapper;

namespace CD_Info.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskMail_Login_VM, TaskMail_Login_DM>();
            CreateMap<TaskMail_Login_DM, TaskMail_Login_VM>();
        }
    }
}