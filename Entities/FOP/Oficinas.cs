using System.Data.SqlClient;
using System.Data;
using Web_Api_Contable.Entities.GENERAL;
using Web_Api_Contable.Entities.SEGURIDAD;

namespace Web_Api_Contable.Entities.FOP
{
    public class Oficinas
    {
        public int id_oficina { get; set; }
        public string nombre { get; set; }


        public Oficinas()
        {
            id_oficina = 0;
            nombre = string.Empty;
        }

        public static List<Oficinas> getListOficinas(int id_oficina)
        {
            var oficinas = new List<Oficinas>();

            var strSQL = @"
        SELECT codigo_oficina, nombre_oficina 
        FROM oficinas 
        WHERE 1=1";

            if (id_oficina > 0)
                strSQL += " AND codigo_oficina = @IdOficina";

            strSQL += " ORDER BY nombre_oficina";

            using (SqlConnection conn = DALBase.GetConnection("Siimva"))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;

                    if (id_oficina > 0)
                        cmd.Parameters.AddWithValue("@IdOficina", id_oficina);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oficinas.Add(new Oficinas
                            {
                                id_oficina = reader.GetInt32(reader.GetOrdinal("codigo_oficina")),
                                nombre = reader.GetString(reader.GetOrdinal("nombre_oficina"))
                            });
                        }
                    }
                }
            }

            return oficinas;
        }

    }
}
