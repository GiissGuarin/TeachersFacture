namespace TeachersFacture.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public List<Teacher> Teachers { get; set; }
    }
}
