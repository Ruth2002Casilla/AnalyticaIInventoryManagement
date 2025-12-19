using InventoryManagement.DAL;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryManagement.Services
{
    public class salidaService
    {
        private readonly Context _context;

        public salidaService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int salidaId)
        {
            return await _context.salidas.AnyAsync(s => s.salidaId == salidaId);
        }

        public async Task<bool> Agregar(salida salida)
        {
            _context.salidas.Add(salida);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(salida salida)
        {
            _context.Update(salida);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(salida salida)
        {
            _context.salidas.Remove(salida);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(salida salida)
        {
            if (!await Verificar(salida.salidaId))
                return await Agregar(salida);
            else
                return await Modificar(salida);
        }

        public async Task<salida?> Buscar(int salidaId)
        {
            return await _context.salidas
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.salidaId == salidaId);
        }

        public async Task<List<salida>> Listar(Expression<Func<salida, bool>> criterio)
        {
            return await _context.salidas
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
