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
        public int UserId { get; set; }

        [ForeignKey("Training")]
        public string TrainingId { get; set; }

        public Training Training { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
