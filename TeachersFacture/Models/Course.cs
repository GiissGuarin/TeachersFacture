namespace TeachersFacture.Models
{
    public class Course
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<TeacherCourse> TeacherCourses { get; set; }
    }
}
