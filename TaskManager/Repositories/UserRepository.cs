using TaskManager.Data;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public User Register(User user)
    {
        user.Id = Guid.NewGuid();
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }

    public User? GetUser(string email)
    {
        return context.Users.FirstOrDefault(u => u.Email == email);
    }

    public bool EmailExists(string email)
    {
        return context.Users.Any(u => u.Email == email);
    }
}