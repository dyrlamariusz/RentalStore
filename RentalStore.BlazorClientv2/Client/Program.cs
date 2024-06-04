using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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

            // rejestracja ProductService w kontenerze zale�no�ci
            builder.Services.AddScoped<IEquipmentService, EquipmentService>();

            // modyfikacja klienta http aby pobiera� dane z pliku konfiguracyjnego
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration.GetValue<string>("RentalStoreAPIUrl"))
            });

            await builder.Build().RunAsync();
        }
    }
}