namespace TeachersFacture.Models
{
    public class Course
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
