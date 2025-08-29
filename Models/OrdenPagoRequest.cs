namespace Web_Api_Contable.Models
{
    public class OrdenPagoRequest
    {
        public OrdenPago Orden { get; set; }
        public List<FormaPagoOrden> FormasPago { get; set; }

        public List<CtaOrdenPago> Cuentas { get; set; }

        public List<PagoProgramaPublico> pagoProgramaPublico { get; set; }

        public List<PagoOrdenCompra> pagoOrdenCompra { get; set; }
        public RetencionRequest Retenciones { get; set; }
        public string Concepto { get; set; }
        public Auditoria Auditoria { get; set; }

    }
}
