namespace MOTOR_WORKFLOW.Models
{
    public class OrdenPedido
    {
        public int nroOrdenPedido { get; set; }
        public DateTime? fechaOrdenPedido { get; set; }
        public decimal? total { get; set; }
        public decimal? saldo { get; set; }
        public int? codProveedor { get; set; }
        public int? codOficinaOrigen { get; set; }
        public int? codOficinaDestino { get; set; }
        public string solicitante { get; set; }
        public string aprobado { get; set; }
        public bool? anulado { get; set; }
        public string usuario { get; set; }
        public string observacion { get; set; }
        public bool? finalizado { get; set; }
        public bool? asignado { get; set; }
        public int? nroOrdenCompra { get; set; }
        public string formaPago { get; set; }
        public string nroPresupuesto { get; set; }
        public string nroFacturas { get; set; }
        public DateTime? fechaOrdenCompra { get; set; }
        public short? recibida { get; set; }
        public DateTime? fechaRecepcion { get; set; }
        public short? web { get; set; }
        public string entregadaPor { get; set; }
        public DateTime? fechaAprobacion { get; set; }
        public short? codEstadoOp { get; set; }
        public int? idLiqTk { get; set; }
        public int? codSecretariaAutoriza { get; set; }
        public int? codOficinaSolicita { get; set; }
        public int? opInterna { get; set; } 

        public OrdenPedido()
        {
            nroOrdenPedido = 0;
            fechaOrdenPedido = null;
            total = null;
            saldo = null;
            codProveedor = null;
            codOficinaOrigen = null;
            codOficinaDestino = null;
            solicitante = string.Empty;
            aprobado = string.Empty;
            anulado = null;
            usuario = string.Empty;
            observacion = string.Empty;
            finalizado = null;
            asignado = null;
            nroOrdenCompra = null;
            formaPago = string.Empty;
            nroPresupuesto = string.Empty;
            nroFacturas = string.Empty;
            fechaOrdenCompra = null;
            recibida = null;
            fechaRecepcion = null;
            web = null;
            entregadaPor = string.Empty;
            fechaAprobacion = null;
            codEstadoOp = null;
            idLiqTk = null;
            codSecretariaAutoriza = null;
            codOficinaSolicita = null;
            opInterna = null;
        }
    }
}
