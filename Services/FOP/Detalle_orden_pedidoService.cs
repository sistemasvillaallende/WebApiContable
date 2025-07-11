using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP

{
    public class Detalle_orden_pedidoService : IDetalle_orden_pedidoService
    {
        public Detalle_orden_pedido getByPk(int Nro_orden_pedido, int Nro_item)
        {
            try
            {
                return Detalle_orden_pedido.getByPk(Nro_orden_pedido, Nro_item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Detalle_orden_pedido> GetByNro_pedido(int Nro_orden_pedido)
        {
            try
            {
                return Detalle_orden_pedido.GetByNro_pedido(Nro_orden_pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Detalle_orden_pedido> read()
        {
            try
            {
                return Detalle_orden_pedido.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Detalle_orden_pedido obj)
        {
            try
            {
                return Detalle_orden_pedido.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Detalle_orden_pedido obj)
        {
            try
            {
                Detalle_orden_pedido.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Detalle_orden_pedido obj)
        {
            try
            {
                Detalle_orden_pedido.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

