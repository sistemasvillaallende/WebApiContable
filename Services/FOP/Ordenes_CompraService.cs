using Microsoft.AspNetCore.Mvc;
using Web_Api_Contable.Entities.FOP;
using Web_Api_Contable.Models;

namespace Web_Api_Contable.Services.FOP
{
    public class Ordenes_CompraService: IOrdenesCompraService
    {
        public Ordenes_compra getByPk(int nroOrdenCompra)
        {
            try
            {
                return Ordenes_compra.getByPk(nroOrdenCompra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Orden_compra obj, List<detalle_orden_compra> detalleItems, Auditoria auditoria)
        {
            try
            {
                return Ordenes_compra.insert(obj, detalleItems, auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(int nroOrdenCompra, [FromBody] OrdenCompraRequest request)
        {
            try
            {
                Ordenes_compra.update(nroOrdenCompra, request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void delete(int nroOrdenCompra ,Auditoria request)
        {
            try
            {
                Ordenes_compra.delete(nroOrdenCompra,request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ordenes_compra> getOrdenByFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                return Ordenes_compra.getOrdenByFecha(fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
