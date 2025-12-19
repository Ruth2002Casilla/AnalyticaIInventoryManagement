using InventoryManagement.DAL;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryManagement.Services
{
    public class productoService
    {
        private readonly Context _context;

        public productoService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int productoId)
        {
            return await _context.productos.AnyAsync(p => p.productoId == productoId);
        }

        public async Task<bool> Agregar(producto producto)
        {
            _context.productos.Add(producto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(producto producto)
        {
            _context.Update(producto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(producto producto)
        {
            _context.productos.Remove(producto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(producto producto)
        {
            if (!await Verificar(producto.productoId))
                return await Agregar(producto);
            else
                return await Modificar(producto);
        }

        public async Task<producto?> Buscar(int productoId)
        {
            return await _context.productos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.productoId == productoId);
        }

        public async Task<List<producto>> Listar(Expression<Func<producto, bool>> criterio)
        {
            return await _context.productos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
