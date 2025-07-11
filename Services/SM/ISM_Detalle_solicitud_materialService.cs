using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.SM;

namespace Web_Api_Contable.Services.SM
{
    public interface ISM_Detalle_solicitud_materialService
    {
        public List<SM_Detalle_solicitud_material> read();
        public SM_Detalle_solicitud_material getByPk(int id_solicitud, int item, int id_material);
        public int insert(SM_Detalle_solicitud_material obj);
        public void update(SM_Detalle_solicitud_material obj);
        public void delete(SM_Detalle_solicitud_material obj);
    }
}

