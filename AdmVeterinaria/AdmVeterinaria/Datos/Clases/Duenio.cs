namespace AdmVeterinaria.Datos.Clases
{
    public class Duenio
    {
        public int IdDuenio { get; set; } // ID autoincremental
        public string Dni {  get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<Animal> Animales { get; set; }
    }
}
