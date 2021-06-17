using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IRepository<TEntity> where TEntity : ModeloBase
    {
        void Adicionar(TEntity entity);

        void Atualizar(TEntity entity);

        void Deletar(TEntity entity);

        Task<IList<TEntity>> ObterTodosAsync();

        Task<TEntity> ObterPorIdAsync(object id);

        Task<int> ObterTotalDeRegistros();
    }
}
