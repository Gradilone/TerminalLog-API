using Microsoft.EntityFrameworkCore;
using TerminalLog.Api.Data;
using TerminalLog.Api.Models;
using TerminalLog.Api.Repositories.Interfaces;

namespace TerminalLog.Api.Repositories
{
    public class DocaRepository : IDocaRepository
    {
        private readonly AppDbContext _context;

        public DocaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Criar(Doca doca)
        {
            _context.Docas.Add(doca);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doca>> ListarTodas()
        {
            return await _context.Docas.ToListAsync();
        }

        public async Task<Doca?> GetDocaId(int id)
        {
            return await _context.Docas.FindAsync(id);
        }

        public async Task SalvarAlteracoes()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Doca doca)
        {
            _context.Docas.Remove(doca);
            await _context.SaveChangesAsync();
        }

    }
}
