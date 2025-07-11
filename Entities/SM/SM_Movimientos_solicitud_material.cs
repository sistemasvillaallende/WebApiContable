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
    public class SM_Movimientos_solicitud_material : DALBase
    {
        public int id_solicitud { get; set; }
        public int nro_paso { get; set; }
        public int id_estado_solicitud { get; set; }
        public DateTime fecha_movimiento { get; set; }
        public string observaciones { get; set; }
        public string usuario_movimiento { get; set; }
        public int nro_envio { get; set; }

        public SM_Movimientos_solicitud_material()
        {
            id_solicitud = 0;
            nro_paso = 0;
            id_estado_solicitud = 0;
            fecha_movimiento = DateTime.Now;
            observaciones = string.Empty;
            usuario_movimiento = string.Empty;
            nro_envio = 0;
        }

        private static List<SM_Movimientos_solicitud_material> mapeo(SqlDataReader dr)
        {
            List<SM_Movimientos_solicitud_material> lst = new List<SM_Movimientos_solicitud_material>();
            SM_Movimientos_solicitud_material obj;
            if (dr.HasRows)
            {
                int id_solicitud = dr.GetOrdinal("id_solicitud");
                int nro_paso = dr.GetOrdinal("nro_paso");
                int id_estado_solicitud = dr.GetOrdinal("id_estado_solicitud");
                int fecha_movimiento = dr.GetOrdinal("fecha_movimiento");
                int observaciones = dr.GetOrdinal("observaciones");
                int usuario_movimiento = dr.GetOrdinal("usuario_movimiento");
                int nro_envio = dr.GetOrdinal("nro_envio");
                while (dr.Read())
                {
                    obj = new SM_Movimientos_solicitud_material();
                    if (!dr.IsDBNull(id_solicitud)) { obj.id_solicitud = dr.GetInt32(id_solicitud); }
                    if (!dr.IsDBNull(nro_paso)) { obj.nro_paso = dr.GetInt32(nro_paso); }
                    if (!dr.IsDBNull(id_estado_solicitud)) { obj.id_estado_solicitud = dr.GetInt32(id_estado_solicitud); }
                    if (!dr.IsDBNull(fecha_movimiento)) { obj.fecha_movimiento = dr.GetDateTime(fecha_movimiento); }
                    if (!dr.IsDBNull(observaciones)) { obj.observaciones = dr.GetString(observaciones); }
                    if (!dr.IsDBNull(usuario_movimiento)) { obj.usuario_movimiento = dr.GetString(usuario_movimiento); }
                    if (!dr.IsDBNull(nro_envio)) { obj.nro_envio = dr.GetInt32(nro_envio); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<SM_Movimientos_solicitud_material> read()
        {
            try
            {
                List<SM_Movimientos_solicitud_material> lst = new List<SM_Movimientos_solicitud_material>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM SM_Movimientos_solicitud_material";
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

        public static SM_Movimientos_solicitud_material getByPk(
        int id_solicitud, int nro_paso)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM SM_Movimientos_solicitud_material WHERE");
                sql.AppendLine("id_solicitud = @id_solicitud");
                sql.AppendLine("AND nro_paso = @nro_paso");
                SM_Movimientos_solicitud_material? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@nro_paso", nro_paso);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<SM_Movimientos_solicitud_material> lst = mapeo(dr);
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

        public static int insert(SM_Movimientos_solicitud_material obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO SM_Movimientos_solicitud_material(");
                sql.AppendLine("id_solicitud");
                sql.AppendLine(", nro_paso");
                sql.AppendLine(", id_estado_solicitud");
                sql.AppendLine(", fecha_movimiento");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", usuario_movimiento");
                sql.AppendLine(", nro_envio");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_solicitud");
                sql.AppendLine(", @nro_paso");
                sql.AppendLine(", @id_estado_solicitud");
                sql.AppendLine(", @fecha_movimiento");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @usuario_movimiento");
                sql.AppendLine(", @nro_envio");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_solicitud", obj.id_solicitud);
                    cmd.Parameters.AddWithValue("@nro_paso", obj.nro_paso);
                    cmd.Parameters.AddWithValue("@id_estado_solicitud", obj.id_estado_solicitud);
                    cmd.Parameters.AddWithValue("@fecha_movimiento", obj.fecha_movimiento);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@usuario_movimiento", obj.usuario_movimiento);
                    cmd.Parameters.AddWithValue("@nro_envio", obj.nro_envio);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(SM_Movimientos_solicitud_material obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  SM_Movimientos_solicitud_material SET");
                sql.AppendLine("id_estado_solicitud=@id_estado_solicitud");
                sql.AppendLine(", fecha_movimiento=@fecha_movimiento");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", usuario_movimiento=@usuario_movimiento");
                sql.AppendLine(", nro_envio=@nro_envio");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_solicitud=@id_solicitud");
                sql.AppendLine("AND nro_paso=@nro_paso");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_solicitud", obj.id_solicitud);
                    cmd.Parameters.AddWithValue("@nro_paso", obj.nro_paso);
                    cmd.Parameters.AddWithValue("@id_estado_solicitud", obj.id_estado_solicitud);
                    cmd.Parameters.AddWithValue("@fecha_movimiento", obj.fecha_movimiento);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@usuario_movimiento", obj.usuario_movimiento);
                    cmd.Parameters.AddWithValue("@nro_envio", obj.nro_envio);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(SM_Movimientos_solicitud_material obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  SM_Movimientos_solicitud_material ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_solicitud=@id_solicitud");
                sql.AppendLine("AND nro_paso=@nro_paso");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_solicitud", obj.id_solicitud);
                    cmd.Parameters.AddWithValue("@nro_paso", obj.nro_paso);
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

