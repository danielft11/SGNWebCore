using Data.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SGNWebCore.WebApi.Models;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = (await _clienteRepository
                .ObterTodosOsClientesAsync())
                .Select(c => c.ToClienteGet());

            return Ok(clientes);
        }

        [HttpGet("{id}", Name = "GetClienteById")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteRepository.ObterClientePorIdAsync(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet("nome/{nome}", Name = "GetClienteByNome")]
        public async Task<IActionResult> GetClienteByNome(string nome)
        {
            var clientes = await _clienteRepository.ObterClientePorNomeAsync(nome);

            if (clientes == null)
                return NotFound();

            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult AddCliente([FromBody] ClienteAddEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var data = model.ToCliente();
            _clienteRepository.Adicionar(data);

            var cliente = data.ToClienteGet();

            return CreatedAtRoute("GetClienteById", new { cliente.Id }, cliente);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClienteAddEdit model)
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
