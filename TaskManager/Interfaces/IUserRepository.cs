using TaskManager.Models;

namespace TaskManager.Interfaces;

public interface IUserRepository
{
    User Register(User user);
    User? GetUser(string email);
    bool EmailExists(string email);

}