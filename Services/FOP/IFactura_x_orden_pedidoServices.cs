using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP

{
    public interface IFactura_x_orden_pedidoServices
    {
        public List<Factura_x_orden_pedido> read(int nroop);
        public Factura_x_orden_pedido getByPk(int ID);

        public List<Factura_x_orden_pedido> GetByNro_pedido(int nroop);
        public int insert(Factura_x_orden_pedido obj);
        public void update(Factura_x_orden_pedido obj);
        public void delete(Factura_x_orden_pedido obj);
        public Task<List<Factura_x_orden_pedido>> ValidarFactura
            (int punto_venta, long nro_comprobante, string cuit_proveedor);
        //public void SubirFactura(int nroop, string archivo, DateTime fecha);
        public bool SubirFactura(string nroop, DateTime fechaemision, int punto_venta, long nro_comprobante, int tipocomprobante, long cuit_proveedor,
            string cae, double importe, string archivo);
        public List<Vista_Factura> Listar_facturas();
        public void UpdateEstadoFactura(int nroop, DateTime fecha_estado, int estado, string obs_estado);
        public List<Detalle_orden_pedido> GetDetalleOPByNro_pedido(int nroop);
        public Factura_x_orden_pedido ReadEstadoFactura(int nroop);


    }

}
