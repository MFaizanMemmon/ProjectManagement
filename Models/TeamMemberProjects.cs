using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
    public class TeamMemberProjects
    {
        [Key]
        public int TeamMemberProjectId { get; set; } // Primary Key

        [Required]
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; } // Foreign Key to Project

        [Required]
        [ForeignKey(nameof(Team))]
        public int TeamMemberID { get; set; } // Foreign Key to Teams

        // Navigation property to Project
        public Project Project { get; set; }

        // Navigation property to Teams
        public Teams Team { get; set; }
    }
}
