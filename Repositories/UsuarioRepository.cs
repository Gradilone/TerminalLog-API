using Microsoft.EntityFrameworkCore;
using TerminalLog.Api.Data;
using TerminalLog.Api.Models;
using TerminalLog.Api.Repositories.Interfaces;

namespace TerminalLog.Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Criar (Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> ListarTodos()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioId(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario?> GetUsuarioEmail(string email)
        {
            return await _context.Usuarios.FindAsync(email);
        }
    }
}
