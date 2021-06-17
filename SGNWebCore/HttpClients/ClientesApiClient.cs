using Domain.Models;
using Microsoft.AspNetCore.Http;
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

        public async Task<IList<Cliente>> GetClientesAsync()
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"clientes/getAll");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<IList<Cliente>>();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            //AddBearerToken();
            HttpResponseMessage resposta = await _httpClient.GetAsync($"clientes/{id}");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<Cliente>();
        }

        public async Task<List<Cliente>> GetClienteByNameAsync(string nome)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"clientes/nome/{nome}");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<List<Cliente>>();
        }

        public async Task AddClienteAsync(Cliente cliente)
        { 
            HttpResponseMessage resposta = await _httpClient.PostAsJsonAsync($"clientes", cliente);
            resposta.EnsureSuccessStatusCode();
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            HttpResponseMessage resposta = await _httpClient.PutAsJsonAsync($"clientes", cliente);
            resposta.EnsureSuccessStatusCode();
        }

        public async Task DeleteClienteAsync(int id) 
        {
            HttpResponseMessage resposta = await _httpClient.DeleteAsync($"clientes/{id}");
            resposta.EnsureSuccessStatusCode();
        }

        public async Task<string> ObterTotalClientes() 
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"clientes/obtertotalclientes");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsStringAsync();
        }

        private void AddBearerToken()
        {
            var Token = _accessor.HttpContext.User.Claims.First(c => c.Type == "Token").Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        }
    }
}
