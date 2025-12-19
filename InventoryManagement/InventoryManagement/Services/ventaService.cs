using InventoryManagement.DAL;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryManagement.Services
{
    public class ventaService
    {
        private readonly Context _context;

        public ventaService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int ventaId)
        {
            return await _context.ventas.AnyAsync(v => v.ventaId == ventaId);
        }

        public async Task<bool> Agregar(venta venta)
        {
            _context.ventas.Add(venta);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(venta venta)
        {
            _context.Update(venta);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(venta venta)
        {
            _context.ventas.Remove(venta);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(venta venta)
        {
            if (!await Verificar(venta.ventaId))
                return await Agregar(venta);
            else
                return await Modificar(venta);
        }

        public async Task<venta?> Buscar(int ventaId)
        {
            return await _context.ventas
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.ventaId == ventaId);
        }

        public async Task<List<venta>> Listar(Expression<Func<venta, bool>> criterio)
        {
            return await _context.ventas
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
