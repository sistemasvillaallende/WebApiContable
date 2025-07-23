using MOTOR_WORKFLOW.Models;

namespace Web_Api_Contable.Models
{
    public class OrdenPedidoRequest
    {
        public OrdenPedido Orden { get; set; }
        public List<detalleOrdenPedido> DetalleItems { get; set; }
        public Auditoria Auditoria { get; set; }

    }
}
