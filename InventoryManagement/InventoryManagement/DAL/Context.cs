using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace InventoryManagement.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<categoria> categorias { get; set; }
        public DbSet<producto> productos { get; set; }
        public DbSet<user> usuarios { get; set; }
        public DbSet<entrada> entradas { get; set; }
        public DbSet<salida> salidas { get; set; }
        public  DbSet<proveedor> proveedores { get; set; }
        public  DbSet<cliente> clientes { get; set; }
        public  DbSet<detalleCompra> detalleCompras { get; set; }
        public  DbSet<detalleVenta> detalleVentas { get; set; }
        public  DbSet<compra> compras { get; set; }
        public  DbSet<venta> ventas { get; set; }

    }
}
