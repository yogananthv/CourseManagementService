using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Model.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string UserName { get; set; }

        [ForeignKey("Training")]
        public int TrainingId { get; set; }

        public Training Training { get; set; }

        public string Status { get; set; }
    }
}
