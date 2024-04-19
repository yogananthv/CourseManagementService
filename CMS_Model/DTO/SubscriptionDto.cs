using System.ComponentModel.DataAnnotations;

namespace CMS_Model.DTO
{
    public class SubscriptionDto
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public string Company { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Status { get; set; }

        [Required]
        public int TrainingId { get; set; }

        public TrainingDto TrainingObj { get; set; }

       
    }
}
