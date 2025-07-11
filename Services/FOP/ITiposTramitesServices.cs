using Web_Api_Contable.Entities.TRAMITES;

namespace Web_Api_Contable.Services.FOP
{
    public interface ITiposTramitesServices
    {
        public List<TIPOS_TRAMITES> read();
        public TIPOS_TRAMITES getByPk(int id);
    }
}
