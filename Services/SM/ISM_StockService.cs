using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.SM;

namespace Web_Api_Contable.Services.SM
{
    public interface ISM_StockService
    {
        public List<SM_Stock> read();
        public SM_Stock getByPk(int cod_material);
        public int insert(SM_Stock obj);
        public void update(SM_Stock obj);
        public void delete(SM_Stock obj);
    }
}

