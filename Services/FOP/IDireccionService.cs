using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP
{
    public interface IDireccionService
    {
        List<Direcciones> getListDirecciones(int id_secretaria);
        List<Direcciones> getDireccionesByNombre(int ejercicio, string nombre);
    }
}
