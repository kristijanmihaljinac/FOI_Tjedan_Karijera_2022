using FakeShop.WebApp;
using FakeShop.WebApp.Services.ProductService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.HostEnvironment.BaseAddress
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://fakestoreapi.com") });
builder.Services.AddMudServices();
builder.Services.AddScoped<IProductClientService, ProductClientService>();


await builder.Build().RunAsync();
