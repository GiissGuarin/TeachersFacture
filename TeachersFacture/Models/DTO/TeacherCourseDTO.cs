namespace TeachersFacture.Models.DTO
{
    public class TeacherCourseDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DictatedHours { get; set; }
        public double Cost { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
    }
}
