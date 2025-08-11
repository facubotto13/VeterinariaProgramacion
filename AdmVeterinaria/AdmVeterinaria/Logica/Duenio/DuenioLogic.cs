

using AdmVeterinaria.Datos.Dtos;
using AdmVeterinaria.Repositorios.Duenio;

namespace AdmVeterinaria.Logica.DuenioLogic
{
    public class DuenioLogic : IDuenioLogic
    {
        private readonly IDuenioRepository _duenioRepository;
        public DuenioLogic(IDuenioRepository duenioRepository)
        {
            _duenioRepository = duenioRepository;
        }
        public DtoDuenio ObtenerDuenio(int id)
        {
            Datos.Clases.Duenio duenio = _duenioRepository.ObtenerDuenio(id);

            if (duenio == null)
            {
                return null;
            }

            return new DtoDuenio
            {
                IdDuenio = duenio.IdDuenio,
                Dni = duenio.Dni,
                Nombre = duenio.Nombre,
                Apellido = duenio.Apellido,
                Animales = duenio.Animales,
            };
        }
        public bool EliminarDuenio(int id)
        {
            var duenio = _duenioRepository.ObtenerDuenio(id);
            if (duenio == null) return false;

            _duenioRepository.Eliminar(duenio);
            return true;
        }
        public bool AgregarDuenio(DtoDuenio nuevaDuenio)
        {
            if (nuevaDuenio == null)
            {
                return false;
            }

            var duenioEntidad = new Datos.Clases.Duenio
            {
                IdDuenio = nuevaDuenio.IdDuenio,
                Dni = nuevaDuenio.Dni,
                Nombre = nuevaDuenio.Nombre,
                Apellido = nuevaDuenio.Apellido,
                Animales = nuevaDuenio.Animales,
            };

            _duenioRepository.Agregar(duenioEntidad);
            return true;
        }
        public bool ActualizarDuenio(int id, DtoDuenio duenioDtos)
        {
            if (duenioDtos == null)
            {
                return false;
            }
            var duenioExist = _duenioRepository.ObtenerDuenio(id);
            if (duenioExist == null)
            {
                return false;
            }
            duenioExist.Dni = duenioExist.Dni;
            duenioExist.Nombre = duenioExist.Nombre;
            duenioExist.Apellido = duenioExist.Apellido;
            duenioExist.Animales = duenioExist.Animales;

            return true;
        }

        public List<DtoDuenio> ObtenerDuenios()
        {
            var duenios = _duenioRepository.ObtenerDuenios();
            return duenios.Select(duenio => new DtoDuenio
            {
                IdDuenio = duenio.IdDuenio,
                Dni = duenio.Dni,
                Nombre = duenio.Nombre,
                Apellido = duenio.Apellido,
                Animales = duenio.Animales,
            }).ToList();

        }
    }
}
