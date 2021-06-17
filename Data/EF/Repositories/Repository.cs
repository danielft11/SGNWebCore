using Data.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : ModeloBase
    {
        private readonly SgnWebContext _ctx;
        protected readonly DbSet<TEntity> _db;

        public Repository(SgnWebContext ctx)
        {
            _ctx = ctx;
            _db = _ctx.Set<TEntity>();
        }
        public async Task<TEntity> ObterPorIdAsync(object id)
        {
            return await _db.FindAsync(id);
        }
        public async Task<IList<TEntity>> ObterTodosAsync()
        {
            return await _db.ToListAsync();
        }
        public void Adicionar(TEntity entity)
        {
            _db.Add(entity);
            _ctx.SaveChangesAsync();
        }
        public void Atualizar(TEntity entity)
        {
            _ctx.Update(entity);
            _ctx.SaveChangesAsync();
        }
        public void Deletar(TEntity entity)
        {
            _ctx.Remove(entity);
            _ctx.SaveChangesAsync();
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            return await _db.CountAsync();
        }

    }
}
