using InventoryManagement.DAL;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryManagement.Services
{
    public class clienteService
    {
        private readonly Context _context;
        public clienteService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int clienteId)
        {
            return await _context.clientes.AnyAsync(m => m.clienteId == clienteId);
        }
        public async Task<bool> Modificar(cliente cliente)
        {
            _context.Update(cliente);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Agregar(cliente cliente)
        {
            _context.clientes.Add(cliente);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Eliminar(cliente cliente)
        {
            _context.clientes.Remove(cliente);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(cliente cliente)
        {
            if (!await Verificar(cliente.clienteId))
                return await Agregar(cliente);
            else
                return await Modificar(cliente);
        }
        public async Task<cliente?> Buscar(int clienteId)
        {
            return await _context.clientes
                   .AsNoTracking()
                   .FirstOrDefaultAsync(m => m.clienteId == clienteId);
        }
        public async Task<List<cliente>> Listar(Expression<Func<cliente, bool>> criterio)
        {
            return await _context.clientes
                         .AsNoTracking()
                         .Where(criterio)
                         .ToListAsync();
        }
    }
}
