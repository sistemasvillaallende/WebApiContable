using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP
{
    public interface IOficinaService
    {
        List<Oficinas> getListOficinas(int id_oficina);
    }
}
