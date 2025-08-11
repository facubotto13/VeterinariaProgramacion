using AdmVeterinaria.Datos.Clases;

namespace AdmVeterinaria.Services
{
    public class AtencionDataStore
    {
        public static AtencionDataStore Current { get; } = new AtencionDataStore();
        public List<Atencion> Atenciones { get; set; }
        private int _currentId; // Contador para IDs autoincrementales

        public AtencionDataStore()
        {
            _currentId = 1; // Inicializamos el contador
            Atenciones = new List<Atencion>();
        }

        public Atencion AddAtencion(int idAnimal, string tipoAtencion, string motivo, string tratamientoRecibido, List<Medicamento> medicamentos)
        {
            // Buscar el animal por ID
            var animal = AnimalDataStore.Current.Animales.FirstOrDefault(a => a.IdAnimal == idAnimal);
            if (animal == null)
            {
                throw new ArgumentException($"No se encontró un animal con el ID {idAnimal}");
            }

            // Crear y agregar la nueva atención
            var nuevaAtencion = new Atencion
            {
                IdAtencion = _currentId++, // Asignamos el ID autoincremental
                TipoAtencion = tipoAtencion,
                Motivo = motivo,
                TratamientoRebicido = tratamientoRecibido,
                Medicamentos = medicamentos,
                Fecha = DateTime.Now,
                Animal = animal
            };

            Atenciones.Add(nuevaAtencion);
            return nuevaAtencion;
        }

        public int GetNextId()
        {
            return _currentId++;
        }
    }
}
