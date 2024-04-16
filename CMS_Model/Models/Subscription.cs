using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [ForeignKey("Training")]
        public int TrainingId { get; set; }

        public Training Training { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
