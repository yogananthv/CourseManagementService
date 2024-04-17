﻿namespace CMS_Model.DTO
{
    public class TrainingDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int CourseId { get; set; }

        public string Month { get; set; }

        public string Status { get; set; }

        public CourseDto CourseObj { get; set; }
    }
}
