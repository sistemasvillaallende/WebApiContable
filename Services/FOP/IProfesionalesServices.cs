using Web_Api_Contable.Entities.TRAMITES;

namespace Web_Api_Contable.Services.FOP
{
    public interface IProfesionalesServices
    {
        public int insert(PROFESIONALES obj);
        public void update(PROFESIONALES obj);
        public void delete(PROFESIONALES obj);
        public List<PROFESIONALES> read();
        public PROFESIONALES getByPk(int id);
    }
}
