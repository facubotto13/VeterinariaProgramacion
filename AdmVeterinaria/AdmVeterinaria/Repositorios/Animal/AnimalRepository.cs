using AdmVeterinaria.Datos;
using AdmVeterinaria.Datos.Clases;
using AdmVeterinaria.Datos.Dtos;
using AdmVeterinaria.Services;
using Microsoft.EntityFrameworkCore;

namespace AdmVeterinaria.Repositorios.Animal
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly TodoContext _context;

        public AnimalRepository(TodoContext context)
        {
            _context = context;
        }

        public List<AdmVeterinaria.Datos.Clases.Animal> ObtenerAnimales()
        {
            return _context.Animals.ToList();
        }

        public AdmVeterinaria.Datos.Clases.Animal ObtenerAnimal(int id)
        {
            return _context.Animals.FirstOrDefault(x => x.IdAnimal == id);
        }
        public List<DtoAnimal> FiltrarAnimales(string? nombre, string? sexo)
        {
            var query = _context.Animals.AsQueryable();

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
            _context.Animals.Remove(animal);
            _context.SaveChanges();

        }

        public void Agregar(AdmVeterinaria.Datos.Clases.Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

        public void Actualizar(AdmVeterinaria.Datos.Clases.Animal animal)
        {
            _context.Animals.Update(animal);
            _context.SaveChanges();
        }
    }
}
