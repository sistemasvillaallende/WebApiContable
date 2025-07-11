using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.FOP
{
    public class Proveedores : DALBase
    {
        public int cod_proveedor { get; set; }
        public string nom_proveedor { get; set; }
        public int nro_bad { get; set; }
        public int cod_tipo_proveedor { get; set; }
        public int cod_cond_ante_iva { get; set; }
        public int cod_calle { get; set; }
        public string nom_calle { get; set; }
        public int nro_dom { get; set; }
        public int cod_barrio { get; set; }
        public string nom_barrio { get; set; }
        public string ciudad { get; set; }
        public string cod_postal { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public string nro_cuit { get; set; }
        public string nro_ing_bruto { get; set; }
        public string nro_caja_jub { get; set; }
        public string telefono { get; set; }
        public string piso_dpto { get; set; }
        public DateTime fecha_alta { get; set; }
        public string e_mail { get; set; }
        public int cod_subtipo { get; set; }
        public short retencionSi { get; set; }
        public string usuario { get; set; }
        public string usuariomodifica { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public short baja { get; set; }
        public DateTime fecha_baja { get; set; }
        public string usuariobaja { get; set; }

        public Proveedores()
        {
            cod_proveedor = 0;
            nom_proveedor = string.Empty;
            nro_bad = 0;
            cod_tipo_proveedor = 0;
            cod_cond_ante_iva = 0;
            cod_calle = 0;
            nom_calle = string.Empty;
            nro_dom = 0;
            cod_barrio = 0;
            nom_barrio = string.Empty;
            ciudad = string.Empty;
            cod_postal = string.Empty;
            provincia = string.Empty;
            pais = string.Empty;
            nro_cuit = string.Empty;
            nro_ing_bruto = string.Empty;
            nro_caja_jub = string.Empty;
            telefono = string.Empty;
            piso_dpto = string.Empty;
            fecha_alta = DateTime.Now;
            e_mail = string.Empty;
            cod_subtipo = 0;
            retencionSi = 0;
            usuario = string.Empty;
            usuariomodifica = string.Empty;
            fecha_modificacion = DateTime.Now;
            baja = 0;
            fecha_baja = DateTime.Now;
            usuariobaja = string.Empty;
        }

        private static List<Proveedores> mapeo(SqlDataReader dr)
        {
            List<Proveedores> lst = new List<Proveedores>();
            Proveedores obj;
            if (dr.HasRows)
            {
                int cod_proveedor = dr.GetOrdinal("cod_proveedor");
                int nom_proveedor = dr.GetOrdinal("nom_proveedor");
                int nro_bad = dr.GetOrdinal("nro_bad");
                int cod_tipo_proveedor = dr.GetOrdinal("cod_tipo_proveedor");
                int cod_cond_ante_iva = dr.GetOrdinal("cod_cond_ante_iva");
                int cod_calle = dr.GetOrdinal("cod_calle");
                int nom_calle = dr.GetOrdinal("nom_calle");
                int nro_dom = dr.GetOrdinal("nro_dom");
                int cod_barrio = dr.GetOrdinal("cod_barrio");
                int nom_barrio = dr.GetOrdinal("nom_barrio");
                int ciudad = dr.GetOrdinal("ciudad");
                int cod_postal = dr.GetOrdinal("cod_postal");
                int provincia = dr.GetOrdinal("provincia");
                int pais = dr.GetOrdinal("pais");
                int nro_cuit = dr.GetOrdinal("nro_cuit");
                int nro_ing_bruto = dr.GetOrdinal("nro_ing_bruto");
                int nro_caja_jub = dr.GetOrdinal("nro_caja_jub");
                int telefono = dr.GetOrdinal("telefono");
                int piso_dpto = dr.GetOrdinal("piso_dpto");
                int fecha_alta = dr.GetOrdinal("fecha_alta");
                int e_mail = dr.GetOrdinal("e_mail");
                int cod_subtipo = dr.GetOrdinal("cod_subtipo");
                int retencionSi = dr.GetOrdinal("retencionSi");
                int usuario = dr.GetOrdinal("usuario");
                int usuariomodifica = dr.GetOrdinal("usuariomodifica");
                int fecha_modificacion = dr.GetOrdinal("fecha_modificacion");
                int baja = dr.GetOrdinal("baja");
                int fecha_baja = dr.GetOrdinal("fecha_baja");
                int usuariobaja = dr.GetOrdinal("usuariobaja");
                while (dr.Read())
                {
                    obj = new Proveedores();
                    if (!dr.IsDBNull(cod_proveedor)) { obj.cod_proveedor = dr.GetInt32(cod_proveedor); }
                    if (!dr.IsDBNull(nom_proveedor)) { obj.nom_proveedor = dr.GetString(nom_proveedor); }
                    if (!dr.IsDBNull(nro_bad)) { obj.nro_bad = dr.GetInt32(nro_bad); }
                    if (!dr.IsDBNull(cod_tipo_proveedor)) { obj.cod_tipo_proveedor = dr.GetInt32(cod_tipo_proveedor); }
                    if (!dr.IsDBNull(cod_cond_ante_iva)) { obj.cod_cond_ante_iva = dr.GetInt32(cod_cond_ante_iva); }
                    if (!dr.IsDBNull(cod_calle)) { obj.cod_calle = dr.GetInt32(cod_calle); }
                    if (!dr.IsDBNull(nom_calle)) { obj.nom_calle = dr.GetString(nom_calle); }
                    if (!dr.IsDBNull(nro_dom)) { obj.nro_dom = dr.GetInt32(nro_dom); }
                    if (!dr.IsDBNull(cod_barrio)) { obj.cod_barrio = dr.GetInt32(cod_barrio); }
                    if (!dr.IsDBNull(nom_barrio)) { obj.nom_barrio = dr.GetString(nom_barrio); }
                    if (!dr.IsDBNull(ciudad)) { obj.ciudad = dr.GetString(ciudad); }
                    if (!dr.IsDBNull(cod_postal)) { obj.cod_postal = dr.GetString(cod_postal); }
                    if (!dr.IsDBNull(provincia)) { obj.provincia = dr.GetString(provincia); }
                    if (!dr.IsDBNull(pais)) { obj.pais = dr.GetString(pais); }
                    if (!dr.IsDBNull(nro_cuit)) { obj.nro_cuit = dr.GetString(nro_cuit); }
                    if (!dr.IsDBNull(nro_ing_bruto)) { obj.nro_ing_bruto = dr.GetString(nro_ing_bruto); }
                    if (!dr.IsDBNull(nro_caja_jub)) { obj.nro_caja_jub = dr.GetString(nro_caja_jub); }
                    if (!dr.IsDBNull(telefono)) { obj.telefono = dr.GetString(telefono); }
                    if (!dr.IsDBNull(piso_dpto)) { obj.piso_dpto = dr.GetString(piso_dpto); }
                    if (!dr.IsDBNull(fecha_alta)) { obj.fecha_alta = dr.GetDateTime(fecha_alta); }
                    if (!dr.IsDBNull(e_mail)) { obj.e_mail = dr.GetString(e_mail); }
                    if (!dr.IsDBNull(cod_subtipo)) { obj.cod_subtipo = dr.GetInt32(cod_subtipo); }
                    if (!dr.IsDBNull(retencionSi)) { obj.retencionSi = dr.GetInt16(retencionSi); }
                    if (!dr.IsDBNull(usuario)) { obj.usuario = dr.GetString(usuario); }
                    if (!dr.IsDBNull(usuariomodifica)) { obj.usuariomodifica = dr.GetString(usuariomodifica); }
                    if (!dr.IsDBNull(fecha_modificacion)) { obj.fecha_modificacion = dr.GetDateTime(fecha_modificacion); }
                    if (!dr.IsDBNull(baja)) { obj.baja = dr.GetInt16(baja); }
                    if (!dr.IsDBNull(fecha_baja)) { obj.fecha_baja = dr.GetDateTime(fecha_baja); }
                    if (!dr.IsDBNull(usuariobaja)) { obj.usuariobaja = dr.GetString(usuariobaja); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Proveedores> read()
        {
            try
            {
                List<Proveedores> lst = new List<Proveedores>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Proveedores";
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

        public static Proveedores getByPk(int cod_proveedor)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Proveedores ");
                sql.AppendLine("WHERE cod_proveedor = @cod_proveedor");
                Proveedores obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_proveedor", cod_proveedor);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Proveedores> lst = mapeo(dr);
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

        public static int insert(Proveedores obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Proveedores(");
                sql.AppendLine("cod_proveedor");
                sql.AppendLine(", nom_proveedor");
                sql.AppendLine(", nro_bad");
                sql.AppendLine(", cod_tipo_proveedor");
                sql.AppendLine(", cod_cond_ante_iva");
                sql.AppendLine(", cod_calle");
                sql.AppendLine(", nom_calle");
                sql.AppendLine(", nro_dom");
                sql.AppendLine(", cod_barrio");
                sql.AppendLine(", nom_barrio");
                sql.AppendLine(", ciudad");
                sql.AppendLine(", cod_postal");
                sql.AppendLine(", provincia");
                sql.AppendLine(", pais");
                sql.AppendLine(", nro_cuit");
                sql.AppendLine(", nro_ing_bruto");
                sql.AppendLine(", nro_caja_jub");
                sql.AppendLine(", telefono");
                sql.AppendLine(", piso_dpto");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(", e_mail");
                sql.AppendLine(", cod_subtipo");
                sql.AppendLine(", retencionSi");
                sql.AppendLine(", usuario");
                sql.AppendLine(", usuariomodifica");
                sql.AppendLine(", fecha_modificacion");
                sql.AppendLine(", baja");
                sql.AppendLine(", fecha_baja");
                sql.AppendLine(", usuariobaja");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_proveedor");
                sql.AppendLine(", @nom_proveedor");
                sql.AppendLine(", @nro_bad");
                sql.AppendLine(", @cod_tipo_proveedor");
                sql.AppendLine(", @cod_cond_ante_iva");
                sql.AppendLine(", @cod_calle");
                sql.AppendLine(", @nom_calle");
                sql.AppendLine(", @nro_dom");
                sql.AppendLine(", @cod_barrio");
                sql.AppendLine(", @nom_barrio");
                sql.AppendLine(", @ciudad");
                sql.AppendLine(", @cod_postal");
                sql.AppendLine(", @provincia");
                sql.AppendLine(", @pais");
                sql.AppendLine(", @nro_cuit");
                sql.AppendLine(", @nro_ing_bruto");
                sql.AppendLine(", @nro_caja_jub");
                sql.AppendLine(", @telefono");
                sql.AppendLine(", @piso_dpto");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(", @e_mail");
                sql.AppendLine(", @cod_subtipo");
                sql.AppendLine(", @retencionSi");
                sql.AppendLine(", @usuario");
                sql.AppendLine(", @usuariomodifica");
                sql.AppendLine(", @fecha_modificacion");
                sql.AppendLine(", @baja");
                sql.AppendLine(", @fecha_baja");
                sql.AppendLine(", @usuariobaja");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_proveedor", obj.cod_proveedor);
                    cmd.Parameters.AddWithValue("@nom_proveedor", obj.nom_proveedor);
                    cmd.Parameters.AddWithValue("@nro_bad", obj.nro_bad);
                    cmd.Parameters.AddWithValue("@cod_tipo_proveedor", obj.cod_tipo_proveedor);
                    cmd.Parameters.AddWithValue("@cod_cond_ante_iva", obj.cod_cond_ante_iva);
                    cmd.Parameters.AddWithValue("@cod_calle", obj.cod_calle);
                    cmd.Parameters.AddWithValue("@nom_calle", obj.nom_calle);
                    cmd.Parameters.AddWithValue("@nro_dom", obj.nro_dom);
                    cmd.Parameters.AddWithValue("@cod_barrio", obj.cod_barrio);
                    cmd.Parameters.AddWithValue("@nom_barrio", obj.nom_barrio);
                    cmd.Parameters.AddWithValue("@ciudad", obj.ciudad);
                    cmd.Parameters.AddWithValue("@cod_postal", obj.cod_postal);
                    cmd.Parameters.AddWithValue("@provincia", obj.provincia);
                    cmd.Parameters.AddWithValue("@pais", obj.pais);
                    cmd.Parameters.AddWithValue("@nro_cuit", obj.nro_cuit);
                    cmd.Parameters.AddWithValue("@nro_ing_bruto", obj.nro_ing_bruto);
                    cmd.Parameters.AddWithValue("@nro_caja_jub", obj.nro_caja_jub);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@piso_dpto", obj.piso_dpto);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@e_mail", obj.e_mail);
                    cmd.Parameters.AddWithValue("@cod_subtipo", obj.cod_subtipo);
                    cmd.Parameters.AddWithValue("@retencionSi", obj.retencionSi);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@usuariomodifica", obj.usuariomodifica);
                    cmd.Parameters.AddWithValue("@fecha_modificacion", obj.fecha_modificacion);
                    cmd.Parameters.AddWithValue("@baja", obj.baja);
                    cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja);
                    cmd.Parameters.AddWithValue("@usuariobaja", obj.usuariobaja);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Proveedores obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Proveedores SET");
                sql.AppendLine("nom_proveedor=@nom_proveedor");
                sql.AppendLine(", nro_bad=@nro_bad");
                sql.AppendLine(", cod_tipo_proveedor=@cod_tipo_proveedor");
                sql.AppendLine(", cod_cond_ante_iva=@cod_cond_ante_iva");
                sql.AppendLine(", cod_calle=@cod_calle");
                sql.AppendLine(", nom_calle=@nom_calle");
                sql.AppendLine(", nro_dom=@nro_dom");
                sql.AppendLine(", cod_barrio=@cod_barrio");
                sql.AppendLine(", nom_barrio=@nom_barrio");
                sql.AppendLine(", ciudad=@ciudad");
                sql.AppendLine(", cod_postal=@cod_postal");
                sql.AppendLine(", provincia=@provincia");
                sql.AppendLine(", pais=@pais");
                sql.AppendLine(", nro_cuit=@nro_cuit");
                sql.AppendLine(", nro_ing_bruto=@nro_ing_bruto");
                sql.AppendLine(", nro_caja_jub=@nro_caja_jub");
                sql.AppendLine(", telefono=@telefono");
                sql.AppendLine(", piso_dpto=@piso_dpto");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine(", e_mail=@e_mail");
                sql.AppendLine(", cod_subtipo=@cod_subtipo");
                sql.AppendLine(", retencionSi=@retencionSi");
                sql.AppendLine(", usuario=@usuario");
                sql.AppendLine(", usuariomodifica=@usuariomodifica");
                sql.AppendLine(", fecha_modificacion=@fecha_modificacion");
                sql.AppendLine(", baja=@baja");
                sql.AppendLine(", fecha_baja=@fecha_baja");
                sql.AppendLine(", usuariobaja=@usuariobaja");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_proveedor=@cod_proveedor");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_proveedor", obj.cod_proveedor);
                    cmd.Parameters.AddWithValue("@nom_proveedor", obj.nom_proveedor);
                    cmd.Parameters.AddWithValue("@nro_bad", obj.nro_bad);
                    cmd.Parameters.AddWithValue("@cod_tipo_proveedor", obj.cod_tipo_proveedor);
                    cmd.Parameters.AddWithValue("@cod_cond_ante_iva", obj.cod_cond_ante_iva);
                    cmd.Parameters.AddWithValue("@cod_calle", obj.cod_calle);
                    cmd.Parameters.AddWithValue("@nom_calle", obj.nom_calle);
                    cmd.Parameters.AddWithValue("@nro_dom", obj.nro_dom);
                    cmd.Parameters.AddWithValue("@cod_barrio", obj.cod_barrio);
                    cmd.Parameters.AddWithValue("@nom_barrio", obj.nom_barrio);
                    cmd.Parameters.AddWithValue("@ciudad", obj.ciudad);
                    cmd.Parameters.AddWithValue("@cod_postal", obj.cod_postal);
                    cmd.Parameters.AddWithValue("@provincia", obj.provincia);
                    cmd.Parameters.AddWithValue("@pais", obj.pais);
                    cmd.Parameters.AddWithValue("@nro_cuit", obj.nro_cuit);
                    cmd.Parameters.AddWithValue("@nro_ing_bruto", obj.nro_ing_bruto);
                    cmd.Parameters.AddWithValue("@nro_caja_jub", obj.nro_caja_jub);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@piso_dpto", obj.piso_dpto);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@e_mail", obj.e_mail);
                    cmd.Parameters.AddWithValue("@cod_subtipo", obj.cod_subtipo);
                    cmd.Parameters.AddWithValue("@retencionSi", obj.retencionSi);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@usuariomodifica", obj.usuariomodifica);
                    cmd.Parameters.AddWithValue("@fecha_modificacion", obj.fecha_modificacion);
                    cmd.Parameters.AddWithValue("@baja", obj.baja);
                    cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja);
                    cmd.Parameters.AddWithValue("@usuariobaja", obj.usuariobaja);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Proveedores obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Proveedores ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_proveedor=@cod_proveedor");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_proveedor", obj.cod_proveedor);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string FechaServer()
        {

            string fecha = "";
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = null;

            cmd = new SqlCommand();

            string strSQL = "SELECT CONVERT(VARCHAR(10), GETDATE(),103) as fecha";
            try
            {
                cn = GetConnectionSIIMVA();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fecha = dr.GetString(dr.GetOrdinal("fecha"));
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cn.Close();
                cmd = null;
            }
            return fecha;
        }

    }
}

