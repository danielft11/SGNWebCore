using Data.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class EquipamentoRepository : Repository<Equipamento>, IEquipamentoRepository
    {
        public EquipamentoRepository(SgnWebContext ctx) : base(ctx)
        {
        }

        public async Task<IList<Equipamento>> ObterPeloNumSerie(string numSerie)
        {
            return await _db
                .Where(c => c.NumSerie.Contains(numSerie))
                .ToListAsync();
        }

        public async Task<Equipamento> ObterEquipamentoPorNumSerieAndIdCliente(string numSerie, int? idCliente) 
        {
            return await _db.FirstOrDefaultAsync(e => e.NumSerie == numSerie && e.ClienteId == idCliente);
        }

        public async Task<IList<Equipamento>> ObterEquipamentos()
        {
            return await _db.
                Include(e => e.TipoEquipamento)
                .Include(e => e.Cliente)
                .ToListAsync();
        }

        public async Task<Equipamento> ObterEquipamentoPorIdAsync(int id)
        {
            return await _db
                .Include(t => t.TipoEquipamento)
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IList<Equipamento>> ObterEquipamentosPorCliente(int idCliente)
        {
            return await _db
                .Include(t => t.TipoEquipamento)
                .Where(e => e.ClienteId == idCliente)
                .ToListAsync();
        }
    }
}
