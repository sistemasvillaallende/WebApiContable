using Microsoft.AspNetCore.Mvc;
using MOTOR_WORKFLOW.Models;
using Web_Api_Contable.Entities.FOP;
using Web_Api_Contable.Models;

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
        public int insert(OrdenPedido obj, List<detalleOrdenPedido> detalleItems, Auditoria auditoria)
        {
            try
            {
                return Ordenes_pedido.insert(obj,detalleItems,auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(int nroOrdenPedido, [FromBody] OrdenPedidoRequest request)
        {
            try
            {
                Ordenes_pedido.update(nroOrdenPedido,request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(int nroOrdenPedido)
        {
            try
            {
                Ordenes_pedido.Delete(nroOrdenPedido);
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

