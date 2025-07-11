using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP

{
    public class Ordenes_pedidoService : IOrdenes_pedidoService
    {
        public Ordenes_pedido getByPk(int Nro_orden_pedido)
        {
            try
            {
                return Ordenes_pedido.getByPk(Nro_orden_pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ordenes_pedido> read()
        {
            try
            {
                return Ordenes_pedido.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ordenes_pedido> readOrdenesByProveedor(int cod_proveedor)
        {
            try
            {
                return Ordenes_pedido.readOrdenesByProveedor(cod_proveedor);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int insert(Ordenes_pedido obj)
        {
            try
            {
                return Ordenes_pedido.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Ordenes_pedido obj)
        {
            try
            {
                Ordenes_pedido.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Ordenes_pedido obj)
        {
            try
            {
                Ordenes_pedido.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ordenes_pedido> readOrdenesByCuit(string cuit)
        {
            try
            {
                return Ordenes_pedido.readOrdenesByCuit(cuit);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

