namespace Web_Api_Contable.Models
{
    public class FormaPagoOrden
    {
        public int NroItem { get; set; }
        public int CodTipoMovimiento { get; set; }
        public int CodBanco { get; set; }
        public string NroCuenta { get; set; }
        public string NroComprobante { get; set; }
        public DateTime FechaAcreditacion { get; set; }
        public decimal Importe { get; set; }
        public bool Pendiente { get; set; }
    }
}
