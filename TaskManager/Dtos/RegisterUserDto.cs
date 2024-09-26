using TaskManager.Enums;

namespace TaskManager.Dtos;

public class RegisterUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    
    public Role? Role { get; set; } 
}