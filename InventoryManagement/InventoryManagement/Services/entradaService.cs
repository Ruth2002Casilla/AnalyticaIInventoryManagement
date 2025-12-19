using InventoryManagement.DAL;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryManagement.Services
{
    public class entradaService
    {
        private readonly Context _context;

        public entradaService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int entradaId)
        {
            return await _context.entradas.AnyAsync(e => e.entradaId == entradaId);
        }

        public async Task<bool> Agregar(entrada entrada)
        {
            _context.entradas.Add(entrada);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(entrada entrada)
        {
            _context.Update(entrada);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(entrada entrada)
        {
            _context.entradas.Remove(entrada);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(entrada entrada)
        {
            if (!await Verificar(entrada.entradaId))
                return await Agregar(entrada);
            else
                return await Modificar(entrada);
        }

        public async Task<entrada?> Buscar(int entradaId)
        {
            return await _context.entradas
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.entradaId == entradaId);
        }

        public async Task<List<entrada>> Listar(Expression<Func<entrada, bool>> criterio)
        {
            return await _context.entradas
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
