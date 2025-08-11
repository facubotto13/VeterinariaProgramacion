using AdmVeterinaria.Datos.Clases;
using AdmVeterinaria.Services;
using Microsoft.AspNetCore.Mvc;
using AdmVeterinaria.Datos.Dtos;
using AdmVeterinaria.Logica.DuenioLogic;

namespace AdmVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuenioController : ControllerBase
    {
        private readonly IDuenioLogic _dueniologic;
        public DuenioController(IDuenioLogic logic)
        {
            _dueniologic = logic;
        }

        // GET: api/Duenio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoDuenio>>> GetDuenio()
        {
            return _dueniologic.ObtenerDuenios();
        }

        // GET: api/Duenio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DtoDuenio>> GetDuenio(int id)
        {
            return _dueniologic.ObtenerDuenio(id);
        }

        // PUT: api/Duenio/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuenio(int id, DtoDuenio duenio)
        {
            if (id != duenio.IdDuenio)
            {
                return BadRequest();
            }

            _dueniologic.ActualizarDuenio(id, duenio);

            return NoContent();
        }

        // POST: api/Duenio
        [HttpPost]
        public async Task<ActionResult<Duenio>> PostDuenio(DtoDuenio duenio)
        {
            _dueniologic.AgregarDuenio(duenio);

            return CreatedAtAction("GetDuenio", new { id = duenio.IdDuenio }, duenio);
        }

        // DELETE: api/Duenio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuenio(int id)
        {
            _dueniologic.EliminarDuenio(id);
            return NoContent();

        }
    }
}
