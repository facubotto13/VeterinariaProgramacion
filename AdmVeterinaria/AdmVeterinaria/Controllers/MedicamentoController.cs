using AdmVeterinaria.Datos.Clases;
using AdmVeterinaria.Datos.Dtos;
using AdmVeterinaria.Logica.MedicamentoLogic;
using AdmVeterinaria.Services;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;

namespace AdmVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoLogic _medicamentologic;
        public MedicamentoController(IMedicamentoLogic logic)
        {
            _medicamentologic = logic;
        }

        // GET: api/Medicamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoMedicamento>>> GetMedicamentos()
        {
            return _medicamentologic.ObtenerMedicamentos();
        }

        // GET: api/Medicamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DtoMedicamento>> GetMedicamento(int id)
        {
            return _medicamentologic.ObtenerMedicamento(id);
        }

        // PUT: api/Medicamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicamento(int id, DtoMedicamento medicamento)
        {
            if (id != medicamento.IdMedicamento)
            {
                return BadRequest();
            }

            _medicamentologic.ActualizarMedicamento(id, medicamento);

            return NoContent();
        }

        // POST: api/Medicamento
        [HttpPost]
        public async Task<ActionResult<Medicamento>> PostMedicamento(DtoMedicamento medicamento)
        {
            _medicamentologic.AgregarMedicamento(medicamento);

            return CreatedAtAction("GetMedicamento", new { id = medicamento.IdMedicamento }, medicamento);
        }

        // DELETE: api/Medicamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicamento(int id)
        {
            _medicamentologic.EliminarMedicamento(id);
            return NoContent();

        }
    }
}
