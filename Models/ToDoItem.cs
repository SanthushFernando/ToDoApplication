using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoApplication.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Task")]
        public String Title { get; set; }

        [Required]
        [DisplayName("Status")]
        public String IsCompleted { get; set; }

        [Required]
        [DisplayName("Assigned To")]
        public String Assignto { get; set; }
    }
}
