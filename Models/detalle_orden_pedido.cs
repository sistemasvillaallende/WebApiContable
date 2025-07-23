namespace MOTOR_WORKFLOW.Models
{
    public class detalleOrdenPedido
    {
        public int nroOrdenPedido { get; set; }
        public int nroItem { get; set; }
        public string descItem { get; set; }
        public decimal? cantidad { get; set; }
        public decimal? precio { get; set; }
        public decimal? importe { get; set; }
        public int? ejercicio { get; set; }
        public int? anexo { get; set; }
        public int? inciso { get; set; }
        public int? partidaPrin { get; set; }
        public int? item { get; set; }
        public int? subItem { get; set; }
        public int? partida { get; set; }
        public int? subPartida { get; set; }
        public int? idSecretaria { get; set; }
        public int? idDireccion { get; set; }
        public string nroCuenta { get; set; }
        public string usuario { get; set; }
        public int? idOficina { get; set; }
        public int? idPrograma { get; set; }

        public detalleOrdenPedido()
        {
            nroOrdenPedido = 0;
            nroItem = 0;
            descItem = string.Empty;
            cantidad = null;
            precio = null;
            importe = null;
            ejercicio = null;
            anexo = null;
            inciso = null;
            partidaPrin = null;
            item = null;
            subItem = null;
            partida = null;
            subPartida = null;
            idSecretaria = null;
            idDireccion = null;
            nroCuenta = string.Empty;
            usuario = string.Empty;
            idOficina = null;
            idPrograma = null;
        }
    }
}
