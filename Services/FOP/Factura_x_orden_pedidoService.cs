using System.Text.RegularExpressions;
using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP

{
    public class Factura_x_orden_pedidoService : IFactura_x_orden_pedidoServices
    {
        public List<Factura_x_orden_pedido> read(int nroop)
        {
            try
            {
                return Factura_x_orden_pedido.read(nroop);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Factura_x_orden_pedido getByPk(int ID)
        {
            try
            {
                return Factura_x_orden_pedido.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Factura_x_orden_pedido> GetByNro_pedido(int nroop)
        {
            try
            {
                return Factura_x_orden_pedido.GetByNro_pedido(nroop);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int insert(Factura_x_orden_pedido obj)
        {
            try
            {
                return Factura_x_orden_pedido.insert(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void delete(Factura_x_orden_pedido obj)
        {
            throw new NotImplementedException();
        }
        public void update(Factura_x_orden_pedido obj)
        {
            try
            {
                Factura_x_orden_pedido.update(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Factura_x_orden_pedido>> ValidarFactura(int punto_venta, long nro_comprobante, string cuit_proveedor)
        {
            try
            {
                return await Factura_x_orden_pedido.ValidarFactura(punto_venta, nro_comprobante, cuit_proveedor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public void SubirFactura(int nroop, string archivo, DateTime fecha)
        //{
        //    try
        //    {
        //        Factura_x_orden_pedido.SubirFactura(nroop, archivo, fecha);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //public void SubirFactura(Factura_x_orden_pedido obj, string archivo, DateTime fecha)
        //{
        //    try
        //    {
        //        Factura_x_orden_pedido.SubirFactura(obj, archivo, fecha);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public bool SubirFactura(string nroop, DateTime fechaemision, int punto_venta, long nro_comprobante, int tipocomprobante, long cuit_proveedor,
            string cae, double importe, string archivo)
        {
            try
            {
                return Factura_x_orden_pedido.SubirFactura(nroop, fechaemision, punto_venta, nro_comprobante, tipocomprobante, cuit_proveedor,
                    cae, importe, archivo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Vista_Factura> Listar_facturas()
        {
            try
            {
                return Factura_x_orden_pedido.Listar_facturas();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateEstadoFactura(int nroop, DateTime fecha_estado, int estado, string obs_estado)
        {
            try
            {
                Factura_x_orden_pedido.UpdateEstadoFactura(nroop, fecha_estado, estado, obs_estado);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Detalle_orden_pedido> GetDetalleOPByNro_pedido(int nroop)
        {
            try
            {
                return Detalle_orden_pedido.GetByNro_pedido(nroop);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Factura_x_orden_pedido ReadEstadoFactura(int nroop)
        {
            try
            {
                return Factura_x_orden_pedido.ReadEstadoFactura(nroop);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
