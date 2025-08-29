using MOTOR_WORKFLOW.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Web_Api_Contable.Models;
using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.FOP
{
    public class Ordenes_pago :DALBase
    {

        public  static int insert(OrdenPagoRequest request)
        {
            using (SqlConnection con = GetConnectionSIIMVA())
            {
                con.Open();

                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        // ---------- VALIDACIONES ----------
                        if (request.Orden.Importe == 0)
                            throw new Exception("Total Pago incorrecto.");
                        if (request.Orden.Importe != request.Orden.APagar)
                            throw new Exception("El monto a pagar difiere de la forma de pago.");

                        if (string.IsNullOrEmpty(request.Orden.NroFactura))
                            throw new Exception("No se ingresaron los números de facturas que paga.");

                        // ---------- GENERAR NRO ORDEN PAGO ----------
                        int nroOrdenPago = request.Orden.NroOrdenPago;

                        if (nroOrdenPago == 0)
                        {
                            using (var cmd = new SqlCommand("SELECT MAX(Nro_Orden_Pago) FROM Numeros_Claves", con, tx))
                            {
                                var result = cmd.ExecuteScalar();
                                nroOrdenPago = (result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;

                                // Actualizar numeros_claves
                                using (var updateCmd = new SqlCommand(
                                           "UPDATE Numeros_Claves SET Nro_Orden_Pago = @NroOrden", con, tx))
                                {
                                    updateCmd.Parameters.AddWithValue("@NroOrden", nroOrdenPago);
                                    updateCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            // validar si el nroOrdenPago ya existe
                            using (var checkCmd = new SqlCommand(
                                       "SELECT COUNT(*) FROM Numeros_Claves WHERE Nro_Orden_Pago = @NroOrden", con, tx))
                            {
                                checkCmd.Parameters.AddWithValue("@NroOrden", nroOrdenPago);
                                var count = (int)checkCmd.ExecuteScalar();
                                if (count > 0)
                                    throw new Exception("El Nro de Orden de Pago ingresado ya existe.");
                            }
                        }

                        // ---------- INSERT ORDEN DE PAGO ----------
                        using (var cmdOrden = new SqlCommand(@"INSERT INTO Ordenes_Pago (nro_orden_pago,fecha_orden_pago,cod_proveedor,importe,usuario,nro_factura,nro_recibo,retencionsi,apagar,retencion,nro_retencion,responsable_op,fecha_movimiento_op,entregada,cod_estado_op,anio,cod_estado_tc,fecha_envio_tc,usuario_op_tc,fecha_aprobacion)
                                                            VALUES (@NroOrden,@Fecha,@CodProveedor,@Importe,@Usuario, @NroFactura,@NroRecibo,@RetencionSi,@Apagar,@Retencion,@NroRetencion,@ResponsableOp,@FechaMovimientoOp,@Entregada,@CodEstadoOp,@Anio,@CodEstadoTC,@FechaEnvioTC,@UsuarioOpTC,@FechaAprobacion)", con, tx))
                        {
                            cmdOrden.Parameters.AddWithValue("@NroOrden", nroOrdenPago);
                            cmdOrden.Parameters.AddWithValue("@Fecha", request.Orden.FechaOrdenPago);
                            cmdOrden.Parameters.AddWithValue("@CodProveedor", request.Orden.CodProveedor);
                            cmdOrden.Parameters.AddWithValue("@Importe", request.Orden.Importe);
                            cmdOrden.Parameters.AddWithValue("@Usuario", request.Orden.Usuario);
                            cmdOrden.Parameters.AddWithValue("@NroFactura", request.Orden.NroFactura ?? (object)DBNull.Value);
                            cmdOrden.Parameters.AddWithValue("@NroRecibo", request.Orden.NroRecibo ?? (object)DBNull.Value);
                            cmdOrden.Parameters.AddWithValue("@RetencionSi", request.Orden.RetencionSI);
                            cmdOrden.Parameters.AddWithValue("@Apagar", request.Orden.APagar);
                            cmdOrden.Parameters.AddWithValue("@Retencion", request.Orden.Retencion ?? (object)DBNull.Value);
                            cmdOrden.Parameters.AddWithValue("@NroRetencion", request.Orden.NroRetencion ?? (object)DBNull.Value);
                            cmdOrden.Parameters.AddWithValue("@ResponsableOp", request.Orden.ResponsableOP ?? (object)DBNull.Value);
                            cmdOrden.Parameters.AddWithValue("@FechaMovimientoOp", request.Orden.FechaMovimientoOP ?? (object)DBNull.Value);
                            cmdOrden.Parameters.AddWithValue("@Entregada", request.Orden.Entregada);
                            cmdOrden.Parameters.AddWithValue("@CodEstadoOp", request.Orden.CodEstadoOP);
                            cmdOrden.Parameters.AddWithValue("@Anio", request.Orden.Anio);
                            cmdOrden.Parameters.AddWithValue("@CodEstadoTC", request.Orden.CodEstadoTC ?? (object)DBNull.Value);
                            cmdOrden.Parameters.AddWithValue("@FechaEnvioTC", request.Orden.FechaEnvioTC ?? (object)DBNull.Value);
                            cmdOrden.Parameters.AddWithValue("@UsuarioOpTC", request.Orden.UsuarioOPTC ?? (object)DBNull.Value);
                            cmdOrden.Parameters.AddWithValue("@FechaAprobacion", request.Orden.FechaAprobacion ?? (object)DBNull.Value);

                            cmdOrden.ExecuteNonQuery();
                        }

                        // ---------- INSERT FORMAS DE PAGO Y MOVIMIENTOS BANCARIOS ----------
                        foreach (var fp in request.FormasPago)
                        {
                            using (var cmdFP = new SqlCommand(
                                      @"INSERT INTO Forma_Pago_Orden (nro_Orden_Pago,nro_item,cod_tipo_movimiento,cod_banco,nro_cuenta,nro_comprobante,fecha_acreditacion,importe,pendiente)
                                        VALUES (@NroOrdenPago,@NroItem,@CodTipoMov,@CodBanco,@NroCuenta,@NroComprobante,@FechaAcreditacion,@Importe,@Pendiente)", con, tx))
                            {
                                cmdFP.Parameters.AddWithValue("@NroOrdenPago", nroOrdenPago);
                                cmdFP.Parameters.AddWithValue("@NroItem", fp.NroItem);
                                cmdFP.Parameters.AddWithValue("@CodTipoMov", fp.CodTipoMovimiento);
                                cmdFP.Parameters.AddWithValue("@CodBanco", fp.CodBanco);
                                cmdFP.Parameters.AddWithValue("@NroCuenta", fp.NroCuenta);
                                cmdFP.Parameters.AddWithValue("@NroComprobante", fp.NroComprobante ?? (object)DBNull.Value);
                                cmdFP.Parameters.AddWithValue("@FechaAcreditacion", fp.FechaAcreditacion);
                                cmdFP.Parameters.AddWithValue("@Importe", fp.Importe);
                                cmdFP.Parameters.AddWithValue("@Pendiente", fp.FechaAcreditacion > request.Orden.FechaOrdenPago);
                                cmdFP.ExecuteNonQuery();
                            }

                            using (var cmdMov = new SqlCommand(
                                       @"INSERT INTO Movimientos_Bancarios
                                     (Cod_Banco, Nro_Cuenta, Cod_Tipo_Movimiento, Nro_Comprobante, Concepto, Fecha_Movimiento, Fecha_Acreditacion, Pendiente, Conciliado, Cancelado, Importe)
                                     VALUES (@CodBanco, @Cuenta, @CodTipoMov, @NroComp, @Concepto, @FechaMov, @FechaAcreditacion, @Pendiente, @Conciliado, @Cancelado, @Importe)", con, tx))
                            {
                                cmdMov.Parameters.AddWithValue("@CodBanco", fp.CodBanco);
                                cmdMov.Parameters.AddWithValue("@Cuenta", fp.NroCuenta);
                                cmdMov.Parameters.AddWithValue("@CodTipoMov", fp.CodTipoMovimiento);
                                cmdMov.Parameters.AddWithValue("@NroComp", fp.NroComprobante);
                                cmdMov.Parameters.AddWithValue("@Concepto", request.Concepto);
                                cmdMov.Parameters.AddWithValue("@FechaMov", request.Orden.FechaOrdenPago);
                                cmdMov.Parameters.AddWithValue("@FechaAcreditacion", fp.FechaAcreditacion);
                                cmdMov.Parameters.AddWithValue("@Pendiente", fp.FechaAcreditacion > request.Orden.FechaOrdenPago);
                                cmdMov.Parameters.AddWithValue("@Conciliado", fp.CodBanco == 0);
                                cmdMov.Parameters.AddWithValue("@Cancelado", false);
                                cmdMov.Parameters.AddWithValue("@Importe", fp.Importe);
                                cmdMov.ExecuteNonQuery();
                            }
                        }
                        foreach (var cta in request.Cuentas)
                        {
                            using (var cmdCta = new SqlCommand(@"
                                INSERT INTO CTAS_X_ORDEN_PAGO
                                (Nro_Orden_Pago, Ejercicio, Anexo, Inciso, Partida_Prin, Item, Sub_Item, Partida, Sub_Partida, Importe)
                                VALUES (@NroOrdenPago, @Ejercicio, @Anexo, @Inciso, @PartidaPrin, @Item, @SubItem, @Partida, @SubPartida, @Importe)", con, tx))
                            {
                                cmdCta.Parameters.AddWithValue("@NroOrdenPago", nroOrdenPago);
                                cmdCta.Parameters.AddWithValue("@Ejercicio", cta.Ejercicio);
                                cmdCta.Parameters.AddWithValue("@Anexo", cta.Anexo);
                                cmdCta.Parameters.AddWithValue("@Inciso", cta.Inciso);
                                cmdCta.Parameters.AddWithValue("@PartidaPrin", cta.PartidaPrin);
                                cmdCta.Parameters.AddWithValue("@Item", cta.Item);
                                cmdCta.Parameters.AddWithValue("@SubItem", cta.SubItem);
                                cmdCta.Parameters.AddWithValue("@Partida", cta.Partida);
                                cmdCta.Parameters.AddWithValue("@SubPartida", cta.SubPartida);
                                cmdCta.Parameters.AddWithValue("@Importe", cta.Importe);
                                cmdCta.ExecuteNonQuery();
                            }

                            // Actualizar Presupuesto_Egreso
                            using (var cmdUpdatePE = new SqlCommand(@"
                                UPDATE Presupuesto_Egreso
                                SET Importe_Pagado = Importe_Pagado + @Importe,
                                    Importe_A_Pagar = Importe_A_Pagar - @Importe
                                WHERE Ejercicio = @Ejercicio 
                                  AND Anexo = @Anexo
                                  AND Inciso = @Inciso
                                  AND Partida_Principal = @PartidaPrin
                                  AND Item = @Item
                                  AND SubItem = @SubItem
                                  AND Partida = @Partida
                                  AND SubPartida = @SubPartida;", con, tx))
                            {
                                cmdUpdatePE.Parameters.AddWithValue("@Importe", cta.Importe);
                                cmdUpdatePE.Parameters.AddWithValue("@Ejercicio", cta.Ejercicio);
                                cmdUpdatePE.Parameters.AddWithValue("@Anexo", cta.Anexo);
                                cmdUpdatePE.Parameters.AddWithValue("@Inciso", cta.Inciso);
                                cmdUpdatePE.Parameters.AddWithValue("@PartidaPrin", cta.PartidaPrin);
                                cmdUpdatePE.Parameters.AddWithValue("@Item", cta.Item);
                                cmdUpdatePE.Parameters.AddWithValue("@SubItem", cta.SubItem);
                                cmdUpdatePE.Parameters.AddWithValue("@Partida", cta.Partida);
                                cmdUpdatePE.Parameters.AddWithValue("@SubPartida", cta.SubPartida);

                                cmdUpdatePE.ExecuteNonQuery();
                            }
                        }

                        // ---------- INSERT PAGOS_X_ORDEN_COMPRA ----------
                        foreach (var pagoOC in request.pagoOrdenCompra)
                        {
                            using (var cmdOC = new SqlCommand(@"
                        INSERT INTO PAGOS_X_ORDEN_COMPRA
                        (Nro_Orden_Compra, Nro_Orden_Pago, Ejercicio, Anexo, Inciso, Partida_Prin, Item, Sub_Item, Partida, Sub_Partida, Importe, Fecha_Pago)
                        VALUES (@NroOrdenCompra, @NroOrdenPago, @Ejercicio, @Anexo, @Inciso, @PartidaPrin, @Item, @SubItem, @Partida, @SubPartida, @Importe, @FechaPago)", con, tx))
                            {
                                cmdOC.Parameters.AddWithValue("@NroOrdenCompra", pagoOC.NroOrdenCompra);
                                cmdOC.Parameters.AddWithValue("@NroOrdenPago", nroOrdenPago);
                                cmdOC.Parameters.AddWithValue("@Ejercicio", pagoOC.Ejercicio);
                                cmdOC.Parameters.AddWithValue("@Anexo", pagoOC.Anexo);
                                cmdOC.Parameters.AddWithValue("@Inciso", pagoOC.Inciso);
                                cmdOC.Parameters.AddWithValue("@PartidaPrin", pagoOC.PartidaPrin);
                                cmdOC.Parameters.AddWithValue("@Item", pagoOC.Item);
                                cmdOC.Parameters.AddWithValue("@SubItem", pagoOC.SubItem);
                                cmdOC.Parameters.AddWithValue("@Partida", pagoOC.Partida);
                                cmdOC.Parameters.AddWithValue("@SubPartida", pagoOC.SubPartida);
                                cmdOC.Parameters.AddWithValue("@Importe", pagoOC.Importe);
                                cmdOC.Parameters.AddWithValue("@FechaPago", pagoOC.FechaPago);
                                cmdOC.ExecuteNonQuery();
                            }

                            // Actualizar saldo de Ordenes_Compra
                            using (var cmdUpdateOC = new SqlCommand(@"
                                UPDATE Ordenes_Compra
                                SET Saldo = Saldo - @Importe
                                WHERE Nro_Orden_Compra = @NroOrdenCompra", con, tx))
                            {
                                cmdUpdateOC.Parameters.AddWithValue("@Importe", pagoOC.Importe);
                                cmdUpdateOC.Parameters.AddWithValue("@NroOrdenCompra", pagoOC.NroOrdenCompra);
                                cmdUpdateOC.ExecuteNonQuery();
                            }
                        }

                        // ---------- INSERT PAGOS_X_PROGRAMAS_PUBLICOS ----------
                        foreach (var prog in request.pagoProgramaPublico)
                        {
                            using (var cmdProg = new SqlCommand(@"
                                INSERT INTO PAGOS_X_PROGRAMAS_PUBLICOS
                                (Nro_Orden_Pago, Ejercicio, Anexo, Inciso, Partida_Prin, Item, Sub_Item, Partida, Sub_Partida, Id_Secretaria, Id_Direccion, Id_Programa, Fecha_Pago, Importe)
                                VALUES (@NroOrdenPago, @Ejercicio, @Anexo, @Inciso, @PartidaPrin, @Item, @SubItem, @Partida, @SubPartida, @IdSecretaria, @IdDireccion, @IdPrograma, @FechaPago, @Importe)", con, tx))
                            {
                                cmdProg.Parameters.AddWithValue("@NroOrdenPago", nroOrdenPago);
                                cmdProg.Parameters.AddWithValue("@Ejercicio", prog.Ejercicio);
                                cmdProg.Parameters.AddWithValue("@Anexo", prog.Anexo);
                                cmdProg.Parameters.AddWithValue("@Inciso", prog.Inciso);
                                cmdProg.Parameters.AddWithValue("@PartidaPrin", prog.PartidaPrin);
                                cmdProg.Parameters.AddWithValue("@Item", prog.Item);
                                cmdProg.Parameters.AddWithValue("@SubItem", prog.SubItem);
                                cmdProg.Parameters.AddWithValue("@Partida", prog.Partida);
                                cmdProg.Parameters.AddWithValue("@SubPartida", prog.SubPartida);
                                cmdProg.Parameters.AddWithValue("@IdSecretaria", prog.IdSecretaria);
                                cmdProg.Parameters.AddWithValue("@IdDireccion", prog.IdDireccion);
                                cmdProg.Parameters.AddWithValue("@IdPrograma", prog.IdPrograma);
                                cmdProg.Parameters.AddWithValue("@FechaPago", prog.FechaPago);
                                cmdProg.Parameters.AddWithValue("@Importe", prog.Importe);
                                cmdProg.ExecuteNonQuery();
                            }
                        }

                        // ---------- INSERT RETENCIONES ----------
                        if (request.Retenciones != null && request.Retenciones.Detalle.Count > 0)
                        {
                            int nroRetencion;
                            int anioRetencion = DateTime.Now.Year;

                            using (var cmdMax = new SqlCommand(
                                       "SELECT ISNULL(MAX(nro_retencion),0) FROM RETENCION_CABECERA_PROV WHERE anio=@anio", con, tx))
                            {
                                cmdMax.Parameters.AddWithValue("@anio", anioRetencion);
                                nroRetencion = (int)cmdMax.ExecuteScalar() + 1;

                                using (var cmdUpdateOrden = new SqlCommand(
                                           "UPDATE Ordenes_Pago SET nro_retencion = @NroRetencion WHERE nro_orden_pago = @NroOrdenPago", con, tx))
                                {
                                    cmdUpdateOrden.Parameters.AddWithValue("@NroRetencion", nroRetencion);
                                    cmdUpdateOrden.Parameters.AddWithValue("@NroOrdenPago", nroOrdenPago);
                                    cmdUpdateOrden.ExecuteNonQuery();
                                }
                            }

                            string certificado = nroRetencion.ToString("D6") + anioRetencion.ToString("D4");

                            using (var cmdCab = new SqlCommand(
                                       @"INSERT INTO RETENCION_CABECERA_PROV (anio,nro_retencion, fecha_movimiento, importe, anulado, usuario,fecha_anulado,usuario_anula,certificado)
                                     VALUES (@Anio,@NroRet, @FechaMov, @Importe, 0, @Usuario, @FechaAnul, @UsuarioAnula, @Certificado)", con, tx))
                            {
                                cmdCab.Parameters.AddWithValue("@Anio", anioRetencion);
                                cmdCab.Parameters.AddWithValue("@NroRet", nroRetencion);
                                cmdCab.Parameters.AddWithValue("@FechaMov", DateTime.Now);
                                cmdCab.Parameters.AddWithValue("@Importe", request.Retenciones.ImporteTotal);
                                cmdCab.Parameters.AddWithValue("@Usuario", request.Auditoria.usuario);
                                cmdCab.Parameters.AddWithValue("@FechaAnul", DateTime.Now);
                                cmdCab.Parameters.AddWithValue("@UsuarioAnula", request.Auditoria.usuario);
                                cmdCab.Parameters.AddWithValue("@Certificado", certificado);
                                cmdCab.ExecuteNonQuery();
                            }

                            foreach (var ret in request.Retenciones.Detalle)
                            {
                                using (var cmdDet = new SqlCommand(
                                           @"INSERT INTO RETENCION_DETALLE_PROV (anio, nro_retencion, cod_concepto_retencion, importe)
                                         VALUES (@Anio, @NroRet, @CodConcepto, @Importe)", con, tx))
                                {
                                    cmdDet.Parameters.AddWithValue("@Anio", anioRetencion);
                                    cmdDet.Parameters.AddWithValue("@NroRet", nroRetencion);
                                    cmdDet.Parameters.AddWithValue("@CodConcepto", ret.CodConceptoRetencion);
                                    cmdDet.Parameters.AddWithValue("@Importe", ret.Importe);
                                    cmdDet.ExecuteNonQuery();
                                }
                            }
                        }

                        // ---------- INSERT AUDITORÍA ----------
                        using (var auditorCmd = new SqlCommand("AUDITOR_V2", con, tx))
                        {
                            auditorCmd.CommandType = CommandType.StoredProcedure;

                            auditorCmd.Parameters.AddWithValue("@usuario", request.Auditoria.usuario);
                            auditorCmd.Parameters.AddWithValue("@autorizacion", request.Auditoria.autorizaciones ?? "");
                            auditorCmd.Parameters.AddWithValue("@identificacion", nroOrdenPago.ToString());
                            auditorCmd.Parameters.AddWithValue("@observaciones", request.Auditoria.observaciones ?? "");
                            auditorCmd.Parameters.AddWithValue("@proceso", "NUEVA ORDEN DE PAGO");

                            string detalle = $"Nro de orden de pago: {nroOrdenPago} Fecha de orden de pago: {request.Orden.FechaOrdenPago:yyyy-MM-dd} Importe: {request.Orden.Importe}";
                            auditorCmd.Parameters.AddWithValue("@detalle", detalle);

                            auditorCmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return nroOrdenPago;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }




        /// <summary>
        /// Elimina una Orden de Pago replicando la secuencia Delphi.
        /// - Valida: Notas_Contabi y cierre de caja.
        /// - Actualiza Presupuesto_Egreso (importe_pagado / importe_a_pagar) usando QCtas_x_Orden.
        /// - Revierte saldos de cuentas bancarias y borra Movimientos/FP (QForma_Pago_Orden).
        /// - Recompone saldos de Ordenes_Compra y borra pagos (QPagos_x_Orden_Compra2/3).
        /// - Borra Pagos_x_Programas_Publicos, Retenciones y finalmente ORDENES_PAGO.
        /// - Registra auditoría AUDITOR_V2.
        /// </summary>
        public static void delete(int nroOrdenPago,Auditoria request )
        {
            using (SqlConnection con = GetConnectionSIIMVA())
            {
                con.Open();

                using (SqlTransaction tx = con.BeginTransaction())
                {

                // Traigo datos base de la OP (fecha/cod_proveedor/importe) para validaciones + auditoría
                DateTime fechaOrdenPago;
                int codProveedor;
                decimal importeOrden;

                using (var cmd = new SqlCommand(
                    @"SELECT fecha_orden_pago, ISNULL(cod_proveedor,0), ISNULL(importe,0)
                  FROM ORDENES_PAGO WITH (NOLOCK)
                  WHERE nro_orden_pago = @nro", con))
                {
                    cmd.Parameters.AddWithValue("@nro", nroOrdenPago);
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                            throw new InvalidOperationException("La Orden de Pago no existe.");

                        fechaOrdenPago = rd.IsDBNull(0) ? DateTime.MinValue : rd.GetDateTime(0);
                        codProveedor = rd.IsDBNull(1) ? 0 : rd.GetInt32(1);
                        importeOrden = rd.IsDBNull(2) ? 0m : rd.GetDecimal(2);
                    }
                }

                // VALIDACIONES previas (equivalentes a las de Delphi)
                // 1) No debe existir Nota de Contabilidad para la OP
                using (var cmd = new SqlCommand(
                    @"IF EXISTS(SELECT 1 FROM NOTAS_CONTABI WITH (NOLOCK) WHERE nro_orden_pago = @nro)
                  SELECT 1 ELSE SELECT 0", con))
                {
                    cmd.Parameters.AddWithValue("@nro", nroOrdenPago);
                    var existeNota = (int)cmd.ExecuteScalar() == 1;
                    if (existeNota)
                        throw new InvalidOperationException("Esta Orden de Pago ya tiene Nota de Contabilidad.");
                }

                // 2) No debe existir cierre de caja para la fecha de la OP
                if (fechaOrdenPago != DateTime.MinValue)
                {
                    using (var cmd = new SqlCommand(
                        @"IF EXISTS(
                          SELECT 1 FROM PLANILLAS_CAJA WITH (NOLOCK)
                          WHERE CAST(fecha_cierre AS date) = CAST(@fec AS date)
                      ) SELECT 1 ELSE SELECT 0", con))
                    {
                        cmd.Parameters.AddWithValue("@fec", fechaOrdenPago);
                        var diaCerrado = (int)cmd.ExecuteScalar() == 1;
                        if (diaCerrado)
                            throw new InvalidOperationException("Ya se cerró el día. No se puede eliminar la Orden de Pago.");
                    }
                }

                {
                    try
                    {
                        // ---------------------------
                        // 1) AUDITORÍA (cabecera / autorización previa)
                        // ---------------------------
                        using (var cmdAudPrep = new SqlCommand("AUDITOR_V2", con, tx))
                        {
                            cmdAudPrep.CommandType = CommandType.StoredProcedure;
                            cmdAudPrep.Parameters.AddWithValue("@usuario", request.usuario ?? (object)DBNull.Value);
                            cmdAudPrep.Parameters.AddWithValue("@autorizacion", request.autorizaciones ?? (object)DBNull.Value);
                            cmdAudPrep.Parameters.AddWithValue("@identificacion", nroOrdenPago.ToString());
                            cmdAudPrep.Parameters.AddWithValue("@observaciones", request.observaciones ?? (object)DBNull.Value);
                            cmdAudPrep.Parameters.AddWithValue("@proceso", "ELIMINA ORDEN PAGO");
                            cmdAudPrep.Parameters.AddWithValue("@detalle",
                                $"Nº Orden Pago: {nroOrdenPago} Fec. Orden Pago: {fechaOrdenPago:yyyy-MM-dd} " +
                                $"Cod. Proveedor: {codProveedor} Importe : {importeOrden} " +
                                $"Fec. Eliminacion: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                            cmdAudPrep.ExecuteNonQuery();
                        }

                        // ---------------------------
                        // 2) QCtas_x_Orden: Ajuste Presupuesto_Egreso y borrado de CTAS_X_ORDEN_PAGO
                        // ---------------------------
                        string sqlQCtas = @"
                                SELECT
                                       B.nro_cta,
                                       B.concepto,
                                       importe = SUM(A.importe),
                                       A.ejercicio,
                                       A.anexo,
                                       A.inciso,
                                       A.partida_prin,
                                       A.item,
                                       A.sub_item,
                                       A.partida,
                                       A.sub_partida
                                FROM PAGOS_X_ORDEN_COMPRA A WITH (NOLOCK)
                                JOIN PRESUPUESTO_EGRESO B ON
                                    A.ejercicio     = B.ejercicio AND
                                    A.anexo         = B.anexo AND
                                    A.inciso        = B.inciso AND
                                    A.partida_prin  = B.partida_prin AND
                                    A.item          = B.item AND
                                    A.sub_item      = B.sub_item AND
                                    A.partida       = B.partida AND
                                    A.sub_partida   = B.sub_partida
                                WHERE A.nro_orden_pago = @nro
                                GROUP BY
                                       A.ejercicio,
                                       A.anexo,
                                       A.inciso,
                                       A.partida_prin,
                                       A.item,
                                       A.sub_item,
                                       A.partida,
                                       A.sub_partida,
                                       B.nro_cta,
                                       B.concepto";

                        using (var cmdQCtas = new SqlCommand(sqlQCtas, con, tx))
                        {
                            cmdQCtas.Parameters.AddWithValue("@nro", nroOrdenPago);
                            using (var rd = cmdQCtas.ExecuteReader())
                            {
                                while (rd.Read())
                                {
                                    // columnas: 0 nro_cta, 1 concepto, 2 importe, 3..10 claves presupuestarias
                                    var importe = rd.IsDBNull(2) ? 0m : rd.GetDecimal(2);
                                    int ejercicio = rd.GetInt32(3);
                                    int anexo = rd.GetInt32(4);
                                    int inciso = rd.GetInt32(5);
                                    int partida_prin = rd.GetInt32(6);
                                    int item = rd.GetInt32(7);
                                    int sub_item = rd.GetInt32(8);
                                    int partida = rd.GetInt32(9);
                                    int sub_partida = rd.GetInt32(10);

                                    using (var cmdUpdPE = new SqlCommand(@"
                                        UPDATE PRESUPUESTO_EGRESO
                                           SET Importe_Pagado  = ISNULL(Importe_Pagado,0) - @imp,
                                               Importe_A_Pagar = ISNULL(Importe_A_Pagar,0) + @imp
                                         WHERE ejercicio=@ej AND anexo=@ax AND inciso=@in
                                           AND partida_prin=@pp AND item=@it AND sub_item=@si
                                           AND partida=@pa AND sub_partida=@sp;", con, tx))
                                    {
                                        cmdUpdPE.Parameters.AddWithValue("@imp", importe);
                                        cmdUpdPE.Parameters.AddWithValue("@ej", ejercicio);
                                        cmdUpdPE.Parameters.AddWithValue("@ax", anexo);
                                        cmdUpdPE.Parameters.AddWithValue("@in", inciso);
                                        cmdUpdPE.Parameters.AddWithValue("@pp", partida_prin);
                                        cmdUpdPE.Parameters.AddWithValue("@it", item);
                                        cmdUpdPE.Parameters.AddWithValue("@si", sub_item);
                                        cmdUpdPE.Parameters.AddWithValue("@pa", partida);
                                        cmdUpdPE.Parameters.AddWithValue("@sp", sub_partida);
                                        cmdUpdPE.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // Borro CTAS_X_ORDEN_PAGO (todas las filas de la OP)
                        using (var cmdDelCtas = new SqlCommand(
                            "DELETE FROM CTAS_X_ORDEN_PAGO WHERE nro_orden_pago = @nro", con, tx))
                        {
                            cmdDelCtas.Parameters.AddWithValue("@nro", nroOrdenPago);
                            cmdDelCtas.ExecuteNonQuery();
                        }

                        // ---------------------------
                        // 3) QForma_Pago_Orden: Revertir saldos de cuentas bancarias, borrar movimientos y FP
                        // ---------------------------
                        using (var cmdFPO = new SqlCommand(@"
                            SELECT A.nro_item,
                                   A.cod_tipo_movimiento,
                                   A.cod_banco,
                                   B .des_tipo_movimiento,
                                   B.bancario,
                                   A.nro_cuenta,
                                   A.nro_comprobante,
                                   A.fecha_acreditacion,
                                   A.pendiente,
                                   C.nom_banco,
                                   A.importe
                                FROM  FORMA_PAGO_ORDEN A (nolock)
                                RIGHT JOIN  TIPOS_MOVIMIENTOS_FONDOS B on
                                  A.cod_tipo_movimiento=B.cod_tipo_movimiento
                                RIGHT JOIN BANCOS C on
                                  A.cod_banco=C.cod_banco
                                WHERE A.nro_orden_pago=@nro", con, tx))
                        {
                            cmdFPO.Parameters.AddWithValue("@nro", nroOrdenPago);
                            using (var rd = cmdFPO.ExecuteReader())
                            {
                                while (rd.Read())
                                {
                                        int nroItem = rd.IsDBNull(0) ? 0 : rd.GetInt32(0);
                                        int codTipoMov = rd.IsDBNull(1) ? 0 : rd.GetInt32(1);
                                        int codBanco = rd.IsDBNull(2) ? 0 : rd.GetInt32(2);
                                        string desTipoMov = rd.IsDBNull(3) ? "" : rd.GetString(3);
                                        bool bancario = !rd.IsDBNull(4) && rd.GetBoolean(4);
                                        string nroCuenta = rd.IsDBNull(5) ? "" : rd.GetString(5);
                                        string nroComp = rd.IsDBNull(6) ? "" : rd.GetString(6);
                                        DateTime? fechaAcred = rd.IsDBNull(7) ? (DateTime?)null : rd.GetDateTime(7);
                                        bool pendiente = !rd.IsDBNull(8) && rd.GetBoolean(8);
                                        string nomBanco = rd.IsDBNull(9) ? "" : rd.GetString(9);
                                        decimal importeFP = rd.IsDBNull(10) ? 0m : rd.GetDecimal(10);

                                        // Revertir saldos CUENTAS_X_BANCO
                                        using (var cmdUpdCta = new SqlCommand(@"
                                        UPDATE CUENTAS_X_BANCO
                                           SET Saldo_Real    = ISNULL(Saldo_Real,0)    + @imp,
                                               Saldo_Nominal = ISNULL(Saldo_Nominal,0) + CASE WHEN @pend=0 THEN @imp ELSE 0 END
                                         WHERE Cod_Banco = @cb AND Nro_Cuenta = @nc;", con, tx))
                                    {
                                        cmdUpdCta.Parameters.AddWithValue("@imp", importeFP);
                                        cmdUpdCta.Parameters.AddWithValue("@pend", pendiente ? 1 : 0);
                                        cmdUpdCta.Parameters.AddWithValue("@cb", codBanco);
                                        cmdUpdCta.Parameters.AddWithValue("@nc", nroCuenta);
                                        cmdUpdCta.ExecuteNonQuery();
                                    }

                                    // Borrar movimiento bancario (por claves movimiento) 
                                    using (var cmdDelMov = new SqlCommand(@"
                                        DELETE FROM MOVIMIENTOS_BANCARIOS
                                         WHERE Cod_Banco=@cb AND Nro_Cuenta=@nc
                                           AND Cod_Tipo_Movimiento=@ctm AND Nro_Comprobante=@comp;", con, tx))
                                    {
                                        cmdDelMov.Parameters.AddWithValue("@cb", codBanco);
                                        cmdDelMov.Parameters.AddWithValue("@nc", nroCuenta);
                                        cmdDelMov.Parameters.AddWithValue("@ctm", codTipoMov);
                                        cmdDelMov.Parameters.AddWithValue("@comp", nroComp);
                                        cmdDelMov.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // Borrar FORMA_PAGO_ORDEN (todas las filas de la OP)
                        using (var cmdDelFPO = new SqlCommand(
                            "DELETE FROM FORMA_PAGO_ORDEN WHERE nro_orden_pago = @nro", con, tx))
                        {
                            cmdDelFPO.Parameters.AddWithValue("@nro", nroOrdenPago);
                            cmdDelFPO.ExecuteNonQuery();
                        }

                        // ---------------------------
                        // 4) QPagos_x_Orden_Compra2: devolver saldo a las OC afectadas
                        // ---------------------------
                        using (var cmdPxOC2 = new SqlCommand(@"
                                SELECT A.nro_orden_compra, 
                                       B.destino,
                                       B.solicitante,   
                                       total=SUM(A.importe) FROM PAGOS_X_ORDEN_COMPRA A (nolock),
                                                                                     ORDENES_COMPRA B 
                                WHERE A.nro_orden_pago=:nro_orden_pago AND
                                               A.nro_orden_compra=B.nro_orden_compra
                                GROUP BY A.nro_orden_compra,B.destino,B.solicitante", con, tx))
                        {
                            cmdPxOC2.Parameters.AddWithValue("@nro", nroOrdenPago);
                            using (var rd = cmdPxOC2.ExecuteReader())
                            {
                                while (rd.Read())
                                {
                                    int nroOC = rd.GetInt32(0);
                                    decimal total = rd.IsDBNull(1) ? 0m : rd.GetDecimal(1);

                                    using (var cmdUpdOC = new SqlCommand(@"
                                        UPDATE ORDENES_COMPRA
                                           SET Saldo = ISNULL(Saldo,0) + @total
                                         WHERE nro_orden_compra = @oc;", con, tx))
                                    {
                                        cmdUpdOC.Parameters.AddWithValue("@total", total);
                                        cmdUpdOC.Parameters.AddWithValue("@oc", nroOC);
                                        cmdUpdOC.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // 5) QPagos_x_Orden_Compra3: borrar pagos de la OP (se puede borrar directo por nro_orden_pago)
                        using (var cmdDelPxOC = new SqlCommand(
                            "DELETE FROM PAGOS_X_ORDEN_COMPRA WHERE nro_orden_pago = @nro", con, tx))
                        {
                            cmdDelPxOC.Parameters.AddWithValue("@nro", nroOrdenPago);
                            cmdDelPxOC.ExecuteNonQuery();
                        }

                        // 6) QDelete_Pagos_x_Programas: borrar Pagos_x_Programas_Publicos
                        using (var cmdDelProg = new SqlCommand(
                            "DELETE FROM PAGOS_X_PROGRAMAS_PUBLICOS WHERE nro_orden_pago = @nro", con, tx))
                        {
                            cmdDelProg.Parameters.AddWithValue("@nro", nroOrdenPago);
                            cmdDelProg.ExecuteNonQuery();
                        }

                        // 7) Eliminar retenciones vinculadas (siguiendo la lógica Delphi: nro_retencion == nro_orden_pago)
                        using (var cmdDelRetDet = new SqlCommand(
                            "DELETE FROM RETENCION_DETALLE_PROV WHERE nro_retencion = @nro", con, tx))
                        {
                            cmdDelRetDet.Parameters.AddWithValue("@nro", nroOrdenPago);
                            cmdDelRetDet.ExecuteNonQuery();
                        }
                        using (var cmdDelRetCab = new SqlCommand(
                            "DELETE FROM RETENCION_CABECERA_PROV WHERE nro_retencion = @nro", con, tx))
                        {
                            cmdDelRetCab.Parameters.AddWithValue("@nro", nroOrdenPago);
                            cmdDelRetCab.ExecuteNonQuery();
                        }

                        // 8) Borrar la Orden de Pago
                        using (var cmdDelOP = new SqlCommand(
                            "DELETE FROM ORDENES_PAGO WHERE nro_orden_pago = @nro", con, tx))
                        {
                            cmdDelOP.Parameters.AddWithValue("@nro", nroOrdenPago);
                            cmdDelOP.ExecuteNonQuery();
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
    }



}
}
