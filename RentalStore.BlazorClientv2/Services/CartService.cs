using Microsoft.JSInterop;
using RentalStore.SharedKernel.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalStore.BlazorClientv2.Services
{
    public interface ICartService
    {
        Task AddToCart(EquipmentDto equipment);
        Task<List<EquipmentDto>> GetCartItems();
        Task RemoveFromCart(int equipmentId);
    }

    public class CartService : ICartService
    {
        private readonly IJSRuntime _jsRuntime;

        public CartService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task AddToCart(EquipmentDto equipment)
        {
            var cart = await GetCartItems();
            if (cart.Find(e => e.EquipmentId == equipment.EquipmentId) == null)
            {
                cart.Add(equipment);
                await SaveCartItems(cart);
            }
        }

        public async Task<List<EquipmentDto>> GetCartItems()
        {
            var cartJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "cart");
            return cartJson == null ? new List<EquipmentDto>() : System.Text.Json.JsonSerializer.Deserialize<List<EquipmentDto>>(cartJson);
        }

        public async Task RemoveFromCart(int equipmentId)
        {
            var cart = await GetCartItems();
            var item = cart.Find(e => e.EquipmentId == equipmentId);
            if (item != null)
            {
                cart.Remove(item);
                await SaveCartItems(cart);
            }
        }

        private async Task SaveCartItems(List<EquipmentDto> cart)
        {
            var cartJson = System.Text.Json.JsonSerializer.Serialize(cart);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "cart", cartJson);
        }
    }
}
