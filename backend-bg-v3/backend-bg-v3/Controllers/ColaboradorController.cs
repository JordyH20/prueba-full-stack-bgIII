
using backend_bg_v3.Dto.Request;
using backend_bg_v3.Service;
using Microsoft.AspNetCore.Mvc;

namespace backend_bg_v3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly ColaboradorService _colaboradorService;

        public ColaboradorController(ColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        // GET: api/Colaborador
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var colaboradores = await _colaboradorService.GetAllColaboradoresAsync();
            return Ok(colaboradores);
        }

        // GET: api/Colaborador/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var colaborador = await _colaboradorService.GettByIdColaborador(id);

            if (colaborador == null)
                return NotFound(new { mensaje = "Colaborador no encontrado" });

            return Ok(colaborador);
        }

        // POST: api/Colaborador
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ColaboradorRequest dto)
        {
            var id = await _colaboradorService.CreateAsync(dto);    

            return CreatedAtAction(
                nameof(GetById),
                new { id },
                new { mensaje = "Colaborador creado correctamente", colaboradorId = id }
            );
        }
    }
}
