using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Web_Api_Contable.Entities.SM;

namespace Web_Api_Contable.Services.SM
{
    public class SM_Movimientos_solicitud_materialService : ISM_Movimientos_solicitud_materialService
    {
        public SM_Movimientos_solicitud_material getByPk(int id_solicitud, int nro_paso)
        {
            try
            {
                return SM_Movimientos_solicitud_material.getByPk(id_solicitud, nro_paso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SM_Movimientos_solicitud_material> read()
        {
            try
            {
                return SM_Movimientos_solicitud_material.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(SM_Movimientos_solicitud_material obj)
        {
            try
            {
                return SM_Movimientos_solicitud_material.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(SM_Movimientos_solicitud_material obj)
        {
            try
            {
                SM_Movimientos_solicitud_material.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(SM_Movimientos_solicitud_material obj)
        {
            try
            {
                SM_Movimientos_solicitud_material.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

