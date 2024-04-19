using System.ComponentModel.DataAnnotations;

namespace CMS_Model.DTO
{
    public class CourseDto
    {
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
