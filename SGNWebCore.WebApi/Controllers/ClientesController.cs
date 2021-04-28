using Data.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SGNWebCore.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("sgnwebcoreapi/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("getAll/{searchTerm?}")]
        public async Task<IActionResult> GetAll(string searchTerm)
       {
            if (string.IsNullOrEmpty(searchTerm))
            {
                var clientes = (await _clienteRepository
                    .ObterTodosOsClientesAsync());

                return Ok(clientes);
            }
            else
            {
                var clientes = (await _clienteRepository
                    .ObterClientePorNomeAsync(searchTerm));

                return Ok(clientes);
            }

        }

        [HttpGet("{id}", Name = "GetClienteById")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteRepository.ObterClientePorIdAsync(id);

            if (cliente == null)
                return await Task.FromResult(NotFound());

            return Ok(cliente);
        }

        [HttpGet("nome/{nome}", Name = "GetClienteByNome")]
        public async Task<IActionResult> GetClienteByNome(string nome)
        {
            var clientes = await _clienteRepository.ObterClientePorNomeAsync(nome);

            if (clientes == null)
                return await Task.FromResult(NotFound());

            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] Cliente model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Cliente clienteJaExistente = await _clienteRepository.ObterClientePeloCPF(model.CPF);

            if (clienteJaExistente != null)
                return await Task.FromResult(BadRequest("Este cliente já está cadastrado."));

            if (!string.IsNullOrEmpty(model.Sexo) && model.Sexo.Equals("Selecione"))
                model.Sexo = null;

            _clienteRepository.Adicionar(model);

            return CreatedAtRoute("GetClienteById", new { model.Id }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cliente model)
        {
            var cliente = await _clienteRepository.ObterClientePorIdAsync(model.Id);
            var clienteAtualizado = new Cliente();

            if (cliente != null)
                clienteAtualizado = model.AtualizarCliente(model, cliente);
            else
                ModelState.AddModelError("Id", "Cliente não localizado.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _clienteRepository.Atualizar(clienteAtualizado);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteRepository.ObterClientePorIdAsync(id);

            if (cliente == null)
            {
                ModelState.AddModelError("Id", "Cliente não localizado.");
                return BadRequest(ModelState);
            }

            _clienteRepository.Deletar(cliente);
            return Ok();

        }

    }

}
