using System.Linq;
using System.Threading.Tasks;
using Data.Contracts;
using Domain.Models;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace SGNWebCore.WebApi.Controllers
{
    [ApiController]
    [Route("sgnwebcoreapi/[controller]")]
    public class EquipamentosController : ControllerBase
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ITipoEquipamentoRepository _tipoEquipamentoRepository;

        public EquipamentosController(IEquipamentoRepository equipamentoRepository, IClienteRepository clienteRepository, ITipoEquipamentoRepository tipoEquipamentoRepository)
        {
            _equipamentoRepository = equipamentoRepository;
            _clienteRepository = clienteRepository;
            _tipoEquipamentoRepository = tipoEquipamentoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipamentos = (await _equipamentoRepository.ObterEquipamentos());
            return Ok(equipamentos);
        }

        [HttpGet("{id}", Name = "GetEquipamentoById")]
        public async Task<IActionResult> GetEquipamentoById(int id)
        {
            var equipamento = await _equipamentoRepository.ObterEquipamentoPorIdAsync(id);

            if (equipamento == null)
                return NotFound();

            return Ok(equipamento);
        }

        [Route("getEquipamentoByCliente/{idCliente}")]
        [HttpGet("idCliente")]
        public async Task<IActionResult> GetEquipamentoByCliente(int idCliente)
        {
            var equipamento = await _equipamentoRepository.ObterEquipamentosPorCliente(idCliente);

            if (equipamento == null)
                return NotFound();

            return Ok(equipamento);
        }

        [HttpPost]
        public async Task<IActionResult> AddEquipamento([FromBody] Equipamento model) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Equipamento equipamentoJaExistente = await _equipamentoRepository.ObterEquipamentoPorNumSerieAndIdCliente(model.NumSerie, model.ClienteId);

            if (equipamentoJaExistente != null)
                return await Task.FromResult(BadRequest("Este equipamento já está cadastrado."));

            _equipamentoRepository.Adicionar(model);

            return CreatedAtRoute("GetEquipamentoById", new { model.Id }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Equipamento model)
        {
            var equipamento = await _equipamentoRepository.ObterEquipamentoPorIdAsync(model.Id);
            var equipamentoAtualizado = new Equipamento();

            if (equipamento != null)
                equipamentoAtualizado = model.AtualizarEquipamento(model, equipamento);
            else
                ModelState.AddModelError("Id", "Equipamento não localizado.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _equipamentoRepository.Atualizar(equipamentoAtualizado);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var equipamento = await _equipamentoRepository.ObterEquipamentoPorIdAsync(id);

            if (equipamento == null)
            {
                ModelState.AddModelError("Id", "Equipamento não localizado.");
                return BadRequest(ModelState);
            }

            _equipamentoRepository.Deletar(equipamento);
            return Ok();

        }
    }
}