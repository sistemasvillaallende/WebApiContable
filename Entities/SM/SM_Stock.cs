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
    public class SM_Stock : DALBase
    {
        public int cod_material { get; set; }
        public string des_material { get; set; }
        public Single cant_material { get; set; }
        public int id_tipo_material { get; set; }
        public bool insumo { get; set; }

        public SM_Stock()
        {
            cod_material = 0;
            des_material = string.Empty;
            cant_material = 0;
            id_tipo_material = 0;
            insumo = false;
        }

        private static List<SM_Stock> mapeo(SqlDataReader dr)
        {
            List<SM_Stock> lst = new List<SM_Stock>();
            SM_Stock obj;
            if (dr.HasRows)
            {
                int cod_material = dr.GetOrdinal("cod_material");
                int des_material = dr.GetOrdinal("des_material");
                int cant_material = dr.GetOrdinal("cant_material");
                int id_tipo_material = dr.GetOrdinal("id_tipo_material");
                int insumo = dr.GetOrdinal("insumo");
                while (dr.Read())
                {
                    obj = new SM_Stock();
                    if (!dr.IsDBNull(cod_material)) { obj.cod_material = dr.GetInt32(cod_material); }
                    if (!dr.IsDBNull(des_material)) { obj.des_material = dr.GetString(des_material); }
                    if (!dr.IsDBNull(cant_material)) { obj.cant_material = dr.GetFloat(cant_material); }
                    if (!dr.IsDBNull(id_tipo_material)) { obj.id_tipo_material = dr.GetInt32(id_tipo_material); }
                    if (!dr.IsDBNull(insumo)) { obj.insumo = dr.GetBoolean(insumo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<SM_Stock> read()
        {
            try
            {
                List<SM_Stock> lst = new List<SM_Stock>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Sm_stock";
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

        public static SM_Stock getByPk(
        int cod_material)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM SM_Stock WHERE");
                sql.AppendLine("cod_material = @cod_material");
                SM_Stock? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_material", cod_material);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<SM_Stock> lst = mapeo(dr);
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

        public static int insert(SM_Stock obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO SM_Stock(");
                sql.AppendLine("cod_material");
                sql.AppendLine(", des_material");
                sql.AppendLine(", cant_material");
                sql.AppendLine(", id_tipo_material");
                sql.AppendLine(", insumo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_material");
                sql.AppendLine(", @des_material");
                sql.AppendLine(", @cant_material");
                sql.AppendLine(", @id_tipo_material");
                sql.AppendLine(", @insumo");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_material", obj.cod_material);
                    cmd.Parameters.AddWithValue("@des_material", obj.des_material);
                    cmd.Parameters.AddWithValue("@cant_material", obj.cant_material);
                    cmd.Parameters.AddWithValue("@id_tipo_material", obj.id_tipo_material);
                    cmd.Parameters.AddWithValue("@insumo", obj.insumo);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(SM_Stock obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  SM_Stock SET");
                sql.AppendLine("des_material=@des_material");
                sql.AppendLine(", cant_material=@cant_material");
                sql.AppendLine(", id_tipo_material=@id_tipo_material");
                sql.AppendLine(", insumo=@insumo");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_material=@cod_material");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_material", obj.cod_material);
                    cmd.Parameters.AddWithValue("@des_material", obj.des_material);
                    cmd.Parameters.AddWithValue("@cant_material", obj.cant_material);
                    cmd.Parameters.AddWithValue("@id_tipo_material", obj.id_tipo_material);
                    cmd.Parameters.AddWithValue("@insumo", obj.insumo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(SM_Stock obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE SM_Stock ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_material=@cod_material");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_material", obj.cod_material);
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

