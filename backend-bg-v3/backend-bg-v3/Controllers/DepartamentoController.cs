
using backend_bg_v3.Dto.Request;
using backend_bg_v3.Service;
using Microsoft.AspNetCore.Mvc;

namespace backend_bg_v3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly DepartamentoService _departamentoService;

        public DepartamentoController(DepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        // GET: api/Departamento
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departamentos =
                await _departamentoService.GetAllDepartamentosAsync();

            return Ok(departamentos);
        }

        // GET: api/Departamento/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var departamento =
                await _departamentoService.GetByIdDepartamentoAsync(id);

            if (departamento == null)
                return NotFound(new
                {
                    mensaje = "Departamento no encontrado"
                });

            return Ok(departamento);
        }

        // POST: api/Departamento
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] DepartamentoRequest dto)
        {
            var id =
                await _departamentoService.CreateDepartamentoAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id },
                new
                {
                    mensaje = "Departamento creado correctamente",
                    departamentoId = id
                }
            );
        }
    }
}
