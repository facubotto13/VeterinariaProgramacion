using AdmVeterinaria.Datos.Clases;
using AdmVeterinaria.Datos.Dtos;
using AdmVeterinaria.Logica.TipoAnimal;
using AdmVeterinaria.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdmVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAnimalController : ControllerBase
    {
        private readonly ITipoAnimalLogic _tipoanimallogic;
        public TipoAnimalController(ITipoAnimalLogic logic)
        {
            _tipoanimallogic = logic;
        }

        // GET: api/TipoAnimal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoTipoAnimal>>> GetTipoAnimales()
        {
            return _tipoanimallogic.ObtenerTipoAnimales();
        }

        // GET: api/TipoAnimal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DtoTipoAnimal>> GetTipoAnimales(int id)
        {
            return _tipoanimallogic.ObtenerTipoAnimal(id);
        }

        // PUT: api/TipoAnimal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoAnimal(int id, DtoTipoAnimal tipoanimal)
        {
            if (id != tipoanimal.IdTipoAnimal)
            {
                return BadRequest();
            }

            _tipoanimallogic.ActualizarTipoAnimal(id, tipoanimal);

            return NoContent();
        }

        // POST: api/TipoAnimal
        [HttpPost]
        public async Task<ActionResult<TipoAnimal>> PostTipoAnimal(DtoTipoAnimal tipoanimal)
        {
            _tipoanimallogic.AgregarTipoAnimal(tipoanimal);

            return CreatedAtAction("GetTipoAnimal", new { id = tipoanimal.IdTipoAnimal }, tipoanimal);
        }

        // DELETE: api/TipoAnimal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoAnimal(int id)
        {
            _tipoanimallogic.EliminarTipoAnimal(id);
            return NoContent();
        }
    }
}
