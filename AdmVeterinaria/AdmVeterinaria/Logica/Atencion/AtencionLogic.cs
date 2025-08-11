using AdmVeterinaria.Datos.Dtos;
using AdmVeterinaria.Repositorios.Atencion;

namespace AdmVeterinaria.Logica.AtencionLogic
{
    public class AtencionLogic : IAtencionLogic
    {
        private readonly IAtencionRepository _atencionRepository;
        public AtencionLogic(IAtencionRepository atencionRepository)
        {
            _atencionRepository = atencionRepository;
        }
        public DtoAtencion ObtenerAtencion(int id)
        {
            Datos.Clases.Atencion atencion = _atencionRepository.ObtenerAtencion(id);

            if (atencion == null)
            {
                return null;
            }

            return new DtoAtencion
            {
                IdAtencion = atencion.IdAtencion,
                TipoAtencion = atencion.TipoAtencion,
                Motivo = atencion.Motivo,
                TratamientoRebicido = atencion.TratamientoRebicido,
                Medicamentos = atencion.Medicamentos,
                Fecha = atencion.Fecha,
                Animal = atencion.Animal,
            };
        }
        public bool EliminarAtencion(int id)
        {
            var atencion = _atencionRepository.ObtenerAtencion(id);
            if (atencion == null) return false;

            _atencionRepository.Eliminar(atencion);
            return true;
        }
        public bool AgregarAtencion(DtoAtencion nuevaAtencion)
        {
            if (nuevaAtencion == null)
            {
                return false;
            }

            if (nuevaAtencion.Fecha < DateTime.Now.AddDays(1) || nuevaAtencion.Fecha > DateTime.Now.AddDays(30))
            {
                throw new ArgumentException("La fecha debe estar entre 1 y 30 días a partir de hoy.");
            }

            var atencionEntidad = new Datos.Clases.Atencion
            {
                IdAtencion = nuevaAtencion.IdAtencion,
                TipoAtencion = nuevaAtencion.TipoAtencion,
                Motivo = nuevaAtencion.Motivo,
                TratamientoRebicido = nuevaAtencion.TratamientoRebicido,
                Medicamentos = nuevaAtencion.Medicamentos,
                Fecha = nuevaAtencion.Fecha,
                Animal = nuevaAtencion.Animal,
            };

            _atencionRepository.Agregar(atencionEntidad);
            return true;
        }
        public bool ActualizarAtencion(int id, DtoAtencion atencionDtos)
        {
            if (atencionDtos == null)
            {
                return false;
            }
            var atencionExist = _atencionRepository.ObtenerAtencion(id);
            if (atencionExist == null)
            {
                return false;
            }
            atencionExist.TipoAtencion = atencionExist.TipoAtencion;
            atencionExist.Motivo = atencionExist.Motivo;
            atencionExist.TratamientoRebicido = atencionExist.TratamientoRebicido;
            atencionExist.Medicamentos = atencionExist.Medicamentos;
            atencionExist.Fecha = atencionExist.Fecha;
            atencionExist.Animal = atencionExist.Animal;
            _atencionRepository.Actualizar(atencionExist);
            return true;
        }

        public List<DtoAtencion> ObtenerAtenciones()
        {
            var atencion = _atencionRepository.ObtenerAtenciones();
            return atencion.Select(at => new DtoAtencion
            {
                IdAtencion = at.IdAtencion,
                TipoAtencion = at.TipoAtencion,
                Motivo = at.Motivo,
                TratamientoRebicido = at.TratamientoRebicido,
                Medicamentos = at.Medicamentos,
                Fecha = at.Fecha,
                Animal = at.Animal,
            }).ToList();

        }
    }
}
