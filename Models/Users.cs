using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]  
        public string? Password { get; set; }

        public string? Role { get; set; }
    }
}
