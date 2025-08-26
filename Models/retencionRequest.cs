namespace Web_Api_Contable.Models
{
    public class RetencionRequest
    {
        public decimal ImporteTotal { get; set; }
        public List<RetencionDetalle> Detalle { get; set; }
    }
}
