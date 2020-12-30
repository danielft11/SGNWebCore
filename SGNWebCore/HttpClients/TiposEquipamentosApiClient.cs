using Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SGNWebCore.HttpClients
{
    public class TiposEquipamentosApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _accessor;

        public TiposEquipamentosApiClient(HttpClient httpClient, IHttpContextAccessor accessor)
        {
            _httpClient = httpClient;
            _accessor = accessor;
        }

        public async Task<List<TipoEquipamento>> GetTiposDeEquipamentosAsync()
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"tiposequipamentos/");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<List<TipoEquipamento>>();
        }
    }
}
