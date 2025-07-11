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
    public class Detalle_orden_pedido : DALBase
    {
        public int Nro_orden_pedido { get; set; }
        public int Nro_item { get; set; }
        public string Desc_item { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public int Ejercicio { get; set; }
        public int Anexo { get; set; }
        public int Inciso { get; set; }
        public int Partida_prin { get; set; }
        public int Item { get; set; }
        public int Sub_item { get; set; }
        public int Partida { get; set; }
        public int Sub_partida { get; set; }
        public int Id_secretaria { get; set; }
        public int Id_direccion { get; set; }
        public string Nro_cuenta { get; set; }
        public string Usuario { get; set; }
        public int id_oficina { get; set; }
        public int id_programa { get; set; }

        public Detalle_orden_pedido()
        {
            Nro_orden_pedido = 0;
            Nro_item = 0;
            Desc_item = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
            Ejercicio = 0;
            Anexo = 0;
            Inciso = 0;
            Partida_prin = 0;
            Item = 0;
            Sub_item = 0;
            Partida = 0;
            Sub_partida = 0;
            Id_secretaria = 0;
            Id_direccion = 0;
            Nro_cuenta = string.Empty;
            Usuario = string.Empty;
            id_oficina = 0;
            id_programa = 0;
        }

        private static List<Detalle_orden_pedido> mapeo(SqlDataReader dr)
        {
            List<Detalle_orden_pedido> lst = new List<Detalle_orden_pedido>();
            Detalle_orden_pedido obj;
            if (dr.HasRows)
            {
                int Nro_orden_pedido = dr.GetOrdinal("Nro_orden_pedido");
                int Nro_item = dr.GetOrdinal("Nro_item");
                int Desc_item = dr.GetOrdinal("Desc_item");
                int Cantidad = dr.GetOrdinal("Cantidad");
                int Precio = dr.GetOrdinal("Precio");
                int Importe = dr.GetOrdinal("Importe");
                int Ejercicio = dr.GetOrdinal("Ejercicio");
                int Anexo = dr.GetOrdinal("Anexo");
                int Inciso = dr.GetOrdinal("Inciso");
                int Partida_prin = dr.GetOrdinal("Partida_prin");
                int Item = dr.GetOrdinal("Item");
                int Sub_item = dr.GetOrdinal("Sub_item");
                int Partida = dr.GetOrdinal("Partida");
                int Sub_partida = dr.GetOrdinal("Sub_partida");
                int Id_secretaria = dr.GetOrdinal("Id_secretaria");
                int Id_direccion = dr.GetOrdinal("Id_direccion");
                int Nro_cuenta = dr.GetOrdinal("Nro_cuenta");
                int Usuario = dr.GetOrdinal("Usuario");
                int id_oficina = dr.GetOrdinal("id_oficina");
                int id_programa = dr.GetOrdinal("id_programa");
                while (dr.Read())
                {
                    obj = new Detalle_orden_pedido();
                    if (!dr.IsDBNull(Nro_orden_pedido)) { obj.Nro_orden_pedido = dr.GetInt32(Nro_orden_pedido); }
                    if (!dr.IsDBNull(Nro_item)) { obj.Nro_item = dr.GetInt32(Nro_item); }
                    if (!dr.IsDBNull(Desc_item)) { obj.Desc_item = dr.GetString(Desc_item); }
                    if (!dr.IsDBNull(Cantidad)) { obj.Cantidad = dr.GetDecimal(Cantidad); }
                    if (!dr.IsDBNull(Precio)) { obj.Precio = dr.GetDecimal(Precio); }
                    if (!dr.IsDBNull(Importe)) { obj.Importe = dr.GetDecimal(Importe); }
                    if (!dr.IsDBNull(Ejercicio)) { obj.Ejercicio = dr.GetInt32(Ejercicio); }
                    if (!dr.IsDBNull(Anexo)) { obj.Anexo = dr.GetInt32(Anexo); }
                    if (!dr.IsDBNull(Inciso)) { obj.Inciso = dr.GetInt32(Inciso); }
                    if (!dr.IsDBNull(Partida_prin)) { obj.Partida_prin = dr.GetInt32(Partida_prin); }
                    if (!dr.IsDBNull(Item)) { obj.Item = dr.GetInt32(Item); }
                    if (!dr.IsDBNull(Sub_item)) { obj.Sub_item = dr.GetInt32(Sub_item); }
                    if (!dr.IsDBNull(Partida)) { obj.Partida = dr.GetInt32(Partida); }
                    if (!dr.IsDBNull(Sub_partida)) { obj.Sub_partida = dr.GetInt32(Sub_partida); }
                    if (!dr.IsDBNull(Id_secretaria)) { obj.Id_secretaria = dr.GetInt32(Id_secretaria); }
                    if (!dr.IsDBNull(Id_direccion)) { obj.Id_direccion = dr.GetInt32(Id_direccion); }
                    if (!dr.IsDBNull(Nro_cuenta)) { obj.Nro_cuenta = dr.GetString(Nro_cuenta); }
                    if (!dr.IsDBNull(Usuario)) { obj.Usuario = dr.GetString(Usuario); }
                    if (!dr.IsDBNull(id_oficina)) { obj.id_oficina = dr.GetInt32(id_oficina); }
                    if (!dr.IsDBNull(id_programa)) { obj.id_programa = dr.GetInt32(id_programa); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Detalle_orden_pedido> read()
        {
            try
            {
                List<Detalle_orden_pedido> lst = new List<Detalle_orden_pedido>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Detalle_orden_pedido";
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

        public static Detalle_orden_pedido getByPk(int Nro_orden_pedido, int Nro_item)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Detalle_orden_pedido WHERE");
                sql.AppendLine("Nro_orden_pedido = @Nro_orden_pedido");
                sql.AppendLine("AND Nro_item = @Nro_item");
                Detalle_orden_pedido obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_orden_pedido", Nro_orden_pedido);
                    cmd.Parameters.AddWithValue("@Nro_item", Nro_item);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Detalle_orden_pedido> lst = mapeo(dr);
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

        public static List<Detalle_orden_pedido> GetByNro_pedido(int Nro_orden_pedido)
        {
            try
            {
                string sql = @"SELECT * 
                               FROM Detalle_orden_pedido 
                               WHERE Nro_orden_pedido = @Nro_orden_pedido";
                List<Detalle_orden_pedido> lst = new List<Detalle_orden_pedido>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_orden_pedido", Nro_orden_pedido);
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

        public static int insert(Detalle_orden_pedido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Detalle_orden_pedido(");
                sql.AppendLine("Nro_orden_pedido");
                sql.AppendLine(", Nro_item");
                sql.AppendLine(", Desc_item");
                sql.AppendLine(", Cantidad");
                sql.AppendLine(", Precio");
                sql.AppendLine(", Importe");
                sql.AppendLine(", Ejercicio");
                sql.AppendLine(", Anexo");
                sql.AppendLine(", Inciso");
                sql.AppendLine(", Partida_prin");
                sql.AppendLine(", Item");
                sql.AppendLine(", Sub_item");
                sql.AppendLine(", Partida");
                sql.AppendLine(", Sub_partida");
                sql.AppendLine(", Id_secretaria");
                sql.AppendLine(", Id_direccion");
                sql.AppendLine(", Nro_cuenta");
                sql.AppendLine(", Usuario");
                sql.AppendLine(", id_oficina");
                sql.AppendLine(", id_programa");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Nro_orden_pedido");
                sql.AppendLine(", @Nro_item");
                sql.AppendLine(", @Desc_item");
                sql.AppendLine(", @Cantidad");
                sql.AppendLine(", @Precio");
                sql.AppendLine(", @Importe");
                sql.AppendLine(", @Ejercicio");
                sql.AppendLine(", @Anexo");
                sql.AppendLine(", @Inciso");
                sql.AppendLine(", @Partida_prin");
                sql.AppendLine(", @Item");
                sql.AppendLine(", @Sub_item");
                sql.AppendLine(", @Partida");
                sql.AppendLine(", @Sub_partida");
                sql.AppendLine(", @Id_secretaria");
                sql.AppendLine(", @Id_direccion");
                sql.AppendLine(", @Nro_cuenta");
                sql.AppendLine(", @Usuario");
                sql.AppendLine(", @id_oficina");
                sql.AppendLine(", @id_programa");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_orden_pedido", obj.Nro_orden_pedido);
                    cmd.Parameters.AddWithValue("@Nro_item", obj.Nro_item);
                    cmd.Parameters.AddWithValue("@Desc_item", obj.Desc_item);
                    cmd.Parameters.AddWithValue("@Cantidad", obj.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("@Importe", obj.Importe);
                    cmd.Parameters.AddWithValue("@Ejercicio", obj.Ejercicio);
                    cmd.Parameters.AddWithValue("@Anexo", obj.Anexo);
                    cmd.Parameters.AddWithValue("@Inciso", obj.Inciso);
                    cmd.Parameters.AddWithValue("@Partida_prin", obj.Partida_prin);
                    cmd.Parameters.AddWithValue("@Item", obj.Item);
                    cmd.Parameters.AddWithValue("@Sub_item", obj.Sub_item);
                    cmd.Parameters.AddWithValue("@Partida", obj.Partida);
                    cmd.Parameters.AddWithValue("@Sub_partida", obj.Sub_partida);
                    cmd.Parameters.AddWithValue("@Id_secretaria", obj.Id_secretaria);
                    cmd.Parameters.AddWithValue("@Id_direccion", obj.Id_direccion);
                    cmd.Parameters.AddWithValue("@Nro_cuenta", obj.Nro_cuenta);
                    cmd.Parameters.AddWithValue("@Usuario", obj.Usuario);
                    cmd.Parameters.AddWithValue("@id_oficina", obj.id_oficina);
                    cmd.Parameters.AddWithValue("@id_programa", obj.id_programa);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Detalle_orden_pedido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Detalle_orden_pedido SET");
                sql.AppendLine("Desc_item=@Desc_item");
                sql.AppendLine(", Cantidad=@Cantidad");
                sql.AppendLine(", Precio=@Precio");
                sql.AppendLine(", Importe=@Importe");
                sql.AppendLine(", Ejercicio=@Ejercicio");
                sql.AppendLine(", Anexo=@Anexo");
                sql.AppendLine(", Inciso=@Inciso");
                sql.AppendLine(", Partida_prin=@Partida_prin");
                sql.AppendLine(", Item=@Item");
                sql.AppendLine(", Sub_item=@Sub_item");
                sql.AppendLine(", Partida=@Partida");
                sql.AppendLine(", Sub_partida=@Sub_partida");
                sql.AppendLine(", Id_secretaria=@Id_secretaria");
                sql.AppendLine(", Id_direccion=@Id_direccion");
                sql.AppendLine(", Nro_cuenta=@Nro_cuenta");
                sql.AppendLine(", Usuario=@Usuario");
                sql.AppendLine(", id_oficina=@id_oficina");
                sql.AppendLine(", id_programa=@id_programa");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_orden_pedido=@Nro_orden_pedido");
                sql.AppendLine("AND Nro_item=@Nro_item");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_orden_pedido", obj.Nro_orden_pedido);
                    cmd.Parameters.AddWithValue("@Nro_item", obj.Nro_item);
                    cmd.Parameters.AddWithValue("@Desc_item", obj.Desc_item);
                    cmd.Parameters.AddWithValue("@Cantidad", obj.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("@Importe", obj.Importe);
                    cmd.Parameters.AddWithValue("@Ejercicio", obj.Ejercicio);
                    cmd.Parameters.AddWithValue("@Anexo", obj.Anexo);
                    cmd.Parameters.AddWithValue("@Inciso", obj.Inciso);
                    cmd.Parameters.AddWithValue("@Partida_prin", obj.Partida_prin);
                    cmd.Parameters.AddWithValue("@Item", obj.Item);
                    cmd.Parameters.AddWithValue("@Sub_item", obj.Sub_item);
                    cmd.Parameters.AddWithValue("@Partida", obj.Partida);
                    cmd.Parameters.AddWithValue("@Sub_partida", obj.Sub_partida);
                    cmd.Parameters.AddWithValue("@Id_secretaria", obj.Id_secretaria);
                    cmd.Parameters.AddWithValue("@Id_direccion", obj.Id_direccion);
                    cmd.Parameters.AddWithValue("@Nro_cuenta", obj.Nro_cuenta);
                    cmd.Parameters.AddWithValue("@Usuario", obj.Usuario);
                    cmd.Parameters.AddWithValue("@id_oficina", obj.id_oficina);
                    cmd.Parameters.AddWithValue("@id_programa", obj.id_programa);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Detalle_orden_pedido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Detalle_orden_pedido ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_orden_pedido=@Nro_orden_pedido");
                sql.AppendLine("AND Nro_item=@Nro_item");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_orden_pedido", obj.Nro_orden_pedido);
                    cmd.Parameters.AddWithValue("@Nro_item", obj.Nro_item);
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

