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
    public class PROFESIONALES : DALBase
    {
        public int id { get; set; }
        public DateTime fecha_alta { get; set; }
        public string dni { get; set; }
        public string cuit { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string calle_dom { get; set; }
        public string nro_dom { get; set; }
        public string piso_dpto_dom { get; set; }
        public string barrio_dom { get; set; }
        public string ciudad_dom { get; set; }
        public string provincia_dom { get; set; }
        public string cod_postal_dom { get; set; }
        public string celular { get; set; }
        public string nro_matricula { get; set; }
        public int cod_especialidad { get; set; }
        public string path { get; set; }
        public bool validado { get; set; }
        public DateTime fecha_validacion { get; set; }
        public bool activo { get; set; }

        public PROFESIONALES()
        {
            id = 0;
            fecha_alta = DateTime.Now;
            dni = string.Empty;
            cuit = string.Empty;
            nombre = string.Empty;
            apellido = string.Empty;
            email = string.Empty;
            calle_dom = string.Empty;
            nro_dom = string.Empty;
            piso_dpto_dom = string.Empty;
            barrio_dom = string.Empty;
            ciudad_dom = string.Empty;
            provincia_dom = string.Empty;
            cod_postal_dom = string.Empty;
            celular = string.Empty;
            nro_matricula = string.Empty;
            cod_especialidad = 0;
            path = string.Empty;
            validado = false;
            fecha_validacion = DateTime.Now;
            activo = false;
        }

        private static List<PROFESIONALES> mapeo(SqlDataReader dr)
        {
            List<PROFESIONALES> lst = new List<PROFESIONALES>();
            PROFESIONALES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PROFESIONALES();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.fecha_alta = dr.GetDateTime(1); }
                    if (!dr.IsDBNull(2)) { obj.dni = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.cuit = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.nombre = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.apellido = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.email = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.calle_dom = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.nro_dom = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.piso_dpto_dom = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.barrio_dom = dr.GetString(10); }
                    if (!dr.IsDBNull(11)) { obj.ciudad_dom = dr.GetString(11); }
                    if (!dr.IsDBNull(12)) { obj.provincia_dom = dr.GetString(12); }
                    if (!dr.IsDBNull(13)) { obj.cod_postal_dom = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.celular = dr.GetString(14); }
                    if (!dr.IsDBNull(15)) { obj.nro_matricula = dr.GetString(15); }
                    if (!dr.IsDBNull(16)) { obj.cod_especialidad = dr.GetInt32(16); }
                    if (!dr.IsDBNull(17)) { obj.path = dr.GetString(17); }
                    if (!dr.IsDBNull(18)) { obj.validado = dr.GetBoolean(18); }
                    if (!dr.IsDBNull(19)) { obj.fecha_validacion = dr.GetDateTime(19); }
                    if (!dr.IsDBNull(20)) { obj.activo = dr.GetBoolean(20); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PROFESIONALES> read()
        {
            try
            {
                List<PROFESIONALES> lst = new List<PROFESIONALES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM PROFESIONALES";
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

        public static PROFESIONALES getByPk(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PROFESIONALES WHERE");
                sql.AppendLine("id = @id");
                PROFESIONALES obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PROFESIONALES> lst = mapeo(dr);
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

        public static int insert(PROFESIONALES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO PROFESIONALES(");
                sql.AppendLine("fecha_alta");
                sql.AppendLine(", dni");
                sql.AppendLine(", cuit");
                sql.AppendLine(", nombre");
                sql.AppendLine(", apellido");
                sql.AppendLine(", email");
                sql.AppendLine(", calle_dom");
                sql.AppendLine(", nro_dom");
                sql.AppendLine(", piso_dpto_dom");
                sql.AppendLine(", barrio_dom");
                sql.AppendLine(", ciudad_dom");
                sql.AppendLine(", provincia_dom");
                sql.AppendLine(", cod_postal_dom");
                sql.AppendLine(", celular");
                sql.AppendLine(", nro_matricula");
                sql.AppendLine(", cod_especialidad");
                sql.AppendLine(", path");
                sql.AppendLine(", validado");
                sql.AppendLine(", fecha_validacion");
                sql.AppendLine(", activo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@fecha_alta");
                sql.AppendLine(", @dni");
                sql.AppendLine(", @cuit");
                sql.AppendLine(", @nombre");
                sql.AppendLine(", @apellido");
                sql.AppendLine(", @email");
                sql.AppendLine(", @calle_dom");
                sql.AppendLine(", @nro_dom");
                sql.AppendLine(", @piso_dpto_dom");
                sql.AppendLine(", @barrio_dom");
                sql.AppendLine(", @ciudad_dom");
                sql.AppendLine(", @provincia_dom");
                sql.AppendLine(", @cod_postal_dom");
                sql.AppendLine(", @celular");
                sql.AppendLine(", @nro_matricula");
                sql.AppendLine(", @cod_especialidad");
                sql.AppendLine(", @path");
                sql.AppendLine(", @validado");
                sql.AppendLine(", @fecha_validacion");
                sql.AppendLine(", @activo");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@dni", obj.dni);
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@apellido", obj.apellido);
                    cmd.Parameters.AddWithValue("@email", obj.email);
                    cmd.Parameters.AddWithValue("@calle_dom", obj.calle_dom);
                    cmd.Parameters.AddWithValue("@nro_dom", obj.nro_dom);
                    cmd.Parameters.AddWithValue("@piso_dpto_dom", obj.piso_dpto_dom);
                    cmd.Parameters.AddWithValue("@barrio_dom", obj.barrio_dom);
                    cmd.Parameters.AddWithValue("@ciudad_dom", obj.ciudad_dom);
                    cmd.Parameters.AddWithValue("@provincia_dom", obj.provincia_dom);
                    cmd.Parameters.AddWithValue("@cod_postal_dom", obj.cod_postal_dom);
                    cmd.Parameters.AddWithValue("@celular", obj.celular);
                    cmd.Parameters.AddWithValue("@nro_matricula", obj.nro_matricula);
                    cmd.Parameters.AddWithValue("@cod_especialidad", obj.cod_especialidad);
                    cmd.Parameters.AddWithValue("@path", obj.path);
                    cmd.Parameters.AddWithValue("@validado", obj.validado);
                    cmd.Parameters.AddWithValue("@fecha_validacion", obj.fecha_validacion);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(PROFESIONALES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  PROFESIONALES SET");
                sql.AppendLine("fecha_alta=@fecha_alta");
                sql.AppendLine(", dni=@dni");
                sql.AppendLine(", cuit=@cuit");
                sql.AppendLine(", nombre=@nombre");
                sql.AppendLine(", apellido=@apellido");
                sql.AppendLine(", email=@email");
                sql.AppendLine(", calle_dom=@calle_dom");
                sql.AppendLine(", nro_dom=@nro_dom");
                sql.AppendLine(", piso_dpto_dom=@piso_dpto_dom");
                sql.AppendLine(", barrio_dom=@barrio_dom");
                sql.AppendLine(", ciudad_dom=@ciudad_dom");
                sql.AppendLine(", provincia_dom=@provincia_dom");
                sql.AppendLine(", cod_postal_dom=@cod_postal_dom");
                sql.AppendLine(", celular=@celular");
                sql.AppendLine(", nro_matricula=@nro_matricula");
                sql.AppendLine(", cod_especialidad=@cod_especialidad");
                sql.AppendLine(", path=@path");
                sql.AppendLine(", validado=@validado");
                sql.AppendLine(", fecha_validacion=@fecha_validacion");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@dni", obj.dni);
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@apellido", obj.apellido);
                    cmd.Parameters.AddWithValue("@email", obj.email);
                    cmd.Parameters.AddWithValue("@calle_dom", obj.calle_dom);
                    cmd.Parameters.AddWithValue("@nro_dom", obj.nro_dom);
                    cmd.Parameters.AddWithValue("@piso_dpto_dom", obj.piso_dpto_dom);
                    cmd.Parameters.AddWithValue("@barrio_dom", obj.barrio_dom);
                    cmd.Parameters.AddWithValue("@ciudad_dom", obj.ciudad_dom);
                    cmd.Parameters.AddWithValue("@provincia_dom", obj.provincia_dom);
                    cmd.Parameters.AddWithValue("@cod_postal_dom", obj.cod_postal_dom);
                    cmd.Parameters.AddWithValue("@celular", obj.celular);
                    cmd.Parameters.AddWithValue("@nro_matricula", obj.nro_matricula);
                    cmd.Parameters.AddWithValue("@cod_especialidad", obj.cod_especialidad);
                    cmd.Parameters.AddWithValue("@path", obj.path);
                    cmd.Parameters.AddWithValue("@validado", obj.validado);
                    cmd.Parameters.AddWithValue("@fecha_validacion", obj.fecha_validacion);
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

        public static void delete(PROFESIONALES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  PROFESIONALES ");
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

