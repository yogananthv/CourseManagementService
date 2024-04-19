using System.ComponentModel.DataAnnotations;

namespace CMS_Model.DTO
{
    public class TrainingDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string Month { get; set; }

        [Required]
        public string Status { get; set; }

        public CourseDto CourseObj { get; set; }
    }
}
