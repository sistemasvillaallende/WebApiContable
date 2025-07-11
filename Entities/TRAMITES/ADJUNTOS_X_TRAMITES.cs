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
    public class ADJUNTOS_X_TRAMITES : DALBase
    {
        public int id { get; set; }
        public int nro_tramite { get; set; }
        public int cod_tipo_adjunto { get; set; }
        public int nro_adjunto { get; set; }
        public DateTime fecha_agregado { get; set; }
        public int cod_requisito { get; set; }
        public string observaciones { get; set; }
        public string path { get; set; }
        public int cod_oficina_adjunto { get; set; }
        public string usuario { get; set; }

        public ADJUNTOS_X_TRAMITES()
        {
            id = 0;
            nro_tramite = 0;
            cod_tipo_adjunto = 0;
            nro_adjunto = 0;
            fecha_agregado = DateTime.Now;
            cod_requisito = 0;
            observaciones = string.Empty;
            path = string.Empty;
            cod_oficina_adjunto = 0;
            usuario = string.Empty;
        }

        private static List<ADJUNTOS_X_TRAMITES> mapeo(SqlDataReader dr)
        {
            List<ADJUNTOS_X_TRAMITES> lst = new List<ADJUNTOS_X_TRAMITES>();
            ADJUNTOS_X_TRAMITES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new ADJUNTOS_X_TRAMITES();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.nro_tramite = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.cod_tipo_adjunto = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.nro_adjunto = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.fecha_agregado = dr.GetDateTime(4); }
                    if (!dr.IsDBNull(5)) { obj.cod_requisito = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.observaciones = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.path = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.cod_oficina_adjunto = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.usuario = dr.GetString(9); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<ADJUNTOS_X_TRAMITES> read()
        {
            try
            {
                List<ADJUNTOS_X_TRAMITES> lst = new List<ADJUNTOS_X_TRAMITES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM ADJUNTOS_X_TRAMITES";
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

        public static ADJUNTOS_X_TRAMITES getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM ADJUNTOS_X_TRAMITES WHERE");
                sql.AppendLine("id = @id");
                ADJUNTOS_X_TRAMITES obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ADJUNTOS_X_TRAMITES> lst = mapeo(dr);
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

        public static int insert(ADJUNTOS_X_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO ADJUNTOS_X_TRAMITES(");
                sql.AppendLine("nro_tramite");
                sql.AppendLine(", cod_tipo_adjunto");
                sql.AppendLine(", nro_adjunto");
                sql.AppendLine(", fecha_agregado");
                sql.AppendLine(", cod_requisito");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", path");
                sql.AppendLine(", cod_oficina_adjunto");
                sql.AppendLine(", usuario");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nro_tramite");
                sql.AppendLine(", @cod_tipo_adjunto");
                sql.AppendLine(", @nro_adjunto");
                sql.AppendLine(", @fecha_agregado");
                sql.AppendLine(", @cod_requisito");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @path");
                sql.AppendLine(", @cod_oficina_adjunto");
                sql.AppendLine(", @usuario");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_tramite", obj.nro_tramite);
                    cmd.Parameters.AddWithValue("@cod_tipo_adjunto", obj.cod_tipo_adjunto);
                    cmd.Parameters.AddWithValue("@nro_adjunto", obj.nro_adjunto);
                    cmd.Parameters.AddWithValue("@fecha_agregado", obj.fecha_agregado);
                    cmd.Parameters.AddWithValue("@cod_requisito", obj.cod_requisito);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@path", obj.path);
                    cmd.Parameters.AddWithValue("@cod_oficina_adjunto", obj.cod_oficina_adjunto);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(ADJUNTOS_X_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  ADJUNTOS_X_TRAMITES SET");
                sql.AppendLine("nro_tramite=@nro_tramite");
                sql.AppendLine(", cod_tipo_adjunto=@cod_tipo_adjunto");
                sql.AppendLine(", nro_adjunto=@nro_adjunto");
                sql.AppendLine(", fecha_agregado=@fecha_agregado");
                sql.AppendLine(", cod_requisito=@cod_requisito");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", path=@path");
                sql.AppendLine(", cod_oficina_adjunto=@cod_oficina_adjunto");
                sql.AppendLine(", usuario=@usuario");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_tramite", obj.nro_tramite);
                    cmd.Parameters.AddWithValue("@cod_tipo_adjunto", obj.cod_tipo_adjunto);
                    cmd.Parameters.AddWithValue("@nro_adjunto", obj.nro_adjunto);
                    cmd.Parameters.AddWithValue("@fecha_agregado", obj.fecha_agregado);
                    cmd.Parameters.AddWithValue("@cod_requisito", obj.cod_requisito);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@path", obj.path);
                    cmd.Parameters.AddWithValue("@cod_oficina_adjunto", obj.cod_oficina_adjunto);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(ADJUNTOS_X_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  ADJUNTOS_X_TRAMITES ");
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

