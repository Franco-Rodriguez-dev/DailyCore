using DailyCore.Application.Empresas.Service;
using Microsoft.AspNetCore.Mvc;
using DailyCore.Application.Empresas.DTOs;

namespace DailyCore.Api.Controllers
{
    [ApiController]
    [Route("api/empresas")]
    public class EmpresasController : ControllerBase
    {

        private readonly EmpresaService _empresaService;

        public EmpresasController(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }


        [HttpPost]
        public async Task<ActionResult<CrearEmpresaResponse>> Crear ( [FromBody] CrearEmpresaRequest request)
        {

            try
            {
                var empresaCreada = await _empresaService.CrearEmpresaAsync(request);

               
                return StatusCode(StatusCodes.Status201Created, empresaCreada);

            }
            catch (ArgumentException ex)
            {

                return BadRequest(new { mensaje = ex.Message });
            }




       
        }











    }
}
