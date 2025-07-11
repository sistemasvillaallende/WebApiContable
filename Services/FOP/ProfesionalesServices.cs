using Web_Api_Contable.Entities.TRAMITES;

namespace Web_Api_Contable.Services.FOP
{
    public class ProfesionalesServices : IProfesionalesServices
    {
        public void delete(PROFESIONALES obj)
        {
            try
            {
                PROFESIONALES.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PROFESIONALES getByPk(int id)
        {
            try
            {
                return PROFESIONALES.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(PROFESIONALES obj)
        {
            try
            {
                return PROFESIONALES.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PROFESIONALES> read()
        {
            try
            {
                return PROFESIONALES.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(PROFESIONALES obj)
        {
            try
            {
                PROFESIONALES.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
