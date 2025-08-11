using AdmVeterinaria.Datos.Dtos;

namespace AdmVeterinaria.Logica.AnimalLogic
{
    public interface IAnimalLogic
    {
        List<DtoAnimal> ObtenerAnimales();
        DtoAnimal ObtenerAnimal(int id);
        bool EliminarAnimal (int id);
        bool AgregarAnimal (DtoAnimal nuevoAnimal);
        bool ActualizarAnimal(int id, DtoAnimal animalDtos);
        List<DtoAnimal> FiltrarAnimales(string? nombre, string? sexo);

    }
}
