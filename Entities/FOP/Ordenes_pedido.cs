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
    public class Ordenes_pedido : DALBase
    {
        public int nro_orden_pedido { get; set; }
        public string fecha_orden_pedido { get; set; }
        public decimal total { get; set; }
        public decimal saldo { get; set; }
        public int cod_proveedor { get; set; }
        public int cod_oficina_origen { get; set; }
        public int cod_oficina_destino { get; set; }
        public string solicitante { get; set; }
        public string aprobado { get; set; }
        public bool anulado { get; set; }
        public string usuario { get; set; }
        public string observacion { get; set; }
        public bool finalizado { get; set; }
        public short asignado { get; set; }
        public int nro_orden_compra { get; set; }
        public string forma_pago { get; set; }
        public string nro_presupuesto { get; set; }
        public string nro_facturas { get; set; }
        public DateTime fecha_orden_compra { get; set; }
        public short recibida { get; set; }
        public DateTime fecha_recepcion { get; set; }
        public short web { get; set; }
        public string entregadaPor { get; set; }
        public DateTime fecha_aprobacion { get; set; }
        public short cod_estado_op { get; set; }
        public int id_liq_tk { get; set; }
        public string nom_proveedor { get; set; }
        public string oficina_destino { get; set; }

        public string status { get; set; }

        public Ordenes_pedido()
        {
            nro_orden_pedido = 0;
            fecha_orden_pedido = DateTime.Today.ToShortDateString();
            total = 0;
            saldo = 0;
            cod_proveedor = 0;
            cod_oficina_origen = 0;
            cod_oficina_destino = 0;
            solicitante = string.Empty;
            aprobado = string.Empty;
            anulado = false;
            usuario = string.Empty;
            observacion = string.Empty;
            finalizado = false;
            asignado = 0;
            nro_orden_compra = 0;
            forma_pago = string.Empty;
            nro_presupuesto = string.Empty;
            nro_facturas = string.Empty;
            fecha_orden_compra = DateTime.Now;
            recibida = 0;
            fecha_recepcion = DateTime.Now;
            web = 0;
            entregadaPor = string.Empty;
            fecha_aprobacion = DateTime.Now;
            cod_estado_op = 0;
            id_liq_tk = 0;
            nom_proveedor = string.Empty;
            oficina_destino = string.Empty;
            status = string.Empty;
        }
        private static List<Ordenes_pedido> mapeo(SqlDataReader dr)
        {
            List<Ordenes_pedido> lst = new List<Ordenes_pedido>();
            Ordenes_pedido obj;
            if (dr.HasRows)
            {
                int Nro_orden_pedido = dr.GetOrdinal("Nro_orden_pedido");
                int Fecha_orden_pedido = dr.GetOrdinal("Fecha_orden_pedido");
                int Total = dr.GetOrdinal("Total");
                int Saldo = dr.GetOrdinal("Saldo");
                int Cod_proveedor = dr.GetOrdinal("Cod_proveedor");
                int Cod_oficina_origen = dr.GetOrdinal("Cod_oficina_origen");
                int Cod_oficina_destino = dr.GetOrdinal("Cod_oficina_destino");
                int Solicitante = dr.GetOrdinal("Solicitante");
                int Aprobado = dr.GetOrdinal("Aprobado");
                int Anulado = dr.GetOrdinal("Anulado");
                int Usuario = dr.GetOrdinal("Usuario");
                int Observacion = dr.GetOrdinal("Observacion");
                int Finalizado = dr.GetOrdinal("Finalizado");
                int Asignado = dr.GetOrdinal("Asignado");
                int Nro_orden_compra = dr.GetOrdinal("Nro_orden_compra");
                int Forma_pago = dr.GetOrdinal("Forma_pago");
                int Nro_presupuesto = dr.GetOrdinal("Nro_presupuesto");
                int Nro_facturas = dr.GetOrdinal("Nro_facturas");
                int Fecha_orden_compra = dr.GetOrdinal("Fecha_orden_compra");
                int Recibida = dr.GetOrdinal("Recibida");
                int Fecha_recepcion = dr.GetOrdinal("Fecha_recepcion");
                int Web = dr.GetOrdinal("Web");
                int EntregadaPor = dr.GetOrdinal("EntregadaPor");
                int Fecha_aprobacion = dr.GetOrdinal("Fecha_aprobacion");
                int Cod_estado_op = dr.GetOrdinal("Cod_estado_op");
                int Id_liq_tk = dr.GetOrdinal("Id_liq_tk");
                int nom_proveedor = dr.GetOrdinal("nom_proveedor");
                int oficina_destino = dr.GetOrdinal("oficina_destino");
                int status = dr.GetOrdinal("status");
                while (dr.Read())
                {
                    obj = new Ordenes_pedido();
                    if (!dr.IsDBNull(Nro_orden_pedido)) { obj.nro_orden_pedido = dr.GetInt32(Nro_orden_pedido); }
                    if (!dr.IsDBNull(Fecha_orden_pedido)) { obj.fecha_orden_pedido = dr.GetDateTime(Fecha_orden_pedido).ToShortDateString(); }
                    if (!dr.IsDBNull(Total)) { obj.total = dr.GetDecimal(Total); }
                    if (!dr.IsDBNull(Saldo)) { obj.saldo = dr.GetDecimal(Saldo); }
                    if (!dr.IsDBNull(Cod_proveedor)) { obj.cod_proveedor = dr.GetInt32(Cod_proveedor); }
                    if (!dr.IsDBNull(Cod_oficina_origen)) { obj.cod_oficina_origen = dr.GetInt32(Cod_oficina_origen); }
                    if (!dr.IsDBNull(Cod_oficina_destino)) { obj.cod_oficina_destino = dr.GetInt32(Cod_oficina_destino); }
                    if (!dr.IsDBNull(Solicitante)) { obj.solicitante = dr.GetString(Solicitante); }
                    if (!dr.IsDBNull(Aprobado)) { obj.aprobado = dr.GetString(Aprobado); }
                    if (!dr.IsDBNull(Anulado)) { obj.anulado = dr.GetBoolean(Anulado); }
                    if (!dr.IsDBNull(Usuario)) { obj.usuario = dr.GetString(Usuario); }
                    if (!dr.IsDBNull(Observacion)) { obj.observacion = dr.GetString(Observacion); }
                    if (!dr.IsDBNull(Finalizado)) { obj.finalizado = dr.GetBoolean(Finalizado); }
                    if (!dr.IsDBNull(Asignado)) { obj.asignado = dr.GetInt16(Asignado); }
                    if (!dr.IsDBNull(Nro_orden_compra)) { obj.nro_orden_compra = dr.GetInt32(Nro_orden_compra); }
                    if (!dr.IsDBNull(Forma_pago)) { obj.forma_pago = dr.GetString(Forma_pago); }
                    if (!dr.IsDBNull(Nro_presupuesto)) { obj.nro_presupuesto = dr.GetString(Nro_presupuesto); }
                    if (!dr.IsDBNull(Nro_facturas)) { obj.nro_facturas = dr.GetString(Nro_facturas); }
                    if (!dr.IsDBNull(Fecha_orden_compra)) { obj.fecha_orden_compra = dr.GetDateTime(Fecha_orden_compra); }
                    if (!dr.IsDBNull(Recibida)) { obj.recibida = dr.GetInt16(Recibida); }
                    if (!dr.IsDBNull(Fecha_recepcion)) { obj.fecha_recepcion = dr.GetDateTime(Fecha_recepcion); }
                    if (!dr.IsDBNull(Web)) { obj.web = dr.GetInt16(Web); }
                    if (!dr.IsDBNull(EntregadaPor)) { obj.entregadaPor = dr.GetString(EntregadaPor); }
                    if (!dr.IsDBNull(Fecha_aprobacion)) { obj.fecha_aprobacion = dr.GetDateTime(Fecha_aprobacion); }
                    if (!dr.IsDBNull(Cod_estado_op)) { obj.cod_estado_op = dr.GetInt16(Cod_estado_op); }
                    if (!dr.IsDBNull(Id_liq_tk)) { obj.id_liq_tk = dr.GetInt32(Id_liq_tk); }
                    if (!dr.IsDBNull(nom_proveedor)) { obj.nom_proveedor = dr.GetString(nom_proveedor); }
                    if (!dr.IsDBNull(oficina_destino)) { obj.oficina_destino = dr.GetString(oficina_destino); }
                    if (!dr.IsDBNull(status)) { obj.status = dr.GetString(status); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<Ordenes_pedido> read()
        {
            try
            {
                List<Ordenes_pedido> lst = new List<Ordenes_pedido>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Ordenes_pedido";
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
        public static List<Ordenes_pedido> readOrdenesByProveedor(int cod_proveedor)
        {
            try
            {
                List<Ordenes_pedido> lst = new List<Ordenes_pedido>();
                string strSQL = @"SELECT a.*, p.nom_proveedor as nom_proveedor, 
                                    o.nombre_oficina as oficina_destino,
                                    CASE
	                                    WHEN a.anulado =1 THEN 'Rechazada'
	                                    WHEN a.recibida = 1 THEN 'Aprobada'
	                                    WHEN a.Finalizado = 1 THEN 'Finalizada'
                                        ELSE 'Pendiente'
                                    END AS status
                                    FROM Ordenes_pedido a
                                    LEFT JOIN PROVEEDORES p on
                                    a.cod_proveedor=p.cod_proveedor
                                    LEFT JOIN OFICINAS o on
                                    a.Cod_oficina_destino=o.codigo_oficina
                                    WHERE a.Cod_proveedor=@cod_proveedor
                                    ORDER By a.nro_orden_pedido desc";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@cod_proveedor", cod_proveedor);
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
        public static List<Ordenes_pedido> readOrdenesByCuit(string cuit)
        {
            try
            {
                List<Ordenes_pedido> lst = new List<Ordenes_pedido>();
                string strSQL = @"SELECT a.*, p.nom_proveedor as nom_proveedor, 
                                    o.nombre_oficina as oficina_destino,
                                    CASE
	                                    WHEN a.anulado =1 THEN 'Rechazada'
	                                    WHEN a.recibida = 1 THEN 'Aprobada'
	                                    WHEN a.Finalizado = 1 THEN 'Finalizada'
                                        ELSE 'Pendiente'
                                    END AS status
                                    FROM Ordenes_pedido a
                                    LEFT JOIN PROVEEDORES p on
                                    a.cod_proveedor=p.cod_proveedor
                                    LEFT JOIN OFICINAS o on
                                    a.Cod_oficina_destino=o.codigo_oficina
                                    WHERE p.nro_cuit=@cuit
                                    ORDER By a.nro_orden_pedido desc";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@cuit", cuit);
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
        public static Ordenes_pedido getByPk(int Nro_orden_pedido)
        {
            try
            {
                string strSQL = @"SELECT a.*, p.nom_proveedor as nom_proveedor, 
                                    o.nombre_oficina as oficina_destino,
                                    CASE
	                                    WHEN a.anulado =1 THEN 'Rechazada'
	                                    WHEN a.recibida = 1 THEN 'Aprobada'
	                                    WHEN a.Finalizado = 1 THEN 'Finalizada'
                                        ELSE 'Pendiente'
                                    END AS status
                                    FROM Ordenes_pedido a
                                    LEFT JOIN PROVEEDORES p on
                                    a.cod_proveedor=p.cod_proveedor
                                    LEFT JOIN OFICINAS o on
                                    a.Cod_oficina_destino=o.codigo_oficina
                                    WHERE a.nro_orden_pedido=@nro_orden_pedido
                                    ORDER By a.nro_orden_pedido desc";

                Ordenes_pedido obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@Nro_orden_pedido", Nro_orden_pedido);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Ordenes_pedido> lst = mapeo(dr);
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
        public static int insert(Ordenes_pedido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Ordenes_pedido(");
                sql.AppendLine("Nro_orden_pedido");
                sql.AppendLine(", Fecha_orden_pedido");
                sql.AppendLine(", Total");
                sql.AppendLine(", Saldo");
                sql.AppendLine(", Cod_proveedor");
                sql.AppendLine(", Cod_oficina_origen");
                sql.AppendLine(", Cod_oficina_destino");
                sql.AppendLine(", Solicitante");
                sql.AppendLine(", Aprobado");
                sql.AppendLine(", Anulado");
                sql.AppendLine(", Usuario");
                sql.AppendLine(", Observacion");
                sql.AppendLine(", Finalizado");
                sql.AppendLine(", Asignado");
                sql.AppendLine(", Nro_orden_compra");
                sql.AppendLine(", Forma_pago");
                sql.AppendLine(", Nro_presupuesto");
                sql.AppendLine(", Nro_facturas");
                sql.AppendLine(", Fecha_orden_compra");
                sql.AppendLine(", Recibida");
                sql.AppendLine(", Fecha_recepcion");
                sql.AppendLine(", Web");
                sql.AppendLine(", EntregadaPor");
                sql.AppendLine(", Fecha_aprobacion");
                sql.AppendLine(", Cod_estado_op");
                sql.AppendLine(", Id_liq_tk");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Nro_orden_pedido");
                sql.AppendLine(", @Fecha_orden_pedido");
                sql.AppendLine(", @Total");
                sql.AppendLine(", @Saldo");
                sql.AppendLine(", @Cod_proveedor");
                sql.AppendLine(", @Cod_oficina_origen");
                sql.AppendLine(", @Cod_oficina_destino");
                sql.AppendLine(", @Solicitante");
                sql.AppendLine(", @Aprobado");
                sql.AppendLine(", @Anulado");
                sql.AppendLine(", @Usuario");
                sql.AppendLine(", @Observacion");
                sql.AppendLine(", @Finalizado");
                sql.AppendLine(", @Asignado");
                sql.AppendLine(", @Nro_orden_compra");
                sql.AppendLine(", @Forma_pago");
                sql.AppendLine(", @Nro_presupuesto");
                sql.AppendLine(", @Nro_facturas");
                sql.AppendLine(", @Fecha_orden_compra");
                sql.AppendLine(", @Recibida");
                sql.AppendLine(", @Fecha_recepcion");
                sql.AppendLine(", @Web");
                sql.AppendLine(", @EntregadaPor");
                sql.AppendLine(", @Fecha_aprobacion");
                sql.AppendLine(", @Cod_estado_op");
                sql.AppendLine(", @Id_liq_tk");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_orden_pedido", obj.nro_orden_pedido);
                    cmd.Parameters.AddWithValue("@Fecha_orden_pedido", obj.fecha_orden_pedido);
                    cmd.Parameters.AddWithValue("@Total", obj.total);
                    cmd.Parameters.AddWithValue("@Saldo", obj.saldo);
                    cmd.Parameters.AddWithValue("@Cod_proveedor", obj.cod_proveedor);
                    cmd.Parameters.AddWithValue("@Cod_oficina_origen", obj.cod_oficina_origen);
                    cmd.Parameters.AddWithValue("@Cod_oficina_destino", obj.cod_oficina_destino);
                    cmd.Parameters.AddWithValue("@Solicitante", obj.solicitante);
                    cmd.Parameters.AddWithValue("@Aprobado", obj.aprobado);
                    cmd.Parameters.AddWithValue("@Anulado", obj.anulado);
                    cmd.Parameters.AddWithValue("@Usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@Observacion", obj.observacion);
                    cmd.Parameters.AddWithValue("@Finalizado", obj.finalizado);
                    cmd.Parameters.AddWithValue("@Asignado", obj.asignado);
                    cmd.Parameters.AddWithValue("@Nro_orden_compra", obj.nro_orden_compra);
                    cmd.Parameters.AddWithValue("@Forma_pago", obj.forma_pago);
                    cmd.Parameters.AddWithValue("@Nro_presupuesto", obj.nro_presupuesto);
                    cmd.Parameters.AddWithValue("@Nro_facturas", obj.nro_facturas);
                    cmd.Parameters.AddWithValue("@Fecha_orden_compra", obj.fecha_orden_compra);
                    cmd.Parameters.AddWithValue("@Recibida", obj.recibida);
                    cmd.Parameters.AddWithValue("@Fecha_recepcion", obj.fecha_recepcion);
                    cmd.Parameters.AddWithValue("@Web", obj.web);
                    cmd.Parameters.AddWithValue("@EntregadaPor", obj.entregadaPor);
                    cmd.Parameters.AddWithValue("@Fecha_aprobacion", obj.fecha_aprobacion);
                    cmd.Parameters.AddWithValue("@Cod_estado_op", obj.cod_estado_op);
                    cmd.Parameters.AddWithValue("@Id_liq_tk", obj.id_liq_tk);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void update(Ordenes_pedido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Ordenes_pedido SET");
                sql.AppendLine("Fecha_orden_pedido=@Fecha_orden_pedido");
                sql.AppendLine(", Total=@Total");
                sql.AppendLine(", Saldo=@Saldo");
                sql.AppendLine(", Cod_proveedor=@Cod_proveedor");
                sql.AppendLine(", Cod_oficina_origen=@Cod_oficina_origen");
                sql.AppendLine(", Cod_oficina_destino=@Cod_oficina_destino");
                sql.AppendLine(", Solicitante=@Solicitante");
                sql.AppendLine(", Aprobado=@Aprobado");
                sql.AppendLine(", Anulado=@Anulado");
                sql.AppendLine(", Usuario=@Usuario");
                sql.AppendLine(", Observacion=@Observacion");
                sql.AppendLine(", Finalizado=@Finalizado");
                sql.AppendLine(", Asignado=@Asignado");
                sql.AppendLine(", Nro_orden_compra=@Nro_orden_compra");
                sql.AppendLine(", Forma_pago=@Forma_pago");
                sql.AppendLine(", Nro_presupuesto=@Nro_presupuesto");
                sql.AppendLine(", Nro_facturas=@Nro_facturas");
                sql.AppendLine(", Fecha_orden_compra=@Fecha_orden_compra");
                sql.AppendLine(", Recibida=@Recibida");
                sql.AppendLine(", Fecha_recepcion=@Fecha_recepcion");
                sql.AppendLine(", Web=@Web");
                sql.AppendLine(", EntregadaPor=@EntregadaPor");
                sql.AppendLine(", Fecha_aprobacion=@Fecha_aprobacion");
                sql.AppendLine(", Cod_estado_op=@Cod_estado_op");
                sql.AppendLine(", Id_liq_tk=@Id_liq_tk");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_orden_pedido=@Nro_orden_pedido");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_orden_pedido", obj.nro_orden_pedido);
                    cmd.Parameters.AddWithValue("@Fecha_orden_pedido", obj.fecha_orden_pedido);
                    cmd.Parameters.AddWithValue("@Total", obj.total);
                    cmd.Parameters.AddWithValue("@Saldo", obj.saldo);
                    cmd.Parameters.AddWithValue("@Cod_proveedor", obj.cod_proveedor);
                    cmd.Parameters.AddWithValue("@Cod_oficina_origen", obj.cod_oficina_origen);
                    cmd.Parameters.AddWithValue("@Cod_oficina_destino", obj.cod_oficina_destino);
                    cmd.Parameters.AddWithValue("@Solicitante", obj.solicitante);
                    cmd.Parameters.AddWithValue("@Aprobado", obj.aprobado);
                    cmd.Parameters.AddWithValue("@Anulado", obj.anulado);
                    cmd.Parameters.AddWithValue("@Usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@Observacion", obj.observacion);
                    cmd.Parameters.AddWithValue("@Finalizado", obj.finalizado);
                    cmd.Parameters.AddWithValue("@Asignado", obj.asignado);
                    cmd.Parameters.AddWithValue("@Nro_orden_compra", obj.nro_orden_compra);
                    cmd.Parameters.AddWithValue("@Forma_pago", obj.forma_pago);
                    cmd.Parameters.AddWithValue("@Nro_presupuesto", obj.nro_presupuesto);
                    cmd.Parameters.AddWithValue("@Nro_facturas", obj.nro_facturas);
                    cmd.Parameters.AddWithValue("@Fecha_orden_compra", obj.fecha_orden_compra);
                    cmd.Parameters.AddWithValue("@Recibida", obj.recibida);
                    cmd.Parameters.AddWithValue("@Fecha_recepcion", obj.fecha_recepcion);
                    cmd.Parameters.AddWithValue("@Web", obj.web);
                    cmd.Parameters.AddWithValue("@EntregadaPor", obj.entregadaPor);
                    cmd.Parameters.AddWithValue("@Fecha_aprobacion", obj.fecha_aprobacion);
                    cmd.Parameters.AddWithValue("@Cod_estado_op", obj.cod_estado_op);
                    cmd.Parameters.AddWithValue("@Id_liq_tk", obj.id_liq_tk);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(Ordenes_pedido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Ordenes_pedido ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_orden_pedido=@Nro_orden_pedido");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_orden_pedido", obj.nro_orden_pedido);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}

