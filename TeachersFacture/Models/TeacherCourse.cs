namespace TeachersFacture.Models
{
    public class TeacherCourse
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public int DictatedHours { get; set; }
        public int Cost { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teachers { get; set; }
        public int CourseId { get; set; }
        public Course Courses { get; set; }
    }
}
