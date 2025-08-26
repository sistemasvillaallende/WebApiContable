namespace Web_Api_Contable.Models
{
    public class PagoOrdenCompra
    {
        public int NroOrdenCompra { get; set; }
        public DateTime FechaPago { get; set; }
        public int Ejercicio { get; set; }
        public string Anexo { get; set; }
        public string Inciso { get; set; }
        public string PartidaPrin { get; set; }
        public string Item { get; set; }
        public string SubItem { get; set; }
        public string Partida { get; set; }
        public string SubPartida { get; set; }
        public decimal Importe { get; set; }
    }

}
