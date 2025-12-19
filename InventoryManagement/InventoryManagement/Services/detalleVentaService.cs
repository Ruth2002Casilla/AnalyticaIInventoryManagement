using InventoryManagement.DAL;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryManagement.Services
{
    public class detalleVentaService
    {
        private readonly Context _context;

        public detalleVentaService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int detalleVentaId)
        {
            return await _context.detalleVentas.AnyAsync(d => d.detalleVentaId == detalleVentaId);
        }

        public async Task<bool> Agregar(detalleVenta detalle)
        {
            _context.detalleVentas.Add(detalle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(detalleVenta detalle)
        {
            _context.Update(detalle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(detalleVenta detalle)
        {
            _context.detalleVentas.Remove(detalle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(detalleVenta detalle)
        {
            if (!await Verificar(detalle.detalleVentaId))
                return await Agregar(detalle);
            else
                return await Modificar(detalle);
        }

        public async Task<detalleVenta?> Buscar(int detalleVentaId)
        {
            return await _context.detalleVentas
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.detalleVentaId == detalleVentaId);
        }

        public async Task<List<detalleVenta>> Listar(Expression<Func<detalleVenta, bool>> criterio)
        {
            return await _context.detalleVentas
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
