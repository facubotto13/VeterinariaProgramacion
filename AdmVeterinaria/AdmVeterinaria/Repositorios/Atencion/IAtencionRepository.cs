namespace AdmVeterinaria.Repositorios.Atencion
{
    public interface IAtencionRepository
    {
        List<AdmVeterinaria.Datos.Clases.Atencion> ObtenerAtenciones();
        AdmVeterinaria.Datos.Clases.Atencion ObtenerAtencion(int id);
        void Eliminar(AdmVeterinaria.Datos.Clases.Atencion atencion);
        void Agregar(AdmVeterinaria.Datos.Clases.Atencion atencion);
        void Actualizar(AdmVeterinaria.Datos.Clases.Atencion atencion);
    }
}
