using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGNWebCore.HttpClients;
using SGNWebCore.Models;

namespace SGNWebCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClientesApiClient _ApiClient;
        public HomeController(ClientesApiClient clientesApiClient)
        {
            _ApiClient = clientesApiClient;
        }
        public async Task<IActionResult> Index()
        {
            var clientes = await _ApiClient.GetClientesAsync();
            ViewBag.TotalClientes = clientes.Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
