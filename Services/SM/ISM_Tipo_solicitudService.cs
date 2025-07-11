using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.SM;

namespace Web_Api_Contable.Services.SM
{
    public interface ISM_Tipo_solicitudService
    {
        public List<SM_Tipo_solicitud> read();
        public SM_Tipo_solicitud getByPk(int id_tipo_solicitud);
        public int insert(SM_Tipo_solicitud obj);
        public void update(SM_Tipo_solicitud obj);
        public void delete(SM_Tipo_solicitud obj);
    }
}

