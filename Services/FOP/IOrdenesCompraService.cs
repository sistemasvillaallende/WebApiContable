using Microsoft.AspNetCore.Mvc;
using MOTOR_WORKFLOW.Models;
using Web_Api_Contable.Entities.FOP;
using Web_Api_Contable.Models;

namespace Web_Api_Contable.Services.FOP
{
    public interface IOrdenesCompraService
    {
        public  Ordenes_compra getByPk(int nroOrdenCompra);
        public int insert(Orden_compra obj, List<detalle_orden_compra> detalleItems, Auditoria auditoria);
        public void update(int nroOrdenCompra, [FromBody] OrdenCompraRequest request);

        public List<Ordenes_compra> getOrdenByFecha(DateTime fechaDesde, DateTime fechaHasta);

        public void delete(int nroOrdenCompra, Auditoria request);

    }
}
