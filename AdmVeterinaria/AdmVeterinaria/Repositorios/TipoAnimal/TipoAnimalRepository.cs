using AdmVeterinaria.Datos;

namespace AdmVeterinaria.Repositorios.TipoAnimal
{
    public class TipoAnimalRepository
    {
        private readonly TodoContext _context;

        public TipoAnimalRepository(TodoContext context)
        {
            _context = context;
        }
        public Datos.Clases.TipoAnimal ObtenerTipoAnimal(int id)
        {
            return _context.TiposAnimals.FirstOrDefault(x => x.IdTipoAnimal == id);
        }
        public void Eliminar(Datos.Clases.TipoAnimal tipoAnimal)
        {
            _context.TiposAnimals.Remove(tipoAnimal);
            _context.SaveChanges();
        }
        public void Agregar(Datos.Clases.TipoAnimal tipoAnimal)
        {
            _context.TiposAnimals.Add(tipoAnimal);
            _context.SaveChanges();
        }
        public void Actualizar(Datos.Clases.TipoAnimal tipoAnimal)
        {
            _context.TiposAnimals.Update(tipoAnimal);
            _context.SaveChanges();
        }
        public List<Datos.Clases.TipoAnimal> ObtenerTipoAnimales()
        {
            return _context.TiposAnimals.ToList();
        }
    }
}
