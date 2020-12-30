using Domain.Models.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;

namespace SGNWebCore.HttpClients
{
    public class AccountApiClient
    {
        private readonly HttpClient _httpClient;

        public AccountApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResult> PostLoginAsync(LoginViewModel model)
        {
            var resposta = await _httpClient.PostAsJsonAsync($"account/login", model);

            return new LoginResult
            {
                Succeeded = resposta.IsSuccessStatusCode,
                Token = await resposta.Content.ReadAsStringAsync()
            };
        }

        public async Task PostRegisterAsync(LoginViewModel model) 
        {
            HttpResponseMessage resposta = await _httpClient.PostAsJsonAsync($"account/register", model);
            resposta.EnsureSuccessStatusCode();
        }
    }

    public class LoginResult
    {
        public bool Succeeded { get; set; }
        public string Token { get; set; }
    }
}
