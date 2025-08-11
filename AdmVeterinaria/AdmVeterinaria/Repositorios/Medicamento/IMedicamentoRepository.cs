namespace AdmVeterinaria.Repositorios.Medicamento
{
    public interface IMedicamentoRepository
    {
        List<AdmVeterinaria.Datos.Clases.Medicamento> ObtenerMedicamentos();
        AdmVeterinaria.Datos.Clases.Medicamento ObtenerMedicamento(int id);
        void Eliminar(AdmVeterinaria.Datos.Clases.Medicamento medicamento);
        void Agregar(AdmVeterinaria.Datos.Clases.Medicamento medicamento);
        void Actualizar(AdmVeterinaria.Datos.Clases.Medicamento medicamento);
    }
}
