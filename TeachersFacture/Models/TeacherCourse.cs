using System.ComponentModel.DataAnnotations;

namespace TeachersFacture.Models
{
    public class TeacherCourse
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int DictatedHours { get; set; }
        public double Cost { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public Teacher Teachers { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course Courses { get; set; }
    }
}
