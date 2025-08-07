using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP
{
    public interface IDetalle_orden_compraService
    {
        public Detalle_orden_compra getByPk(int nroOrdenCompra);
    }
}
