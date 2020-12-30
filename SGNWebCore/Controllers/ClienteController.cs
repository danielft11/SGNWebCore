using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGNWebCore.HttpClients;
using SGNWebCore.Models;
using SGNWebCore.WebApi.Models;
using System;
using System.Threading.Tasks;

namespace SGNWebCore.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClientesApiClient _ApiClient;

        public ClienteController(ClientesApiClient clientesApiClient)
        {
            _ApiClient = clientesApiClient;
        }

        public async Task<IActionResult> Index(string nome)
        {
            var clientes = await _ApiClient.GetClientesAsync();

            if (!string.IsNullOrEmpty(nome))
                clientes = await _ApiClient.GetClienteByNameAsync(nome);

            return View(clientes);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo(ClienteAddEdit cliente)
        {
            RemoveMascarasDosCampos(cliente);

            if (ModelState.IsValid)
            {
                await _ApiClient.AddClienteAsync(cliente);
                return RedirectToAction("Index", "Cliente");
            }
            return View(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int id)
        {
            var cliente = await _ApiClient.GetClienteByIdAsync(id);

            if (cliente == null) return NotFound();

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detalhes(ClienteAddEdit cliente)
        {
            RemoveMascarasDosCampos(cliente);

            if (ModelState.IsValid)
            {
                await _ApiClient.UpdateClienteAsync(cliente);
                return RedirectToAction("Index", "Cliente");
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remover(int id)
        {
            var cliente = _ApiClient.GetClienteByIdAsync(id);

            if (cliente == null)
                return NotFound();

            try
            {
                await _ApiClient.DeleteClienteAsync(id);
                return RedirectToAction("Index", "Cliente");
            }
            catch (Exception)
            {
                ModelState.AddModelError("Cliente", "Falha ao remover este cliente. Verifique se existem equipamentos ou Ordens de Serviço cadastrados para este cliente.");
                return BadRequest(ModelState);
            }

        }

        [HttpPost]
        public async Task<JsonResult> RemoverViaAjax([FromBody] int id)
        {
            MessageResponse messageResponse;
            var cliente = _ApiClient.GetClienteByIdAsync(id);

            if (cliente != null)
            {
                try
                {
                    await _ApiClient.DeleteClienteAsync(id);
                    messageResponse = new MessageResponse { Status = "00", Message = "Cliente removido com sucesso." };
                    return Json(messageResponse);
                }
                catch (Exception)
                {
                    messageResponse = new MessageResponse { Status = "01", Message = "Falha ao remover este cliente. Verifique se existem equipamentos ou Ordens de Serviço cadastrados para este cliente." };
                    return Json(messageResponse);
                }

            }
            else
            {
                messageResponse = new MessageResponse { Status = "01", Message = "Falha ao remover cliente." };
                return Json(messageResponse);
            }

        }

        private static void RemoveMascarasDosCampos(ClienteAddEdit cliente)
        {
            if (!string.IsNullOrEmpty(cliente.CPF))
            {
                string cpf = cliente.CPF.Replace(".", string.Empty).Replace("-", string.Empty);
                cliente.CPF = cpf;
            }

            if (!string.IsNullOrEmpty(cliente.Endereco.CEP))
            {
                string cep = cliente.Endereco.CEP.Replace("-", string.Empty);
                cliente.Endereco.CEP = cep;
            }

            if (!string.IsNullOrEmpty(cliente.Telefone))
            {
                string telefone = cliente.Telefone.Replace("-", string.Empty);
                cliente.Telefone = telefone;
            }

            if (!string.IsNullOrEmpty(cliente.CelPrincipal))
            {
                string celular = cliente.CelPrincipal.Replace("-", string.Empty);
                cliente.CelPrincipal = celular;
            }

            if (!string.IsNullOrEmpty(cliente.Cel2))
            {
                string cel2 = cliente.Cel2.Replace("-", string.Empty);
                cliente.Cel2 = cel2;
            }
        }

    }
}