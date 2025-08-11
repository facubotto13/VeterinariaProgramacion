using AdmVeterinaria.Datos;

namespace AdmVeterinaria.Repositorios.Medicamento
{
    public class MedicamentoRepository
    {
        private readonly TodoContext _context;

        public MedicamentoRepository(TodoContext context)
        {
            _context = context;
        }
        public AdmVeterinaria.Datos.Clases.Medicamento ObtenerMedicamento(int id)
        {
            return _context.Medicamentos.FirstOrDefault(x => x.IdMedicamento == id);
        }
        public void Eliminar(AdmVeterinaria.Datos.Clases.Medicamento medicamento)
        {
            _context.Medicamentos.Remove(medicamento);
            _context.SaveChanges();
        }
        public void Agregar(AdmVeterinaria.Datos.Clases.Medicamento medicamento)
        {
            _context.Medicamentos.Add(medicamento);
            _context.SaveChanges();
        }
        public void Actualizar(AdmVeterinaria.Datos.Clases.Medicamento medicamento)
        {
            _context.Medicamentos.Update(medicamento);
            _context.SaveChanges();
        }
        public List<AdmVeterinaria.Datos.Clases.Medicamento> ObtenerMedicamentos()
        {
            return _context.Medicamentos.ToList();
        }
    }
}
