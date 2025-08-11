using AdmVeterinaria.Datos;

namespace AdmVeterinaria.Repositorios.Atencion
{
    public class AtencionRepository
    {
       
            private readonly TodoContext _context;

        public AtencionRepository(TodoContext context)
        {
            _context = context;
        }
        public AdmVeterinaria.Datos.Clases.Atencion ObtenerAtencion(int id)
        {
            return _context.Atencions.FirstOrDefault(x => x.IdAtencion == id);
        }
        public void Eliminar(AdmVeterinaria.Datos.Clases.Atencion atencion)
        {
            _context.Atencions.Remove(atencion);
            _context.SaveChanges();
        }
        public void Agregar(AdmVeterinaria.Datos.Clases.Atencion atencion)
        {
            _context.Atencions.Add(atencion);
            _context.SaveChanges();
        }
        public void Actualizar(AdmVeterinaria.Datos.Clases.Atencion atencion)
        {
            _context.Atencions.Update(atencion);
            _context.SaveChanges();
        }

        public List<AdmVeterinaria.Datos.Clases.Atencion> ObtenerAtenciones()
        {
            return _context.Atencions.ToList();
        }

    }
}
