using System.ComponentModel.DataAnnotations;

namespace TeachersFacture.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string IdentifyNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        [Required]
        public string MoneyPay { get; set; }
        [Required]
        public int RateHour { get; set; }
        public int RolId { get; set; }
    }
}
