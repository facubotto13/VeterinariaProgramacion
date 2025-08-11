using AdmVeterinaria.Datos.Clases;
using AdmVeterinaria.Datos.Dtos;
using AdmVeterinaria.Logica.AtencionLogic;
using AdmVeterinaria.Services;
using Microsoft.AspNetCore.Mvc;


namespace AdmVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtencionController : ControllerBase
    {
        private readonly IAtencionLogic _atencionlogic;
        public AtencionController(IAtencionLogic logic)
        {
            _atencionlogic = logic;
        }

        // GET: api/Atencion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoAtencion>>> GetAtencion()
        {
            return _atencionlogic.ObtenerAtenciones();
        }

        // GET: api/Atencion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DtoAtencion>> GetAtencion(int id)
        {
            return _atencionlogic.ObtenerAtencion(id);
        }

        // PUT: api/Atencion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtencion(int id, DtoAtencion atencion)
        {
            if (id != atencion.IdAtencion)
            {
                return BadRequest();
            }

            _atencionlogic.ActualizarAtencion(id, atencion);

            return NoContent();
        }

        // POST: api/Atencion
        [HttpPost]
        public async Task<ActionResult<Atencion>> PostAtencion(DtoAtencion atencion)
        {
            _atencionlogic.AgregarAtencion(atencion);

            return CreatedAtAction("GetAtencion", new { id = atencion.IdAtencion }, atencion);
        }

        // DELETE: api/Atencion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtencion(int id)
        {
            _atencionlogic.EliminarAtencion(id);
            return NoContent();

        }
    }
}
