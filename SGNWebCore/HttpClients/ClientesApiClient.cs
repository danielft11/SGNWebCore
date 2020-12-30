using Microsoft.AspNetCore.Http;
using SGNWebCore.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SGNWebCore.HttpClients
{
    public class ClientesApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _accessor;

        public ClientesApiClient(HttpClient httpClient, IHttpContextAccessor accessor)
        {
            _httpClient = httpClient;
            _accessor = accessor;
            //Teste commit.
        }

        public async Task<IList<ClientesGet>> GetClientesAsync()
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"clientes/");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<IList<ClientesGet>>();
        }

        public async Task<ClienteAddEdit> GetClienteByIdAsync(int id)
        {
            //AddBearerToken();
            HttpResponseMessage resposta = await _httpClient.GetAsync($"clientes/{id}");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<ClienteAddEdit>();
        }

        public async Task<List<ClientesGet>> GetClienteByNameAsync(string nome)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"clientes/nome/{nome}");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<List<ClientesGet>>();
        }

        public async Task AddClienteAsync(ClienteAddEdit cliente)
        { 
            HttpResponseMessage resposta = await _httpClient.PostAsJsonAsync($"clientes", cliente);
            resposta.EnsureSuccessStatusCode();
        }

        public async Task UpdateClienteAsync(ClienteAddEdit cliente)
        {
            HttpResponseMessage resposta = await _httpClient.PutAsJsonAsync($"clientes", cliente);
            resposta.EnsureSuccessStatusCode();
        }

        public async Task DeleteClienteAsync(int id) 
        {
            HttpResponseMessage resposta = await _httpClient.DeleteAsync($"clientes/{id}");
            resposta.EnsureSuccessStatusCode();
        }

        private void AddBearerToken()
        {
            var Token = _accessor.HttpContext.User.Claims.First(c => c.Type == "Token").Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        }
    }
}
