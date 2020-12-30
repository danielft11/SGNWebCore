using Microsoft.AspNetCore.Mvc;
using SGNWebCore.HttpClients;
using System.Threading.Tasks;

namespace SGNWebCore.Controllers
{
    public class TiposEquipamentosController : Controller
    {
        private readonly TiposEquipamentosApiClient _tiposEquipamentosApiClient;

        public TiposEquipamentosController(TiposEquipamentosApiClient tiposEqupamentosApiClient)
        {
            _tiposEquipamentosApiClient = tiposEqupamentosApiClient;
        }

        [HttpGet]
        public async Task<JsonResult> GetTiposEquipamentosAjax() 
        {
            var tiposDeEquipamentos = await _tiposEquipamentosApiClient.GetTiposDeEquipamentosAsync();
            return Json(tiposDeEquipamentos);
        }
        
    }
}