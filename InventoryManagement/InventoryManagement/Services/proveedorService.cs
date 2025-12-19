using InventoryManagement.DAL;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryManagement.Services
{
    public class proveedorService
    {
        private readonly Context _context;

        public proveedorService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int proveedorId)
        {
            return await _context.proveedores.AnyAsync(p => p.proveedorId == proveedorId);
        }

        public async Task<bool> Agregar(proveedor proveedor)
        {
            _context.proveedores.Add(proveedor);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(proveedor proveedor)
        {
            _context.Update(proveedor);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(proveedor proveedor)
        {
            _context.proveedores.Remove(proveedor);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(proveedor proveedor)
        {
            if (!await Verificar(proveedor.proveedorId))
                return await Agregar(proveedor);
            else
                return await Modificar(proveedor);
        }

        public async Task<proveedor?> Buscar(int proveedorId)
        {
            return await _context.proveedores
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.proveedorId == proveedorId);
        }

        public async Task<List<proveedor>> Listar(Expression<Func<proveedor, bool>> criterio)
        {
            return await _context.proveedores
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
