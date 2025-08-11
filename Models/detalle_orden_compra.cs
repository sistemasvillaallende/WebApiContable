namespace Web_Api_Contable.Models
{
    public class detalle_orden_compra
    {
        public int nro_orden_compra { get; set; }
        public int nro_item { get; set; }
        public int? id_secretaria { get; set; }
        public int? id_direccion { get; set; }
        public string? des_item { get; set; }
        public decimal? cantidad { get; set; }
        public decimal? precio_unitario { get; set; }
        public decimal? importe { get; set; }
        public int? ejercicio { get; set; }
        public int? anexo { get; set; }
        public int? inciso { get; set; }
        public int? partida_prin { get; set; }
        public int? item { get; set; }
        public int? sub_item { get; set; }
        public int? partida { get; set; }
        public int? sub_partida { get; set; }
        public int? id_oficina { get; set; }
        public int? id_programa { get; set; }
        public int? mes { get; set; }
        public int? nro_nota_contabi { get; set; }

        public detalle_orden_compra()
        {
            nro_orden_compra = 0;
            nro_item = 0;
            id_secretaria = null;
            id_direccion = null;
            des_item = null;
            cantidad = null;
            precio_unitario = 0;
            importe = 0;
            ejercicio = null;
            anexo = null;
            inciso = null;
            partida_prin = null;
            item = null;
            sub_item = null;
            partida = null;
            sub_partida = null;
            id_oficina = null;
            id_programa = null;
            mes = null;
            nro_nota_contabi = null;
        }
    }
}
