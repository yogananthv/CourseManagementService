using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
