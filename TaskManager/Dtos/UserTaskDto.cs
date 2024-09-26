using TaskManager.Enums;


namespace TaskManager.Dtos
{
    public record UserTaskDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public DateTime? DueDate { get; init; }
    }
}
