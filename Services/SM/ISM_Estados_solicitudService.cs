using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.SM;

namespace Web_Api_Contable.Services.SM
{
    public interface ISM_Estados_solicitudService
    {
        public List<SM_Estados_solicitud> read();
        public SM_Estados_solicitud getByPk(int id_estado);
        public int insert(SM_Estados_solicitud obj);
        public void update(SM_Estados_solicitud obj);
        public void delete(SM_Estados_solicitud obj);
    }
}

