
using AdmVeterinaria.Datos.Clases;

namespace AdmVeterinaria.Datos.Dtos
{
    public class DtoDuenio
    {
        public int IdDuenio { get; set; } // ID autoincremental
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<Animal> Animales { get; set; }
    }
}
