using AutoMapper;
using TaskManager.Data;
using TaskManager.Dtos;
using TaskManager.Enums;
using TaskManager.Extensions;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class UserTaskService(ApplicationDbContext context, IJwtService jwtService, IMapper mapper) : IUserTaskService
    {
        public UserTaskDto CreateTask(string token, CreateTaskDto taskDto)
        {
            var userId = jwtService.GetUserIdFromToken(token);
            if (userId == null)
            {
                throw new UnauthorizedAccessException(ErrorMessageType.InvalidToken.GetMessage());
            }

            var userTask = mapper.Map<UserTask>(taskDto);
            userTask.Id = Guid.NewGuid();
            userTask.UserId = Guid.Parse(userId);

            userTask.DueDate = taskDto.Frequency switch
            {
                TaskFrequency.Daily => DateTime.UtcNow.AddDays(1),
                TaskFrequency.Weekly => DateTime.UtcNow.AddDays(7),
                TaskFrequency.Monthly => DateTime.UtcNow.AddDays(30),
                _ => throw new ArgumentOutOfRangeException()
            };

            context.UserTasks.Add(userTask);
            context.SaveChanges();

            return mapper.Map<UserTaskDto>(userTask);
        }
        

        public void DeleteTask(string token, Guid taskId)
        {
            var userId = jwtService.GetUserIdFromToken(token);
            if (userId == null)
            {
                throw new UnauthorizedAccessException(ErrorMessageType.InvalidToken.GetMessage());
            }

            var userTask = context.UserTasks
                .FirstOrDefault(t => t.Id == taskId && t.UserId == Guid.Parse(userId));

            if (userTask == null)
            {
                throw new KeyNotFoundException("Görevi silmek icin yetkili degilsin");
            }

            context.UserTasks.Remove(userTask);
            context.SaveChanges(); 
        }
    }
}