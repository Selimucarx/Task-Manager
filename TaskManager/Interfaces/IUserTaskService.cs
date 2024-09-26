using TaskManager.Dtos;

namespace TaskManager.Interfaces
{
    public interface IUserTaskService
    {
         UserTaskDto CreateTask(string token, CreateTaskDto taskDto);

          void DeleteTask(string token, Guid taskId);
    }
}