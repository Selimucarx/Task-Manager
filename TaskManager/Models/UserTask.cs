using System;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Enums;

namespace TaskManager.Models
{
    public class UserTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(20)")]
        public TaskFrequency Frequency { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }
    }
}