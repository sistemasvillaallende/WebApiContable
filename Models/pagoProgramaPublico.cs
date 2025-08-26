namespace Web_Api_Contable.Models
{
    public class PagoProgramaPublico
    {
        public int NroOrdenPago { get; set; }
        public int Ejercicio { get; set; }
        public int Anexo { get; set; }
        public int Inciso { get; set; }
        public int PartidaPrin { get; set; }
        public int Item { get; set; }
        public int SubItem { get; set; }
        public int Partida { get; set; }
        public int SubPartida { get; set; }
        public int IdSecretaria { get; set; }
        public int IdDireccion { get; set; }
        public int IdPrograma { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Importe { get; set; }
    }

}
