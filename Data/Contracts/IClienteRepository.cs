﻿using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<IList<Cliente>> ObterTodosOsClientesAsync();

        Task<Cliente> ObterClientePorIdAsync(int? id);

        Task<IList<Cliente>> ObterClientePorNomeAsync(string nome);

    }
}
