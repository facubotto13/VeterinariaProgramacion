namespace AdmVeterinaria.Datos.Clases
{
    public class Atencion
    {
        public int IdAtencion { get; set; }
        public string TipoAtencion { get; set; }
        public string Motivo { get; set; }
        public string TratamientoRebicido { get; set; }
        public List<Medicamento> Medicamentos { get; set; }
        public DateTime Fecha { get; set; }
        public Animal Animal { get; set; }
    }
}
