using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.SEGURIDAD
{
    public class OFICINAS : DALBase
    {
        public int id { get; set; }
        public int cod_oficina { get; set; }
        public string oficina { get; set; }
        public bool activo { get; set; }
        public DateTime fecha_lata { get; set; }

        public OFICINAS()
        {
            id = 0;
            cod_oficina = 0;
            oficina = string.Empty;
            activo = false;
            fecha_lata = DateTime.Now;
        }

        private static List<OFICINAS> mapeo(SqlDataReader dr)
        {
            List<OFICINAS> lst = new List<OFICINAS>();
            OFICINAS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new OFICINAS();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.cod_oficina = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.oficina = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.activo = dr.GetBoolean(3); }
                    if (!dr.IsDBNull(4)) { obj.fecha_lata = dr.GetDateTime(4); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<OFICINAS> read()
        {
            try
            {
                List<OFICINAS> lst = new List<OFICINAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM OFICINAS";
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

        public static OFICINAS getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM OFICINAS WHERE");
                OFICINAS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<OFICINAS> lst = mapeo(dr);
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

        public static int insert(OFICINAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO OFICINAS(");
                sql.AppendLine("id");
                sql.AppendLine(", cod_oficina");
                sql.AppendLine(", oficina");
                sql.AppendLine(", activo");
                sql.AppendLine(", fecha_lata");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id");
                sql.AppendLine(", @cod_oficina");
                sql.AppendLine(", @oficina");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @fecha_lata");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@cod_oficina", obj.cod_oficina);
                    cmd.Parameters.AddWithValue("@oficina", obj.oficina);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@fecha_lata", obj.fecha_lata);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(OFICINAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  OFICINAS SET");
                sql.AppendLine("id=@id");
                sql.AppendLine(", cod_oficina=@cod_oficina");
                sql.AppendLine(", oficina=@oficina");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", fecha_lata=@fecha_lata");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@cod_oficina", obj.cod_oficina);
                    cmd.Parameters.AddWithValue("@oficina", obj.oficina);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@fecha_lata", obj.fecha_lata);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(OFICINAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  OFICINAS ");
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

