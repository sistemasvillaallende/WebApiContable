using System.Data.SqlClient;
using System.Data;
using Web_Api_Contable.Controllers;
using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.FOP
{
    public class Direcciones: DALBase
    {
        public int id_direccion { get; set; }
        public string descripcion { get; set; }
        public string nroCta{ get; set; }

        public Direcciones()
        {
            id_direccion = 0;
            descripcion = string.Empty;
            nroCta = string.Empty;
        }

        public static List<Direcciones> getListDirecciones(int id_secretaria)
        {
            var direcciones = new List<Direcciones>();

            string strSQL = @"
                SELECT DISTINCT 
                    dxs.id_direccion, 
                    d.Descripcion AS direccion, 
                    dxs.nro_cta 
                FROM DIRECCION_X_SECRETARIA dxs 
                JOIN DIRECCION d ON d.Id_direccion = dxs.Id_direccion 
                WHERE dxs.activo = 1 ";

            if (id_secretaria > 0)
            {
                strSQL += " AND dxs.id_secretaria = @IdSecretaria";
            }

            strSQL += " ORDER BY d.descripcion";

            using (SqlConnection conn = DALBase.GetConnection("Siimva"))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;

                    if (id_secretaria > 0)
                    {
                        cmd.Parameters.AddWithValue("@IdSecretaria", id_secretaria);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            direcciones.Add(new Direcciones
                            {
                                id_direccion = reader.GetInt32(reader.GetOrdinal("id_direccion")),
                                descripcion = reader.GetString(reader.GetOrdinal("direccion")),
                                nroCta = reader.IsDBNull(reader.GetOrdinal("nro_cta"))
                                            ? null
                                            : reader.GetString(reader.GetOrdinal("nro_cta"))
                            });
                        }
                    }
                }
            }

            return direcciones;
        }


        public static List<Direcciones> getDireccionesByNombre(int ejercicio, string nombre)
        {
            var lista = new List<Direcciones>();

            var sql = @"
                SELECT 
                    Nombre = descripcion,
                    Codigo = id_direccion,
                    Activa
                FROM Direccion
                WHERE
                    activa = 1 
                    AND ejercicio = @ejercicio
                    AND descripcion LIKE @nombre_aproximado
                ORDER BY id_direccion";

            using (var conn = DALBase.GetConnection("Siimva"))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@ejercicio", ejercicio);
                    cmd.Parameters.AddWithValue("@nombre_aproximado", $"%{nombre}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Direcciones
                            {
                                descripcion = reader["Nombre"].ToString(),
                                id_direccion = Convert.ToInt32(reader["Codigo"]),
                            });
                        }
                    }
                }
            }

            return lista;
        }


    }
}
