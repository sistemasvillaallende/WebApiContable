using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP
{
    public class ProgramaService: IProgramasService
    {
        public List<Programas> getListProgramas(int id_secretaria, int id_direccion)
        {
            try
            {
                return Programas.getListProgramas(id_secretaria,id_direccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Programas> getListProgramasById(int id_programa)
        {
            try
            {
                return Programas.getListProgramasById(id_programa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
