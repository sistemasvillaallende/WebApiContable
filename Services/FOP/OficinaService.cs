using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP
{
    public class OficinaService: IOficinaService
    {
        public List<Oficinas> getListOficinas(int id_oficina)
        {
            try
            {
                return Oficinas.getListOficinas(id_oficina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
