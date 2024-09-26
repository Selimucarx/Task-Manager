using TaskManager.Enums;

namespace TaskManager.Dtos;

public class CreateTaskDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskFrequency Frequency { get; set; }
}