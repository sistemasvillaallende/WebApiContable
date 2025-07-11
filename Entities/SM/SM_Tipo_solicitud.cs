using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.SM
{
    public class SM_Tipo_solicitud : DALBase
    {
        public int id_tipo_solicitud { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }

        public SM_Tipo_solicitud()
        {
            id_tipo_solicitud = 0;
            descripcion = string.Empty;
            activo = false;
        }

        private static List<SM_Tipo_solicitud> mapeo(SqlDataReader dr)
        {
            List<SM_Tipo_solicitud> lst = new List<SM_Tipo_solicitud>();
            SM_Tipo_solicitud obj;
            if (dr.HasRows)
            {
                int id_tipo_solicitud = dr.GetOrdinal("id_tipo_solicitud");
                int descripcion = dr.GetOrdinal("descripcion");
                int activo = dr.GetOrdinal("activo");
                while (dr.Read())
                {
                    obj = new SM_Tipo_solicitud();
                    if (!dr.IsDBNull(id_tipo_solicitud)) { obj.id_tipo_solicitud = dr.GetInt32(id_tipo_solicitud); }
                    if (!dr.IsDBNull(descripcion)) { obj.descripcion = dr.GetString(descripcion); }
                    if (!dr.IsDBNull(activo)) { obj.activo = dr.GetBoolean(activo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<SM_Tipo_solicitud> read()
        {
            try
            {
                List<SM_Tipo_solicitud> lst = new List<SM_Tipo_solicitud>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM SM_Tipo_solicitud";
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

        public static SM_Tipo_solicitud getByPk(
        int id_tipo_solicitud)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM SM_Tipo_solicitud WHERE");
                sql.AppendLine("id_tipo_solicitud = @id_tipo_solicitud");
                SM_Tipo_solicitud? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tipo_solicitud", id_tipo_solicitud);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<SM_Tipo_solicitud> lst = mapeo(dr);
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

        public static int insert(SM_Tipo_solicitud obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO SM_Tipo_solicitud(");
                sql.AppendLine("id_tipo_solicitud");
                sql.AppendLine(", descripcion");
                sql.AppendLine(", activo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_tipo_solicitud");
                sql.AppendLine(", @descripcion");
                sql.AppendLine(", @activo");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tipo_solicitud", obj.id_tipo_solicitud);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(SM_Tipo_solicitud obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  SM_Tipo_solicitud SET");
                sql.AppendLine("descripcion=@descripcion");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_tipo_solicitud=@id_tipo_solicitud");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tipo_solicitud", obj.id_tipo_solicitud);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
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

        public static void delete(SM_Tipo_solicitud obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  SM_Tipo_solicitud ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_tipo_solicitud=@id_tipo_solicitud");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tipo_solicitud", obj.id_tipo_solicitud);
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

