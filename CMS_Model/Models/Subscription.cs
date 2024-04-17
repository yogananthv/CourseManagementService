using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Model.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string UserName { get; set; }

        [ForeignKey("Training")]
        public int TrainingId { get; set; }

        public Training Training { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
