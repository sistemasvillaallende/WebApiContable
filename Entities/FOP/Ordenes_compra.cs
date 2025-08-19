using MOTOR_WORKFLOW.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Web_Api_Contable.Entities.GENERAL;
using Web_Api_Contable.Models;

namespace Web_Api_Contable.Entities.FOP
{
    public class Ordenes_compra : DALBase
    {
            public int nroOrdenCompra { get; set; }
            public DateTime fechaOrdenCompra { get; set; }
            public int? nroNotaPedido { get; set; }
            public decimal total { get; set; }
            public decimal saldo { get; set; }
            public int codProveedor { get; set; }
            public string destino { get; set; }
            public string solicitante { get; set; }
            public bool? anulado { get; set; }
            public DateTime? fechaAnulado { get; set; }
            public int? codEstadoOc { get; set; }
            public string formaPago { get; set; }
            public string observacion { get; set; }
            public DateTime? fechaAprobacion { get; set; }
            public bool? aprobado { get; set; }
            public DateTime? fechaEnvioTc { get; set; }
            public string nroPresupuesto { get; set; }
            public string nroFacturas { get; set; }
            public bool? tieneFacturas { get; set; }
            public string usuario { get; set; }
        public Ordenes_compra()
        {
            nroOrdenCompra = 0;
            fechaOrdenCompra = DateTime.MinValue;
            nroNotaPedido = null;
            total = 0;
            saldo = 0;
            codProveedor = 0;
            destino = string.Empty;
            solicitante = string.Empty;
            anulado = null;
            fechaAnulado = null;
            codEstadoOc = null;
            formaPago = string.Empty;
            observacion = string.Empty;
            fechaAprobacion = null;
            aprobado = null;
            fechaEnvioTc = null;
            nroPresupuesto = string.Empty;
            nroFacturas = string.Empty;
            tieneFacturas = null;
            usuario = string.Empty;


        }
        public static Ordenes_compra getByPk(int nroOrdenCompra)
        {
            using var conn = GetConnectionSIIMVA();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            SELECT 
                nro_orden_compra,
                fecha_orden_compra,
                nro_nota_pedido,
                total,
                saldo,
                cod_proveedor,
                destino,
                solicitante,
                anulado,
                fecha_anulado,
                cod_estado_oc,
                forma_pago,
                observacion,
                fecha_aprobacion,
                aprobado,
                fecha_envio_tc,
                nro_presupuesto,
                nro_facturas,
                tieneFacturas,
                usuario
            FROM ORDENES_COMPRA 
            WHERE nro_orden_compra = @nro";

            cmd.Parameters.AddWithValue("@nro", nroOrdenCompra);

            using var reader = cmd.ExecuteReader();
            Ordenes_compra ordenCompra = null;
            if (reader.Read())
            {
                 ordenCompra = new Ordenes_compra
                {
                    nroOrdenCompra = reader.IsDBNull(reader.GetOrdinal("nro_orden_compra")) ? 0 : reader.GetInt32(reader.GetOrdinal("nro_orden_compra")),
                    fechaOrdenCompra = reader.IsDBNull(reader.GetOrdinal("fecha_orden_compra")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("fecha_orden_compra")),
                    nroNotaPedido = reader.IsDBNull(reader.GetOrdinal("nro_nota_pedido")) ? null : reader.GetInt32(reader.GetOrdinal("nro_nota_pedido")),
                    total = reader.IsDBNull(reader.GetOrdinal("total")) ? 0 : Convert.ToDecimal(reader["total"]),
                    saldo = reader.IsDBNull(reader.GetOrdinal("saldo")) ? 0 : Convert.ToDecimal(reader["saldo"]),
                    codProveedor = reader.IsDBNull(reader.GetOrdinal("cod_proveedor")) ? 0 : Convert.ToInt32(reader["cod_proveedor"]),
                    destino = reader.IsDBNull(reader.GetOrdinal("destino")) ? string.Empty : reader.GetString(reader.GetOrdinal("destino")),
                    solicitante = reader.IsDBNull(reader.GetOrdinal("solicitante")) ? string.Empty : reader.GetString(reader.GetOrdinal("solicitante")),
                    anulado = reader.IsDBNull(reader.GetOrdinal("anulado"))? (bool?)null: Convert.ToInt32(reader["anulado"]) == 1,
                    fechaAnulado = reader.IsDBNull(reader.GetOrdinal("fecha_anulado")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha_anulado")),
                    codEstadoOc = reader.IsDBNull(reader.GetOrdinal("cod_estado_oc")) ? (int?)null : Convert.ToInt32(reader["cod_estado_oc"]),
                    formaPago = reader.IsDBNull(reader.GetOrdinal("forma_pago")) ? string.Empty : reader.GetString(reader.GetOrdinal("forma_pago")),
                    observacion = reader.IsDBNull(reader.GetOrdinal("observacion")) ? string.Empty : reader.GetString(reader.GetOrdinal("observacion")),
                    fechaAprobacion = reader.IsDBNull(reader.GetOrdinal("fecha_aprobacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha_aprobacion")),
                    aprobado = reader.IsDBNull(reader.GetOrdinal("aprobado"))? (bool?)null: Convert.ToInt32(reader["aprobado"]) == 1,
                    fechaEnvioTc = reader.IsDBNull(reader.GetOrdinal("fecha_envio_tc")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha_envio_tc")),
                    nroPresupuesto = reader.IsDBNull(reader.GetOrdinal("nro_presupuesto")) ? string.Empty : reader.GetString(reader.GetOrdinal("nro_presupuesto")),
                    nroFacturas = reader.IsDBNull(reader.GetOrdinal("nro_facturas")) ? string.Empty : reader.GetString(reader.GetOrdinal("nro_facturas")),
                    tieneFacturas = reader.IsDBNull(reader.GetOrdinal("tieneFacturas"))? (bool?)null: Convert.ToInt32(reader["tieneFacturas"]) == 1,
                    usuario = reader.IsDBNull(reader.GetOrdinal("usuario")) ? string.Empty : reader.GetString(reader.GetOrdinal("usuario"))

                };

               
            }

            return ordenCompra;
        }

        private static int GenerarNuevoNroOrden(SqlConnection conn, SqlTransaction tx)
        {
            int nuevo;

            using (var cmd = new SqlCommand("SELECT Nro_orden_compra FROM numeros_claves", conn, tx))
            {
                int max = (int)cmd.ExecuteScalar();
                nuevo = max + 1;
            }

            using (var updateCmd = new SqlCommand("UPDATE numeros_claves SET Nro_orden_compra = @nuevo", conn, tx))
            {
                updateCmd.Parameters.AddWithValue("@nuevo", nuevo);
                updateCmd.ExecuteNonQuery();
            }

            return nuevo;
        }

        public static int insert(Orden_compra obj, List<detalle_orden_compra> detalleItems, Auditoria auditoria)
        {
            using (SqlConnection con = GetConnectionSIIMVA())
            {
                con.Open();

                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        // Generar nuevo número de orden y asignarlo
                        obj.nroOrdenCompra = GenerarNuevoNroOrden(con, tx);

                        StringBuilder sql = new StringBuilder();
                        sql.AppendLine("INSERT INTO ORDENES_COMPRA(");
                        sql.AppendLine("nro_orden_compra,fecha_orden_compra,nro_nota_pedido,total,saldo,");
                        sql.AppendLine("cod_proveedor, destino, solicitante,anulado, Fecha_anulado,");
                        sql.AppendLine("cod_estado_oc,Forma_pago,Observacion,Fecha_aprobacion,Aprobado,");
                        sql.AppendLine("fecha_envio_tc,nro_presupuesto,nro_facturas,tieneFacturas,Usuario)");
                        sql.AppendLine("VALUES (");
                        sql.AppendLine("@nro_orden_compra, @fecha_orden_compra, @nro_nota_pedido, @total, @saldo,");
                        sql.AppendLine("@cod_proveedor, @destino, @solicitante, @anulado, @Fecha_anulado,");
                        sql.AppendLine("@cod_estado_oc, @Forma_pago, @Observacion, @Fecha_aprobacion, @Aprobado,");
                        sql.AppendLine("@Fecha_envio_tc, @Nro_presupuesto, @Nro_facturas, @TieneFacturas, @Usuario)");

                        using (SqlCommand cmd = new SqlCommand(sql.ToString(), con, tx))
                        {
                            cmd.Parameters.AddWithValue("@nro_orden_compra", obj.nroOrdenCompra);
                            cmd.Parameters.AddWithValue("@fecha_orden_compra", obj.fechaOrdenCompra ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@nro_nota_pedido", obj.nroNotaPedido ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@total", obj.total ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@saldo", obj.saldo ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@cod_proveedor", obj.codProveedor ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@destino", string.IsNullOrEmpty(obj.destino) ? (object)DBNull.Value : obj.destino);
                            cmd.Parameters.AddWithValue("@solicitante", string.IsNullOrEmpty(obj.solicitante) ? (object)DBNull.Value : obj.solicitante);
                            cmd.Parameters.AddWithValue("@anulado", obj.anulado ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Fecha_anulado", obj.fechaAnulado ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@cod_estado_oc", obj.codEstadoOc ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Forma_pago", string.IsNullOrEmpty(obj.formaPago) ? (object)DBNull.Value : obj.formaPago);
                            cmd.Parameters.AddWithValue("@Observacion", string.IsNullOrEmpty(obj.observacion) ? (object)DBNull.Value : obj.observacion);
                            cmd.Parameters.AddWithValue("@Fecha_aprobacion", obj.fechaAprobacion ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Aprobado", obj.aprobado ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Fecha_envio_tc", obj.fechaEnvioTc ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Nro_presupuesto", string.IsNullOrEmpty(obj.nroPresupuesto) ? (object)DBNull.Value : obj.nroPresupuesto);
                            cmd.Parameters.AddWithValue("@Nro_facturas", string.IsNullOrEmpty(obj.nroFacturas) ? (object)DBNull.Value : obj.nroFacturas);
                            cmd.Parameters.AddWithValue("@TieneFacturas", obj.tieneFacturas ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Usuario", string.IsNullOrEmpty(obj.usuario) ? (object)DBNull.Value : obj.usuario);

                            cmd.ExecuteNonQuery();
                        }

                        int nroItem = 1;
                        foreach (var item in detalleItems)
                        {
                            InsertDetalleOrdenCompra(obj.nroOrdenCompra, nroItem++, item, con, tx);
                        }

                        // auditoría
                        var auditorCmd = new SqlCommand("AUDITOR_V2", con, tx);
                        auditorCmd.CommandType = CommandType.StoredProcedure;

                        auditorCmd.Parameters.AddWithValue("@usuario", auditoria.usuario);
                        auditorCmd.Parameters.AddWithValue("@autorizacion", auditoria.autorizaciones);
                        auditorCmd.Parameters.AddWithValue("@identificacion", auditoria.identificacion);
                        auditorCmd.Parameters.AddWithValue("@observaciones", auditoria.observaciones);
                        auditorCmd.Parameters.AddWithValue("@proceso", "NUEVA ORDEN DE COMPRA");

                        string detalle = $"Nº orden de compra: {obj.nroOrdenCompra} Fecha de orden de compra: {obj.fechaOrdenCompra:yyyy-MM-dd}";
                        auditorCmd.Parameters.AddWithValue("@detalle", detalle);

                        auditorCmd.ExecuteNonQuery();


                        tx.Commit();

                        return obj.nroOrdenCompra;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
        private static void InsertDetalleOrdenCompra(int nroOrden, int nroItem, detalle_orden_compra item, SqlConnection conn, SqlTransaction tx)
        {
            string sql = @"
                INSERT INTO DETALLE_ORDEN_COMPRA
                (nro_orden_compra, nro_item, id_secretaria, id_direccion, des_item, cantidad, 
                 precio_unitario, importe, ejercicio, anexo, inciso, partida_prin, item, sub_item, 
                 partida, sub_partida, id_oficina, id_programa, mes, nro_nota_contabi)
                VALUES
                (@NroOrden, @NroItem, @IdSecretaria, @IdDireccion, @DesItem, @Cantidad, 
                 @PrecioUnitario, @Importe, @Ejercicio, @Anexo, @Inciso, @PartidaPrin, @Item, @SubItem, 
                 @Partida, @SubPartida, @IdOficina, @IdPrograma, @Mes, @NroNotaContabi)";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@NroOrden", nroOrden);
                cmd.Parameters.AddWithValue("@NroItem", nroItem);
                cmd.Parameters.AddWithValue("@IdSecretaria", item.id_secretaria ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdDireccion", item.id_direccion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DesItem", string.IsNullOrEmpty(item.des_item) ? (object)DBNull.Value : item.des_item);
                cmd.Parameters.AddWithValue("@Cantidad", item.cantidad ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PrecioUnitario", item.precio_unitario ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Importe", item.importe ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Ejercicio", item.ejercicio ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Anexo", item.anexo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Inciso", item.inciso ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PartidaPrin", item.partida_prin ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Item", item.item ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SubItem", item.sub_item ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Partida", item.partida ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SubPartida", item.sub_partida ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdOficina", item.id_oficina ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdPrograma", item.id_programa ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Mes", item.mes ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NroNotaContabi", item.nro_nota_contabi ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }
        public static int update(int nroOrdenCompra, OrdenCompraRequest request)
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
                var sqlUpdate = @"UPDATE Ordenes_compra SET 
                            Total = @Total,
                            Saldo = @Saldo,
                            Cod_proveedor = @CodProveedor,
                            Observacion = @Observacion
                          WHERE nro_orden_compra = @nro_orden_compra";

                using (var cmd = new SqlCommand(sqlUpdate, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@Total", request.Orden.total);
                    cmd.Parameters.AddWithValue("@Saldo", request.Orden.saldo);
                    cmd.Parameters.AddWithValue("@CodProveedor", request.Orden.codProveedor);
                    cmd.Parameters.AddWithValue("@Observacion", request.Orden.observacion ?? "");
                    cmd.Parameters.AddWithValue("@nro_orden_compra", nroOrdenCompra);

                    cmd.ExecuteNonQuery();
                }

                // Borrar detalle anterior
                using (var cmdDel = new SqlCommand("DELETE FROM detalle_orden_compra WHERE @nro_orden_compra =@nro_orden_compra", conn, tx))
                {
                    cmdDel.Parameters.AddWithValue("@nro_orden_compra", nroOrdenCompra);
                    cmdDel.ExecuteNonQuery();
                }

                // Insertar detalle nuevo
                int nroItem = 1;
                foreach (var item in request.DetalleItems)
                {
                    InsertDetalleOrdenCompra(nroOrdenCompra, nroItem++, item, conn, tx);
                }

                // Auditoría
                using (var cmdAud = new SqlCommand("EXEC AUDITOR_V2 @usuario, @autorizacion, @identificacion, @observaciones, @proceso, @detalle", conn, tx))
                {
                    cmdAud.Parameters.AddWithValue("@usuario", request.Auditoria.usuario);
                    cmdAud.Parameters.AddWithValue("@autorizacion", request.Auditoria.autorizaciones ?? "");
                    cmdAud.Parameters.AddWithValue("@identificacion", request.Auditoria.identificacion);
                    cmdAud.Parameters.AddWithValue("@observaciones", request.Auditoria.observaciones ?? "");
                    cmdAud.Parameters.AddWithValue("@proceso", "MODIFICA ORDEN Compra");
                    cmdAud.Parameters.AddWithValue("@detalle", $"Nº Orden Pedido: {nroOrdenCompra} Fecha Movimiento: {DateTime.Now:yyyy-MM-dd}");

                    cmdAud.ExecuteNonQuery();
                }

                tx.Commit();
                return nroOrdenCompra;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public static List<Ordenes_compra> getOrdenByFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            var ordenes = new List<Ordenes_compra>();

            using var conn = GetConnectionSIIMVA();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            SELECT 
                nro_orden_compra,
                fecha_orden_compra,
                nro_nota_pedido,
                total,
                saldo,
                cod_proveedor,
                destino,
                solicitante,
                anulado,
                fecha_anulado,
                cod_estado_oc,
                forma_pago,
                observacion,
                fecha_aprobacion,
                aprobado,
                fecha_envio_tc,
                nro_presupuesto,
                nro_facturas,
                tieneFacturas,
                usuario
            FROM ORDENES_COMPRA
            WHERE fecha_orden_compra BETWEEN @fechaDesde AND @fechaHasta";

            cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ordenCompra = new Ordenes_compra
                {
                    nroOrdenCompra = reader.IsDBNull(reader.GetOrdinal("nro_orden_compra")) ? 0 : reader.GetInt32(reader.GetOrdinal("nro_orden_compra")),
                    fechaOrdenCompra = reader.IsDBNull(reader.GetOrdinal("fecha_orden_compra")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("fecha_orden_compra")),
                    nroNotaPedido = reader.IsDBNull(reader.GetOrdinal("nro_nota_pedido")) ? null : reader.GetInt32(reader.GetOrdinal("nro_nota_pedido")),
                    total = reader.IsDBNull(reader.GetOrdinal("total")) ? 0 : Convert.ToDecimal(reader["total"]),
                    saldo = reader.IsDBNull(reader.GetOrdinal("saldo")) ? 0 : Convert.ToDecimal(reader["saldo"]),
                    codProveedor = reader.IsDBNull(reader.GetOrdinal("cod_proveedor")) ? 0 : Convert.ToInt32(reader["cod_proveedor"]),
                    destino = reader.IsDBNull(reader.GetOrdinal("destino")) ? string.Empty : reader.GetString(reader.GetOrdinal("destino")),
                    solicitante = reader.IsDBNull(reader.GetOrdinal("solicitante")) ? string.Empty : reader.GetString(reader.GetOrdinal("solicitante")),
                    anulado = reader.IsDBNull(reader.GetOrdinal("anulado")) ? (bool?)null : Convert.ToInt32(reader["anulado"]) == 1,
                    fechaAnulado = reader.IsDBNull(reader.GetOrdinal("fecha_anulado")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha_anulado")),
                    codEstadoOc = reader.IsDBNull(reader.GetOrdinal("cod_estado_oc")) ? (int?)null : Convert.ToInt32(reader["cod_estado_oc"]),
                    formaPago = reader.IsDBNull(reader.GetOrdinal("forma_pago")) ? string.Empty : reader.GetString(reader.GetOrdinal("forma_pago")),
                    observacion = reader.IsDBNull(reader.GetOrdinal("observacion")) ? string.Empty : reader.GetString(reader.GetOrdinal("observacion")),
                    fechaAprobacion = reader.IsDBNull(reader.GetOrdinal("fecha_aprobacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha_aprobacion")),
                    aprobado = reader.IsDBNull(reader.GetOrdinal("aprobado")) ? (bool?)null : Convert.ToInt32(reader["aprobado"]) == 1,
                    fechaEnvioTc = reader.IsDBNull(reader.GetOrdinal("fecha_envio_tc")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha_envio_tc")),
                    nroPresupuesto = reader.IsDBNull(reader.GetOrdinal("nro_presupuesto")) ? string.Empty : reader.GetString(reader.GetOrdinal("nro_presupuesto")),
                    nroFacturas = reader.IsDBNull(reader.GetOrdinal("nro_facturas")) ? string.Empty : reader.GetString(reader.GetOrdinal("nro_facturas")),
                    tieneFacturas = reader.IsDBNull(reader.GetOrdinal("tieneFacturas")) ? (bool?)null : Convert.ToInt32(reader["tieneFacturas"]) == 1,
                    usuario = reader.IsDBNull(reader.GetOrdinal("usuario")) ? string.Empty : reader.GetString(reader.GetOrdinal("usuario"))
                };

                ordenes.Add(ordenCompra);
            }

            return ordenes;
        }

        public static void delete(int nroOrdenCompra, Auditoria request)
        {
            using var conn = DALBase.GetConnection();
            conn.Open();

            using var tx = conn.BeginTransaction();

            try
            {
                // Validar si la orden tiene pagos o notas de contabilidad (saldo distinto de total)
                using (var checkSaldo = new SqlCommand(
                    @"SELECT Total, Saldo 
                      FROM Ordenes_compra 
                      WHERE nro_orden_compra = @nro_orden_compra", conn, tx))
                {
                    checkSaldo.Parameters.AddWithValue("@nro_orden_compra", nroOrdenCompra);

                    using var reader = checkSaldo.ExecuteReader();
                    if (reader.Read())
                    {
                        decimal total = reader.GetDecimal(0);
                        decimal saldo = reader.GetDecimal(1);

                        if (total != saldo)
                            throw new Exception("La orden ya fue afectada por una Orden de Pago o Nota de Contabilidad.");
                    }
                }

                // Validar si el balance mensual del período está cerrado
                using (var checkBalance = new SqlCommand(
                    @"SELECT FECHA_CIERRE
                      FROM Bal_Men_Egresos 
                      WHERE EJERCICIO = YEAR(GETDATE()) 
                      AND MES = MONTH(GETDATE())", conn, tx))
                {
                    var fechaCierre = checkBalance.ExecuteScalar();
                    if (fechaCierre != DBNull.Value && fechaCierre != null)
                        throw new Exception("El balance mensual correspondiente ya se cerró.");
                }

                // Verificar si está asociada a una orden de pedido finalizada
                using (var checkCmd = new SqlCommand(
                    @"SELECT nro_orden_pedido 
                      FROM Ordenes_pedido 
                      WHERE nro_orden_compra = @nro_orden_compra 
                      AND Finalizado = 1", conn, tx))
                {
                    checkCmd.Parameters.AddWithValue("@nro_orden_compra", nroOrdenCompra);

                    var result = checkCmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        throw new Exception($"La orden está asociada a la orden de pedido nro: {result}");
                    }
                }

                // Elimina primero el detalle
                using (var delDetalle = new SqlCommand(
                    @"DELETE FROM Detalle_orden_compra 
                    WHERE nro_orden_compra = @nro_orden_compra", conn, tx))
                {
                    delDetalle.Parameters.AddWithValue("@nro_orden_compra", nroOrdenCompra);
                    delDetalle.ExecuteNonQuery();
                }

                // Luego elimina la orden
                using (var delOrden = new SqlCommand(
                    @"DELETE FROM Ordenes_compra
              WHERE nro_orden_compra = @nro_orden_compra", conn, tx))
                {
                    delOrden.Parameters.AddWithValue("@nro_orden_compra", nroOrdenCompra);
                    delOrden.ExecuteNonQuery();
                }

                // Auditoría
                using (var cmdAud = new SqlCommand(
                    "EXEC AUDITOR_V2 @usuario, @autorizacion, @identificacion, @observaciones, @proceso, @detalle", conn, tx))
                {
                    cmdAud.Parameters.AddWithValue("@usuario", request.usuario);
                    cmdAud.Parameters.AddWithValue("@autorizacion", request.autorizaciones ?? "");
                    cmdAud.Parameters.AddWithValue("@identificacion", nroOrdenCompra.ToString());
                    cmdAud.Parameters.AddWithValue("@observaciones", request.observaciones ?? "");
                    cmdAud.Parameters.AddWithValue("@proceso", "ELIMINA ORDEN COMPRA");
                    cmdAud.Parameters.AddWithValue("@detalle",
                        $"Nº Orden Compra: {nroOrdenCompra} - Fecha Movimiento: {DateTime.Now:yyyy-MM-dd}");

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


    }
}
