using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP

{
    public interface IDetalle_orden_pedidoService
    {
        public List<Detalle_orden_pedido> read();
        public Detalle_orden_pedido getByPk(int Nro_orden_pedido, int Nro_item);
        public List<Detalle_orden_pedido> GetByNro_pedido(int Nro_orden_pedido);
        public int insert(Detalle_orden_pedido obj);
        public void update(Detalle_orden_pedido obj);
        public void delete(Detalle_orden_pedido obj);
    }
}

