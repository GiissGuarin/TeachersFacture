namespace TeachersFacture.Models.DTO
{
    public class NominaDTO
    {
        public NominaDTO(int id, string name, string surname, string moneyPay, double cost, double costInCOP)
        {
            Id = id;
            Name = name;
            Surname = surname;
            MoneyPay = moneyPay;
            Cost = cost;
            CostInCOP = costInCOP;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MoneyPay { get; set; }
        public double Cost { get; set; }
        public double CostInCOP { get; set; }

    }
}
