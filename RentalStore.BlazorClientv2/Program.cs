using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using RentalStore.BlazorClientv2;
using RentalStore.BlazorClientv2.Services;

namespace RentalStore.BlazorClientv2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // rejestracja Service w kontenerze zale¿noœci
            builder.Services.AddScoped<IEquipmentService, EquipmentService>();
            builder.Services.AddScoped<IRentalClientService, RentalClientService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddSingleton<CartStateService>();
            builder.Services.AddScoped<NotificationService>();

            // modyfikacja klienta http aby pobiera³ dane z pliku konfiguracyjnego
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration.GetValue<string>("RentalStoreAPIUrl"))
            });

            await builder.Build().RunAsync();
        }
    }
}