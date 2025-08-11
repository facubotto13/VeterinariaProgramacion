namespace AdmVeterinaria.Repositorios.Duenio
{
    public interface IDuenioRepository
    {
        List<AdmVeterinaria.Datos.Clases.Duenio> ObtenerDuenios();
        AdmVeterinaria.Datos.Clases.Duenio ObtenerDuenio(int id);
        void Eliminar(AdmVeterinaria.Datos.Clases.Duenio duenio);
        void Agregar(AdmVeterinaria.Datos.Clases.Duenio duenio);
        void Actualizar(AdmVeterinaria.Datos.Clases.Duenio duenio);
    }
}
