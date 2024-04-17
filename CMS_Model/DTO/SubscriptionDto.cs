using System.ComponentModel.DataAnnotations;

namespace CMS_Model.DTO
{
    public class SubscriptionDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string UserName { get; set; }

        public string Status { get; set; }

        public int TrainingId { get; set; }

        public TrainingDto TrainingObj { get; set; }

       
    }
}
