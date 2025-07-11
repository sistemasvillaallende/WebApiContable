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
    public class SM_Estados_solicitud : DALBase
    {
        public int id_estado { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }

        public SM_Estados_solicitud()
        {
            id_estado = 0;
            descripcion = string.Empty;
            activo = false;
        }

        private static List<SM_Estados_solicitud> mapeo(SqlDataReader dr)
        {
            List<SM_Estados_solicitud> lst = new List<SM_Estados_solicitud>();
            SM_Estados_solicitud obj;
            if (dr.HasRows)
            {
                int id_estado = dr.GetOrdinal("id_estado");
                int descripcion = dr.GetOrdinal("descripcion");
                int activo = dr.GetOrdinal("activo");
                while (dr.Read())
                {
                    obj = new SM_Estados_solicitud();
                    if (!dr.IsDBNull(id_estado)) { obj.id_estado = dr.GetInt32(id_estado); }
                    if (!dr.IsDBNull(descripcion)) { obj.descripcion = dr.GetString(descripcion); }
                    if (!dr.IsDBNull(activo)) { obj.activo = dr.GetBoolean(activo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<SM_Estados_solicitud> read()
        {
            try
            {
                List<SM_Estados_solicitud> lst = new List<SM_Estados_solicitud>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Sm_estados_solicitud";
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

        public static SM_Estados_solicitud getByPk(
        int id_estado)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Sm_estados_solicitud WHERE");
                sql.AppendLine("id_estado = @id_estado");
                SM_Estados_solicitud obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_estado", id_estado);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<SM_Estados_solicitud> lst = mapeo(dr);
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

        public static int insert(SM_Estados_solicitud obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Sm_estados_solicitud(");
                sql.AppendLine("id_estado");
                sql.AppendLine(", descripcion");
                sql.AppendLine(", activo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_estado");
                sql.AppendLine(", @descripcion");
                sql.AppendLine(", @activo");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_estado", obj.id_estado);
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

        public static void update(SM_Estados_solicitud obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Sm_estados_solicitud SET");
                sql.AppendLine("descripcion=@descripcion");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_estado=@id_estado");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_estado", obj.id_estado);
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

        public static void delete(SM_Estados_solicitud obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Sm_estados_solicitud ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_estado=@id_estado");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_estado", obj.id_estado);
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

