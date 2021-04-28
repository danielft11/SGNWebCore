using Domain.Models;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SGNWebCore.HttpClients
{
    public class EquipamentosApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _accessor;

        public EquipamentosApiClient(HttpClient httpClient, IHttpContextAccessor accessor)
        {
            _httpClient = httpClient;
            _accessor = accessor;
        }

        public async Task<List<Equipamento>> GetEquipamentosAsync() 
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"equipamentos/");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<List<Equipamento>>();
        }

        public async Task<Equipamento> GetEquipamentosByIdAsync(int id)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"equipamentos/{id}");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<Equipamento>();
        }

        public async Task<Equipamento> GetEquipamentosByClienteAsync(int idCliente)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"equipamentos/getEquipamentoByCliente/{idCliente}");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<Equipamento>();
        }

        public async Task AddEquipamentoAsync(Equipamento equipamento)
        {
            HttpResponseMessage resposta = await _httpClient.PostAsJsonAsync($"equipamentos", equipamento);
            resposta.EnsureSuccessStatusCode();
        }

        public async Task UpdateEquipamentoAsync(Equipamento equipamento)
        {
            HttpResponseMessage resposta = await _httpClient.PutAsJsonAsync($"equipamentos", equipamento);
            resposta.EnsureSuccessStatusCode();
        }

        public async Task DeleteEquipamentoAsync(int id)
        {
            HttpResponseMessage resposta = await _httpClient.DeleteAsync($"equipamentos/{id}");
            resposta.EnsureSuccessStatusCode();
        }

        private void AddBearerToken()
        {
            var Token = _accessor.HttpContext.User.Claims.First(c => c.Type == "Token").Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        }
    }

   
}
