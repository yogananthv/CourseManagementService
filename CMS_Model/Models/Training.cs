using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Model.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [ForeignKey("Course")]
        public string CourseId { get; set; }

        public Course Course { get; set; }

        [Required]
        public string Month { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
