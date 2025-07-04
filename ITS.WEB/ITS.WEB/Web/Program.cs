using Abstracciones.Interfaces.Reglas;
using Reglas;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
//  Configuración de servicios
// -----------------------------
builder.Services.AddRazorPages();
builder.Services.AddSession(); // Soporte para sesiones

// -----------------------------
//  Configuración de dependencias HTTP
// -----------------------------
var apiBaseUrl = builder.Configuration["ApiEndPointsInventario:UrlBase"];
builder.Services.AddHttpClient<IInventarioApi, InventarioApi>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddScoped<IConfiguracion, Configuracion>();

// -----------------------------
//  Build de la aplicación
// -----------------------------
var app = builder.Build();

// -----------------------------
//  Configuración del pipeline HTTP
// -----------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapRazorPages();

app.Run();
