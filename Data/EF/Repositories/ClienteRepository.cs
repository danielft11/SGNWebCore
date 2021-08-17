using Data.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SgnWebContext ctx) : base(ctx) { }

        public async Task<IList<Cliente>> ObterTodosOsClientesAsync()
        {
            return await _db
                .Include(e => e.Endereco)
                .OrderBy(c => c.Nome)
                .ToListAsync();
        }

        public async Task<Cliente> ObterClientePorIdAsync(int? id)
        {
            return await _db
                .Include(end => end.Endereco)
                .Include(e => e.Equipamentos)
                .ThenInclude(eq => eq.TipoEquipamento)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> ObterClientePeloCPF(string cpf) 
        {
            return await _db.AsNoTracking().FirstOrDefaultAsync(c => c.CPF == cpf);
        }

        public async Task<IList<Cliente>> ObterClientePorNomeAsync(string nome)
        {
            return await _db.AsNoTracking()
                .Include(e => e.Endereco)
                .Where(c => c.Nome.Contains(nome))
                .OrderBy(c => c.Nome)
                .ToListAsync();
        }

    }
}
