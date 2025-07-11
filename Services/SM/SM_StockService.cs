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
    public class SM_StockService : ISM_StockService
    {
        public SM_Stock getByPk(int cod_material)
        {
            try
            {
                return SM_Stock.getByPk(cod_material);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SM_Stock> read()
        {
            try
            {
                return SM_Stock.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(SM_Stock obj)
        {
            try
            {
                return SM_Stock.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(SM_Stock obj)
        {
            try
            {
                SM_Stock.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(SM_Stock obj)
        {
            try
            {
                SM_Stock.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

