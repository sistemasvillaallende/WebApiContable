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
    }
}
