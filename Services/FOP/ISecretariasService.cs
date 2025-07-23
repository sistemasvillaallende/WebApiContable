using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP
{
    public interface ISecretariasService
    {
       List <Secretarias> getListSecretarias(int id_secretaria);
       List<Secretarias> getSecretariasByNombre(int ejercicio, string nombre);

    }
}
