using AutoMapper;
using TaskMail.ViewModels; 
using TaskMail.DataModels;
public class TM_TaskHeaderMapping : Profile
   {
    public TM_TaskHeaderMapping()
    {
    CreateMap<TM_TaskHeaderVM, TM_TaskHeaderDM>()
     .ForMember(dest => dest.TM_UsersName, opt => opt.MapFrom(src => src.Resource))
     .ForMember(dest => dest.TM_Type, opt => opt.MapFrom(src => src.Type))
     .ForMember(dest => dest.TM_Month, opt => opt.MapFrom(src => src.Month))
     .ForMember(dest => dest.TM_Date, opt => opt.MapFrom(src => src.Date))
     .ForMember(dest => dest.TM_Year, opt => opt.MapFrom(src => src.Year))
     .ForMember(dest => dest.TM_In_Time, opt => opt.MapFrom(src => src.In_Time))
     .ForMember(dest => dest.TM_Out_Time, opt => opt.MapFrom(src => src.Out_Time))
     .ForMember(dest => dest.TM_Total_Duration, opt => opt.MapFrom(src => src.Total_Duration))
     .ForMember(dest => dest.TM_Break_Duration, opt => opt.MapFrom(src => src.Break_Duration))
     .ForMember(dest => dest.TM_Act_Work_Hours, opt => opt.MapFrom(src => src.Act_Work_Hours))
     .ForMember(dest => dest.TM_Comments, opt => opt.MapFrom(src => src.Comments)).ReverseMap()

     .ForMember(dest => dest.Resource, opt => opt.MapFrom(src => src.TM_UsersName))
     .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.TM_Type))
     .ForMember(dest => dest.Month, opt => opt.MapFrom(src => src.TM_Month))
     .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.TM_Date))
     .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.TM_Year))
     .ForMember(dest => dest.In_Time, opt => opt.MapFrom(src => src.TM_In_Time))
     .ForMember(dest => dest.Out_Time, opt => opt.MapFrom(src => src.TM_Out_Time))
     .ForMember(dest => dest.Total_Duration, opt => opt.MapFrom(src => src.TM_Total_Duration))
     .ForMember(dest => dest.Break_Duration, opt => opt.MapFrom(src => src.TM_Break_Duration))
     .ForMember(dest => dest.Act_Work_Hours, opt => opt.MapFrom(src => src.TM_Act_Work_Hours))
     .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.TM_Comments)).ReverseMap();
       }
   }
 
 