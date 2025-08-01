using Microsoft.AspNetCore.Mvc;
using MOTOR_WORKFLOW.Models;
using Web_Api_Contable.Entities.FOP;
using Web_Api_Contable.Models;

namespace Web_Api_Contable.Services.FOP

{
    public class Ordenes_pedidoService : IOrdenes_pedidoService
    {
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

        public void anular(int nroOrdenPedido, [FromBody] Auditoria auditoria)
        {
            try
            {
                Ordenes_pedido.anular(nroOrdenPedido, auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ordenes_pedido> getOrdenByFecha(DateTime fechaDesde, DateTime fechaHasta, int tipoSeleccion)
        {
            try
            {
              return Ordenes_pedido.getOrdenByFecha(fechaDesde, fechaHasta, tipoSeleccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HistorialOrdenDePedido> getHistorialByNro(int nroOrdenPedido)
        {
            try
            {
               return Ordenes_pedido.getHistorialByNro(nroOrdenPedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

