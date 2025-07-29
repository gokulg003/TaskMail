using AutoMapper;
using TaskMail.ViewModels; 
using TaskMail.DataModels;
public class TaskSetailsMapping : Profile
   {
    public TaskSetailsMapping()
    {
    CreateMap<TaskDetailsVM, TaskDetailsDM>()
     .ForMember(dest => dest.Res_Name, opt => opt.MapFrom(src => src.ResName)).ReverseMap()
   

     .ForMember(dest => dest.ResName, opt => opt.MapFrom(src => src.Res_Name)).ReverseMap();
    
       }
   }
 
 