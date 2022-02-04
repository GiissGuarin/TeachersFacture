﻿using System.ComponentModel.DataAnnotations;

namespace TeachersFacture.Models
{
    public class TeacherCourse
    {
        public string Name { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public int DictatedHours { get; set; }
        public int Cost { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teachers { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course Courses { get; set; }
    }
}
