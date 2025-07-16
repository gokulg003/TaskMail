using AutoMapper;

namespace CD_Info.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TM_Login_VM, TM_Login_DM>();
            CreateMap<TM_Login_DM, TM_Login_VM>();
        }
    }
}