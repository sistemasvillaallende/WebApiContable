using Web_Api_Contable.Entities.TRAMITES;

namespace Web_Api_Contable.Services.TRAMITES
{
    public interface ITramitesServices
    {
        public int insert(TRAMITE obj);
        public void update(TRAMITE obj);
        public void delete(TRAMITE obj);
        public List<TRAMITE> read();
        public TRAMITE getByPk(int nro_bad);
        public List<TIPOS_TRAMITES> listartipos_tramites();
        public List<TIPOLOGIAS> listartipologias();

    }
}
