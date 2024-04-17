using System.ComponentModel.DataAnnotations;

namespace CMS_Model.Models
{
    public class User
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
