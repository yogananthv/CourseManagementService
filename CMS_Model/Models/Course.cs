﻿using System.ComponentModel.DataAnnotations;

namespace CMS_Model.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }


    }
}
