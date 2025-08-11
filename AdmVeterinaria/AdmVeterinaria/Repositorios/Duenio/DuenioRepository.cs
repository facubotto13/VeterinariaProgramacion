using AdmVeterinaria.Datos;

namespace AdmVeterinaria.Repositorios.Duenio
{
    public class DuenioRepository
    {
        private readonly TodoContext _context;

        public DuenioRepository(TodoContext context)
        {
            _context = context;
        }
        public AdmVeterinaria.Datos.Clases.Duenio ObtenerDuenio(int id)
        {
            return _context.Duenios.FirstOrDefault(x => x.IdDuenio == id);
        }
        public void Eliminar(AdmVeterinaria.Datos.Clases.Duenio duenio)
        {
            _context.Duenios.Remove(duenio);
            _context.SaveChanges();
        }
        public void Agregar(AdmVeterinaria.Datos.Clases.Duenio duenio)
        {
            _context.Duenios.Add(duenio);
            _context.SaveChanges();
        }
        public void Actualizar(AdmVeterinaria.Datos.Clases.Duenio duenio)
        {
            _context.Duenios.Update(duenio);
            _context.SaveChanges();
        }
        public List<AdmVeterinaria.Datos.Clases.Duenio> ObtenerDuenios()
        {
            return _context.Duenios.ToList();
        }
    }
}
