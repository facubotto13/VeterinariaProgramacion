using AdmVeterinaria.Datos.Clases;
using AdmVeterinaria.Datos.Dtos;
using AdmVeterinaria.Services;
using Microsoft.EntityFrameworkCore;

namespace AdmVeterinaria.Repositorios.Animal
{
    public class AnimalRepository : IAnimalRepository
    {
        public List<AdmVeterinaria.Datos.Clases.Animal> ObtenerAnimales()
        {
            return AnimalDataStore.Current.Animales;
        }

        public AdmVeterinaria.Datos.Clases.Animal ObtenerAnimal(int id)
        {
            return AnimalDataStore.Current.Animales.FirstOrDefault(x => x.IdAnimal == id);
        }
        public List<DtoAnimal> FiltrarAnimales(string? nombre, string? sexo)
        {
            var query = AnimalDataStore.Current.Animales.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nombre))
               query = query.Where(a =>
            (a.Nombre != null && a.Nombre.ToLower().StartsWith(nombre)) ||
            (a.Raza != null && a.Raza.ToLower().StartsWith(nombre)) ||
            a.Edad.ToString().StartsWith(nombre));


            if (!string.IsNullOrWhiteSpace(sexo))
                query = query.Where(a => a.Sexo != null && a.Sexo.ToLower() == sexo.ToLower());

            return query.Select(a => new DtoAnimal
            {
                IdAnimal = a.IdAnimal,
                Nombre = a.Nombre,
                Raza = a.Raza,
                Edad = a.Edad,
                Sexo = a.Sexo,
            }).ToList();
        }



        public void Eliminar(AdmVeterinaria.Datos.Clases.Animal animal)
        {
            AnimalDataStore.Current.Animales.Remove(animal);
        }

        public void Agregar(AdmVeterinaria.Datos.Clases.Animal animal)
        {
            // Asignar un ID autoincremental
            animal.IdAnimal = AnimalDataStore.Current.Animales.Count > 0
                ? AnimalDataStore.Current.Animales.Max(a => a.IdAnimal) + 1
                : 1;

            AnimalDataStore.Current.Animales.Add(animal);
        }

        public void Actualizar(AdmVeterinaria.Datos.Clases.Animal animal)
        {
            var existente = ObtenerAnimal(animal.IdAnimal);
            if (existente != null)
            {
                existente.Nombre = animal.Nombre;
                existente.Raza = animal.Raza;
                existente.Edad = animal.Edad;
                existente.Sexo = animal.Sexo;
            }
        }
    }
}
