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
    public class ESTADOS_TRAMITES : DALBase
    {
        public int id { get; set; }
        public string estado_tramite { get; set; }
        public DateTime fecha_alta { get; set; }

        public ESTADOS_TRAMITES()
        {
            id = 0;
            estado_tramite = string.Empty;
            fecha_alta = DateTime.Now;
        }

        private static List<ESTADOS_TRAMITES> mapeo(SqlDataReader dr)
        {
            List<ESTADOS_TRAMITES> lst = new List<ESTADOS_TRAMITES>();
            ESTADOS_TRAMITES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new ESTADOS_TRAMITES();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.estado_tramite = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.fecha_alta = dr.GetDateTime(2); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<ESTADOS_TRAMITES> read()
        {
            try
            {
                List<ESTADOS_TRAMITES> lst = new List<ESTADOS_TRAMITES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM ESTADOS_TRAMITES";
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

        public static ESTADOS_TRAMITES getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM ESTADOS_TRAMITES WHERE");
                sql.AppendLine("id = @id");
                ESTADOS_TRAMITES obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ESTADOS_TRAMITES> lst = mapeo(dr);
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

        public static int insert(ESTADOS_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO ESTADOS_TRAMITES(");
                sql.AppendLine("estado_tramite");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@estado_tramite");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@estado_tramite", obj.estado_tramite);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(ESTADOS_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  ESTADOS_TRAMITES SET");
                sql.AppendLine("estado_tramite=@estado_tramite");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@estado_tramite", obj.estado_tramite);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(ESTADOS_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  ESTADOS_TRAMITES ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
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

