using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.TRAMITES;
using Web_Api_Contable.Services.FOP;

namespace Web_Api_Contable.Services.TRAMITES
{
    public class Adjuntos_x_TramitesServices : IAdjuntos_x_TramitesServices
    {
        public void delete(ADJUNTOS_X_TRAMITES obj)
        {
            try
            {
                ADJUNTOS_X_TRAMITES.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ADJUNTOS_X_TRAMITES getByPk(int nro_bad)
        {
            try
            {
                return ADJUNTOS_X_TRAMITES.getByPk(nro_bad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(ADJUNTOS_X_TRAMITES obj)
        {
            try
            {
                return ADJUNTOS_X_TRAMITES.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ADJUNTOS_X_TRAMITES> read()
        {
            try
            {
                return ADJUNTOS_X_TRAMITES.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(ADJUNTOS_X_TRAMITES obj)
        {
            try
            {
                ADJUNTOS_X_TRAMITES.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
