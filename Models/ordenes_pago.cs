namespace Web_Api_Contable.Models
{
    public class OrdenPago
    {
        public int NroOrdenPago { get; set; }
        public DateTime FechaOrdenPago { get; set; }
        public int CodProveedor { get; set; }
        public decimal Importe { get; set; }
        public string Usuario { get; set; }
        public string NroFactura { get; set; }
        public string NroRecibo { get; set; }
        public bool? RetencionSI { get; set; }
        public decimal? APagar { get; set; }
        public decimal? Retencion { get; set; }
        public string NroRetencion { get; set; }
        public string ResponsableOP { get; set; }
        public DateTime? FechaMovimientoOP { get; set; }
        public bool Entregada { get; set; }
        public int CodEstadoOP { get; set; }
        public int Anio { get; set; }
        public int? CodEstadoTC { get; set; }
        public DateTime? FechaEnvioTC { get; set; }
        public string UsuarioOPTC { get; set; }
        public DateTime? FechaAprobacion { get; set; }

        public OrdenPago()
        {
            NroOrdenPago = 0;
            FechaOrdenPago = DateTime.Now;
            CodProveedor = 0;
            Importe = 0;
            Usuario = string.Empty;
            NroFactura = string.Empty;
            NroRecibo = string.Empty;
            RetencionSI = null;
            APagar = null;
            Retencion = null;
            NroRetencion = string.Empty;
            ResponsableOP = string.Empty;
            FechaMovimientoOP = null;
            Entregada = false;
            CodEstadoOP = 0;
            Anio = DateTime.Now.Year;
            CodEstadoTC = null;
            FechaEnvioTC = null;
            UsuarioOPTC = string.Empty;
            FechaAprobacion = null;
        }
    }
}
