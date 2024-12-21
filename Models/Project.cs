using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(100)] // Optional: Limit the length of the project name if needed
        public string ProjectName { get; set; }

        [NotMapped]
        public bool Checked { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<TeamMemberProjects> TeamMemberProjects { get; set; } = new List<TeamMemberProjects>();
    }
}
