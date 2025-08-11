using AdmVeterinaria.Datos.Clases;
using AdmVeterinaria.Datos.Dtos;
using AdmVeterinaria.Logica.AnimalLogic;
using AdmVeterinaria.Services;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;

namespace AdmVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalLogic _animallogic;

        public AnimalController(IAnimalLogic logica)
        {
            _animallogic = logica;
        }

        // GET: api/Animal  
        [HttpGet]
        public ActionResult<IEnumerable<DtoAnimal>> GetAnimals()
        {
            return _animallogic.ObtenerAnimales();
        }

        // GET: api/Animal/filtrar?texto=per
        [HttpGet("filtrar")]
        public IActionResult Filtrar(string? nombre, string? sexo)
        {
            var resultado = _animallogic.FiltrarAnimales(nombre, sexo);
            return Ok(resultado);
        }


        // GET: api/Animal/5  
        [HttpGet("{id}")]
        public async Task<ActionResult<DtoAnimal>> GetAnimal(int id)
        {
            var animals = _animallogic.ObtenerAnimal(id);

            if (animals == null)
            {
                return NotFound();
            }

            return animals;
        }

        // PUT: api/Animal/5  
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimals(int id, DtoAnimal animal)
        {
            if (id != animal.IdAnimal)
            {
                return BadRequest();
            }

            _animallogic.ActualizarAnimal(id, animal);

            return NoContent();
        }

        // POST: api/Animal  
        [HttpPost]
        public async Task<ActionResult<DtoAnimal>> PostAnimals(DtoAnimal animal)
        {
            _animallogic.AgregarAnimal(animal);

            return CreatedAtAction("GetAnimals", new { id = animal.IdAnimal }, animal);
        }

        // DELETE: api/Animal/5  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimals(int id)
        {
            _animallogic.EliminarAnimal(id);

            return NoContent();
        }
    }
}
