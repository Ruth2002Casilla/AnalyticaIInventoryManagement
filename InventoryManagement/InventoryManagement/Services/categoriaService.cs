using InventoryManagement.DAL;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace InventoryManagement.Services
{
    public class categoriaService
    {
        private readonly Context _context;
        public categoriaService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int categoriaId)
        {
            return await _context.categorias.AnyAsync(m => m.categoriaId == categoriaId);
        }
        public async Task<bool> Modificar(categoria categoria)
        {
            _context.Update(categoria);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Agregar(categoria categoria)
        {
            _context.categorias.Add(categoria);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Eliminar(categoria categoria)
        {
            _context.categorias.Remove(categoria);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(categoria categoria)
        {
            if (!await Verificar(categoria.categoriaId))
                return await Agregar(categoria);
            else
                return await Modificar(categoria);
        }
        public async Task<categoria?> Buscar(int categoriaId)
        {
            return await _context.categorias
                   .AsNoTracking()
                   .FirstOrDefaultAsync(m => m.categoriaId == categoriaId);
        }
        public async Task<List<categoria>> Listar(Expression<Func<categoria, bool>> criterio)
        {
            return await _context.categorias
                         .AsNoTracking()
                         .Where(criterio)
                         .ToListAsync();
        }
    }
}

