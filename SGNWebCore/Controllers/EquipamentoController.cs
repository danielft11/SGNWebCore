using System;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGNWebCore.HttpClients;
using SGNWebCore.Models;

namespace SGNWebCore.Controllers
{
    public class EquipamentoController : Controller
    {
        private readonly ClientesApiClient _clienteApiClient;
        private readonly EquipamentosApiClient _equipamentosApiClient;
        private readonly TiposEquipamentosApiClient _tiposEquipamentosApiClient;

        public EquipamentoController(ClientesApiClient clientesApiClient, EquipamentosApiClient equipamentosApiClient, TiposEquipamentosApiClient tiposEquipamentosApiClient)
        {
            _clienteApiClient = clientesApiClient;
            _equipamentosApiClient = equipamentosApiClient;
            _tiposEquipamentosApiClient = tiposEquipamentosApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var equipamentos = await _equipamentosApiClient.GetEquipamentosAsync();
            return View(equipamentos);            
        }

        [HttpGet]
        public async Task<IActionResult> Novo()
        {
            var clientes = await _clienteApiClient.GetClientesAsync(1);
            var tiposEquipamentos = await _tiposEquipamentosApiClient.GetTiposDeEquipamentosAsync();

            Equipamento equipamento = new Equipamento(clientes, tiposEquipamentos);

            return View(equipamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo(Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                await _equipamentosApiClient.AddEquipamentoAsync(equipamento);
                return RedirectToAction("Index", "Equipamento");
            }
            return View(equipamento);
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int id)
        {
            var equipamento = await _equipamentosApiClient.GetEquipamentosByIdAsync(id);
            var clientes = await _clienteApiClient.GetClientesAsync(1);
            var tiposEquipamentos = await _tiposEquipamentosApiClient.GetTiposDeEquipamentosAsync();

            ViewBag.Cliente = new SelectList(clientes, "Id", "Nome", equipamento.ClienteId);
            ViewBag.TipoEquipamento = new SelectList(tiposEquipamentos, "Id", "Nome", equipamento.TipoEquipamentoId);

            if (equipamento == null) 
                return NotFound();

            return View(equipamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detalhes(Equipamento equipamento) 
        {
            if (ModelState.IsValid) 
            {
                await _equipamentosApiClient.UpdateEquipamentoAsync(equipamento);
                return RedirectToAction("Index", "Equipamento");
            }
            return View(equipamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remover(int id)
        {
            var equipamento = await _equipamentosApiClient.GetEquipamentosByIdAsync(id);
     
            if (equipamento == null) 
                return NotFound();

            await _equipamentosApiClient.DeleteEquipamentoAsync(id);
            return RedirectToAction("Index", "Equipamento");

        }

        [HttpGet]
        public async Task<JsonResult> GetEquipamentosViAjax(int id)
        {
            var equipamentos = await _equipamentosApiClient.GetEquipamentosByIdAsync(id);
            return Json(equipamentos);
        }

        [HttpPost]
        public async Task<JsonResult> NovoEquipamentoAjax([FromBody] Equipamento equipamento) 
        {
            MessageResponse messageResponse;

            if (ModelState.IsValid)
            {
                try
                {
                    await _equipamentosApiClient.AddEquipamentoAsync(equipamento);
                    messageResponse = new MessageResponse { Status = "00", Message = "Equipamento incluído com sucesso." };
                    return Json(messageResponse);
                }
                catch (Exception ex)
                {
                    messageResponse = new MessageResponse { Status = "01", Message = "Ocorreu o seguinte erro ao incluir o equipamento: " + ex.InnerException.Message };
                    return Json(messageResponse);
                }

            }
            else 
            {
                messageResponse = new MessageResponse { Status = "01", Message = "Erro geral ao incluir o equipamento."};
                return Json(messageResponse);
            }
            

        }

        [HttpPost]
        public async Task<JsonResult> AtualizarEquipamentoAjax([FromBody] Equipamento equipamento) 
        {
            MessageResponse messageResponse;

            if (ModelState.IsValid)
            {
                try
                {
                    await _equipamentosApiClient.UpdateEquipamentoAsync(equipamento);
                    messageResponse = new MessageResponse { Status = "00", Message = "Equipamento atualizado com sucesso." };
                    return Json(messageResponse);
                }
                catch (Exception ex)
                {
                    messageResponse = new MessageResponse { Status = "01", Message = "Ocorreu o seguinte erro ao atualizar o equipamento: " + ex.InnerException.Message };
                    return Json(messageResponse);
                }
            }
            else 
            {
                messageResponse = new MessageResponse { Status = "01", Message = "Erro geral ao atualizar o equipamento." };
                return Json(messageResponse);
            }


        }

        [HttpPost]
        public async Task<JsonResult> RemoverViaAjax([FromBody] int id)
        {
            MessageResponse messageResponse;
            var equipamento = await _equipamentosApiClient.GetEquipamentosByIdAsync(id);

            if (equipamento != null)
            {
                try
                {
                    await _equipamentosApiClient.DeleteEquipamentoAsync(id);
                    messageResponse = new MessageResponse { Status = "00", Message = "Equipamento removido com sucesso." };
                    return Json(messageResponse);
                }
                catch (Exception ex)
                {
                    messageResponse = new MessageResponse { Status = "01", Message = "Ocorreu o seguinte erro ao remover este equipamento: " + ex.InnerException.Message };
                    return Json(messageResponse);
                }

            }
            else
            {
                messageResponse = new MessageResponse { Status = "01", Message = "Falha ao remover equipamento." };
                return Json(messageResponse);
            }

        }
    }
}