using AdmVeterinaria.Datos.Clases;

namespace AdmVeterinaria.Services
{
    public class DuenioDataStore
    {
        public static DuenioDataStore Current { get; } = new DuenioDataStore();
        public List<Duenio> Duenios { get; set; }
        private int _currentId; // Contador para IDs autoincrementales

        public DuenioDataStore()
        {
            _currentId = 1; // Inicializamos el contador
            Duenios = new List<Duenio>();
        }
        public Duenio AddDuenio(string dni, string nombre, string apellido)
        {
            // Crear y agregar el nuevo dueño
            var nuevoDuenio = new Duenio
            {
                IdDuenio = _currentId++, // Asignamos el ID autoincremental
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                Animales = new List<Animal>()
            };
            Duenios.Add(nuevoDuenio);
            return nuevoDuenio;
        }
        public int GetNextId()
        {
            return _currentId++;
        }

    }
}
