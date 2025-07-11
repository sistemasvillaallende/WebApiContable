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
    public class MOVIMIENTOS_TRAMITES : DALBase
    {
        public int id { get; set; }
        public int id_tramite { get; set; }
        public int id_estado_tramite { get; set; }
        public int nro_paso { get; set; }
        public int cod_oficina_origen { get; set; }
        public int cod_oficina_destino { get; set; }
        public DateTime fecha_pase { get; set; }
        public DateTime fecha_recepcion { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public string observaciones { get; set; }
        public bool atendido { get; set; }
        public string usuario { get; set; }
        public int dias_sin_resolver { get; set; }
        public int fojas { get; set; }

        public MOVIMIENTOS_TRAMITES()
        {
            id = 0;
            id_tramite = 0;
            id_estado_tramite = 0;
            nro_paso = 0;
            cod_oficina_origen = 0;
            cod_oficina_destino = 0;
            fecha_pase = DateTime.Now;
            fecha_recepcion = DateTime.Now;
            fecha_vencimiento = DateTime.Now;
            observaciones = string.Empty;
            atendido = false;
            usuario = string.Empty;
            dias_sin_resolver = 0;
            fojas = 0;
        }

        private static List<MOVIMIENTOS_TRAMITES> mapeo(SqlDataReader dr)
        {
            List<MOVIMIENTOS_TRAMITES> lst = new List<MOVIMIENTOS_TRAMITES>();
            MOVIMIENTOS_TRAMITES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new MOVIMIENTOS_TRAMITES();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.id_tramite = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.id_estado_tramite = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.nro_paso = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.cod_oficina_origen = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.cod_oficina_destino = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.fecha_pase = dr.GetDateTime(6); }
                    if (!dr.IsDBNull(7)) { obj.fecha_recepcion = dr.GetDateTime(7); }
                    if (!dr.IsDBNull(8)) { obj.fecha_vencimiento = dr.GetDateTime(8); }
                    if (!dr.IsDBNull(9)) { obj.observaciones = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.atendido = dr.GetBoolean(10); }
                    if (!dr.IsDBNull(11)) { obj.usuario = dr.GetString(11); }
                    if (!dr.IsDBNull(12)) { obj.dias_sin_resolver = dr.GetInt32(12); }
                    if (!dr.IsDBNull(13)) { obj.fojas = dr.GetInt32(13); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<MOVIMIENTOS_TRAMITES> read()
        {
            try
            {
                List<MOVIMIENTOS_TRAMITES> lst = new List<MOVIMIENTOS_TRAMITES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM MOVIMIENTOS_TRAMITES";
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

        public static MOVIMIENTOS_TRAMITES getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM MOVIMIENTOS_TRAMITES WHERE");
                sql.AppendLine("id = @id");
                MOVIMIENTOS_TRAMITES? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<MOVIMIENTOS_TRAMITES> lst = mapeo(dr);
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

        public static int insert(MOVIMIENTOS_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new();
                sql.AppendLine("INSERT INTO MOVIMIENTOS_TRAMITES(");
                sql.AppendLine("id_tramite");
                sql.AppendLine(", id_estado_tramite");
                sql.AppendLine(", nro_paso");
                sql.AppendLine(", cod_oficina_origen");
                sql.AppendLine(", cod_oficina_destino");
                sql.AppendLine(", fecha_pase");
                sql.AppendLine(", fecha_recepcion");
                sql.AppendLine(", fecha_vencimiento");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", atendido");
                sql.AppendLine(", usuario");
                sql.AppendLine(", dias_sin_resolver");
                sql.AppendLine(", fojas");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_tramite");
                sql.AppendLine(", @id_estado_tramite");
                sql.AppendLine(", @nro_paso");
                sql.AppendLine(", @cod_oficina_origen");
                sql.AppendLine(", @cod_oficina_destino");
                sql.AppendLine(", @fecha_pase");
                sql.AppendLine(", @fecha_recepcion");
                sql.AppendLine(", @fecha_vencimiento");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @atendido");
                sql.AppendLine(", @usuario");
                sql.AppendLine(", @dias_sin_resolver");
                sql.AppendLine(", @fojas");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tramite", obj.id_tramite);
                    cmd.Parameters.AddWithValue("@id_estado_tramite", obj.id_estado_tramite);
                    cmd.Parameters.AddWithValue("@nro_paso", obj.nro_paso);
                    cmd.Parameters.AddWithValue("@cod_oficina_origen", obj.cod_oficina_origen);
                    cmd.Parameters.AddWithValue("@cod_oficina_destino", obj.cod_oficina_destino);
                    cmd.Parameters.AddWithValue("@fecha_pase", obj.fecha_pase);
                    cmd.Parameters.AddWithValue("@fecha_recepcion", obj.fecha_recepcion);
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", obj.fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@atendido", obj.atendido);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@dias_sin_resolver", obj.dias_sin_resolver);
                    cmd.Parameters.AddWithValue("@fojas", obj.fojas);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(MOVIMIENTOS_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  MOVIMIENTOS_TRAMITES SET");
                sql.AppendLine("id_tramite=@id_tramite");
                sql.AppendLine(", id_estado_tramite=@id_estado_tramite");
                sql.AppendLine(", nro_paso=@nro_paso");
                sql.AppendLine(", cod_oficina_origen=@cod_oficina_origen");
                sql.AppendLine(", cod_oficina_destino=@cod_oficina_destino");
                sql.AppendLine(", fecha_pase=@fecha_pase");
                sql.AppendLine(", fecha_recepcion=@fecha_recepcion");
                sql.AppendLine(", fecha_vencimiento=@fecha_vencimiento");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", atendido=@atendido");
                sql.AppendLine(", usuario=@usuario");
                sql.AppendLine(", dias_sin_resolver=@dias_sin_resolver");
                sql.AppendLine(", fojas=@fojas");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tramite", obj.id_tramite);
                    cmd.Parameters.AddWithValue("@id_estado_tramite", obj.id_estado_tramite);
                    cmd.Parameters.AddWithValue("@nro_paso", obj.nro_paso);
                    cmd.Parameters.AddWithValue("@cod_oficina_origen", obj.cod_oficina_origen);
                    cmd.Parameters.AddWithValue("@cod_oficina_destino", obj.cod_oficina_destino);
                    cmd.Parameters.AddWithValue("@fecha_pase", obj.fecha_pase);
                    cmd.Parameters.AddWithValue("@fecha_recepcion", obj.fecha_recepcion);
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", obj.fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@atendido", obj.atendido);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@dias_sin_resolver", obj.dias_sin_resolver);
                    cmd.Parameters.AddWithValue("@fojas", obj.fojas);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(MOVIMIENTOS_TRAMITES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  MOVIMIENTOS_TRAMITES ");
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

