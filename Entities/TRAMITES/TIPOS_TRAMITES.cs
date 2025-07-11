using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.TRAMITES
{
    public class TIPOS_TRAMITES : DALBase
    {
        public int id { get; set; }
        public DateTime fecha_alta { get; set; }
        public string tramite { get; set; }
        public bool genera_deuda { get; set; }
        public decimal monto_tramite { get; set; }
        public bool activo { get; set; }

        public TIPOS_TRAMITES()
        {
            id = 0;
            fecha_alta = DateTime.Now;
            tramite = string.Empty;
            genera_deuda = false;
            monto_tramite = 0;
            activo = false;
        }

        private static List<TIPOS_TRAMITES> mapeo(SqlDataReader dr)
        {
            List<TIPOS_TRAMITES> lst = new List<TIPOS_TRAMITES>();
            TIPOS_TRAMITES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new TIPOS_TRAMITES();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.fecha_alta = dr.GetDateTime(1); }
                    if (!dr.IsDBNull(2)) { obj.tramite = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.genera_deuda = dr.GetBoolean(3); }
                    if (!dr.IsDBNull(4)) { obj.monto_tramite = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.activo = dr.GetBoolean(5); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<TIPOS_TRAMITES> read()
        {
            try
            {
                List<TIPOS_TRAMITES> lst = new List<TIPOS_TRAMITES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM TIPOS_TRAMITES";
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

        public static TIPOS_TRAMITES getByPk(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TIPOS_TRAMITES WHERE");
                sql.AppendLine("id = @id");
                TIPOS_TRAMITES obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<TIPOS_TRAMITES> lst = mapeo(dr);
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

        public static int insert(TIPOS_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TIPOS_TRAMITES(");
                sql.AppendLine("fecha_alta");
                sql.AppendLine(", tramite");
                sql.AppendLine(", genera_deuda");
                sql.AppendLine(", monto_tramite");
                sql.AppendLine(", activo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@fecha_alta");
                sql.AppendLine(", @tramite");
                sql.AppendLine(", @genera_deuda");
                sql.AppendLine(", @monto_tramite");
                sql.AppendLine(", @activo");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@tramite", obj.tramite);
                    cmd.Parameters.AddWithValue("@genera_deuda", obj.genera_deuda);
                    cmd.Parameters.AddWithValue("@monto_tramite", obj.monto_tramite);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(TIPOS_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  TIPOS_TRAMITES SET");
                sql.AppendLine("fecha_alta=@fecha_alta");
                sql.AppendLine(", tramite=@tramite");
                sql.AppendLine(", genera_deuda=@genera_deuda");
                sql.AppendLine(", monto_tramite=@monto_tramite");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@tramite", obj.tramite);
                    cmd.Parameters.AddWithValue("@genera_deuda", obj.genera_deuda);
                    cmd.Parameters.AddWithValue("@monto_tramite", obj.monto_tramite);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(TIPOS_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  TIPOS_TRAMITES ");
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

