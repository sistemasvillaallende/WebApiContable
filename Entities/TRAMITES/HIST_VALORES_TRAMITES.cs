using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.TRAMITES
{
    public class HIST_VALORES_TRAMITES : DALBase
    {
        public int id { get; set; }
        public int id_tramite { get; set; }
        public DateTime fecha_alta { get; set; }
        public decimal monto_tramite { get; set; }

        public HIST_VALORES_TRAMITES()
        {
            id = 0;
            id_tramite = 0;
            fecha_alta = DateTime.Now;
            monto_tramite = 0;
        }

        private static List<HIST_VALORES_TRAMITES> mapeo(SqlDataReader dr)
        {
            List<HIST_VALORES_TRAMITES> lst = new List<HIST_VALORES_TRAMITES>();
            HIST_VALORES_TRAMITES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new HIST_VALORES_TRAMITES();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.id_tramite = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.fecha_alta = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.monto_tramite = dr.GetDecimal(3); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<HIST_VALORES_TRAMITES> read()
        {
            try
            {
                List<HIST_VALORES_TRAMITES> lst = new List<HIST_VALORES_TRAMITES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM HIST_VALORES_TRAMITES";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static HIST_VALORES_TRAMITES getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM HIST_VALORES_TRAMITES WHERE");
                HIST_VALORES_TRAMITES obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<HIST_VALORES_TRAMITES> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(HIST_VALORES_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO HIST_VALORES_TRAMITES(");
                sql.AppendLine("id");
                sql.AppendLine(", id_tramite");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(", monto_tramite");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id");
                sql.AppendLine(", @id_tramite");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(", @monto_tramite");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@id_tramite", obj.id_tramite);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@monto_tramite", obj.monto_tramite);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(HIST_VALORES_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  HIST_VALORES_TRAMITES SET");
                sql.AppendLine("id=@id");
                sql.AppendLine(", id_tramite=@id_tramite");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine(", monto_tramite=@monto_tramite");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@id_tramite", obj.id_tramite);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@monto_tramite", obj.monto_tramite);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(HIST_VALORES_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  HIST_VALORES_TRAMITES ");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

