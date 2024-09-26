using AutoMapper;
using TaskManager.Dtos;
using TaskManager.Models;

namespace TaskManager.Mappings
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTaskDto, UserTask>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.DueDate, opt => opt.Ignore()) 
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 
            CreateMap<UserTask, UserTaskDto>().ReverseMap();
        }
    }
}