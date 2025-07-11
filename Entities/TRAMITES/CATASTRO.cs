using System.Collections.Generic;
using System.Data;
using System.Text;
using System;
using System.Data.SqlClient;
using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.TRAMITES
{
    public class CATASTRO : DALBase
    {
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public int Nro_Bad { get; set; }
        public string Nombre { get; set; }
        public string Manzana_Oficial { get; set; }
        public string Lote_Oficial { get; set; }
        public int Dominio { get; set; }
        public int Folio { get; set; }
        public int Tomo { get; set; }
        public int Anio { get; set; }
        public string Matricula { get; set; }
        public float Superficie { get; set; }
        public float Coor_x { get; set; }
        public float Coor_y { get; set; }
        public int Cod_calle_pf { get; set; }
        public int Nro_dom_pf { get; set; }
        public DateTime Fecha_escritura { get; set; }
        public string Loteo { get; set; }
        public DateTime Fecha_Protocolo { get; set; }
        public string Escribano { get; set; }
        public string Prop_anterior { get; set; }
        public string Observacion { get; set; }
        public DateTime Fecha_alta { get; set; }
        public float superficie_edificada { get; set; }
        public string cod_categoria_zona_liq { get; set; }
        public int Tipo_ph { get; set; }
        public DateTime Fecha_tipo_ph { get; set; }

        public CATASTRO()
        {
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            Nro_Bad = 0;
            Nombre = string.Empty;
            Manzana_Oficial = string.Empty;
            Lote_Oficial = string.Empty;
            Dominio = 0;
            Folio = 0;
            Tomo = 0;
            Anio = 0;
            Matricula = string.Empty;
            Superficie = 0;
            Coor_x = 0;
            Coor_y = 0;
            Cod_calle_pf = 0;
            Nro_dom_pf = 0;
            Fecha_escritura = DateTime.Now;
            Loteo = string.Empty;
            Fecha_Protocolo = DateTime.Now;
            Escribano = string.Empty;
            Prop_anterior = string.Empty;
            Observacion = string.Empty;
            Fecha_alta = DateTime.Now;
            superficie_edificada = 0;
            cod_categoria_zona_liq = string.Empty;
            Tipo_ph = 0;
            Fecha_tipo_ph = DateTime.Now;
        }

        private static List<CATASTRO> mapeo(SqlDataReader dr)
        {
            List<CATASTRO> lst = new List<CATASTRO>();
            CATASTRO obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new CATASTRO();
                    if (!dr.IsDBNull(0)) { obj.circunscripcion = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.seccion = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.manzana = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.parcela = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.p_h = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.Nro_Bad = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.Nombre = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.Manzana_Oficial = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.Lote_Oficial = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.Dominio = dr.GetInt32(9); }
                    if (!dr.IsDBNull(10)) { obj.Folio = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.Tomo = dr.GetInt32(11); }
                    if (!dr.IsDBNull(12)) { obj.Anio = dr.GetInt32(12); }
                    if (!dr.IsDBNull(13)) { obj.Matricula = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.Superficie = dr.GetFloat(14); }
                    if (!dr.IsDBNull(15)) { obj.Coor_x = dr.GetFloat(15); }
                    if (!dr.IsDBNull(16)) { obj.Coor_y = dr.GetFloat(16); }
                    if (!dr.IsDBNull(17)) { obj.Cod_calle_pf = dr.GetInt32(17); }
                    if (!dr.IsDBNull(18)) { obj.Nro_dom_pf = dr.GetInt32(18); }
                    if (!dr.IsDBNull(19)) { obj.Fecha_escritura = dr.GetDateTime(19); }
                    if (!dr.IsDBNull(20)) { obj.Loteo = dr.GetString(20); }
                    if (!dr.IsDBNull(21)) { obj.Fecha_Protocolo = dr.GetDateTime(21); }
                    if (!dr.IsDBNull(22)) { obj.Escribano = dr.GetString(22); }
                    if (!dr.IsDBNull(23)) { obj.Prop_anterior = dr.GetString(23); }
                    if (!dr.IsDBNull(24)) { obj.Observacion = dr.GetString(24); }
                    if (!dr.IsDBNull(25)) { obj.Fecha_alta = dr.GetDateTime(25); }
                    if (!dr.IsDBNull(26)) { obj.superficie_edificada = dr.GetFloat(26); }
                    if (!dr.IsDBNull(27)) { obj.cod_categoria_zona_liq = dr.GetString(27); }
                    if (!dr.IsDBNull(28)) { obj.Tipo_ph = dr.GetInt32(28); }
                    if (!dr.IsDBNull(29)) { obj.Fecha_tipo_ph = dr.GetDateTime(29); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CATASTRO> read()
        {
            try
            {
                List<CATASTRO> lst = new List<CATASTRO>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CATASTRO";
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

        public static CATASTRO getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CATASTRO WHERE");
                sql.AppendLine("Circunscripcion = @circunscripcion");
                sql.AppendLine("AND seccion = @seccion");
                sql.AppendLine("AND manzana = @manzana");
                sql.AppendLine("AND parcela = @parcela");
                sql.AppendLine("AND P_H = @p_h");
                CATASTRO obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@circunscripcion", circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", seccion);
                    cmd.Parameters.AddWithValue("@manzana", manzana);
                    cmd.Parameters.AddWithValue("@parcela", parcela);
                    cmd.Parameters.AddWithValue("@p_H", p_h);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CATASTRO> lst = mapeo(dr);
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

        public static int insert(CATASTRO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO CATASTRO(");
                sql.AppendLine("Circunscripcion");
                sql.AppendLine(", seccion");
                sql.AppendLine(", manzana");
                sql.AppendLine(", parcela");
                sql.AppendLine(", P_H");
                sql.AppendLine(", Nro_Bad");
                sql.AppendLine(", Nombre");
                sql.AppendLine(", Manzana_Oficial");
                sql.AppendLine(", Lote_Oficial");
                sql.AppendLine(", Dominio");
                sql.AppendLine(", Folio");
                sql.AppendLine(", Tomo");
                sql.AppendLine(", Anio");
                sql.AppendLine(", Matricula");
                sql.AppendLine(", Superficie");
                sql.AppendLine(", Coor_x");
                sql.AppendLine(", Coor_y");
                sql.AppendLine(", Cod_calle_pf");
                sql.AppendLine(", Nro_dom_pf");
                sql.AppendLine(", Fecha_escritura");
                sql.AppendLine(", Loteo");
                sql.AppendLine(", Fecha_Protocolo");
                sql.AppendLine(", Escribano");
                sql.AppendLine(", Prop_anterior");
                sql.AppendLine(", Observacion");
                sql.AppendLine(", Fecha_alta");
                sql.AppendLine(", superficie_edificada");
                sql.AppendLine(", cod_categoria_zona_liq");
                sql.AppendLine(", Tipo_ph");
                sql.AppendLine(", Fecha_tipo_ph");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Circunscripcion");
                sql.AppendLine(", @seccion");
                sql.AppendLine(", @manzana");
                sql.AppendLine(", @parcela");
                sql.AppendLine(", @P_H");
                sql.AppendLine(", @Nro_Bad");
                sql.AppendLine(", @Nombre");
                sql.AppendLine(", @Manzana_Oficial");
                sql.AppendLine(", @Lote_Oficial");
                sql.AppendLine(", @Dominio");
                sql.AppendLine(", @Folio");
                sql.AppendLine(", @Tomo");
                sql.AppendLine(", @Anio");
                sql.AppendLine(", @Matricula");
                sql.AppendLine(", @Superficie");
                sql.AppendLine(", @Coor_x");
                sql.AppendLine(", @Coor_y");
                sql.AppendLine(", @Cod_calle_pf");
                sql.AppendLine(", @Nro_dom_pf");
                sql.AppendLine(", @Fecha_escritura");
                sql.AppendLine(", @Loteo");
                sql.AppendLine(", @Fecha_Protocolo");
                sql.AppendLine(", @Escribano");
                sql.AppendLine(", @Prop_anterior");
                sql.AppendLine(", @Observacion");
                sql.AppendLine(", @Fecha_alta");
                sql.AppendLine(", @superficie_edificada");
                sql.AppendLine(", @cod_categoria_zona_liq");
                sql.AppendLine(", @Tipo_ph");
                sql.AppendLine(", @Fecha_tipo_ph");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@P_H", obj.p_h);
                    cmd.Parameters.AddWithValue("@Nro_Bad", obj.Nro_Bad);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Manzana_Oficial", obj.Manzana_Oficial);
                    cmd.Parameters.AddWithValue("@Lote_Oficial", obj.Lote_Oficial);
                    cmd.Parameters.AddWithValue("@Dominio", obj.Dominio);
                    cmd.Parameters.AddWithValue("@Folio", obj.Folio);
                    cmd.Parameters.AddWithValue("@Tomo", obj.Tomo);
                    cmd.Parameters.AddWithValue("@Anio", obj.Anio);
                    cmd.Parameters.AddWithValue("@Matricula", obj.Matricula);
                    cmd.Parameters.AddWithValue("@Superficie", obj.Superficie);
                    cmd.Parameters.AddWithValue("@Coor_x", obj.Coor_x);
                    cmd.Parameters.AddWithValue("@Coor_y", obj.Coor_y);
                    cmd.Parameters.AddWithValue("@Cod_calle_pf", obj.Cod_calle_pf);
                    cmd.Parameters.AddWithValue("@Nro_dom_pf", obj.Nro_dom_pf);
                    cmd.Parameters.AddWithValue("@Fecha_escritura", obj.Fecha_escritura);
                    cmd.Parameters.AddWithValue("@Loteo", obj.Loteo);
                    cmd.Parameters.AddWithValue("@Fecha_Protocolo", obj.Fecha_Protocolo);
                    cmd.Parameters.AddWithValue("@Escribano", obj.Escribano);
                    cmd.Parameters.AddWithValue("@Prop_anterior", obj.Prop_anterior);
                    cmd.Parameters.AddWithValue("@Observacion", obj.Observacion);
                    cmd.Parameters.AddWithValue("@Fecha_alta", obj.Fecha_alta);
                    cmd.Parameters.AddWithValue("@superficie_edificada", obj.superficie_edificada);
                    cmd.Parameters.AddWithValue("@cod_categoria_zona_liq", obj.cod_categoria_zona_liq);
                    cmd.Parameters.AddWithValue("@Tipo_ph", obj.Tipo_ph);
                    cmd.Parameters.AddWithValue("@Fecha_tipo_ph", obj.Fecha_tipo_ph);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(CATASTRO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  CATASTRO SET");
                sql.AppendLine("Nro_Bad=@Nro_Bad");
                sql.AppendLine(", Nombre=@Nombre");
                sql.AppendLine(", Manzana_Oficial=@Manzana_Oficial");
                sql.AppendLine(", Lote_Oficial=@Lote_Oficial");
                sql.AppendLine(", Dominio=@Dominio");
                sql.AppendLine(", Folio=@Folio");
                sql.AppendLine(", Tomo=@Tomo");
                sql.AppendLine(", Anio=@Anio");
                sql.AppendLine(", Matricula=@Matricula");
                sql.AppendLine(", Superficie=@Superficie");
                sql.AppendLine(", Coor_x=@Coor_x");
                sql.AppendLine(", Coor_y=@Coor_y");
                sql.AppendLine(", Cod_calle_pf=@Cod_calle_pf");
                sql.AppendLine(", Nro_dom_pf=@Nro_dom_pf");
                sql.AppendLine(", Fecha_escritura=@Fecha_escritura");
                sql.AppendLine(", Loteo=@Loteo");
                sql.AppendLine(", Fecha_Protocolo=@Fecha_Protocolo");
                sql.AppendLine(", Escribano=@Escribano");
                sql.AppendLine(", Prop_anterior=@Prop_anterior");
                sql.AppendLine(", Observacion=@Observacion");
                sql.AppendLine(", Fecha_alta=@Fecha_alta");
                sql.AppendLine(", superficie_edificada=@superficie_edificada");
                sql.AppendLine(", cod_categoria_zona_liq=@cod_categoria_zona_liq");
                sql.AppendLine(", Tipo_ph=@Tipo_ph");
                sql.AppendLine(", Fecha_tipo_ph=@Fecha_tipo_ph");
                sql.AppendLine("WHERE");
                sql.AppendLine("Circunscripcion=@Circunscripcion");
                sql.AppendLine("AND seccion=@seccion");
                sql.AppendLine("AND manzana=@manzana");
                sql.AppendLine("AND parcela=@parcela");
                sql.AppendLine("AND P_H=@P_H");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@P_H", obj.p_h);
                    cmd.Parameters.AddWithValue("@Nro_Bad", obj.Nro_Bad);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Manzana_Oficial", obj.Manzana_Oficial);
                    cmd.Parameters.AddWithValue("@Lote_Oficial", obj.Lote_Oficial);
                    cmd.Parameters.AddWithValue("@Dominio", obj.Dominio);
                    cmd.Parameters.AddWithValue("@Folio", obj.Folio);
                    cmd.Parameters.AddWithValue("@Tomo", obj.Tomo);
                    cmd.Parameters.AddWithValue("@Anio", obj.Anio);
                    cmd.Parameters.AddWithValue("@Matricula", obj.Matricula);
                    cmd.Parameters.AddWithValue("@Superficie", obj.Superficie);
                    cmd.Parameters.AddWithValue("@Coor_x", obj.Coor_x);
                    cmd.Parameters.AddWithValue("@Coor_y", obj.Coor_y);
                    cmd.Parameters.AddWithValue("@Cod_calle_pf", obj.Cod_calle_pf);
                    cmd.Parameters.AddWithValue("@Nro_dom_pf", obj.Nro_dom_pf);
                    cmd.Parameters.AddWithValue("@Fecha_escritura", obj.Fecha_escritura);
                    cmd.Parameters.AddWithValue("@Loteo", obj.Loteo);
                    cmd.Parameters.AddWithValue("@Fecha_Protocolo", obj.Fecha_Protocolo);
                    cmd.Parameters.AddWithValue("@Escribano", obj.Escribano);
                    cmd.Parameters.AddWithValue("@Prop_anterior", obj.Prop_anterior);
                    cmd.Parameters.AddWithValue("@Observacion", obj.Observacion);
                    cmd.Parameters.AddWithValue("@Fecha_alta", obj.Fecha_alta);
                    cmd.Parameters.AddWithValue("@superficie_edificada", obj.superficie_edificada);
                    cmd.Parameters.AddWithValue("@cod_categoria_zona_liq", obj.cod_categoria_zona_liq);
                    cmd.Parameters.AddWithValue("@Tipo_ph", obj.Tipo_ph);
                    cmd.Parameters.AddWithValue("@Fecha_tipo_ph", obj.Fecha_tipo_ph);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(CATASTRO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  CATASTRO ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Circunscripcion=@Circunscripcion");
                sql.AppendLine("AND seccion=@seccion");
                sql.AppendLine("AND manzana=@manzana");
                sql.AppendLine("AND parcela=@parcela");
                sql.AppendLine("AND P_H=@P_H");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@P_H", obj.p_h);
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

