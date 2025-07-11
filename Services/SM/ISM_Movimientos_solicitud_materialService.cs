using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.SM;

namespace Web_Api_Contable.Services.SM
{
    public interface ISM_Movimientos_solicitud_materialService
    {
        public List<SM_Movimientos_solicitud_material> read();
        public SM_Movimientos_solicitud_material getByPk(int id_solicitud, int nro_paso);
        public int insert(SM_Movimientos_solicitud_material obj);
        public void update(SM_Movimientos_solicitud_material obj);
        public void delete(SM_Movimientos_solicitud_material obj);
    }
}

