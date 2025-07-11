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
    public class SM_Solicitud_material : DALBase
    {
        public int id { get; set; }
        public int nro_solicitud { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public Int16 id_estado_solicitud { get; set; }
        public int id_proveedor { get; set; }
        public Int16 id_tipo_solicitud { get; set; }
        public Int16 id_prioridad_compra { get; set; }
        public int id_secretaria { get; set; }
        public int id_direccion { get; set; }
        public int id_programa { get; set; }
        public int id_oficina_origen { get; set; }
        public int id_oficina_destino { get; set; }
        public string observaciones { get; set; }
        public int id_aprobador { get; set; }
        public Int16 aprobado { get; set; }
        public Int16 rechazado { get; set; }
        public Int16 id_usuario_alta { get; set; }
        public int id_usuario_modifica { get; set; }
        public DateTime fecha_modifica { get; set; }
        public decimal total { get; set; }
        public decimal saldo { get; set; }

        public SM_Solicitud_material()
        {
            id = 0;
            nro_solicitud = 0;
            fecha_solicitud = DateTime.Now;
            id_estado_solicitud = 0;
            id_proveedor = 0;
            id_tipo_solicitud = 0;
            id_prioridad_compra = 0;
            id_secretaria = 0;
            id_direccion = 0;
            id_programa = 0;
            id_oficina_origen = 0;
            id_oficina_destino = 0;
            observaciones = string.Empty;
            id_aprobador = 0;
            aprobado = 0;
            rechazado = 0;
            id_usuario_alta = 0;
            id_usuario_modifica = 0;
            fecha_modifica = DateTime.Now;
            total = 0;
            saldo = 0;
        }

        private static List<SM_Solicitud_material> mapeo(SqlDataReader dr)
        {
            List<SM_Solicitud_material> lst = new List<SM_Solicitud_material>();
            SM_Solicitud_material obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int nro_solicitud = dr.GetOrdinal("nro_solicitud");
                int fecha_solicitud = dr.GetOrdinal("fecha_solicitud");
                int id_estado_solicitud = dr.GetOrdinal("id_estado_solicitud");
                int id_proveedor = dr.GetOrdinal("id_proveedor");
                int id_tipo_solicitud = dr.GetOrdinal("id_tipo_solicitud");
                int id_prioridad_compra = dr.GetOrdinal("id_prioridad_compra");
                int id_secretaria = dr.GetOrdinal("id_secretaria");
                int id_direccion = dr.GetOrdinal("id_direccion");
                int id_programa = dr.GetOrdinal("id_programa");
                int id_oficina_origen = dr.GetOrdinal("id_oficina_origen");
                int id_oficina_destino = dr.GetOrdinal("id_oficina_destino");
                int observaciones = dr.GetOrdinal("observaciones");
                int id_aprobador = dr.GetOrdinal("id_aprobador");
                int aprobado = dr.GetOrdinal("aprobado");
                int rechazado = dr.GetOrdinal("rechazado");
                int id_usuario_alta = dr.GetOrdinal("id_usuario_alta");
                int id_usuario_modifica = dr.GetOrdinal("id_usuario_modifica");
                int fecha_modifica = dr.GetOrdinal("fecha_modifica");
                int total = dr.GetOrdinal("total");
                int saldo = dr.GetOrdinal("saldo");
                while (dr.Read())
                {
                    obj = new SM_Solicitud_material();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(nro_solicitud)) { obj.nro_solicitud = dr.GetInt32(nro_solicitud); }
                    if (!dr.IsDBNull(fecha_solicitud)) { obj.fecha_solicitud = dr.GetDateTime(fecha_solicitud); }
                    if (!dr.IsDBNull(id_estado_solicitud)) { obj.id_estado_solicitud = dr.GetInt16(id_estado_solicitud); }
                    if (!dr.IsDBNull(id_proveedor)) { obj.id_proveedor = dr.GetInt32(id_proveedor); }
                    if (!dr.IsDBNull(id_tipo_solicitud)) { obj.id_tipo_solicitud = dr.GetInt16(id_tipo_solicitud); }
                    if (!dr.IsDBNull(id_prioridad_compra)) { obj.id_prioridad_compra = dr.GetInt16(id_prioridad_compra); }
                    if (!dr.IsDBNull(id_secretaria)) { obj.id_secretaria = dr.GetInt32(id_secretaria); }
                    if (!dr.IsDBNull(id_direccion)) { obj.id_direccion = dr.GetInt32(id_direccion); }
                    if (!dr.IsDBNull(id_programa)) { obj.id_programa = dr.GetInt32(id_programa); }
                    if (!dr.IsDBNull(id_oficina_origen)) { obj.id_oficina_origen = dr.GetInt32(id_oficina_origen); }
                    if (!dr.IsDBNull(id_oficina_destino)) { obj.id_oficina_destino = dr.GetInt32(id_oficina_destino); }
                    if (!dr.IsDBNull(observaciones)) { obj.observaciones = dr.GetString(observaciones); }
                    if (!dr.IsDBNull(id_aprobador)) { obj.id_aprobador = dr.GetInt32(id_aprobador); }
                    if (!dr.IsDBNull(aprobado)) { obj.aprobado = dr.GetInt16(aprobado); }
                    if (!dr.IsDBNull(rechazado)) { obj.rechazado = dr.GetInt16(rechazado); }
                    if (!dr.IsDBNull(id_usuario_alta)) { obj.id_usuario_alta = dr.GetInt16(id_usuario_alta); }
                    if (!dr.IsDBNull(id_usuario_modifica)) { obj.id_usuario_modifica = dr.GetInt32(id_usuario_modifica); }
                    if (!dr.IsDBNull(fecha_modifica)) { obj.fecha_modifica = dr.GetDateTime(fecha_modifica); }
                    if (!dr.IsDBNull(total)) { obj.total = dr.GetDecimal(total); }
                    if (!dr.IsDBNull(saldo)) { obj.saldo = dr.GetDecimal(saldo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<SM_Solicitud_material> read()
        {
            try
            {
                List<SM_Solicitud_material> lst = new List<SM_Solicitud_material>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM SM_Solicitud_material";
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

        public static SM_Solicitud_material getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Sm_solicitud_material WHERE");
                sql.AppendLine("id = @id");
                SM_Solicitud_material? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<SM_Solicitud_material> lst = mapeo(dr);
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

        public static int insert(SM_Solicitud_material obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO SM_Solicitud_material(");
                sql.AppendLine("id");
                sql.AppendLine(", nro_solicitud");
                sql.AppendLine(", fecha_solicitud");
                sql.AppendLine(", id_estado_solicitud");
                sql.AppendLine(", id_proveedor");
                sql.AppendLine(", id_tipo_solicitud");
                sql.AppendLine(", id_prioridad_compra");
                sql.AppendLine(", id_secretaria");
                sql.AppendLine(", id_direccion");
                sql.AppendLine(", id_programa");
                sql.AppendLine(", id_oficina_origen");
                sql.AppendLine(", id_oficina_destino");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", id_aprobador");
                sql.AppendLine(", aprobado");
                sql.AppendLine(", rechazado");
                sql.AppendLine(", id_usuario_alta");
                sql.AppendLine(", id_usuario_modifica");
                sql.AppendLine(", fecha_modifica");
                sql.AppendLine(", total");
                sql.AppendLine(", saldo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id");
                sql.AppendLine(", @nro_solicitud");
                sql.AppendLine(", @fecha_solicitud");
                sql.AppendLine(", @id_estado_solicitud");
                sql.AppendLine(", @id_proveedor");
                sql.AppendLine(", @id_tipo_solicitud");
                sql.AppendLine(", @id_prioridad_compra");
                sql.AppendLine(", @id_secretaria");
                sql.AppendLine(", @id_direccion");
                sql.AppendLine(", @id_programa");
                sql.AppendLine(", @id_oficina_origen");
                sql.AppendLine(", @id_oficina_destino");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @id_aprobador");
                sql.AppendLine(", @aprobado");
                sql.AppendLine(", @rechazado");
                sql.AppendLine(", @id_usuario_alta");
                sql.AppendLine(", @id_usuario_modifica");
                sql.AppendLine(", @fecha_modifica");
                sql.AppendLine(", @total");
                sql.AppendLine(", @saldo");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@nro_solicitud", obj.nro_solicitud);
                    cmd.Parameters.AddWithValue("@fecha_solicitud", obj.fecha_solicitud);
                    cmd.Parameters.AddWithValue("@id_estado_solicitud", obj.id_estado_solicitud);
                    cmd.Parameters.AddWithValue("@id_proveedor", obj.id_proveedor);
                    cmd.Parameters.AddWithValue("@id_tipo_solicitud", obj.id_tipo_solicitud);
                    cmd.Parameters.AddWithValue("@id_prioridad_compra", obj.id_prioridad_compra);
                    cmd.Parameters.AddWithValue("@id_secretaria", obj.id_secretaria);
                    cmd.Parameters.AddWithValue("@id_direccion", obj.id_direccion);
                    cmd.Parameters.AddWithValue("@id_programa", obj.id_programa);
                    cmd.Parameters.AddWithValue("@id_oficina_origen", obj.id_oficina_origen);
                    cmd.Parameters.AddWithValue("@id_oficina_destino", obj.id_oficina_destino);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@id_aprobador", obj.id_aprobador);
                    cmd.Parameters.AddWithValue("@aprobado", obj.aprobado);
                    cmd.Parameters.AddWithValue("@rechazado", obj.rechazado);
                    cmd.Parameters.AddWithValue("@id_usuario_alta", obj.id_usuario_alta);
                    cmd.Parameters.AddWithValue("@id_usuario_modifica", obj.id_usuario_modifica);
                    cmd.Parameters.AddWithValue("@fecha_modifica", obj.fecha_modifica);
                    cmd.Parameters.AddWithValue("@total", obj.total);
                    cmd.Parameters.AddWithValue("@saldo", obj.saldo);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(SM_Solicitud_material obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  SM_Solicitud_material SET");
                sql.AppendLine("nro_solicitud=@nro_solicitud");
                sql.AppendLine(", fecha_solicitud=@fecha_solicitud");
                sql.AppendLine(", id_estado_solicitud=@id_estado_solicitud");
                sql.AppendLine(", id_proveedor=@id_proveedor");
                sql.AppendLine(", id_tipo_solicitud=@id_tipo_solicitud");
                sql.AppendLine(", id_prioridad_compra=@id_prioridad_compra");
                sql.AppendLine(", id_secretaria=@id_secretaria");
                sql.AppendLine(", id_direccion=@id_direccion");
                sql.AppendLine(", id_programa=@id_programa");
                sql.AppendLine(", id_oficina_origen=@id_oficina_origen");
                sql.AppendLine(", id_oficina_destino=@id_oficina_destino");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", id_aprobador=@id_aprobador");
                sql.AppendLine(", aprobado=@aprobado");
                sql.AppendLine(", rechazado=@rechazado");
                sql.AppendLine(", id_usuario_alta=@id_usuario_alta");
                sql.AppendLine(", id_usuario_modifica=@id_usuario_modifica");
                sql.AppendLine(", fecha_modifica=@fecha_modifica");
                sql.AppendLine(", total=@total");
                sql.AppendLine(", saldo=@saldo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@nro_solicitud", obj.nro_solicitud);
                    cmd.Parameters.AddWithValue("@fecha_solicitud", obj.fecha_solicitud);
                    cmd.Parameters.AddWithValue("@id_estado_solicitud", obj.id_estado_solicitud);
                    cmd.Parameters.AddWithValue("@id_proveedor", obj.id_proveedor);
                    cmd.Parameters.AddWithValue("@id_tipo_solicitud", obj.id_tipo_solicitud);
                    cmd.Parameters.AddWithValue("@id_prioridad_compra", obj.id_prioridad_compra);
                    cmd.Parameters.AddWithValue("@id_secretaria", obj.id_secretaria);
                    cmd.Parameters.AddWithValue("@id_direccion", obj.id_direccion);
                    cmd.Parameters.AddWithValue("@id_programa", obj.id_programa);
                    cmd.Parameters.AddWithValue("@id_oficina_origen", obj.id_oficina_origen);
                    cmd.Parameters.AddWithValue("@id_oficina_destino", obj.id_oficina_destino);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@id_aprobador", obj.id_aprobador);
                    cmd.Parameters.AddWithValue("@aprobado", obj.aprobado);
                    cmd.Parameters.AddWithValue("@rechazado", obj.rechazado);
                    cmd.Parameters.AddWithValue("@id_usuario_alta", obj.id_usuario_alta);
                    cmd.Parameters.AddWithValue("@id_usuario_modifica", obj.id_usuario_modifica);
                    cmd.Parameters.AddWithValue("@fecha_modifica", obj.fecha_modifica);
                    cmd.Parameters.AddWithValue("@total", obj.total);
                    cmd.Parameters.AddWithValue("@saldo", obj.saldo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(SM_Solicitud_material obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  SM_Solicitud_material ");
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
        /// <summary>
        /// REGION DE DESPLEGABLES
        /// </summary>
        /// <returns></returns>
        public static List<Combo> Prioridad()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM SM_Prioridad";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = Convert.ToString(dr.GetString(1)); }
                            //if (!dr.IsDBNull(2)) { obj.campo_enlace = string.Empty; }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Combo> Estado_solicitud()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM SM_Estados_solicitud";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = Convert.ToString(dr.GetString(1)); }
                            //if (!dr.IsDBNull(2)) { obj.campo_enlace = string.Empty; }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Combo> Tipo_solicitud()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM SM_Tipo_solicitud";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = Convert.ToString(dr.GetString(1)); }
                            //if (!dr.IsDBNull(2)) { obj.campo_enlace = string.Empty; }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

