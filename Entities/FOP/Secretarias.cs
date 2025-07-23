using System.Data.SqlClient;
using System.Data;
using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.FOP
{
    public class Secretarias : DALBase
    {
        public int id_secretaria { get; set; }
        public string descripcion { get; set; }
        public string nombre { get; set; }

        public Secretarias()
        {
            id_secretaria = 0;
            descripcion = string.Empty;
            nombre = string.Empty;
        }
        public static List<Secretarias> getListSecretarias(int idSecretaria)
        {
            var lista = new List<Secretarias>();

            using var conn = DALBase.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            if (idSecretaria > 0)
            {
                cmd.CommandText = @"
                SELECT id_secretaria, descripcion
                FROM Secretaria
                WHERE activa = 1 AND id_secretaria = @IdSecretaria
                ORDER BY descripcion";
                cmd.Parameters.AddWithValue("@IdSecretaria", idSecretaria);
            }
            else
            {
                cmd.CommandText = @"
                SELECT id_secretaria, descripcion
                FROM Secretaria
                WHERE activa = 1
                ORDER BY descripcion";
            }

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var secretaria = new Secretarias
                {
                    id_secretaria = reader.GetInt32(0),
                    descripcion = reader.GetString(1)
                };
                lista.Add(secretaria);
            }

            return lista;
        }

        public static List<Secretarias> getSecretariasByNombre(int ejercicio, string nombreAproximado)
        {
            var lista = new List<Secretarias>();

            var sql = @"
        SELECT 
            Nombre = descripcion,
            Codigo = id_secretaria,
            Activa
        FROM Secretaria
        WHERE
            activa = 1 AND
            ejercicio = @ejercicio AND
            descripcion LIKE @nombre_aproximado
        ORDER BY id_secretaria";

            using (var conn = DALBase.GetConnection("Siimva"))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@ejercicio", ejercicio);
                    cmd.Parameters.AddWithValue("@nombre_aproximado", $"%{nombreAproximado}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Secretarias
                            {
                                nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                id_secretaria = reader.GetInt32(reader.GetOrdinal("Codigo")),
                            });
                        }
                    }
                }
            }

            return lista;
        }



    }

}

