using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.GENERAL;
using Web_Api_Contable.Entities.SM;

namespace Web_Api_Contable.Services.SM
{
    public interface ISM_Solicitud_materialService
    {
        public List<SM_Solicitud_material> read();
        public SM_Solicitud_material getByPk(int id);
        public int insert(SM_Solicitud_material obj);
        public void update(SM_Solicitud_material obj);
        public void delete(SM_Solicitud_material obj);
        public List<Combo> Estado_solicitud();
        public List<Combo> Tipo_solicitud();
        public List<Combo> Prioridad();
    }
}

