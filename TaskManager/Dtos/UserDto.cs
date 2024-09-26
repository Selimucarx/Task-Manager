using TaskManager.Enums;

namespace TaskManager.Dtos;

public record UserDto
{
    public Guid Id { get; init; }
    public string Email { get; init; }
    public Role Role { get; init; }
}
