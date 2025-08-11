namespace Web_Api_Contable.Models
{
    public class OrdenCompraRequest
    {
        public Orden_compra Orden { get; set; }
        public List<detalle_orden_compra> DetalleItems { get; set; }
        public Auditoria Auditoria { get; set; }
    }
}
