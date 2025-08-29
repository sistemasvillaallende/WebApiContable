using MOTOR_WORKFLOW.Models;
using Web_Api_Contable.Entities.FOP;
using Web_Api_Contable.Models;

namespace Web_Api_Contable.Services.FOP
{
    public class Ordenes_pagoService : IOrdenes_pagoService
    {
        public int insert(OrdenPagoRequest request)
        {
            try
            {
                return Ordenes_pago.insert(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(int nroOrdenPago, Auditoria request)
        {
            try
            {
                Ordenes_pago.delete(nroOrdenPago, request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
