using System.Threading.Tasks;
using Data.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace SGNWebCore.WebApi.Controllers
{
    [Route("sgnwebcoreapi/[controller]")]
    [ApiController]
    public class TiposEquipamentosController : ControllerBase
    {
        private readonly ITipoEquipamentoRepository _tipoEquipamentoRepository;

        public TiposEquipamentosController(ITipoEquipamentoRepository tipoEquipamentoRepository)
        {
            _tipoEquipamentoRepository = tipoEquipamentoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tiposDeEquipamentos = (await _tipoEquipamentoRepository.ObterTodosAsync());
            return Ok(tiposDeEquipamentos);
        }
    }
}