
using AdmVeterinaria.Datos.Dtos;

namespace AdmVeterinaria.Logica.AtencionLogic
{
    public interface IAtencionLogic
    {
        List<DtoAtencion> ObtenerAtenciones();
        DtoAtencion ObtenerAtencion(int id);
        bool EliminarAtencion(int id);
        bool AgregarAtencion(DtoAtencion nuevaAtencion);
        bool ActualizarAtencion(int id, DtoAtencion atencionDtos);
    }
}
