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
    public class REQUISITOS_TRAMITES : DALBase
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_alta { get; set; }

        public REQUISITOS_TRAMITES()
        {
            id = 0;
            descripcion = string.Empty;
            fecha_alta = DateTime.Now;
        }

        private static List<REQUISITOS_TRAMITES> mapeo(SqlDataReader dr)
        {
            List<REQUISITOS_TRAMITES> lst = new List<REQUISITOS_TRAMITES>();
            REQUISITOS_TRAMITES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new REQUISITOS_TRAMITES();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.descripcion = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.fecha_alta = dr.GetDateTime(2); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<REQUISITOS_TRAMITES> read()
        {
            try
            {
                List<REQUISITOS_TRAMITES> lst = new List<REQUISITOS_TRAMITES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM REQUISITOS_TRAMITES";
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

        public static REQUISITOS_TRAMITES getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM REQUISITOS_TRAMITES WHERE");
                sql.AppendLine("id = @id");
                REQUISITOS_TRAMITES obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<REQUISITOS_TRAMITES> lst = mapeo(dr);
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

        public static int insert(REQUISITOS_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO REQUISITOS_TRAMITES(");
                sql.AppendLine("descripcion");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@descripcion");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
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

        public static void update(REQUISITOS_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  REQUISITOS_TRAMITES SET");
                sql.AppendLine("descripcion=@descripcion");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
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

        public static void delete(REQUISITOS_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  REQUISITOS_TRAMITES ");
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

