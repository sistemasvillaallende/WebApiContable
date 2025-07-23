using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP
{
    public interface IProgramasService
    {
        List<Programas> getListProgramas(int id_secretaria, int id_direccion);
        List<Programas> getListProgramasById(int id_programa);
    }
}
