using AdmVeterinaria.Datos.Dtos;

namespace AdmVeterinaria.Logica.DuenioLogic
{
    public interface IDuenioLogic
    {
        List<DtoDuenio> ObtenerDuenios();
        DtoDuenio ObtenerDuenio(int id);
        bool EliminarDuenio(int id);
        bool AgregarDuenio(DtoDuenio nuevaDuenio);
        bool ActualizarDuenio(int id, DtoDuenio duenioDtos);
    }
}
