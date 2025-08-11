namespace AdmVeterinaria.Datos.Dtos
{
    public class DtoAnimal
    {
        public int IdAnimal { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        // public Duenio? Duenio { get; set; }
        // public TipoAnimal TipoAnimal { get; set; }
        // public List<Atencion> Atenciones { get; set; }
    }
}
