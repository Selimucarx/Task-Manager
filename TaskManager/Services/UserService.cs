using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TaskManager.Dtos;
using TaskManager.Enums;
using TaskManager.Extensions;
using TaskManager.Interfaces;

public class UserService(IUserRepository userRepository, IJwtService jwtService, IMapper mapper, IPasswordHasher<User> passwordHasher) : IUserService
{
    public UserDto Register(RegisterUserDto dto)
    {
        if (userRepository.EmailExists(dto.Email))
        {
            throw new InvalidOperationException(ErrorMessageType.EmailAlreadyExists.GetMessage());
        }

        var user = mapper.Map<User>(dto);
        user.Role = dto.Role ?? Role.User;
        user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);
        userRepository.Register(user);

        return mapper.Map<UserDto>(user);
    }


    public LoginResponseDto? Login(LoginUserDto dto, out string? errorMessage)
    {
        var user = userRepository.GetUser(dto.Email);
        if (user == null || passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password) != PasswordVerificationResult.Success)
        {
            errorMessage = ErrorMessageType.InvalidCredentials.GetMessage();
            return null;
        }

        errorMessage = null;
        var token = jwtService.GenerateToken(user.Id.ToString(), user.Role);

        return new LoginResponseDto
        {
            User = mapper.Map<UserDto>(user),
            Token = token
        };
    }

    public LogoutResponseDto Logout(string token)
    {
        jwtService.AddTokenToBlacklist(token);

        return new LogoutResponseDto
        {
            Message = "Çıkış başarılı"
        };
    }
}