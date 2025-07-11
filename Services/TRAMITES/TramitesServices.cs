using Web_Api_Contable.Entities.TRAMITES;

namespace Web_Api_Contable.Services.TRAMITES
{
    public class TramitesServices : ITramitesServices
    {
        public void delete(TRAMITE obj)
        {
            try
            {
                TRAMITE.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TRAMITE getByPk(int nro_bad)
        {
            try
            {
                return TRAMITE.getByPk(nro_bad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public Entities.TRAMITE getByPk2(int nro_bad)
        //{
        //    try
        //    {
        //        return Entities.TRAMITE.getByPk2(nro_bad);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public int insert(TRAMITE obj)
        {
            try
            {
                return TRAMITE.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TRAMITE> read()
        {
            try
            {
                return TRAMITE.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(TRAMITE obj)
        {
            try
            {
                TRAMITE.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TIPOS_TRAMITES> listartipos_tramites()
        {
            try
            {
                return TRAMITE.ObtenerTipoTramite();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TIPOLOGIAS> listartipologias()
        {
            try
            {
                return TRAMITE.ObtenerTipologia();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
