using AutoMapper;
using System;
using TaskMail.ViewModels;

public class TaskDetailsProfile : Profile
{
    public TaskDetailsProfile()
    {
       
    CreateMap<TaskDetailsVM, TaskDetailsDM>()
        .ForMember(dest => dest.EstStDt, opt => opt.MapFrom(src => DateTime.ParseExact(src.EstStDt, "MM-dd-yyyy", null)))
        .ForMember(dest => dest.EstEndDt, opt => opt.MapFrom(src => DateTime.ParseExact(src.EstEndDt, "MM-dd-yyyy", null)))
        .ForMember(dest => dest.ActStDt, opt => opt.MapFrom(src => DateTime.ParseExact(src.ActStDt, "MM-dd-yyyy", null)))
        .ForMember(dest => dest.ActEndDt, opt => opt.MapFrom(src => DateTime.ParseExact(src.ActEndDt, "MM-dd-yyyy", null)))

        .ForMember(dest => dest.EstHours, opt => opt.MapFrom(src => TimeSpan.Parse(src.EstHours)))
        .ForMember(dest => dest.StTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.StTime)))
        .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.EndTime)))
        .ForMember(dest => dest.ActHours, opt => opt.MapFrom(src => TimeSpan.Parse(src.ActHours)));

    CreateMap<TaskDetailsDM, TaskDetailsVM>()
        .ForMember(dest => dest.EstStDt, opt => opt.MapFrom(src => src.EstStDt.ToString("MM-dd-yyyy")))
        .ForMember(dest => dest.EstEndDt, opt => opt.MapFrom(src => src.EstEndDt.ToString("MM-dd-yyyy")))
        .ForMember(dest => dest.ActStDt, opt => opt.MapFrom(src => src.ActStDt.ToString("MM-dd-yyyy")))
        .ForMember(dest => dest.ActEndDt, opt => opt.MapFrom(src => src.ActEndDt.ToString("MM-dd-yyyy")))

        .ForMember(dest => dest.EstHours, opt => opt.MapFrom(src => src.EstHours.ToString(@"hh\:mm\:ss")))
        .ForMember(dest => dest.StTime, opt => opt.MapFrom(src => src.StTime.ToString(@"hh\:mm\:ss")))
        .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString(@"hh\:mm\:ss")))
        .ForMember(dest => dest.ActHours, opt => opt.MapFrom(src => src.ActHours.ToString(@"hh\:mm\:ss")));

    }
}
