using InventoryManagement.Components;
using InventoryManagement.DAL;
using InventoryManagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var conexion = builder.Configuration.GetConnectionString("conexion");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite(conexion));

builder.Services.AddScoped<categoriaService>();
builder.Services.AddScoped<productoService>();
builder.Services.AddScoped<clienteService>();
builder.Services.AddScoped<userService>();
builder.Services.AddScoped<entradaService>();
builder.Services.AddScoped<salidaService>();
builder.Services.AddScoped<proveedorService>();
builder.Services.AddScoped<detalleCompraService>();
builder.Services.AddScoped<detalleVentaService>();
builder.Services.AddScoped<compraService>();
builder.Services.AddScoped<ventaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
