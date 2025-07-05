using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using DA;
using DA.Repositorios;
using Flujo;
using Microsoft.IdentityModel.Tokens;
using Reglas;
using Servicios;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
//  Configuraci�n del token (si aplica)
// -----------------------------
// Si no tienes JWT configurado, puedes comentar o quitar esta secci�n.
// var tokenConfiguration = builder.Configuration
//     .GetSection("Token")
//     .Get<TokenConfiguracion>();

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuer = true,
//             ValidateAudience = true,
//             ValidateLifetime = true,
//             ValidateIssuerSigningKey = true,
//             ValidIssuer = tokenConfiguration.Issuer,
//             ValidAudience = tokenConfiguration.Audience,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.key))
//         };
//     });

// -----------------------------
//  Servicios base
// -----------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

// -----------------------------
//  Inyecci�n de dependencias
// -----------------------------

// Pedido Inventario
builder.Services.AddScoped<IPedidoInventarioDA, PedidoInventarioDA>();
builder.Services.AddScoped<IPedidoInventarioFlujo, PedidoInventarioFlujo>();


// Base de datos
builder.Services.AddScoped<IRepositorioDapper, RepositorioDapper>();

// Productos
builder.Services.AddScoped<IProductoDA, ProductoDA>();
builder.Services.AddScoped<IProductoFlujo, ProductoFlujo>();

// Categor�as
builder.Services.AddScoped<ICategoriaDA, CategoriaDA>();
builder.Services.AddScoped<ICategoriaFlujo, CategoriaFlujo>();

// Movimientos de Inventario
builder.Services.AddScoped<IMovimientoInventarioDA, MovimientoInventarioDA>();
builder.Services.AddScoped<IMovimientoInventarioFlujo, MovimientoInventarioFlujo>();

// Reorden de Inventario
builder.Services.AddScoped<IPoliticaReabastecimientoDA, PoliticaReabastecimientoDA>();
builder.Services.AddScoped<IPoliticaReabastecimientoFlujo, PoliticaReabastecimientoFlujo>();

// Reaastecimiento Reglas
builder.Services.AddScoped<IReabastecimientoReglas, ReabastecimientoReglas>();

// Inventario externo (MockAPI)
builder.Services.AddScoped<IInventarioServicio, InventarioServicio>();
builder.Services.AddScoped<IInventarioFlujo, InventarioFlujo>();

// Configuraci�n y HTTP
builder.Services.AddScoped<IConfiguracion, Configuracion>();




var app = builder.Build();

// -----------------------------
//  Middleware pipeline
// -----------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar si agregas autenticaci�n
// app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
