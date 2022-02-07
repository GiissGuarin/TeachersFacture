using System.Text.Json;
using TeachersFacture.Models.DTO;

namespace TeachersFacture.Repository
{
    public class ExchangeRepository : IExchangeRepository
    {
        public async Task<ExchangeDTO> GetByMoney(string Money)
        {

            var API_KEY = "23a7f2cf6089bc8e564bc539";

            var url = $"https://v6.exchangerate-api.com/v6/{API_KEY}/latest/{Money}";
            Console.WriteLine(url);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var content = await response.Content.ReadAsStringAsync();
                var moneysExchange = JsonSerializer.Deserialize<ExchangeDTO>(content);
                return moneysExchange;
              

            }
        }
    }
}
