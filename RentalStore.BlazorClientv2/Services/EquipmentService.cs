using Newtonsoft.Json;
using RentalStore.SharedKernel.Dto;

namespace RentalStore.BlazorClientv2.Services
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentDto>> GetAll();
    }
    public class EquipmentService : IEquipmentService
    {
        private readonly HttpClient _httpClient;
        public EquipmentService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IEnumerable<EquipmentDto>> GetAll()
        {
            var response = await _httpClient.GetAsync("/equipment");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var equipments = JsonConvert.DeserializeObject<IEnumerable<EquipmentDto>>(content);
                return equipments;
            }
            return new List<EquipmentDto>();
        }
    }
}
