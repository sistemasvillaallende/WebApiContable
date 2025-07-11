using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.ServiceModel;
using Web_Api_Contable.Entities.FOP;
using Web_Api_Contable.Services.FOP;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Factura_x_orden_pedidoController : Controller
    {
        private IFactura_x_orden_pedidoServices _Factura_x_orden_pedidoService;


        public Factura_x_orden_pedidoController(IFactura_x_orden_pedidoServices factura_x_orden_pedidoServices)
        {
            _Factura_x_orden_pedidoService = factura_x_orden_pedidoServices;
        }
        [HttpGet]
        public IActionResult getByPk(int nroop)
        {
            var Factura_x_orden_pedido = _Factura_x_orden_pedidoService.getByPk(nroop);
            if (Factura_x_orden_pedido == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Factura_x_orden_pedido);
        }

        [HttpGet]
        public async Task<string> ValidarComprobante(DateTime fechaemision, long nro_comprobante, int tipoComprobante, long cuit_proveedor,
            string cae, double importe, int punto_venta)
        {
            string respuesta;
            //bool validaOK = false;
            List<Factura_x_orden_pedido> lstOP = new List<Factura_x_orden_pedido>();
            //
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            var endpoint = new EndpointAddress("http://10.0.0.200/WSAfip/WSAFIP.asmx");
            var binding = new BasicHttpBinding();
            var metodo = "CAE";
            var codAutorizacion = cae;
            fechaemision = Convert.ToDateTime(fechaemision.ToShortDateString(), culturaFecArgentina);
            WSAfip.CmpResponse resultado;
            WSAfip.WSAFIPSoapClient clienteAFIP = new WSAfip.WSAFIPSoapClient(binding, endpoint);
            //Validaciones del Comprobante en Base y en Afip.
            //1. Validacion
            //si la lstOP a la que consulto viene vacia es pq esta factura no esta en base
            lstOP = await _Factura_x_orden_pedidoService.ValidarFactura(punto_venta, nro_comprobante, Convert.ToString(cuit_proveedor));
            if (lstOP.Count == 0)
            {
                //2. Validacion
                ////Por este lado ahora valido con afip
                resultado = await clienteAFIP.consultaComprobanteAsync(fechaemision, metodo, nro_comprobante, tipoComprobante, codAutorizacion,
                    cuit_proveedor, importe, punto_venta);
                if (resultado.Resultado == "A")
                    respuesta = "ok";
                else
                    respuesta = "Error Afip : " + resultado.Observaciones[0].Msg;
            }
            else
            {
                respuesta = "No puede agregarse la factura porque ya se encuentra en la order de pedido Nro " + lstOP[0].Nro_orden_pedido.ToString();
            }
            return respuesta;
        }

        [HttpGet]
        public IActionResult getByNro_pedido(int nroop)
        {
            var Factura_x_orden_pedido = _Factura_x_orden_pedidoService.GetByNro_pedido(nroop);
            if (Factura_x_orden_pedido == null)
            {
                return BadRequest(new { message = "Error al obtener los datos!" });
            }
            return Ok(Factura_x_orden_pedido);
        }

        [HttpGet]
        public IActionResult Listar_facturas()
        {
            var facturas = _Factura_x_orden_pedidoService.Listar_facturas();
            //.Where((ent => ent.nro_orden_pedido == 65654));
            return Ok(facturas);
        }

        //[HttpPost]
        //public IActionResult SubirFactura(string nroop, DateTime fechaemision, int punto_venta, long nro_comprobante, int tipoComprobante, long cuit_proveedor,
        //    string cae, double importe, string archivo)
        //{
        //    var resultado = _Factura_x_orden_pedidoService.SubirFactura(nroop, fechaemision, punto_venta, nro_comprobante, tipoComprobante, cuit_proveedor,
        //        cae, importe, archivo);
        //    //var Factura_x_orden_pedido = _Factura_x_orden_pedidoService.read(nroop);
        //    return Ok(resultado);
        //}

        [HttpPost]
        public IActionResult UpdateEstadoFactura(int nroop, DateTime fecha_estado, int estado, string obs_estado)
        {
            _Factura_x_orden_pedidoService.UpdateEstadoFactura(nroop, fecha_estado, estado, obs_estado);
            var facturas = _Factura_x_orden_pedidoService.read(nroop);
            return Ok(facturas);
        }


        [HttpPost]
        public IActionResult SubirFactura()
        {
            string nroop = Request.Form["nroop"];
            DateTime fechaemision = Convert.ToDateTime(Request.Form["fechaemision"], new CultureInfo("es-AR"));
            int punto_venta = Convert.ToInt32(Request.Form["punto_venta"]);
            long nro_comprobante = Convert.ToInt64(Request.Form["nro_comprobante"]);
            int tipocomprobante = Convert.ToInt32(Request.Form["tipocomprobante"]);
            long cuit_proveedor = Convert.ToInt64(Request.Form["cuit_proveedor"]);
            string cae = Request.Form["cae"];
            double importe = Convert.ToInt64(Request.Form["importe"]);
            string archivo = Request.Form["archivo"];

            var resultado = _Factura_x_orden_pedidoService.SubirFactura(nroop, fechaemision, punto_venta, nro_comprobante, tipocomprobante, cuit_proveedor,
                cae, importe, archivo);
            if (resultado == false)
            {
                return BadRequest(new { message = "Error, no se pudo Subir la Factura" });
            }
            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult GetDetalleOPByNro_pedido(int nroop)
        {
            var Factura_x_orden_pedido = _Factura_x_orden_pedidoService.GetDetalleOPByNro_pedido(nroop);
            return Ok(Factura_x_orden_pedido);
        }

        [HttpGet]
        public IActionResult ReadEstadoFactura(int nroop)
        {
            var resultado = _Factura_x_orden_pedidoService.ReadEstadoFactura(nroop);
            if (resultado == null)
            {
                return BadRequest(new { message = "Error al obtener los datos!" });
            }
            return Ok(resultado);
        }
    }
}

