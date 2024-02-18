using BlazorShop.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

const string BASE_URI = "https://localhost:7175";
builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(BASE_URI) });

await builder.Build().RunAsync();
