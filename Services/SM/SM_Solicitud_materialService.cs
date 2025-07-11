using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Web_Api_Contable.Entities.GENERAL;
using Web_Api_Contable.Entities.SM;

namespace Web_Api_Contable.Services.SM
{
    public class SM_Solicitud_materialService : ISM_Solicitud_materialService
    {
        public SM_Solicitud_material getByPk(int id)
        {
            try
            {
                return SM_Solicitud_material.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SM_Solicitud_material> read()
        {
            try
            {
                return SM_Solicitud_material.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(SM_Solicitud_material obj)
        {
            try
            {
                return SM_Solicitud_material.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(SM_Solicitud_material obj)
        {
            try
            {
                SM_Solicitud_material.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(SM_Solicitud_material obj)
        {
            try
            {
                SM_Solicitud_material.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ////////////////////
        ///
        public List<Combo> Tipo_solicitud()
        {
            try
            {
                return SM_Solicitud_material.Tipo_solicitud();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Combo> Estado_solicitud()
        {
            try
            {
                return SM_Solicitud_material.Estado_solicitud();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Combo> Prioridad()
        {
            try
            {
                return SM_Solicitud_material.Prioridad();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

