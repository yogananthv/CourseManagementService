using System.ComponentModel.DataAnnotations;

namespace CMS_Model.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        [Required]
        public string Status { get; set; }


    }
}
