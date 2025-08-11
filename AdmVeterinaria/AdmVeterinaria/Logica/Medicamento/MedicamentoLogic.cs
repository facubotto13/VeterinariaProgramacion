

using AdmVeterinaria.Datos.Dtos;
using AdmVeterinaria.Repositorios.Medicamento;

namespace AdmVeterinaria.Logica.MedicamentoLogic
{
    public class MedicamentoLogic : IMedicamentoLogic
    {
        private readonly IMedicamentoRepository _medicamentoRepository;

        public MedicamentoLogic(IMedicamentoRepository medicamentoRepository)
        {
            _medicamentoRepository = medicamentoRepository;
        }
        public DtoMedicamento ObtenerMedicamento(int id)
        {
            Datos.Clases.Medicamento medicamento = _medicamentoRepository.ObtenerMedicamento(id);

            if (medicamento == null)
            {
                return null;
            }

            return new DtoMedicamento
            {
                IdMedicamento = medicamento.IdMedicamento,
                Nombre = medicamento.Nombre,
            };
        }
        public bool EliminarMedicamento(int id)
        {
            var medicamento = _medicamentoRepository.ObtenerMedicamento(id);
            if (medicamento == null) return false;

            _medicamentoRepository.Eliminar(medicamento);
            return true;
        }
        public bool AgregarMedicamento(DtoMedicamento nuevoMedicamento)
        {
            if (nuevoMedicamento == null)
            {
                return false;
            }

            var medicamentoEntidad = new Datos.Clases.Medicamento
            {
                IdMedicamento = nuevoMedicamento.IdMedicamento,
                Nombre = nuevoMedicamento.Nombre,
                
                //IdDuenio = nuevoAnimal.IdDuenio,
            };

            _medicamentoRepository.Agregar(medicamentoEntidad);
            return true;
        }
        public bool ActualizarMedicamento(int id, DtoMedicamento medicamentoDto)
        {
            if (medicamentoDto == null)
            {
                return false;
            }
            var medicamentoExistente = _medicamentoRepository.ObtenerMedicamento(id);
            if (medicamentoExistente == null)
            {
                return false;
            }
            medicamentoExistente.Nombre = medicamentoDto.Nombre;
            return true;
        }
        public List<DtoMedicamento> ObtenerMedicamentos()
        {
            List<AdmVeterinaria.Datos.Clases.Medicamento> medicamentos = _medicamentoRepository.ObtenerMedicamentos();
            List<DtoMedicamento> medicamentosDtos = new List<DtoMedicamento>();
            foreach (var medicamento in medicamentos)
            {
                medicamentosDtos.Add(new DtoMedicamento
                {
                    IdMedicamento = medicamento.IdMedicamento,
                    Nombre = medicamento.Nombre,
                });
            }
            return medicamentosDtos;
        }
    }
}
