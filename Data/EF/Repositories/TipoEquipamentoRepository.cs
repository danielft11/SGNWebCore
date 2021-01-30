using Data.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class TipoEquipamentoRepository : Repository<TipoEquipamento>, ITipoEquipamentoRepository
    {

        public TipoEquipamentoRepository(SgnWebContext ctx) : base(ctx)
        {

        }

        public Task<IEnumerable<TipoEquipamento>> ObterPeloNome(string nome)
        {
            throw new NotImplementedException();
        }

       
    }
}
