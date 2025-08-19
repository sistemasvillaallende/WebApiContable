using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP
{
    public class Detalle_orden_compraService : IDetalle_orden_compraService
    {
        public Detalle_orden_compra getByPk(int nroOrdenCompra)
        {
            try
            {
                return Detalle_orden_compra.getByPk(nroOrdenCompra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Detalle_orden_compra> getDetalleOrdenByEjercicio(int ejercicio)
        {
            try
            {
                return Detalle_orden_compra.getDetalleOrdenByEjercicio(ejercicio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
