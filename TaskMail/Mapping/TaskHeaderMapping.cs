using AutoMapper;
using TaskMail.ViewModels; 
using TaskMail.DataModels;
public class TaskHeaderMapping : Profile
   {
    public TaskHeaderMapping()
    {
    CreateMap<TaskHeaderVM, TaskHeaderDM>()
     .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Resource)).ReverseMap()
    //  .ForMember(dest => dest.TM_Type, opt => opt.MapFrom(src => src.Type))
    //  .ForMember(dest => dest.TM_Month, opt => opt.MapFrom(src => src.Month))
    //  .ForMember(dest => dest.TM_Date, opt => opt.MapFrom(src => src.Date))
    //  .ForMember(dest => dest.TM_Year, opt => opt.MapFrom(src => src.Year))
    //  .ForMember(dest => dest.TM_InTime, opt => opt.MapFrom(src => src.In_Time))
    //  .ForMember(dest => dest.TM_OutTime, opt => opt.MapFrom(src => src.Out_Time))
    //  .ForMember(dest => dest.TM_TotalDuration, opt => opt.MapFrom(src => src.Total_Duration))
    //  .ForMember(dest => dest.TM_BreakDuration, opt => opt.MapFrom(src => src.Break_Duration))
    //  .ForMember(dest => dest.TM_ActWorkHours, opt => opt.MapFrom(src => src.Act_Work_Hours))
    //  .ForMember(dest => dest.TM_Comments, opt => opt.MapFrom(src => src.Comments))

     .ForMember(dest => dest.Resource, opt => opt.MapFrom(src => src.UserName)).ReverseMap();
    //  .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.TM_Type))
    //  .ForMember(dest => dest.Month, opt => opt.MapFrom(src => src.TM_Month))
    //  .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.TM_Date))
    //  .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.TM_Year))
    //  .ForMember(dest => dest.In_Time, opt => opt.MapFrom(src => src.TM_InTime))
    //  .ForMember(dest => dest.Out_Time, opt => opt.MapFrom(src => src.TM_OutTime))
    //  .ForMember(dest => dest.Total_Duration, opt => opt.MapFrom(src => src.TM_TotalDuration))
    //  .ForMember(dest => dest.Break_Duration, opt => opt.MapFrom(src => src.TM_BreakDuration))
    //  .ForMember(dest => dest.Act_Work_Hours, opt => opt.MapFrom(src => src.TM_ActWorkHours))
    //  .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.TM_Comments)).ReverseMap();
       }
   }
 
 