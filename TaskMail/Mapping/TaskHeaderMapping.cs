using AutoMapper;
using TaskMail.ViewModels; 
using TaskMail.DataModels;
public class TaskHeaderMapping : Profile
{
   public TaskHeaderMapping()
   {
      CreateMap<TaskHeaderDM, TaskHeader>()
       .ForMember(dest => dest.TaskHeaderId, opt => opt.MapFrom(src => src.HeaderPk)).ReverseMap();

      
      CreateMap<TaskHeader, TaskHeaderDM>()
            .ForMember(dest => dest.InTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.InTime)))
            .ForMember(dest => dest.OutTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.OutTime)))
            .ForMember(dest => dest.TotalDuration, opt => opt.MapFrom(src => TimeSpan.Parse(src.TotalDuration)))
            .ForMember(dest => dest.BreakDuration, opt => opt.MapFrom(src => TimeSpan.Parse(src.BreakDuration)))
            .ForMember(dest => dest.ActWorkHours, opt => opt.MapFrom(src => TimeSpan.Parse(src.ActWorkHours)));

      CreateMap<TaskHeaderDM, TaskHeader>()
            .ForMember(dest => dest.InTime, opt => opt.MapFrom(src => src.InTime.ToString(@"hh\:mm\:ss")))
            .ForMember(dest => dest.OutTime, opt => opt.MapFrom(src => src.OutTime.ToString(@"hh\:mm\:ss")))
            .ForMember(dest => dest.TotalDuration, opt => opt.MapFrom(src => src.TotalDuration.ToString(@"hh\:mm\:ss")))
            .ForMember(dest => dest.BreakDuration, opt => opt.MapFrom(src => src.BreakDuration.ToString(@"hh\:mm\:ss")))
            .ForMember(dest => dest.ActWorkHours, opt => opt.MapFrom(src => src.ActWorkHours.ToString(@"hh\:mm\:ss")));
    }
}

   
 
 
 