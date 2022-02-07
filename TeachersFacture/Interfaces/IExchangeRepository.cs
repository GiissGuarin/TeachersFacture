using TeachersFacture.Models.DTO;

namespace TeachersFacture.Repository
{
    public interface IExchangeRepository
    {
        Task<ExchangeDTO> GetByMoney(string Money);
    }
}
