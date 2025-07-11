using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.SM
{
    public class SM_Detalle_solicitud_material : DALBase
    {
        public int id_solicitud { get; set; }
        public int item { get; set; }
        public int id_material { get; set; }
        public string descripcion { get; set; }
        public decimal cantidad { get; set; }
        public int id_unidad_medida { get; set; }
        public decimal precio_referencia { get; set; }
        public int id_aprobador_tecnico { get; set; }
        public string observaciones { get; set; }

        public SM_Detalle_solicitud_material()
        {
            id_solicitud = 0;
            item = 0;
            id_material = 0;
            descripcion = string.Empty;
            cantidad = 0;
            id_unidad_medida = 0;
            precio_referencia = 0;
            id_aprobador_tecnico = 0;
            observaciones = string.Empty;
        }

        private static List<SM_Detalle_solicitud_material> mapeo(SqlDataReader dr)
        {
            List<SM_Detalle_solicitud_material> lst = new List<SM_Detalle_solicitud_material>();
            SM_Detalle_solicitud_material obj;
            if (dr.HasRows)
            {
                int id_solicitud = dr.GetOrdinal("id_solicitud");
                int item = dr.GetOrdinal("item");
                int id_material = dr.GetOrdinal("id_material");
                int descripcion = dr.GetOrdinal("descripcion");
                int cantidad = dr.GetOrdinal("cantidad");
                int id_unidad_medida = dr.GetOrdinal("id_unidad_medida");
                int precio_referencia = dr.GetOrdinal("precio_referencia");
                int id_aprobador_tecnico = dr.GetOrdinal("id_aprobador_tecnico");
                int observaciones = dr.GetOrdinal("observaciones");
                while (dr.Read())
                {
                    obj = new SM_Detalle_solicitud_material();
                    if (!dr.IsDBNull(id_solicitud)) { obj.id_solicitud = dr.GetInt32(id_solicitud); }
                    if (!dr.IsDBNull(item)) { obj.item = dr.GetInt32(item); }
                    if (!dr.IsDBNull(id_material)) { obj.id_material = dr.GetInt32(id_material); }
                    if (!dr.IsDBNull(descripcion)) { obj.descripcion = dr.GetString(descripcion); }
                    if (!dr.IsDBNull(cantidad)) { obj.cantidad = dr.GetDecimal(cantidad); }
                    if (!dr.IsDBNull(id_unidad_medida)) { obj.id_unidad_medida = dr.GetInt32(id_unidad_medida); }
                    if (!dr.IsDBNull(precio_referencia)) { obj.precio_referencia = dr.GetDecimal(precio_referencia); }
                    if (!dr.IsDBNull(id_aprobador_tecnico)) { obj.id_aprobador_tecnico = dr.GetInt32(id_aprobador_tecnico); }
                    if (!dr.IsDBNull(observaciones)) { obj.observaciones = dr.GetString(observaciones); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<SM_Detalle_solicitud_material> read()
        {
            try
            {
                List<SM_Detalle_solicitud_material> lst = new List<SM_Detalle_solicitud_material>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Sm_detalle_solicitud_material";
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

        public static SM_Detalle_solicitud_material getByPk(
        int id_solicitud, int item, int id_material)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Sm_detalle_solicitud_material WHERE");
                sql.AppendLine("id_solicitud = @id_solicitud");
                sql.AppendLine("AND item = @item");
                sql.AppendLine("AND id_material = @id_material");
                SM_Detalle_solicitud_material? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@item", item);
                    cmd.Parameters.AddWithValue("@id_material", id_material);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<SM_Detalle_solicitud_material> lst = mapeo(dr);
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

        public static int insert(SM_Detalle_solicitud_material obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Sm_detalle_solicitud_material(");
                sql.AppendLine("id_solicitud");
                sql.AppendLine(", item");
                sql.AppendLine(", id_material");
                sql.AppendLine(", descripcion");
                sql.AppendLine(", cantidad");
                sql.AppendLine(", id_unidad_medida");
                sql.AppendLine(", precio_referencia");
                sql.AppendLine(", id_aprobador_tecnico");
                sql.AppendLine(", observaciones");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_solicitud");
                sql.AppendLine(", @item");
                sql.AppendLine(", @id_material");
                sql.AppendLine(", @descripcion");
                sql.AppendLine(", @cantidad");
                sql.AppendLine(", @id_unidad_medida");
                sql.AppendLine(", @precio_referencia");
                sql.AppendLine(", @id_aprobador_tecnico");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_solicitud", obj.id_solicitud);
                    cmd.Parameters.AddWithValue("@item", obj.item);
                    cmd.Parameters.AddWithValue("@id_material", obj.id_material);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@cantidad", obj.cantidad);
                    cmd.Parameters.AddWithValue("@id_unidad_medida", obj.id_unidad_medida);
                    cmd.Parameters.AddWithValue("@precio_referencia", obj.precio_referencia);
                    cmd.Parameters.AddWithValue("@id_aprobador_tecnico", obj.id_aprobador_tecnico);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(SM_Detalle_solicitud_material obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Sm_detalle_solicitud_material SET");
                sql.AppendLine("descripcion=@descripcion");
                sql.AppendLine(", cantidad=@cantidad");
                sql.AppendLine(", id_unidad_medida=@id_unidad_medida");
                sql.AppendLine(", precio_referencia=@precio_referencia");
                sql.AppendLine(", id_aprobador_tecnico=@id_aprobador_tecnico");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_solicitud=@id_solicitud");
                sql.AppendLine("AND item=@item");
                sql.AppendLine("AND id_material=@id_material");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_solicitud", obj.id_solicitud);
                    cmd.Parameters.AddWithValue("@item", obj.item);
                    cmd.Parameters.AddWithValue("@id_material", obj.id_material);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@cantidad", obj.cantidad);
                    cmd.Parameters.AddWithValue("@id_unidad_medida", obj.id_unidad_medida);
                    cmd.Parameters.AddWithValue("@precio_referencia", obj.precio_referencia);
                    cmd.Parameters.AddWithValue("@id_aprobador_tecnico", obj.id_aprobador_tecnico);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(SM_Detalle_solicitud_material obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Sm_detalle_solicitud_material ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_solicitud=@id_solicitud");
                sql.AppendLine("AND item=@item");
                sql.AppendLine("AND id_material=@id_material");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_solicitud", obj.id_solicitud);
                    cmd.Parameters.AddWithValue("@item", obj.item);
                    cmd.Parameters.AddWithValue("@id_material", obj.id_material);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

