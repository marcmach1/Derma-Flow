using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using DermaFlow.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Aqui é onde a mágica da interface acontece
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 1. Configura o HttpClient para falar com a sua API
// Dica: Verifique se a porta da sua API local é mesmo 5253 ou 5001
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://localhost:5253") 
});

// 2. Adiciona os serviços da Radzen (Notificações, Diálogos, etc)
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();