using Blazor.QrCodeGen;
using CleanArchi.Client.Components;
using CleanArchi.Client.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after"); 

// register the cookie handler
builder.Services.AddScoped<CookieHandler>();

// set up authorization
builder.Services.AddAuthorizationCore();

// register the custom state provider
builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();

// register the account management interface
builder.Services.AddScoped(
    sp => (IAccountManagement)sp.GetRequiredService<AuthenticationStateProvider>());

// set base address for default host
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:7296") });

// configure client for auth interactions
builder.Services.AddHttpClient(
    "Auth",
    opt => opt.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:7295"))
    .AddHttpMessageHandler<CookieHandler>();

// Use for Js in code
builder.Services.AddTransient(sp => new ModuleCreator(sp.GetService<IJSRuntime>()));

//MudBlazor
builder.Services.AddMudServices();
await builder.Build().RunAsync();
