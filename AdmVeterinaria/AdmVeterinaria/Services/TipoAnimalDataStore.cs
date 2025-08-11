using AdmVeterinaria.Datos.Clases;

namespace AdmVeterinaria.Services
{
    public class TipoAnimalDataStore
    {
        private static TipoAnimalDataStore _current = new TipoAnimalDataStore();
        public static TipoAnimalDataStore Current
        {
            get { return _current; }
        }

        public List<TipoAnimal> TipoAnimales { get; set; }
        private int _currentId; // Contador para IDs autoincrementales

        public TipoAnimalDataStore()
        {
            _currentId = 1; // Inicializamos el contador
            TipoAnimales = new List<TipoAnimal>
            {
                new TipoAnimal
                {
                    IdTipoAnimal = _currentId++, // Asignamos el ID autoincremental
                    Tipoanimal = "Perro",
                    Animal = new List<Animal>()
                },
                new TipoAnimal
                {
                    IdTipoAnimal = _currentId++, // Asignamos el ID autoincremental
                    Tipoanimal = "Gato",
                    Animal = new List<Animal>()
                }
            };
        }

        public int GetNextId()
        {
            return _currentId++;
        }
    }
}
