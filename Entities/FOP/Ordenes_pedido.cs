using System;
using System.Collections;
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
        public int? nro_orden_pedido { get; set; }
        public string? fecha_orden_pedido { get; set; }
        public string? oficina_destino { get; set; }
        public string? nom_proveedor { get; set; }
        public string? solicitante { get; set; }
        public string? aprobado { get; set; }
        public string? nro_presupuesto { get; set; }
        public string? nro_facturas { get; set; }
        public DateTime? fecha_recepcion { get; set; }
        public decimal? total { get; set; }
        public string? observacion { get; set; }
        public int? nro_orden_compra { get; set; }
        public DateTime? fecha_orden_compra { get; set; }
        public DateTime? fecha_aprobacion { get; set; }
        public DateTime? fecha_envio_tc { get; set; }
        public decimal? saldo { get; set; }
        public string? usuario { get; set; }
        public string? status { get; set; }

        public Ordenes_pedido()
        {
            nro_orden_pedido = null;
            fecha_orden_pedido = null;
            oficina_destino = null;
            nom_proveedor = null;
            solicitante = null;
            aprobado = null;
            nro_presupuesto = null;
            nro_facturas = null;
            fecha_recepcion = null;
            total = null;
            observacion = null;
            nro_orden_compra = null;
            fecha_orden_compra = null;
            fecha_aprobacion = null;
            fecha_envio_tc = null;
            saldo = null;
            usuario = null;
            status = null;
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


        public static void anular(int nroOrdenPedido,Auditoria auditoria)
        {
            using var conn = DALBase.GetConnection();
            conn.Open();

            using var tx = conn.BeginTransaction();

            try
            {

                using (var checkFinalizada = new SqlCommand(
                    @"SELECT 1
                      FROM ORDENES_PEDIDO op
                      WHERE op.Nro_orden_pedido = @NroOrdenPedido
                        AND op.Finalizado = 1
                        AND EXISTS (
                            SELECT 1 FROM ORDENES_COMPRA oc
                            WHERE oc.nro_nota_pedido = op.Nro_orden_pedido
                        )", conn, tx))
                {
                    checkFinalizada.Parameters.AddWithValue("@NroOrdenPedido", nroOrdenPedido);
                    var existeFinalizada = checkFinalizada.ExecuteScalar();

                    if (existeFinalizada != null && existeFinalizada != DBNull.Value)
                    {
                        throw new InvalidOperationException("No se puede anular la orden porque está finalizada y tiene al menos una orden de compra asociada.");
                    }
                }


                // Luego Anular
                using (var cmdAud = new SqlCommand("EXEC AUDITOR_V2 @usuario, @autorizacion, @identificacion, @observaciones, @proceso, @detalle", conn, tx))
                {
                    cmdAud.Parameters.AddWithValue("@usuario", auditoria.usuario);
                    cmdAud.Parameters.AddWithValue("@autorizacion", auditoria.autorizaciones ?? "");
                    cmdAud.Parameters.AddWithValue("@identificacion", auditoria.identificacion);
                    cmdAud.Parameters.AddWithValue("@observaciones", auditoria.observaciones ?? "");
                    cmdAud.Parameters.AddWithValue("@proceso", "ANULAR ORDEN PEDIDO");
                    cmdAud.Parameters.AddWithValue("@detalle", $"Nº Orden Pedido: {nroOrdenPedido} Fecha Movimiento: {DateTime.Now:yyyy-MM-dd}");

                    cmdAud.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }


        public static List<Ordenes_pedido> getOrdenByFecha(DateTime fechaDesde, DateTime fechaHasta, int tipoSeleccion)
        {
            var lista = new List<Ordenes_pedido>();

            using var conn = GetConnectionSIIMVA(); // Hereda de DALBase
            conn.Open();

            using var cmd = new SqlCommand("EXEC PR_OBTENER_ORDENES @fechaDesde, @fechaHasta, @tipoSeleccion", conn);
            cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);
            cmd.Parameters.AddWithValue("@tipoSeleccion", tipoSeleccion);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var op = new Ordenes_pedido
                {
                    nro_orden_pedido = reader.IsDBNull(reader.GetOrdinal("Nro_orden_pedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("Nro_orden_pedido")),
                    fecha_orden_pedido = reader.IsDBNull(reader.GetOrdinal("fecha_op")) ? null : reader.GetString(reader.GetOrdinal("fecha_op")),
                    oficina_destino = reader.IsDBNull(reader.GetOrdinal("destino")) ? null : reader.GetString(reader.GetOrdinal("destino")),
                    nom_proveedor = reader.IsDBNull(reader.GetOrdinal("nom_proveedor")) ? null : reader.GetString(reader.GetOrdinal("nom_proveedor")),
                    solicitante = reader.IsDBNull(reader.GetOrdinal("Solicitante")) ? null : reader.GetString(reader.GetOrdinal("Solicitante")),
                    aprobado = reader.IsDBNull(reader.GetOrdinal("Aprobado")) ? null : reader.GetString(reader.GetOrdinal("Aprobado")),
                    nro_presupuesto = reader.IsDBNull(reader.GetOrdinal("Nro_presupuesto")) ? null : reader.GetString(reader.GetOrdinal("Nro_presupuesto")),
                    nro_facturas = reader.IsDBNull(reader.GetOrdinal("Nro_facturas")) ? null : reader.GetString(reader.GetOrdinal("Nro_facturas")),
                    fecha_recepcion = reader.IsDBNull(reader.GetOrdinal("Fecha_recepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha_recepcion")),
                    total = reader.IsDBNull(reader.GetOrdinal("Total")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("Total")),
                    observacion = reader.IsDBNull(reader.GetOrdinal("Observacion")) ? null : reader.GetString(reader.GetOrdinal("Observacion")),
                    nro_orden_compra = reader.IsDBNull(reader.GetOrdinal("Nro_orden_compra")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("Nro_orden_compra")),
                    fecha_orden_compra = reader.IsDBNull(reader.GetOrdinal("Fecha_orden_compra")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha_orden_compra")),
                    fecha_aprobacion = reader.IsDBNull(reader.GetOrdinal("fecha_aprobacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha_aprobacion")),
                    fecha_envio_tc = reader.IsDBNull(reader.GetOrdinal("fecha_envio_tc")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha_envio_tc")),
                    saldo = reader.IsDBNull(reader.GetOrdinal("saldo")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("saldo")),
                    usuario = reader.IsDBNull(reader.GetOrdinal("Usuario")) ? null : reader.GetString(reader.GetOrdinal("Usuario")),
                    status = reader.IsDBNull(reader.GetOrdinal("OficinaUSR")) ? null : reader.GetString(reader.GetOrdinal("OficinaUSR")),
                };

                lista.Add(op);
            }

            return lista;
        }

        public static List<HistorialOrdenDePedido> getHistorialByNro(int nroOrdenPedido)
        {
            var lista = new List<HistorialOrdenDePedido>();

            using var conn = GetConnectionSIIMVA();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
        SELECT 
            a.nro_nota_pedido, 
            a.nro_paso, 
            CASE 
              WHEN cod_estado_op = 1 THEN 'OP. Recibida'
              WHEN cod_estado_op = 2 THEN 'OP. Devuelta'
              WHEN cod_estado_op = 0 THEN 'Sin Estado'
            END AS estado,
            CONVERT(VARCHAR(10), a.fecha_mov_op, 103) AS fecha,
            a.observaciones, 
            a.responsable_op, 
            a.usuario
        FROM ORDENES_PEDIDO_MOVIMIENTOS a
        WHERE a.nro_nota_pedido = @nro";

            cmd.Parameters.AddWithValue("@nro", nroOrdenPedido);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var historial = new HistorialOrdenDePedido
                {
                    nro_nota_pedido = reader.GetInt32(0),
                    nro_paso = reader.GetInt32(1),
                    estado = reader.GetString(2),
                    fecha = reader.GetString(3),
                    observaciones = reader.IsDBNull(4) ? null : reader.GetString(4),
                    responsable_op = reader.IsDBNull(5) ? null : reader.GetString(5),
                    usuario = reader.IsDBNull(6) ? null : reader.GetString(6),
                };

                lista.Add(historial);
            }

            return lista;
        }



    }
}

