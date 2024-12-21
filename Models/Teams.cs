using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
    public class Teams
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [DisplayName("Member Name")]
        public string? MemberName { get; set; }

        public string? Role { get; set; }

        public List<Project> Projects { get; set; }
        // Navigation property for many-to-many relationship
        public ICollection<TeamMemberProjects> TeamMemberProjects { get; set; } = new List<TeamMemberProjects>();
    }
}
