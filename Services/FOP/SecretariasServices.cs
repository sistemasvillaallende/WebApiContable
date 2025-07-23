using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP
{
    public class SecretariasServices : ISecretariasService
    {
    
        public List<Secretarias> getListSecretarias(int id_secretaria)
        {
            try
            {
               return Secretarias.getListSecretarias(id_secretaria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Secretarias> getSecretariasByNombre(int ejercicio, string nombre)
        {
            try
            {
                return Secretarias.getSecretariasByNombre(ejercicio,nombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
