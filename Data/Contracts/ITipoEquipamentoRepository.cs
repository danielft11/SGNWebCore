using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface ITipoEquipamentoRepository: IRepository<TipoEquipamento>
    {
        Task<IEnumerable<TipoEquipamento>> ObterPeloNome(string nome);
    }
}
