namespace Web_Api_Contable.Models
{
    public class Orden_compra
    {
        public int nroOrdenCompra { get; set; }
        public DateTime? fechaOrdenCompra { get; set; }
        public int? nroNotaPedido { get; set; }
        public decimal? total { get; set; }
        public decimal? saldo { get; set; }
        public int? codProveedor { get; set; }
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
        public Orden_compra()
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
    }

}
