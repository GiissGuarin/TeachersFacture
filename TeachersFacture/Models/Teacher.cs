﻿using System.ComponentModel.DataAnnotations;

namespace TeachersFacture.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string IdentifyNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string MoneyPay { get; set; }
        [Required]
        public int RateHour { get; set; }
        [Required]
        public int RolId { get; set; }
        public List<TeacherCourse> TeacherCourses { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
