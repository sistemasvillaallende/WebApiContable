using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.TRAMITES;

namespace Web_Api_Contable.Services.FOP
{
    public interface IAdjuntos_x_TramitesServices
    {
        public int insert(ADJUNTOS_X_TRAMITES obj);
        public void update(ADJUNTOS_X_TRAMITES obj);
        public void delete(ADJUNTOS_X_TRAMITES obj);
        public List<ADJUNTOS_X_TRAMITES> read();
        public ADJUNTOS_X_TRAMITES getByPk(int nro_bad);
    }
}
