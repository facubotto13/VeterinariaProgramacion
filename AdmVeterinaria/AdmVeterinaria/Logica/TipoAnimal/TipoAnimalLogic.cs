

using AdmVeterinaria.Datos.Dtos;
using AdmVeterinaria.Repositorios.TipoAnimal;

namespace AdmVeterinaria.Logica.TipoAnimal
{
    public class TipoAnimalLogic : ITipoAnimalLogic
    {
        private readonly ITipoAnimalRepository _tipoAnimalRepository;
        public TipoAnimalLogic(ITipoAnimalRepository tipoAnimalRepository)
        {
            _tipoAnimalRepository = tipoAnimalRepository;
        }
        public DtoTipoAnimal ObtenerTipoAnimal(int id)
        {
            Datos.Clases.TipoAnimal tipoAnimal = _tipoAnimalRepository.ObtenerTipoAnimal(id);

            if (tipoAnimal == null)
            {
                return null;
            }

            return new DtoTipoAnimal
            {
                IdTipoAnimal = tipoAnimal.IdTipoAnimal,
                Tipoanimal = tipoAnimal.Tipoanimal,
                Animal = tipoAnimal.Animal,
                
            };
        }
        public bool EliminarTipoAnimal(int id)
        {
            var tipoAnimal = _tipoAnimalRepository.ObtenerTipoAnimal(id);
            if (tipoAnimal == null) return false;

            _tipoAnimalRepository.Eliminar(tipoAnimal);
            return true;
        }
        public bool AgregarTipoAnimal(DtoTipoAnimal nuevaTipoAnimal)
        {
            if (nuevaTipoAnimal == null)
            {
                return false;
            }

            var tipoAnimalEntidad = new Datos.Clases.TipoAnimal
            {
                IdTipoAnimal = nuevaTipoAnimal.IdTipoAnimal,
                Tipoanimal = nuevaTipoAnimal.Tipoanimal,
                Animal = nuevaTipoAnimal.Animal,
                
            };

            _tipoAnimalRepository.Agregar(tipoAnimalEntidad);
            return true;
        }
        public bool ActualizarTipoAnimal(int id, DtoTipoAnimal tipoAnimalDtos)
        {
            if (tipoAnimalDtos == null)
            {
                return false;
            }
            var tipoAnimalExist = _tipoAnimalRepository.ObtenerTipoAnimal(id);
            if (tipoAnimalExist == null)
            {
                return false;
            }
            tipoAnimalExist.Tipoanimal = tipoAnimalExist.Tipoanimal;
            tipoAnimalExist.Animal = tipoAnimalExist.Animal;
            

            return true;
        }
        public List<DtoTipoAnimal> ObtenerTipoAnimales()
        {
            var tipoAnimales = _tipoAnimalRepository.ObtenerTipoAnimales();
            return tipoAnimales.Select(tipoAnimal => new DtoTipoAnimal
            {
                IdTipoAnimal = tipoAnimal.IdTipoAnimal,
                Tipoanimal = tipoAnimal.Tipoanimal,
                Animal = tipoAnimal.Animal,

            }).ToList();
        }
    }
}
