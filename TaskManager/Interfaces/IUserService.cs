using TaskManager.Dtos;

namespace TaskManager.Interfaces
{
    public interface IUserService
    {
         UserDto Register(RegisterUserDto dto);
          LoginResponseDto? Login(LoginUserDto dto, out string? errorMessage);
           LogoutResponseDto Logout(string token);
    }
}