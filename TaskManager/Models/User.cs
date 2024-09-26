using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Enums;
using TaskManager.Models;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash  { get; set; } = string.Empty; 
    public ICollection<UserTask> Tasks { get; set; } = new List<UserTask>();

    [Column(TypeName = "nvarchar(24)")] 
    public Role Role { get; set; } = Role.User;
}


