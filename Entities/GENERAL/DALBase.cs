using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_Contable.Entities.GENERAL
{
    public class DALBase
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection("Data Source=10.0.0.23; Initial Catalog=SIIMVA;User ID=general");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SqlConnection GetConnectionSIIMVA()
        {
            try
            {
                return new SqlConnection("Data Source=10.0.0.23;Initial Catalog=SIIMVA;User ID=general;MultipleActiveResultSets=True");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlConnection GetConnection(string strDB)
        {
            try
            {
                return new SqlConnection("Data Source=10.0.0.23;Initial Catalog=" + strDB + ";User ID=general");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}