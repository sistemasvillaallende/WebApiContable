using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.GENERAL;
using WSAfip;

namespace Web_Api_Contable.Entities.FOP
{
    public class Factura_x_orden_pedido : DALBase
    {
        public int Id { get; set; }
        public int Nro_orden_pedido { get; set; }
        public string Nro_cuit_proveedor { get; set; }
        public DateTime? Fecha_emision { get; set; }
        public int Punto_venta { get; set; }
        public long Nro_comprobante { get; set; }
        public long Nro_cae { get; set; }
        public decimal Importe { get; set; }
        public int Tipo_comprobante { get; set; } //9
        public int Usuario_carga { get; set; }
        public DateTime? Fecha_carga { get; set; } //11
        public int Estado { get; set; }
        public DateTime? Fecha_estado { get; set; } //13
        public string Archivo { get; set; } //14
        public int Usuario_estado { get; set; } //15
        public string Obs_estado { get; set; } //16
        public string Tip_comp { get; set; }
        public string Comp_completo { get; set; }
        //public string Nom_usr_carga { get; set; }
        //public string Nom_proveedor { get; set; }
        //public string Des_estado { get; set; }
        //public string Nom_usr_estado { get; set; }

        public Factura_x_orden_pedido()
        {
            Id = 0;
            Nro_orden_pedido = 0;
            Nro_cuit_proveedor = string.Empty;
            Fecha_emision = null;
            Punto_venta = 0;
            Nro_comprobante = 0;
            Nro_cae = 0;
            Importe = 0;
            Tipo_comprobante = 0;
            Usuario_carga = 0;
            Fecha_carga = null;
            Estado = 0;
            Tip_comp = string.Empty;
            //12
            Comp_completo = string.Empty;
            Fecha_estado = null;
            Archivo = string.Empty;
            Usuario_estado = 0;
            Obs_estado = string.Empty;
            //Nom_usr_carga = string.Empty;
            //Nom_proveedor = string.Empty;
            //Des_estado = string.Empty;
            //Nom_usr_estado = string.Empty;
        }
        private static List<Factura_x_orden_pedido> mapeo(SqlDataReader dr)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            List<Factura_x_orden_pedido> lst = new List<Factura_x_orden_pedido>();
            Factura_x_orden_pedido obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Factura_x_orden_pedido();
                    if (!dr.IsDBNull(0)) { obj.Id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.Nro_orden_pedido = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.Nro_cuit_proveedor = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.Fecha_emision = Convert.ToDateTime(dr.GetDateTime(3), culturaFecArgentina); }
                    if (!dr.IsDBNull(4)) { obj.Punto_venta = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.Nro_comprobante = dr.GetInt64(5); }
                    if (!dr.IsDBNull(6)) { obj.Nro_cae = dr.GetInt64(6); }
                    if (!dr.IsDBNull(7)) { obj.Importe = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.Tipo_comprobante = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.Usuario_carga = dr.GetInt32(9); }
                    if (!dr.IsDBNull(10)) { obj.Fecha_carga = dr.GetDateTime(10); }
                    if (!dr.IsDBNull(11)) { obj.Estado = dr.GetInt32(11); }
                    if (!dr.IsDBNull(12)) { obj.Fecha_estado = dr.GetDateTime(12); }
                    if (!dr.IsDBNull(13)) { obj.Archivo = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.Usuario_estado = dr.GetInt32(14); }
                    if (!dr.IsDBNull(15)) { obj.Obs_estado = dr.GetString(15); }
                    //
                    switch (obj.Tipo_comprobante)
                    {
                        case 1:
                            obj.Tip_comp = "Factura A";
                            break;
                        case 2:
                            obj.Tip_comp = "Nota de Débito A";
                            break;
                        case 3:
                            obj.Tip_comp = "Nota de Crédito A";
                            break;
                        case 4:
                            obj.Tip_comp = "Recibo A";
                            break;
                        case 5:
                            obj.Tip_comp = "Nota de Venta al Contado A";
                            break;
                        case 6:
                            obj.Tip_comp = "Factura B";
                            break;
                        case 7:
                            obj.Tip_comp = "Nota de Débito B";
                            break;
                        case 8:
                            obj.Tip_comp = "Nota de Crédito B";
                            break;
                        case 9:
                            obj.Tip_comp = "Recibo B";
                            break;
                        case 10:
                            obj.Tip_comp = "Nota de Venta al Contado B";
                            break;
                        case 11:
                            obj.Tip_comp = "Factura C";
                            break;
                        case 12:
                            obj.Tip_comp = "Nota de Débito C";
                            break;
                        case 13:
                            obj.Tip_comp = "Nota de Crédito C";
                            break;
                        case 15:
                            obj.Tip_comp = "Recibo C";
                            break;
                        case 19:
                            obj.Tip_comp = "Factura de Exportación";
                            break;
                        case 20:
                            obj.Tip_comp = "Nota Déb. P/Operac. con el Exterior";
                            break;
                        case 21:
                            obj.Tip_comp = "Nota Créd. P/Operac. con el Exterior";
                            break;
                        case 39:
                            obj.Tip_comp = "Otros Comprobantes A que Cumplan con la R.G. Nro. 1415";
                            break;
                        case 40:
                            obj.Tip_comp = "Otros Comprobantes B que Cumplan con la R.G. Nro. 1415";
                            break;
                        case 49:
                            obj.Tip_comp = "Comprobante de Compra de Bienes Usados";
                            break;
                        case 51:
                            obj.Tip_comp = "Factura M";
                            break;
                        case 52:
                            obj.Tip_comp = "Nota de Débito M";
                            break;
                        case 53:
                            obj.Tip_comp = "Nota de Crédito M";
                            break;
                        case 54:
                            obj.Tip_comp = "Recibo M";
                            break;
                        case 60:
                            obj.Tip_comp = "Cta. de Vta. y Líquido Prod. A";
                            break;
                        case 61:
                            obj.Tip_comp = "Cta. de Vta. y Líquido Prod. B";
                            break;
                        case 63:
                            obj.Tip_comp = "Liquidación A";
                            break;
                        case 64:
                            obj.Tip_comp = "Liquidación B";
                            break;
                        default:
                            break;
                    }
                    //Aca mapea hasta el capmpo tipo_comprobante (13)
                    //13 al 21
                    if (!dr.IsDBNull(13))
                    {
                        obj.Comp_completo = string.Format("(0)-(1)",
                            obj.Punto_venta.ToString().PadLeft(4, Convert.ToChar("0")),
                            obj.Nro_comprobante.ToString().PadLeft(8, Convert.ToChar("0")));
                    }
                    //
                    //if (!dr.IsDBNull(17)) { obj.Obs_estado = dr.GetString(17); }
                    //if (!dr.IsDBNull(18)) { obj.Nom_usr_carga = dr.GetString(18); }
                    //if (!dr.IsDBNull(19)) { obj.Nom_proveedor = dr.GetString(19); }
                    //if (!dr.IsDBNull(20)) { obj.Des_estado = dr.GetString(20); }
                    //if (!dr.IsDBNull(21)) { obj.Nom_usr_estado = dr.GetString(21); }
                    lst.Add(obj);
                    //Tip_comp = string.Empty;
                    ////12
                    //Comp_completo = string.Empty;
                    //Fecha_estado = DateTime.Now;
                    //Archivo = string.Empty;
                }
            }
            return lst;
        }
        public static List<Factura_x_orden_pedido> read(int nroop)
        {
            try
            {
                List<Factura_x_orden_pedido> lst = new List<Factura_x_orden_pedido>();
                string sql = @"SELECT * 
                               FROM FACTURA_X_ORDEN_PEDIDO
                               WHERE nro_orden_pedido = @NRO_ORDEN_PEDIDO";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@NRO_ORDEN_PEDIDO", nroop);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Factura_x_orden_pedido getByPk(int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM FACTURA_X_ORDEN_PEDIDO ");
                sql.AppendLine("WHERE ID = @ID");
                Factura_x_orden_pedido obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Factura_x_orden_pedido> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Factura_x_orden_pedido> GetByNro_pedido(int nroop)
        {
            try
            {
                string sql = @"SELECT * 
                               FROM FACTURA_X_ORDEN_PEDIDO
                               WHERE nro_orden_pedido = @nroop";
                List<Factura_x_orden_pedido> lst = new List<Factura_x_orden_pedido>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nroop", nroop);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Factura_x_orden_pedido> ValidarExistencia(int PUNTO_VENTA, long NRO_COMPROBANTE, string NRO_CUIT_PROVEEDOR)
        {
            try
            {
                string sql = @"SELECT *
                               FROM FACTURA_X_ORDEN_PEDIDO 
                               WHERE
                                PUNTO_VENTA=@PUNTO_VENTA AND 
                                NRO_COMPROBANTE=@NRO_COMPROBANTE AND 
                                NRO_CUIT_PROVEEDOR=@NRO_CUIT_PROVEEDOR AND 
                                ESTADO <> 5";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PUNTO_VENTA", PUNTO_VENTA);
                    cmd.Parameters.AddWithValue("@NRO_COMPROBANTE", NRO_COMPROBANTE);
                    cmd.Parameters.AddWithValue("@NRO_CUIT_PROVEEDOR", NRO_CUIT_PROVEEDOR);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    return mapeo(dr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<List<Factura_x_orden_pedido>> ValidarFactura
            (int punto_venta, long nro_comprobante, string cuit_proveedor)
        {
            try
            {
                string sql = @"SELECT *
                               FROM FACTURA_X_ORDEN_PEDIDO 
                               WHERE
                                PUNTO_VENTA=@PUNTO_VENTA AND 
                                NRO_COMPROBANTE=@NRO_COMPROBANTE AND 
                                NRO_CUIT_PROVEEDOR=@NRO_CUIT_PROVEEDOR AND 
                                ESTADO <> 5";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PUNTO_VENTA", punto_venta);
                    cmd.Parameters.AddWithValue("@NRO_COMPROBANTE", nro_comprobante);
                    cmd.Parameters.AddWithValue("@NRO_CUIT_PROVEEDOR", cuit_proveedor);
                    cmd.Connection.Open();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    return mapeo(dr);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int insert(Factura_x_orden_pedido obj)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO FACTURA_X_ORDEN_PEDIDO(");
                sql.AppendLine("NRO_ORDEN_PEDIDO");
                sql.AppendLine(", NRO_CUIT_PROVEEDOR");
                sql.AppendLine(", FECHA_EMISION");
                sql.AppendLine(", PUNTO_VENTA");
                sql.AppendLine(", NRO_COMPROBANTE");
                sql.AppendLine(", NRO_CAE");
                sql.AppendLine(", IMPORTE");
                sql.AppendLine(", TIPO_COMPROBANTE");
                sql.AppendLine(", USUARIO_CARGA");
                sql.AppendLine(", FECHA_CARGA");
                sql.AppendLine(", ESTADO");
                sql.AppendLine(", ARCHIVO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@NRO_ORDEN_PEDIDO");
                sql.AppendLine(", @NRO_CUIT_PROVEEDOR");
                sql.AppendLine(", @FECHA_EMISION");
                sql.AppendLine(", @PUNTO_VENTA");
                sql.AppendLine(", @NRO_COMPROBANTE");
                sql.AppendLine(", @NRO_CAE");
                sql.AppendLine(", @IMPORTE");
                sql.AppendLine(", @TIPO_COMPROBANTE");
                sql.AppendLine(", @USUARIO_CARGA");
                sql.AppendLine(", @FECHA_CARGA");
                sql.AppendLine(", @ESTADO");
                sql.AppendLine(", @ARCHIVO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_ORDEN_PEDIDO", obj.Nro_orden_pedido);
                    cmd.Parameters.AddWithValue("@NRO_CUIT_PROVEEDOR", obj.Nro_cuit_proveedor);
                    cmd.Parameters.AddWithValue("@FECHA_EMISION", Convert.ToDateTime(obj.Fecha_emision, culturaFecArgentina));
                    cmd.Parameters.AddWithValue("@PUNTO_VENTA", obj.Punto_venta);
                    cmd.Parameters.AddWithValue("@NRO_COMPROBANTE", obj.Nro_comprobante);
                    cmd.Parameters.AddWithValue("@NRO_CAE", obj.Nro_cae);
                    cmd.Parameters.AddWithValue("@IMPORTE", obj.Importe);
                    cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", obj.Tipo_comprobante);
                    cmd.Parameters.AddWithValue("@USUARIO_CARGA", obj.Usuario_carga);
                    cmd.Parameters.AddWithValue("@FECHA_CARGA", Convert.ToDateTime(obj.Fecha_carga, culturaFecArgentina));
                    cmd.Parameters.AddWithValue("@ESTADO", obj.Estado);
                    cmd.Parameters.AddWithValue("@ARCHIVO", obj.Archivo);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                    //cmd.ExecuteNonQuery();
                    //return obj.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int insert(Factura_x_orden_pedido obj, SqlConnection cn, SqlTransaction trx)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Factura_x_orden_pedido(");
                sql.AppendLine("NRO_ORDEN_PEDIDO");
                sql.AppendLine(", NRO_CUIT_PROVEEDOR");
                sql.AppendLine(", FECHA_EMISION");
                sql.AppendLine(", PUNTO_VENTA");
                sql.AppendLine(", NRO_COMPROBANTE");
                sql.AppendLine(", NRO_CAE");
                sql.AppendLine(", IMPORTE");
                sql.AppendLine(", TIPO_COMPROBANTE");
                sql.AppendLine(", USUARIO_CARGA");
                sql.AppendLine(", FECHA_CARGA");
                sql.AppendLine(", ESTADO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@NRO_ORDEN_PEDIDO");
                sql.AppendLine(", @NRO_CUIT_PROVEEDOR");
                sql.AppendLine(", @FECHA_EMISION");
                sql.AppendLine(", @PUNTO_VENTA");
                sql.AppendLine(", @NRO_COMPROBANTE");
                sql.AppendLine(", @NRO_CAE");
                sql.AppendLine(", @IMPORTE");
                sql.AppendLine(", @TIPO_COMPROBANTE");
                sql.AppendLine(", @USUARIO_CARGA");
                sql.AppendLine(", @FECHA_CARGA");
                sql.AppendLine(", @ESTADO");
                sql.AppendLine(")");

                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@NRO_ORDEN_PEDIDO", obj.Nro_orden_pedido);
                cmd.Parameters.AddWithValue("@NRO_CUIT_PROVEEDOR", obj.Nro_cuit_proveedor);
                cmd.Parameters.AddWithValue("@FECHA_EMISION", Convert.ToDateTime(obj.Fecha_emision, culturaFecArgentina));
                cmd.Parameters.AddWithValue("@PUNTO_VENTA", obj.Punto_venta);
                cmd.Parameters.AddWithValue("@NRO_COMPROBANTE", obj.Nro_comprobante);
                cmd.Parameters.AddWithValue("@NRO_CAE", obj.Nro_cae);
                cmd.Parameters.AddWithValue("@IMPORTE", obj.Importe);
                cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", obj.Tipo_comprobante);
                cmd.Parameters.AddWithValue("@USUARIO_CARGA", obj.Usuario_carga);
                cmd.Parameters.AddWithValue("@FECHA_CARGA", Convert.ToDateTime(obj.Fecha_carga, culturaFecArgentina));
                cmd.Parameters.AddWithValue("@ESTADO", obj.Estado);
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void update(Factura_x_orden_pedido obj)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Factura_x_orden_pedido SET");
                sql.AppendLine("NRO_ORDEN_PEDIDO=@NRO_ORDEN_PEDIDO");
                sql.AppendLine(", NRO_CUIT_PROVEEDOR=@NRO_CUIT_PROVEEDOR");
                sql.AppendLine(", FECHA_EMISION=@FECHA_EMISION");
                sql.AppendLine(", PUNTO_VENTA=@PUNTO_VENTA");
                sql.AppendLine(", NRO_COMPROBANTE=@NRO_COMPROBANTE");
                sql.AppendLine(", NRO_CAE=@NRO_CAE");
                sql.AppendLine(", IMPORTE=@IMPORTE");
                sql.AppendLine(", TIPO_COMPROBANTE=@TIPO_COMPROBANTE");
                sql.AppendLine(", USUARIO_CARGA=@USUARIO_CARGA");
                sql.AppendLine(", FECHA_CARGA=@FECHA_CARGA");
                sql.AppendLine(", ESTADO=@ESTADO");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_ORDEN_PEDIDO", obj.Nro_orden_pedido);
                    cmd.Parameters.AddWithValue("@NRO_CUIT_PROVEEDOR", obj.Nro_cuit_proveedor);
                    cmd.Parameters.AddWithValue("@FECHA_EMISION", Convert.ToDateTime(obj.Fecha_emision, culturaFecArgentina));
                    cmd.Parameters.AddWithValue("@PUNTO_VENTA", obj.Punto_venta);
                    cmd.Parameters.AddWithValue("@NRO_COMPROBANTE", obj.Nro_comprobante);
                    cmd.Parameters.AddWithValue("@NRO_CAE", obj.Nro_cae);
                    cmd.Parameters.AddWithValue("@IMPORTE", obj.Importe);
                    cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", obj.Tipo_comprobante);
                    cmd.Parameters.AddWithValue("@USUARIO_CARGA", obj.Usuario_carga);
                    cmd.Parameters.AddWithValue("@FECHA_CARGA", Convert.ToDateTime(obj.Fecha_carga, culturaFecArgentina));
                    cmd.Parameters.AddWithValue("@ESTADO", obj.Estado);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void delete(int nroOp)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE Factura_x_orden_pedido");
                sql.AppendLine("WHERE");
                sql.AppendLine("NRO_ORDEN_PEDIDO=@NRO_ORDEN_PEDIDO");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_ORDEN_PEDIDO", nroOp);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(int nroOp, SqlConnection cn, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Factura_x_orden_pedido ");
                sql.AppendLine("WHERE");
                sql.AppendLine("NRO_ORDEN_PEDIDO=@NRO_ORDEN_PEDIDO");
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.Transaction = trx;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_ORDEN_PEDIDO", nroOp);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public static void SubirFactura(int nroop, string archivo, DateTime fecha)
        //{
        //    DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
        //    try
        //    {
        //        StringBuilder sql = new StringBuilder();
        //        sql.AppendLine("UPDATE  Factura_x_orden_pedido");
        //        sql.AppendLine("SET");
        //        sql.AppendLine("fecha_archivo=@fecha,");
        //        sql.AppendLine("archivo=@archivo");
        //        sql.AppendLine("WHERE");
        //        sql.AppendLine("nro_orden_pedido=@nroop");
        //        using (SqlConnection con = GetConnectionSIIMVA())
        //        {
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = sql.ToString();
        //            cmd.Parameters.AddWithValue("@NRO_ORDEN_PEDIDO", nroop);
        //            cmd.Parameters.AddWithValue("@archivo", archivo);
        //            cmd.Parameters.AddWithValue("@fecha_archivo", Convert.ToDateTime(fecha, culturaFecArgentina));

        //            cmd.Connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public static void SubirFactura(Entities.Factura_x_orden_pedido obj, string archivo, DateTime fecha)
        //{
        //    DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
        //    try
        //    {
        //        StringBuilder sql = new StringBuilder();
        //        sql.AppendLine("UPDATE  Factura_x_orden_pedido");
        //        sql.AppendLine("SET");
        //        sql.AppendLine("archivo=@archivo");
        //        sql.AppendLine("WHERE");
        //        sql.AppendLine("nro_orden_pedido=@nroop");
        //        using (SqlConnection con = GetConnectionSIIMVA())
        //        {
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = sql.ToString();
        //            cmd.Parameters.AddWithValue("@nroop", obj.Nro_orden_pedido);
        //            cmd.Parameters.AddWithValue("@archivo", archivo);
        //            cmd.Connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public static bool SubirFactura1(string nroop, DateTime fechaemision, int punto_venta,
            long nro_comprobante, int tipocomprobante, long cuit_proveedor,
            string cae, double importe, string archivo)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            bool retorno = false;
            var resultado = 0;
            try
            {
                string sql = @"UPDATE Factura_x_orden_pedido
                                SET
                                nro_cuit_proveedor=@cuit_proveedor,
                                fecha_emision=@fecha_emision,
                                punto_venta=@punto_venta,
                                nro_comprobante=@nro_comprobante,
                                nro_cae=@nro_cae,
                                importe=@importe,
                                tipo_comprobante=@tipo_comprobante,
                                fecha_carga=@fecha_carga,
                                usuario_carga=@usuario_carga,
                                archivo=@archivo                
                                WHERE nro_orden_pedido=@nroop";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nroop", nroop);
                    cmd.Parameters.AddWithValue("@fecha_emision", Convert.ToDateTime(fechaemision, culturaFecArgentina));
                    cmd.Parameters.AddWithValue("@punto_venta", punto_venta);
                    cmd.Parameters.AddWithValue("@nro_comprobante", nro_comprobante);
                    cmd.Parameters.AddWithValue("@tipo_comprobante", tipocomprobante);
                    cmd.Parameters.AddWithValue("@cuit_proveedor", cuit_proveedor);
                    cmd.Parameters.AddWithValue("@nro_cae", cae);
                    cmd.Parameters.AddWithValue("@importe", importe);
                    cmd.Parameters.AddWithValue("@fecha_carga", Convert.ToDateTime(DateTime.Today, culturaFecArgentina));
                    cmd.Parameters.AddWithValue("@usuario_carga", 0);
                    cmd.Parameters.AddWithValue("@archivo", archivo);
                    cmd.Connection.Open();
                    resultado = cmd.ExecuteNonQuery();
                    if (resultado > 0)
                        retorno = true;
                }
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool SubirFactura(string nroop, DateTime fechaemision, int punto_venta,
            long nro_comprobante, int tipocomprobante, long cuit_proveedor,
            string cae, double importe, string archivo)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            bool retorno = false;
            var resultado = 0;
            try
            {
                Factura_x_orden_pedido oFOP = new Factura_x_orden_pedido();
                oFOP.Nro_orden_pedido = int.Parse(nroop);
                oFOP.Nro_cuit_proveedor = cuit_proveedor.ToString();
                oFOP.Fecha_emision = fechaemision;
                oFOP.Punto_venta = punto_venta;
                oFOP.Nro_comprobante = nro_comprobante;
                oFOP.Nro_cae = long.Parse(cae);
                oFOP.Importe = Convert.ToDecimal(importe);
                oFOP.Tipo_comprobante = tipocomprobante;
                oFOP.Archivo = archivo;
                //
                oFOP.Usuario_carga = 0;
                oFOP.Fecha_carga = DateTime.Now;
                oFOP.Estado = 0;

                resultado = insert(oFOP);
                if (resultado > 0)
                    retorno = true;
                return retorno;
                //string sql = @"UPDATE Factura_x_orden_pedido
                //                SET
                //                nro_cuit_proveedor=@cuit_proveedor,
                //                fecha_emision=@fecha_emision,
                //                punto_venta=@punto_venta,
                //                nro_comprobante=@nro_comprobante,
                //                nro_cae=@nro_cae,
                //                importe=@importe,
                //                tipo_comprobante=@tipo_comprobante,
                //                fecha_carga=@fecha_carga,
                //                usuario_carga=@usuario_carga,
                //                archivo=@archivo                
                //                WHERE nro_orden_pedido=@nroop";
                //using (SqlConnection con = GetConnectionSIIMVA())
                //{
                //    SqlCommand cmd = con.CreateCommand();
                //    cmd.CommandType = CommandType.Text;
                //    cmd.CommandText = sql.ToString();
                //    cmd.Parameters.AddWithValue("@nroop", nroop);
                //    cmd.Parameters.AddWithValue("@fecha_emision", Convert.ToDateTime(fechaemision, culturaFecArgentina));
                //    cmd.Parameters.AddWithValue("@punto_venta", punto_venta);
                //    cmd.Parameters.AddWithValue("@nro_comprobante", nro_comprobante);
                //    cmd.Parameters.AddWithValue("@tipo_comprobante", tipocomprobante);
                //    cmd.Parameters.AddWithValue("@cuit_proveedor", cuit_proveedor);
                //    cmd.Parameters.AddWithValue("@nro_cae", cae);
                //    cmd.Parameters.AddWithValue("@importe", importe);
                //    cmd.Parameters.AddWithValue("@fecha_carga", Convert.ToDateTime(DateTime.Today, culturaFecArgentina));
                //    cmd.Parameters.AddWithValue("@usuario_carga", 0);
                //    cmd.Parameters.AddWithValue("@archivo", archivo);
                //    cmd.Connection.Open();
                //    resultado = cmd.ExecuteNonQuery();
                //    if (resultado > 0)
                //        retorno = true;
                //}
                //return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static List<Vista_Factura> mapeoFactura(SqlDataReader dr)
        {
            List<Vista_Factura> lst = new List<Vista_Factura>();
            Vista_Factura obj;
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int nro_orden_pedido = dr.GetOrdinal("nro_orden_pedido");
                int cuit_proveedor = dr.GetOrdinal("cuit_proveedor");
                int nom_proveedor = dr.GetOrdinal("nom_proveedor");
                int fecha_emision_factura = dr.GetOrdinal("fecha_emision_factura");
                int nro_cae = dr.GetOrdinal("nro_cae");
                int importe = dr.GetOrdinal("importe");
                int tipo_comprobante = dr.GetOrdinal("tipo_comprobante");
                int des_comprobante_factu = dr.GetOrdinal("des_comprobante_factu");
                int comprobante_factu = dr.GetOrdinal("comprobante_factu");
                int fecha_carga = dr.GetOrdinal("fecha_carga");
                int usuario_carga = dr.GetOrdinal("usuario_carga");
                int nom_usr_carga = dr.GetOrdinal("nom_usr_carga");
                int cod_estado = dr.GetOrdinal("cod_estado");
                int des_estado_factura = dr.GetOrdinal("des_estado_factura");
                int usuario_estado = dr.GetOrdinal("usuario_estado");
                int nom_usr_estado = dr.GetOrdinal("nom_usr_estado");
                //int fecha_archivo = dr.GetOrdinal("fecha_archivo");
                int archivo = dr.GetOrdinal("archivo");
                while (dr.Read())
                {
                    obj = new Vista_Factura();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(nro_orden_pedido)) { obj.nro_orden_pedido = dr.GetInt32(nro_orden_pedido); }
                    if (!dr.IsDBNull(cuit_proveedor)) { obj.cuit_proveedor = dr.GetString(cuit_proveedor); }
                    if (!dr.IsDBNull(nom_proveedor)) { obj.nom_proveedor = dr.GetString(nom_proveedor); }
                    if (!dr.IsDBNull(fecha_emision_factura))
                    {
                        obj.fecha_emision_factura =
                            Convert.ToDateTime(dr.GetDateTime(fecha_emision_factura), culturaFecArgentina);
                    }
                    if (!dr.IsDBNull(nro_cae)) { obj.nro_cae = dr.GetInt64(nro_cae); }
                    if (!dr.IsDBNull(importe)) { obj.importe = dr.GetDecimal(importe); }
                    if (!dr.IsDBNull(tipo_comprobante)) { obj.tipo_comprobante = dr.GetInt32(tipo_comprobante); }
                    if (!dr.IsDBNull(des_comprobante_factu)) { obj.des_comprobante_factu = dr.GetString(des_comprobante_factu); }
                    if (!dr.IsDBNull(comprobante_factu)) { obj.comprobante_factu = dr.GetString(comprobante_factu); }
                    if (!dr.IsDBNull(fecha_carga))
                    {
                        obj.fecha_carga =
                            Convert.ToDateTime(dr.GetDateTime(fecha_carga), culturaFecArgentina);
                    }
                    if (!dr.IsDBNull(usuario_carga)) { obj.usuario_carga = dr.GetInt32(usuario_carga); }
                    if (!dr.IsDBNull(nom_usr_carga)) { obj.nom_usr_carga = dr.GetString(nom_usr_carga); }
                    if (!dr.IsDBNull(cod_estado)) { obj.cod_estado = dr.GetInt32(cod_estado); }
                    if (!dr.IsDBNull(des_estado_factura)) { obj.des_estado_factura = dr.GetString(des_estado_factura); }
                    if (!dr.IsDBNull(usuario_estado)) { obj.usuario_estado = dr.GetInt32(usuario_estado); }
                    if (!dr.IsDBNull(nom_usr_estado)) { obj.nom_usr_estado = dr.GetString(nom_usr_estado); }
                    //if (!dr.IsDBNull(fecha_archivo))
                    //{
                    //    obj.fecha_archivo =
                    //        Convert.ToDateTime(dr.GetDateTime(fecha_archivo), culturaFecArgentina);
                    //}
                    if (!dr.IsDBNull(archivo)) { obj.archivo = dr.GetString(archivo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<Vista_Factura> Listar_facturas()
        {
            try
            {
                List<Vista_Factura> lst = new List<Vista_Factura>();
                string sql = @"SELECT 
                                f.id,
	                            f.nro_orden_pedido,
	                            f.NRO_CUIT_PROVEEDOR as cuit_proveedor,
	                            p.nom_proveedor,
	                            f.FECHA_EMISION as fecha_emision_factura,
	                            f.NRO_CAE as nro_cae,
	                            f.IMPORTE as importe,
	                            f.TIPO_COMPROBANTE as tipo_comprobante,
		                            CASE 
			                            WHEN f.TIPO_COMPROBANTE=1 THEN 'Factura A'
			                            WHEN f.TIPO_COMPROBANTE=6 THEN 'Factura B'
			                            WHEN f.TIPO_COMPROBANTE=11 THEN 'Factura C'
			                            ELSE 'Sin Estado' 
		                            END AS des_comprobante_factu,
	                            right('0000'+ cast(f.PUNTO_VENTA as varchar),4) + '-' +
	                            right('00000000'+ cast(f.NRO_COMPROBANTE as varchar),8)  as comprobante_factu,
	                            f.FECHA_CARGA as fecha_carga,
	                            f.USUARIO_CARGA as usuario_carga,
	                            u.NOMBRE_COMPLETO as nom_usr_carga,
	                            f.estado as cod_estado,
		                            CASE 
			                            WHEN f.estado=1 THEN 'Aprobado'
			                            WHEN f.estado=2 THEN 'Rechazado'
			                            ELSE 'Sin Estado' 
		                            END AS des_estado_factura,
	                            f.USUARIO_ESTADO as usuario_estado,
	                            u2.NOMBRE_COMPLETO as nom_usr_estado,
	                            f.archivo
	                            FROM FACTURA_X_ORDEN_PEDIDO f 
	                            JOIN PROVEEDORES p on
	                            f.NRO_CUIT_PROVEEDOR=p.nro_cuit
	                            LEFT JOIN USUARIOS_V2 u on
		                            u.COD_USUARIO=f.USUARIO_CARGA
	                            LEFT JOIN USUARIOS_V2 u2 on    
		                            u2.COD_USUARIO=f.USUARIO_ESTADO
	                            --WHERE f.nro_orden_pedido = 65654
	                            Order by f.FECHA_CARGA";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    //cmd.Parameters.AddWithValue("@NRO_ORDEN_PEDIDO", nroop);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeoFactura(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateEstadoFactura(int nroop, DateTime fecha_estado, int estado, string obs_estado)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            try
            {
                string sql = @"UPDATE Factura_x_orden_pedido
                                SET
                                    fecha_estado=@fecha_estado,
                                    estado=@estado, 
                                    obs_estado=@obs_estado
                                WHERE nro_orden_pedido=@nroop";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nroop", nroop);
                    cmd.Parameters.AddWithValue("@fecha_estado", Convert.ToDateTime(fecha_estado, culturaFecArgentina));
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@obs_estado", obs_estado);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Factura_x_orden_pedido ReadEstadoFactura(int nroop)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            try
            {
                Factura_x_orden_pedido? obj = null;
                string sql = @"Select * 
                               From Factura_x_orden_pedido
                               WHERE nro_orden_pedido=@nroop";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nroop", nroop);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Factura_x_orden_pedido> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }


}
