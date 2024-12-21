using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
    public class ToDo
    {
        [Key]
        public int TodoId { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please Select Status")]
        public string? Status { get; set; }
        [Required(ErrorMessage = "Due Date is Required")]
        public DateTime DueDate { get; set; }

        public string? FileNames { get; set; }


        [ForeignKey(nameof(Project))]
        public int ProjectID { get; set; }

        public Project? Project { get; set; }
    }
}
