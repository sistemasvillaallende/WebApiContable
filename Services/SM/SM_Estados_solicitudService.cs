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
    public class SM_Estados_solicitudService : ISM_Estados_solicitudService
    {
        public SM_Estados_solicitud getByPk(int id_estado)
        {
            try
            {
                return SM_Estados_solicitud.getByPk(id_estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SM_Estados_solicitud> read()
        {
            try
            {
                return SM_Estados_solicitud.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(SM_Estados_solicitud obj)
        {
            try
            {
                return SM_Estados_solicitud.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(SM_Estados_solicitud obj)
        {
            try
            {
                SM_Estados_solicitud.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(SM_Estados_solicitud obj)
        {
            try
            {
                SM_Estados_solicitud.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

