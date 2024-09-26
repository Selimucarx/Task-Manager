namespace TaskManager.Dtos;

public record LoginResponseDto
{
    public UserDto User { get; init; }
    public string Token { get; init; }
}
