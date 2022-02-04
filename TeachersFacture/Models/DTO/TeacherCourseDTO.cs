namespace TeachersFacture.Models.DTO
{
    public class TeacherCourseDTO
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public int DictatedHours { get; set; }
        public int Cost { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
    }
}
