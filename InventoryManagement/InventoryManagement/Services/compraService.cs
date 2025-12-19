using InventoryManagement.DAL;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryManagement.Services
{
    public class compraService
    {
        private readonly Context _context;

        public compraService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int compraId)
        {
            return await _context.compras.AnyAsync(c => c.compraId == compraId);
        }

        public async Task<bool> Agregar(compra compra)
        {
            _context.compras.Add(compra);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(compra compra)
        {
            _context.Update(compra);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(compra compra)
        {
            _context.compras.Remove(compra);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(compra compra)
        {
            if (!await Verificar(compra.compraId))
                return await Agregar(compra);
            else
                return await Modificar(compra);
        }

        public async Task<compra?> Buscar(int compraId)
        {
            return await _context.compras
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.compraId == compraId);
        }

        public async Task<List<compra>> Listar(Expression<Func<compra, bool>> criterio)
        {
            return await _context.compras
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
