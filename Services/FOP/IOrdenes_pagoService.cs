using MOTOR_WORKFLOW.Models;
using Web_Api_Contable.Models;

namespace Web_Api_Contable.Services.FOP
{
    public interface IOrdenes_pagoService
    {
        public int insert(OrdenPagoRequest request);
    }
}
