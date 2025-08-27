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

    }
}
