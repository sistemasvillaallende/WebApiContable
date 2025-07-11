using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.TRAMITES
{
    public class TRAMITE : DALBase
    {
        public int id { get; set; }
        public string nro_tramite { get; set; }
        public DateTime fecha_alta { get; set; }
        public int nro_expediente { get; set; }
        public int anio { get; set; }
        public int id_tipo_tramite { get; set; }
        public int id_profesional { get; set; }
        public string cuit_vecino { get; set; }
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public string manzana_oficial { get; set; }
        public string parcela_oficial { get; set; }
        public string nomenclatura_provincial { get; set; }
        public int cod_calle_pf { get; set; }
        public string calle_pf { get; set; }
        public string nro_pf { get; set; }
        public string piso_pf { get; set; }
        public string dpto_pf { get; set; }
        public int cod_barrio_pf { get; set; }
        public string barrio_pf { get; set; }
        public int id_tipologia { get; set; }
        public float superficie { get; set; }
        public decimal presupuesto_destinado { get; set; }
        public string otros_datos { get; set; }
        public int cod_oficina_origen { get; set; }
        public int cod_oficina_destino { get; set; }
        public int id_estado_tramite { get; set; }
        public int fojas { get; set; }
        public string usuario { get; set; }
        public bool atendido { get; set; }
        public DateTime fecha_atendido { get; set; }
        public bool anulado { get; set; }
        public DateTime fecha_anulado { get; set; }
        public DateTime fecha_fin_tramite { get; set; }
        public string observaciones { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string dir_google { get; set; }
        public string expediente_mun { get; set; }

        public string nombre_titular { get; set; }

        public string descripcion { get; set; }
        public string nomeclatura { get; set; }
        public string estado { get; set; }

        public string area { get; set; }

        public TRAMITE()
        {
            id = 0;
            nro_tramite = string.Empty;
            fecha_alta = DateTime.Now;
            nro_expediente = 0;
            anio = 0;
            id_tipo_tramite = 0;
            id_profesional = 0;
            cuit_vecino = string.Empty;
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            manzana_oficial = string.Empty;
            parcela_oficial = string.Empty;
            nomenclatura_provincial = string.Empty;
            cod_calle_pf = 0;
            calle_pf = string.Empty;
            nro_pf = string.Empty;
            piso_pf = string.Empty;
            dpto_pf = string.Empty;
            cod_barrio_pf = 0;
            barrio_pf = string.Empty;
            id_tipologia = 0;
            superficie = 0;
            presupuesto_destinado = 0;
            otros_datos = string.Empty;
            cod_oficina_origen = 0;
            cod_oficina_destino = 0;
            id_estado_tramite = 0;
            fojas = 0;
            usuario = string.Empty;
            atendido = false;
            fecha_atendido = DateTime.Now;
            anulado = false;
            fecha_anulado = DateTime.Now;
            fecha_fin_tramite = DateTime.Now;
            observaciones = string.Empty;
            latitud = string.Empty;
            longitud = string.Empty;
            dir_google = string.Empty;
            expediente_mun = string.Empty;
            nombre_titular = string.Empty;
            descripcion = string.Empty;
            nomeclatura = string.Empty;
            estado = string.Empty;
            area = string.Empty;
        }

        private static List<TRAMITE> mapeo(SqlDataReader dr)
        {
            List<TRAMITE> lst = new List<TRAMITE>();
            TRAMITE obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new TRAMITE();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.nro_tramite = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.fecha_alta = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.nro_expediente = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.anio = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.id_tipo_tramite = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.id_profesional = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.cuit_vecino = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.circunscripcion = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.seccion = dr.GetInt32(9); }
                    if (!dr.IsDBNull(10)) { obj.manzana = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.parcela = dr.GetInt32(11); }
                    if (!dr.IsDBNull(12)) { obj.p_h = dr.GetInt32(12); }
                    if (!dr.IsDBNull(13)) { obj.manzana_oficial = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.parcela_oficial = dr.GetString(14); }
                    if (!dr.IsDBNull(15)) { obj.nomenclatura_provincial = dr.GetString(15); }
                    if (!dr.IsDBNull(16)) { obj.cod_calle_pf = dr.GetInt32(16); }
                    if (!dr.IsDBNull(17)) { obj.calle_pf = dr.GetString(17); }
                    if (!dr.IsDBNull(18)) { obj.nro_pf = dr.GetString(18); }
                    if (!dr.IsDBNull(19)) { obj.piso_pf = dr.GetString(19); }
                    if (!dr.IsDBNull(20)) { obj.dpto_pf = dr.GetString(20); }
                    if (!dr.IsDBNull(21)) { obj.cod_barrio_pf = dr.GetInt32(21); }
                    if (!dr.IsDBNull(22)) { obj.barrio_pf = dr.GetString(22); }
                    if (!dr.IsDBNull(23)) { obj.id_tipologia = dr.GetInt32(23); }
                    if (!dr.IsDBNull(24)) { obj.superficie = dr.GetFloat(24); }
                    if (!dr.IsDBNull(25)) { obj.presupuesto_destinado = dr.GetDecimal(25); }
                    if (!dr.IsDBNull(26)) { obj.otros_datos = dr.GetString(26); }
                    if (!dr.IsDBNull(27)) { obj.cod_oficina_origen = dr.GetInt32(27); }
                    if (!dr.IsDBNull(28)) { obj.cod_oficina_destino = dr.GetInt32(28); }
                    if (!dr.IsDBNull(29)) { obj.id_estado_tramite = dr.GetInt32(29); }
                    if (!dr.IsDBNull(30)) { obj.fojas = dr.GetInt32(30); }
                    if (!dr.IsDBNull(31)) { obj.usuario = dr.GetString(31); }
                    if (!dr.IsDBNull(32)) { obj.atendido = dr.GetBoolean(32); }
                    if (!dr.IsDBNull(33)) { obj.fecha_atendido = dr.GetDateTime(33); }
                    if (!dr.IsDBNull(34)) { obj.anulado = dr.GetBoolean(34); }
                    if (!dr.IsDBNull(35)) { obj.fecha_anulado = dr.GetDateTime(35); }
                    if (!dr.IsDBNull(36)) { obj.fecha_fin_tramite = dr.GetDateTime(36); }
                    if (!dr.IsDBNull(37)) { obj.observaciones = dr.GetString(37); }
                    if (!dr.IsDBNull(38)) { obj.latitud = dr.GetString(38); }
                    if (!dr.IsDBNull(39)) { obj.longitud = dr.GetString(39); }
                    if (!dr.IsDBNull(40)) { obj.dir_google = dr.GetString(40); }

                    if (!dr.IsDBNull(41))
                    {
                        obj.nombre_titular = dr.GetString(41);
                    }
                    if (!dr.IsDBNull(42))
                    {
                        obj.descripcion = dr.GetString(42);
                    }
                    //--------------------------------------------------------------------------------//
                    if (!dr.IsDBNull(3))
                    {
                        obj.expediente_mun =
                             string.Format("{0}{1}",
                             Convert.ToString(dr.GetInt32(3)), Convert.ToString(dr.GetInt32(4)));
                    }
                    if (!dr.IsDBNull(8))
                    {
                        obj.nomeclatura =
                             string.Format("{0}{1}{2}{3}{4}",
                             Convert.ToString(dr.GetInt32(8)).PadLeft(2, '0'),
                             Convert.ToString(dr.GetInt32(9)).PadLeft(2, '0'),
                             Convert.ToString(dr.GetInt32(10)).PadLeft(3, '0'),
                             Convert.ToString(dr.GetInt32(11)).PadLeft(3, '0'),
                             Convert.ToString(dr.GetInt32(12)).PadLeft(3, '0'));
                    }
                    if (!dr.IsDBNull(29))
                    {
                        obj.estado = dr.GetString(43);
                    }
                    if (!dr.IsDBNull(28))
                    {
                        obj.area = dr.GetString(44);
                    }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<TRAMITE> read()
        {
            string strSQL = @"SELECT a.*, b.estado_tramite, o.oficina
                            FROM TRAMITE a
                            JOIN ESTADOS_TRAMITES b on
                            a.id_estado_tramite=b.id
                            JOIN OFICINAS o on
                            a.cod_oficina_destino=o.cod_oficina";
            try
            {
                List<TRAMITE> lst = new List<TRAMITE>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
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

        public static TRAMITE getByPk(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TRAMITE WHERE");
                sql.AppendLine("id = @id");
                TRAMITE obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<TRAMITE> lst = mapeo(dr);
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

        public static int insert(TRAMITE obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TRAMITE(");
                sql.AppendLine("nro_tramite");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(", nro_expediente");
                sql.AppendLine(", anio");
                sql.AppendLine(", id_tipo_tramite");
                sql.AppendLine(", id_profesional");
                sql.AppendLine(", cuit_vecino");
                sql.AppendLine(", circunscripcion");
                sql.AppendLine(", seccion");
                sql.AppendLine(", manzana");
                sql.AppendLine(", parcela");
                sql.AppendLine(", p_h");
                sql.AppendLine(", manzana_oficial");
                sql.AppendLine(", parcela_oficial");
                sql.AppendLine(", nomenclatura_provincial");
                sql.AppendLine(", cod_calle_pf");
                sql.AppendLine(", calle_pf");
                sql.AppendLine(", nro_pf");
                sql.AppendLine(", piso_pf");
                sql.AppendLine(", dpto_pf");
                sql.AppendLine(", cod_barrio_pf");
                sql.AppendLine(", barrio_pf");
                sql.AppendLine(", id_tipologia");
                sql.AppendLine(", superficie");
                sql.AppendLine(", presupuesto_destinado");
                sql.AppendLine(", otros_datos");
                sql.AppendLine(", cod_oficina_origen");
                sql.AppendLine(", cod_oficina_destino");
                sql.AppendLine(", id_estado_tramite");
                sql.AppendLine(", fojas");
                sql.AppendLine(", usuario");
                sql.AppendLine(", atendido");
                sql.AppendLine(", fecha_atendido");
                sql.AppendLine(", anulado");
                sql.AppendLine(", fecha_anulado");
                sql.AppendLine(", fecha_fin_tramite");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", latitud");
                sql.AppendLine(", longitud");
                sql.AppendLine(", dir_google");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nro_tramite");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(", @nro_expediente");
                sql.AppendLine(", @anio");
                sql.AppendLine(", @id_tipo_tramite");
                sql.AppendLine(", @id_profesional");
                sql.AppendLine(", @cuit_vecino");
                sql.AppendLine(", @circunscripcion");
                sql.AppendLine(", @seccion");
                sql.AppendLine(", @manzana");
                sql.AppendLine(", @parcela");
                sql.AppendLine(", @p_h");
                sql.AppendLine(", @manzana_oficial");
                sql.AppendLine(", @parcela_oficial");
                sql.AppendLine(", @nomenclatura_provincial");
                sql.AppendLine(", @cod_calle_pf");
                sql.AppendLine(", @calle_pf");
                sql.AppendLine(", @nro_pf");
                sql.AppendLine(", @piso_pf");
                sql.AppendLine(", @dpto_pf");
                sql.AppendLine(", @cod_barrio_pf");
                sql.AppendLine(", @barrio_pf");
                sql.AppendLine(", @id_tipologia");
                sql.AppendLine(", @superficie");
                sql.AppendLine(", @presupuesto_destinado");
                sql.AppendLine(", @otros_datos");
                sql.AppendLine(", @cod_oficina_origen");
                sql.AppendLine(", @cod_oficina_destino");
                sql.AppendLine(", @id_estado_tramite");
                sql.AppendLine(", @fojas");
                sql.AppendLine(", @usuario");
                sql.AppendLine(", @atendido");
                sql.AppendLine(", @fecha_atendido");
                sql.AppendLine(", @anulado");
                sql.AppendLine(", @fecha_anulado");
                sql.AppendLine(", @fecha_fin_tramite");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @latitud");
                sql.AppendLine(", @longitud");
                sql.AppendLine(", @dir_google");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_tramite", obj.nro_tramite);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@nro_expediente", obj.nro_expediente);
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@id_tipo_tramite", obj.id_tipo_tramite);
                    cmd.Parameters.AddWithValue("@id_profesional", obj.id_profesional);
                    cmd.Parameters.AddWithValue("@cuit_vecino", obj.cuit_vecino);
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Parameters.AddWithValue("@manzana_oficial", obj.manzana_oficial);
                    cmd.Parameters.AddWithValue("@parcela_oficial", obj.parcela_oficial);
                    cmd.Parameters.AddWithValue("@nomenclatura_provincial", obj.nomenclatura_provincial);
                    cmd.Parameters.AddWithValue("@cod_calle_pf", obj.cod_calle_pf);
                    cmd.Parameters.AddWithValue("@calle_pf", obj.calle_pf);
                    cmd.Parameters.AddWithValue("@nro_pf", obj.nro_pf);
                    cmd.Parameters.AddWithValue("@piso_pf", obj.piso_pf);
                    cmd.Parameters.AddWithValue("@dpto_pf", obj.dpto_pf);
                    cmd.Parameters.AddWithValue("@cod_barrio_pf", obj.cod_barrio_pf);
                    cmd.Parameters.AddWithValue("@barrio_pf", obj.barrio_pf);
                    cmd.Parameters.AddWithValue("@id_tipologia", obj.id_tipologia);
                    cmd.Parameters.AddWithValue("@superficie", obj.superficie);
                    cmd.Parameters.AddWithValue("@presupuesto_destinado", obj.presupuesto_destinado);
                    cmd.Parameters.AddWithValue("@otros_datos", obj.otros_datos);
                    cmd.Parameters.AddWithValue("@cod_oficina_origen", obj.cod_oficina_origen);
                    cmd.Parameters.AddWithValue("@cod_oficina_destino", obj.cod_oficina_destino);
                    cmd.Parameters.AddWithValue("@id_estado_tramite", obj.id_estado_tramite);
                    cmd.Parameters.AddWithValue("@fojas", obj.fojas);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@atendido", obj.atendido);
                    cmd.Parameters.AddWithValue("@fecha_atendido", obj.fecha_atendido);
                    cmd.Parameters.AddWithValue("@anulado", obj.anulado);
                    cmd.Parameters.AddWithValue("@fecha_anulado", obj.fecha_anulado);
                    cmd.Parameters.AddWithValue("@fecha_fin_tramite", obj.fecha_fin_tramite);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@latitud", obj.latitud);
                    cmd.Parameters.AddWithValue("@longitud", obj.longitud);
                    cmd.Parameters.AddWithValue("@dir_google", obj.dir_google);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(TRAMITE obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  TRAMITE SET");
                sql.AppendLine("nro_tramite=@nro_tramite");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine(", nro_expediente=@nro_expediente");
                sql.AppendLine(", anio=@anio");
                sql.AppendLine(", id_tipo_tramite=@id_tipo_tramite");
                sql.AppendLine(", id_profesional=@id_profesional");
                sql.AppendLine(", cuit_vecino=@cuit_vecino");
                sql.AppendLine(", circunscripcion=@circunscripcion");
                sql.AppendLine(", seccion=@seccion");
                sql.AppendLine(", manzana=@manzana");
                sql.AppendLine(", parcela=@parcela");
                sql.AppendLine(", p_h=@p_h");
                sql.AppendLine(", manzana_oficial=@manzana_oficial");
                sql.AppendLine(", parcela_oficial=@parcela_oficial");
                sql.AppendLine(", nomenclatura_provincial=@nomenclatura_provincial");
                sql.AppendLine(", cod_calle_pf=@cod_calle_pf");
                sql.AppendLine(", calle_pf=@calle_pf");
                sql.AppendLine(", nro_pf=@nro_pf");
                sql.AppendLine(", piso_pf=@piso_pf");
                sql.AppendLine(", dpto_pf=@dpto_pf");
                sql.AppendLine(", cod_barrio_pf=@cod_barrio_pf");
                sql.AppendLine(", barrio_pf=@barrio_pf");
                sql.AppendLine(", id_tipologia=@id_tipologia");
                sql.AppendLine(", superficie=@superficie");
                sql.AppendLine(", presupuesto_destinado=@presupuesto_destinado");
                sql.AppendLine(", otros_datos=@otros_datos");
                sql.AppendLine(", cod_oficina_origen=@cod_oficina_origen");
                sql.AppendLine(", cod_oficina_destino=@cod_oficina_destino");
                sql.AppendLine(", id_estado_tramite=@id_estado_tramite");
                sql.AppendLine(", fojas=@fojas");
                sql.AppendLine(", usuario=@usuario");
                sql.AppendLine(", atendido=@atendido");
                sql.AppendLine(", fecha_atendido=@fecha_atendido");
                sql.AppendLine(", anulado=@anulado");
                sql.AppendLine(", fecha_anulado=@fecha_anulado");
                sql.AppendLine(", fecha_fin_tramite=@fecha_fin_tramite");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", latitud=@latitud");
                sql.AppendLine(", longitud=@longitud");
                sql.AppendLine(", dir_google=@dir_google");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_tramite", obj.nro_tramite);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@nro_expediente", obj.nro_expediente);
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@id_tipo_tramite", obj.id_tipo_tramite);
                    cmd.Parameters.AddWithValue("@id_profesional", obj.id_profesional);
                    cmd.Parameters.AddWithValue("@cuit_vecino", obj.cuit_vecino);
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Parameters.AddWithValue("@manzana_oficial", obj.manzana_oficial);
                    cmd.Parameters.AddWithValue("@parcela_oficial", obj.parcela_oficial);
                    cmd.Parameters.AddWithValue("@nomenclatura_provincial", obj.nomenclatura_provincial);
                    cmd.Parameters.AddWithValue("@cod_calle_pf", obj.cod_calle_pf);
                    cmd.Parameters.AddWithValue("@calle_pf", obj.calle_pf);
                    cmd.Parameters.AddWithValue("@nro_pf", obj.nro_pf);
                    cmd.Parameters.AddWithValue("@piso_pf", obj.piso_pf);
                    cmd.Parameters.AddWithValue("@dpto_pf", obj.dpto_pf);
                    cmd.Parameters.AddWithValue("@cod_barrio_pf", obj.cod_barrio_pf);
                    cmd.Parameters.AddWithValue("@barrio_pf", obj.barrio_pf);
                    cmd.Parameters.AddWithValue("@id_tipologia", obj.id_tipologia);
                    cmd.Parameters.AddWithValue("@superficie", obj.superficie);
                    cmd.Parameters.AddWithValue("@presupuesto_destinado", obj.presupuesto_destinado);
                    cmd.Parameters.AddWithValue("@otros_datos", obj.otros_datos);
                    cmd.Parameters.AddWithValue("@cod_oficina_origen", obj.cod_oficina_origen);
                    cmd.Parameters.AddWithValue("@cod_oficina_destino", obj.cod_oficina_destino);
                    cmd.Parameters.AddWithValue("@id_estado_tramite", obj.id_estado_tramite);
                    cmd.Parameters.AddWithValue("@fojas", obj.fojas);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@atendido", obj.atendido);
                    cmd.Parameters.AddWithValue("@fecha_atendido", obj.fecha_atendido);
                    cmd.Parameters.AddWithValue("@anulado", obj.anulado);
                    cmd.Parameters.AddWithValue("@fecha_anulado", obj.fecha_anulado);
                    cmd.Parameters.AddWithValue("@fecha_fin_tramite", obj.fecha_fin_tramite);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@latitud", obj.latitud);
                    cmd.Parameters.AddWithValue("@longitud", obj.longitud);
                    cmd.Parameters.AddWithValue("@dir_google", obj.dir_google);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(TRAMITE obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  TRAMITE ");
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

        #region (Combos)
        public static List<TIPOS_TRAMITES> ObtenerTipoTramite()
        {
            try
            {
                string sql = @"SELECT * FROM TIPOS_TRAMITES";
                List<TIPOS_TRAMITES> lst = new List<TIPOS_TRAMITES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    TIPOS_TRAMITES obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new TIPOS_TRAMITES();
                            if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.tramite = dr.GetString(1); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<TIPOLOGIAS> ObtenerTipologia()
        {
            try
            {
                string sql = @"SELECT * FROM TIPOLOGIAS";
                List<TIPOLOGIAS> lst = new List<TIPOLOGIAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    TIPOLOGIAS obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new TIPOLOGIAS();
                            if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.tipologia = dr.GetString(1); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}

