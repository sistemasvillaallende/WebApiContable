using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.FOP
{
    public class Detalle_orden_compra: DALBase
    {
        
            public int nro_orden_compra { get; set; }
            public int nro_item { get; set; }
            public int? id_secretaria { get; set; }
            public int? id_direccion { get; set; }
            public string? des_item { get; set; }
            public float cantidad { get; set; }
            public decimal precio_unitario { get; set; }
            public decimal importe { get; set; }
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
        
        public Detalle_orden_compra()
        {
            nro_orden_compra = 0;
            nro_item = 0;
            id_secretaria = null;
            id_direccion = null;
            des_item = null;
            cantidad = 0;
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

        public static Detalle_orden_compra getByPk(int nroOrdenCompra)
        {
            using var conn = GetConnectionSIIMVA();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            SELECT 
                nro_orden_compra,
                nro_item,
                id_Secretaria,
                id_direccion,
                des_item,
                cantidad,
                precio_unitario,
                importe,
                ejercicio,
                anexo,
                inciso,
                partida_prin,
                item,
                sub_item,
                partida,
                sub_partida,
                id_oficina,
                id_programa,
                mes,
                nro_nota_contabi
            FROM DETALLE_ORDEN_COMPRA
            WHERE nro_orden_compra = @nro";

            cmd.Parameters.AddWithValue("@nro", nroOrdenCompra);

            using var reader = cmd.ExecuteReader();
            Detalle_orden_compra detalleOrdenCompra = null;
            if (reader.Read())
            {
                detalleOrdenCompra = new Detalle_orden_compra
                {
                    nro_orden_compra = reader.GetInt32(reader.GetOrdinal("nro_orden_compra")),
                    nro_item = reader.GetInt32(reader.GetOrdinal("nro_item")),
                    id_secretaria = reader.IsDBNull(reader.GetOrdinal("id_secretaria")) ? null : reader.GetInt32(reader.GetOrdinal("id_secretaria")),
                    id_direccion = reader.IsDBNull(reader.GetOrdinal("id_direccion")) ? null : reader.GetInt32(reader.GetOrdinal("id_direccion")),
                    des_item = reader.IsDBNull(reader.GetOrdinal("des_item")) ? null : reader.GetString(reader.GetOrdinal("des_item")),
                    cantidad = Convert.ToSingle(reader["cantidad"]),
                    precio_unitario = reader.GetDecimal(reader.GetOrdinal("precio_unitario")),
                    importe = reader.GetDecimal(reader.GetOrdinal("importe")),
                    ejercicio = reader.IsDBNull(reader.GetOrdinal("ejercicio")) ? null : reader.GetInt32(reader.GetOrdinal("ejercicio")),
                    anexo = reader.IsDBNull(reader.GetOrdinal("anexo")) ? null : reader.GetInt32(reader.GetOrdinal("anexo")),
                    inciso = reader.IsDBNull(reader.GetOrdinal("inciso")) ? null : reader.GetInt32(reader.GetOrdinal("inciso")),
                    partida_prin = reader.IsDBNull(reader.GetOrdinal("partida_prin")) ? null : reader.GetInt32(reader.GetOrdinal("partida_prin")),
                    item = reader.IsDBNull(reader.GetOrdinal("item")) ? null : reader.GetInt32(reader.GetOrdinal("item")),
                    sub_item = reader.IsDBNull(reader.GetOrdinal("sub_item")) ? null : reader.GetInt32(reader.GetOrdinal("sub_item")),
                    partida = reader.IsDBNull(reader.GetOrdinal("partida")) ? null : reader.GetInt32(reader.GetOrdinal("partida")),
                    sub_partida = reader.IsDBNull(reader.GetOrdinal("sub_partida")) ? null : reader.GetInt32(reader.GetOrdinal("sub_partida")),
                    id_oficina = reader.IsDBNull(reader.GetOrdinal("id_oficina")) ? null : reader.GetInt32(reader.GetOrdinal("id_oficina")),
                    id_programa = reader.IsDBNull(reader.GetOrdinal("id_programa")) ? null : reader.GetInt32(reader.GetOrdinal("id_programa")),
                    mes = reader.IsDBNull(reader.GetOrdinal("mes")) ? null : reader.GetInt32(reader.GetOrdinal("mes")),
                    nro_nota_contabi = reader.IsDBNull(reader.GetOrdinal("nro_nota_contabi")) ? null : reader.GetInt32(reader.GetOrdinal("nro_nota_contabi"))
                };


            }

            return detalleOrdenCompra;
        }
    }
}
