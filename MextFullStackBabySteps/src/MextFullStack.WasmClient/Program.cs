using Blazored.Toast;
using MextFullStack.WasmClient;
using MextFullStack.WasmClient.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OpenAI.Extensions;
using Sotsera.Blazor.Toaster.Core.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5285/api/") });

builder.Services.AddBlazoredToast();

builder.Services.AddToaster(config =>
{
    //example customizations
    config.PositionClass = Defaults.Classes.Position.BottomRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = false;
});

builder.Services.AddScoped<IToasterService, SotseraToasterManager>();

//Gpt api key
const string apiKey= "";

builder.Services.AddOpenAIService(settings => settings.ApiKey= apiKey);

await builder.Build().RunAsync();
