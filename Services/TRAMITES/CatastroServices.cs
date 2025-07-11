using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.TRAMITES;

namespace Web_Api_Contable.Services.TRAMITES
{
    public interface ICatastroServices
    {
        public List<CATASTRO> read();
        public CATASTRO getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h);
    }
    public class CatastroServices : ICatastroServices
    {
        public List<CATASTRO> read()
        {
            try
            {
                return CATASTRO.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CATASTRO getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                return CATASTRO.getByPk(circunscripcion, seccion, manzana, parcela, p_h);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
