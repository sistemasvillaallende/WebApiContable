using System.Data.SqlClient;
using System.Data;

namespace Web_Api_Contable.Entities.FOP
{
    public class Vista_Factura
    {
        public int id { get; set; }
        public int nro_orden_pedido { get; set; }
        public string cuit_proveedor { get; set; }
        public string nom_proveedor { get; set; }
        public DateTime fecha_emision_factura { get; set; }
        public long nro_cae { get; set; }
        public decimal importe { get; set; }
        public int tipo_comprobante { get; set; }
        public string des_comprobante_factu { get; set; }
        public string comprobante_factu { get; set; }
        public DateTime fecha_carga { get; set; }
        public int usuario_carga { get; set; }
        public string nom_usr_carga { get; set; }
        public int cod_estado { get; set; }
        public string des_estado_factura { get; set; }
        public int usuario_estado { get; set; }
        public string nom_usr_estado { get; set; }
        //public DateTime fecha_archivo { get; set; }
        public string archivo { get; set; }

        public Vista_Factura()
        {
            id = 0;
            nro_orden_pedido = 0;
            cuit_proveedor = string.Empty;
            nom_proveedor = string.Empty;
            fecha_emision_factura = DateTime.Now;
            nro_cae = 0;
            importe = 0;
            tipo_comprobante = 0;
            des_comprobante_factu = string.Empty;
            comprobante_factu = string.Empty;
            fecha_carga = DateTime.Now;
            usuario_carga = 0;
            nom_usr_carga = string.Empty;
            cod_estado = 0;
            des_estado_factura = string.Empty;
            usuario_estado = 0;
            nom_usr_estado = string.Empty;
            //fecha_archivo = DateTime.Now;
            archivo = string.Empty;
        }

    }
}
