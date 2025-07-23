using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOTOR_WORKFLOW.Models;
using Web_Api_Contable.Entities.GENERAL;
using Web_Api_Contable.Models;
using WSAfip;

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
        private static int GenerarNuevoNroOrden(SqlConnection conn, SqlTransaction tx)
        {
            int nuevo;

            using (var cmd = new SqlCommand("SELECT Nro_orden_pedido FROM numeros_claves", conn, tx))
            {
                int max = (int)cmd.ExecuteScalar();
                nuevo = max + 1;
            }

            using (var updateCmd = new SqlCommand("UPDATE numeros_claves SET Nro_orden_pedido = @nuevo", conn, tx))
            {
                updateCmd.Parameters.AddWithValue("@nuevo", nuevo);
                updateCmd.ExecuteNonQuery();
            }

            return nuevo;
        }

        public static int insert(OrdenPedido obj, List<detalleOrdenPedido> detalleItems, Auditoria auditoria)
        {
            using (SqlConnection con = GetConnectionSIIMVA())
            {
                con.Open();

                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        // Generar nuevo número de orden y asignarlo
                        obj.nroOrdenPedido = GenerarNuevoNroOrden(con, tx);

                        StringBuilder sql = new StringBuilder();
                        sql.AppendLine("INSERT INTO Ordenes_pedido(");
                        sql.AppendLine("Nro_orden_pedido, Fecha_orden_pedido, Total, Saldo, Cod_proveedor,");
                        sql.AppendLine("Cod_oficina_origen, Cod_oficina_destino, Solicitante, Aprobado, Anulado,");
                        sql.AppendLine("Usuario, Observacion, Finalizado, Asignado, Nro_orden_compra, Forma_pago,");
                        sql.AppendLine("Nro_presupuesto, Nro_facturas, Fecha_orden_compra, Recibida, Fecha_recepcion,");
                        sql.AppendLine("Web, EntregadaPor, Fecha_aprobacion, Cod_estado_op, Id_liq_tk,");
                        sql.AppendLine("cod_secretaria_autoriza, cod_oficina_solicita, op_interna)");
                        sql.AppendLine("VALUES (");
                        sql.AppendLine("@Nro_orden_pedido, @Fecha_orden_pedido, @Total, @Saldo, @Cod_proveedor,");
                        sql.AppendLine("@Cod_oficina_origen, @Cod_oficina_destino, @Solicitante, @Aprobado, @Anulado,");
                        sql.AppendLine("@Usuario, @Observacion, @Finalizado, @Asignado, @Nro_orden_compra, @Forma_pago,");
                        sql.AppendLine("@Nro_presupuesto, @Nro_facturas, @Fecha_orden_compra, @Recibida, @Fecha_recepcion,");
                        sql.AppendLine("@Web, @EntregadaPor, @Fecha_aprobacion, @Cod_estado_op, @Id_liq_tk,");
                        sql.AppendLine("@cod_secretaria_autoriza, @cod_oficina_solicita, @op_interna)");

                        using (SqlCommand cmd = new SqlCommand(sql.ToString(), con, tx))
                        {
                            cmd.Parameters.AddWithValue("@Nro_orden_pedido", obj.nroOrdenPedido);
                            cmd.Parameters.AddWithValue("@Fecha_orden_pedido", obj.fechaOrdenPedido ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Total", obj.total ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Saldo", obj.saldo ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Cod_proveedor", obj.codProveedor ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Cod_oficina_origen", obj.codOficinaOrigen ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Cod_oficina_destino", obj.codOficinaDestino ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Solicitante", string.IsNullOrEmpty(obj.solicitante) ? (object)DBNull.Value : obj.solicitante);
                            cmd.Parameters.AddWithValue("@Aprobado", string.IsNullOrEmpty(obj.aprobado) ? (object)DBNull.Value : obj.aprobado);
                            cmd.Parameters.AddWithValue("@Anulado", obj.anulado ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Usuario", string.IsNullOrEmpty(obj.usuario) ? (object)DBNull.Value : obj.usuario);
                            cmd.Parameters.AddWithValue("@Observacion", string.IsNullOrEmpty(obj.observacion) ? (object)DBNull.Value : obj.observacion);
                            cmd.Parameters.AddWithValue("@Finalizado", obj.finalizado ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Asignado", obj.asignado ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Nro_orden_compra", obj.nroOrdenCompra ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Forma_pago", string.IsNullOrEmpty(obj.formaPago) ? (object)DBNull.Value : obj.formaPago);
                            cmd.Parameters.AddWithValue("@Nro_presupuesto", string.IsNullOrEmpty(obj.nroPresupuesto) ? (object)DBNull.Value : obj.nroPresupuesto);
                            cmd.Parameters.AddWithValue("@Nro_facturas", string.IsNullOrEmpty(obj.nroFacturas) ? (object)DBNull.Value : obj.nroFacturas);
                            cmd.Parameters.AddWithValue("@Fecha_orden_compra", obj.fechaOrdenCompra ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Recibida", obj.recibida ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Fecha_recepcion", obj.fechaRecepcion ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Web", obj.web ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@EntregadaPor", string.IsNullOrEmpty(obj.entregadaPor) ? (object)DBNull.Value : obj.entregadaPor);
                            cmd.Parameters.AddWithValue("@Fecha_aprobacion", obj.fechaAprobacion ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Cod_estado_op", obj.codEstadoOp ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Id_liq_tk", obj.idLiqTk ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@cod_secretaria_autoriza", obj.codSecretariaAutoriza ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@cod_oficina_solicita", obj.codOficinaSolicita ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@op_interna", obj.opInterna);

                            cmd.ExecuteNonQuery();
                        }

                        int nroItem = 1;
                        foreach (var item in detalleItems)
                        {
                            InsertDetalleOrdenPedido(obj.nroOrdenPedido, nroItem++, item, con, tx);
                        }

                        // auditoría
                        var auditorCmd = new SqlCommand("AUDITOR_V2", con, tx);
                        auditorCmd.CommandType = CommandType.StoredProcedure;

                        auditorCmd.Parameters.AddWithValue("@usuario", auditoria.usuario );
                        auditorCmd.Parameters.AddWithValue("@autorizacion",auditoria.autorizaciones);
                        auditorCmd.Parameters.AddWithValue("@identificacion",auditoria.identificacion);
                        auditorCmd.Parameters.AddWithValue("@observaciones", auditoria.observaciones);
                        auditorCmd.Parameters.AddWithValue("@proceso", "NUEVA ORDEN DE PEDIDO");

                        string detalle = $"Nº orden de pedido: {obj.nroOrdenPedido} Fecha de orden de pedido: {obj.fechaOrdenPedido:yyyy-MM-dd}";
                        auditorCmd.Parameters.AddWithValue("@detalle", detalle);

                        auditorCmd.ExecuteNonQuery();

                        // actualizar LIQUIDACION_TICKETS
                        if (obj.idLiqTk.HasValue && obj.idLiqTk.Value != 0)
                        {
                            var updLiqCmd = new SqlCommand(@"
                            UPDATE LIQUIDACION_TICKETS 
                            SET FINALIZADO = 1 
                            WHERE ID_LIQUIDACION = @id_liq", con, tx);

                            updLiqCmd.Parameters.AddWithValue("@id_liq", obj.idLiqTk.Value);

                            updLiqCmd.ExecuteNonQuery();
                        }

                        tx.Commit();

                        return obj.nroOrdenPedido;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
        private static void InsertDetalleOrdenPedido(int nroOrden,int nroItem,detalleOrdenPedido item,SqlConnection conn,SqlTransaction tx)
        {
            string sql = @"
            INSERT INTO detalle_orden_pedido
            (Nro_orden_pedido, Nro_item, Desc_item, Cantidad, Precio, Importe, Ejercicio,
             Anexo, Inciso, Partida_prin, Item, Sub_item, Partida, Sub_partida,
             Id_secretaria, Id_direccion, Nro_cuenta, Usuario, id_oficina, id_programa)
            VALUES
            (@NroOrden, @NroItem, @DescItem, @Cantidad, @Precio, @Importe, @Ejercicio,
             @Anexo, @Inciso, @PartidaPrin, @Item, @SubItem, @Partida, @SubPartida,
             @IdSecretaria, @IdDireccion, @NroCuenta, @Usuario, @IdOficina, @IdPrograma)";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@NroOrden", nroOrden);
                cmd.Parameters.AddWithValue("@NroItem", nroItem);
                cmd.Parameters.AddWithValue("@DescItem", item.descItem ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Cantidad", item.cantidad ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Precio", item.precio ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Importe", item.importe ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Ejercicio", item.ejercicio ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Anexo", item.anexo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Inciso", item.inciso ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PartidaPrin", item.partidaPrin ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Item", item.item ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SubItem", item.subItem ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Partida", item.partida ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SubPartida", item.subPartida ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdSecretaria", item.idSecretaria ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdDireccion", item.idDireccion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NroCuenta", item.nroCuenta ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Usuario", item.usuario ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdOficina", item.idOficina ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdPrograma", item.idPrograma ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public static int update(int nroOrdenPedido, OrdenPedidoRequest request)
        {
            using var conn = GetConnection();
            conn.Open();
            using var tx = conn.BeginTransaction();

            try
            {
                // Validaciones
                if (request.Orden.codProveedor == null)
                    throw new Exception("Debe ingresar un proveedor.");

                if (request.Orden.total <= 0)
                    throw new Exception("El total de la orden debe ser mayor a cero.");

                // Actualizar cabecera
                var sqlUpdate = @"UPDATE Ordenes_pedido SET 
                            Total = @Total,
                            Saldo = @Saldo,
                            Cod_proveedor = @CodProveedor,
                            Observacion = @Observacion
                          WHERE Nro_orden_pedido = @NroOrdenPedido";

                using (var cmd = new SqlCommand(sqlUpdate, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@Total", request.Orden.total);
                    cmd.Parameters.AddWithValue("@Saldo", request.Orden.saldo);
                    cmd.Parameters.AddWithValue("@CodProveedor", request.Orden.codProveedor);
                    cmd.Parameters.AddWithValue("@Observacion", request.Orden.observacion?? "");
                    cmd.Parameters.AddWithValue("@NroOrdenPedido", nroOrdenPedido);

                    cmd.ExecuteNonQuery();
                }

                // Borrar detalle anterior
                using (var cmdDel = new SqlCommand("DELETE FROM detalle_orden_pedido WHERE Nro_orden_pedido = @NroOrdenPedido", conn, tx))
                {
                    cmdDel.Parameters.AddWithValue("@NroOrdenPedido", nroOrdenPedido);
                    cmdDel.ExecuteNonQuery();
                }

                // Insertar detalle nuevo
                int nroItem = 1;
                foreach (var item in request.DetalleItems)
                {
                    InsertDetalleOrdenPedido(nroOrdenPedido, nroItem++, item, conn, tx);
                }

                // Auditoría
                using (var cmdAud = new SqlCommand("EXEC AUDITOR_V2 @usuario, @autorizacion, @identificacion, @observaciones, @proceso, @detalle", conn, tx))
                {
                    cmdAud.Parameters.AddWithValue("@usuario", request.Auditoria.usuario);
                    cmdAud.Parameters.AddWithValue("@autorizacion", request.Auditoria.autorizaciones ?? "");
                    cmdAud.Parameters.AddWithValue("@identificacion", request.Auditoria.identificacion);
                    cmdAud.Parameters.AddWithValue("@observaciones", request.Auditoria.observaciones?? "");
                    cmdAud.Parameters.AddWithValue("@proceso", "MODIFICA ORDEN PEDIDO");
                    cmdAud.Parameters.AddWithValue("@detalle", $"Nº Orden Pedido: {nroOrdenPedido} Fecha Movimiento: {DateTime.Now:yyyy-MM-dd}");

                    cmdAud.ExecuteNonQuery();
                }

                tx.Commit();
                return nroOrdenPedido;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public static void Delete(int nroOrdenPedido)
        {
            using var conn = DALBase.GetConnection();
            conn.Open();

            using var tx = conn.BeginTransaction();

            try
            {
                // Validar si la orden está asociada a una orden de compra
                using (var checkCmd = new SqlCommand(
                    @"SELECT Nro_orden_compra 
                      FROM Ordenes_pedido 
                      WHERE Nro_orden_pedido = @NroOrdenPedido
                      AND Finalizado = 1", conn, tx))
                {
                    checkCmd.Parameters.AddWithValue("@NroOrdenPedido", nroOrdenPedido);

                    var result = checkCmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        throw new Exception($"La orden está asociada a la orden de compra nro: {result}");
                    }
                }

                // Elimina primero el detalle
                using (var delDetalle = new SqlCommand(
                    @"DELETE FROM Detalle_orden_pedido 
                    WHERE Nro_orden_pedido = @NroOrdenPedido", conn, tx))
                {
                    delDetalle.Parameters.AddWithValue("@NroOrdenPedido", nroOrdenPedido);
                    delDetalle.ExecuteNonQuery();
                }

                // Luego elimina la orden
                using (var delOrden = new SqlCommand(
                    @"DELETE FROM Ordenes_pedido 
                    WHERE Nro_orden_pedido = @NroOrdenPedido", conn, tx))
                {
                    delOrden.Parameters.AddWithValue("@NroOrdenPedido", nroOrdenPedido);
                    delOrden.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }




    }
}

