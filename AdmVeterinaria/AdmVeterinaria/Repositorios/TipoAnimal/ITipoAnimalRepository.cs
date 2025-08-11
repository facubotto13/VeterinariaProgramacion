namespace AdmVeterinaria.Repositorios.TipoAnimal
{
    public interface ITipoAnimalRepository
    {
        List<AdmVeterinaria.Datos.Clases.TipoAnimal> ObtenerTipoAnimales();
        AdmVeterinaria.Datos.Clases.TipoAnimal ObtenerTipoAnimal(int id);
        void Eliminar(AdmVeterinaria.Datos.Clases.TipoAnimal tipoAnimal);
        void Agregar(AdmVeterinaria.Datos.Clases.TipoAnimal tipoAnimal);
        void Actualizar(AdmVeterinaria.Datos.Clases.TipoAnimal tipoAnimal);
    }
}
