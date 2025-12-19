using InventoryManagement.DAL;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryManagement.Services
{
    public class userService
    {
        private readonly Context _context;

        public userService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int userId)
        {
            return await _context.usuarios.AnyAsync(u => u.userId == userId);
        }

        public async Task<bool> Agregar(user usuario)
        {
            _context.usuarios.Add(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(user usuario)
        {
            _context.Update(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(user usuario)
        {
            _context.usuarios.Remove(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(user usuario)
        {
            if (!await Verificar(usuario.userId))
                return await Agregar(usuario);
            else
                return await Modificar(usuario);
        }

        public async Task<user?> Buscar(int userId)
        {
            return await _context.usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.userId == userId);
        }

        public async Task<List<user>> Listar(Expression<Func<user, bool>> criterio)
        {
            return await _context.usuarios
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
