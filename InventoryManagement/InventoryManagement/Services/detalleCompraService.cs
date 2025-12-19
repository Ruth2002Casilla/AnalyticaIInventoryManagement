using InventoryManagement.DAL;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryManagement.Services
{
    public class detalleCompraService
    {
        private readonly Context _context;

        public detalleCompraService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int detalleCompraId)
        {
            return await _context.detalleCompras.AnyAsync(d => d.detalleCompraId == detalleCompraId);
        }

        public async Task<bool> Agregar(detalleCompra detalle)
        {
            _context.detalleCompras.Add(detalle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(detalleCompra detalle)
        {
            _context.Update(detalle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(detalleCompra detalle)
        {
            _context.detalleCompras.Remove(detalle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(detalleCompra detalle)
        {
            if (!await Verificar(detalle.detalleCompraId))
                return await Agregar(detalle);
            else
                return await Modificar(detalle);
        }

        public async Task<detalleCompra?> Buscar(int detalleCompraId)
        {
            return await _context.detalleCompras
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.detalleCompraId == detalleCompraId);
        }

        public async Task<List<detalleCompra>> Listar(Expression<Func<detalleCompra, bool>> criterio)
        {
            return await _context.detalleCompras
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
