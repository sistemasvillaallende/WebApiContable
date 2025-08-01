namespace Web_Api_Contable.Models
{
    public class HistorialOrdenDePedido
    {
        public int nro_orden_pedido { get; set; }
        public int nro_paso { get; set; }
        public string estado { get; set; }
        public string fecha { get; set; }
        public string observaciones { get; set; }
        public string responsable_op { get; set; }
        public string usuario { get; set; }
        public HistorialOrdenDePedido()
        {
            nro_orden_pedido = 0;
            nro_paso = 0;
            estado = string.Empty;
            fecha = string.Empty;
            observaciones = string.Empty;
            responsable_op = string.Empty;
            usuario = string.Empty;
        }
    }
}
