using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP

{
    public interface IOrdenes_pedidoService
    {
        public List<Ordenes_pedido> read();
        public Ordenes_pedido getByPk(int Nro_orden_pedido);
        public int insert(Ordenes_pedido obj);
        public void update(Ordenes_pedido obj);
        public void delete(Ordenes_pedido obj);
        public List<Ordenes_pedido> readOrdenesByProveedor(int cod_proveedor);
        public List<Ordenes_pedido> readOrdenesByCuit(string cuit);
    }
}

