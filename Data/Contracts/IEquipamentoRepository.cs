using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IEquipamentoRepository : IRepository<Equipamento>
    {
        Task<IList<Equipamento>> ObterPeloNumSerie(string nome);
        Task<IList<Equipamento>> ObterEquipamentos();
        Task<Equipamento> ObterEquipamentoPorIdAsync(int id);

        Task<IList<Equipamento>> ObterEquipamentosPorCliente(int idCliente);
    }
}
