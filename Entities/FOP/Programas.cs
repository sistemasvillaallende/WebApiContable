using System.Data.SqlClient;
using System.Data;
using Web_Api_Contable.Entities.GENERAL;

namespace Web_Api_Contable.Entities.FOP
{
    public class Programas
    {
        public int id_programa { get; set; }
        public string nombre { get; set; }


        public Programas()
        {
            id_programa = 0;
            nombre = string.Empty;
        }
        public static List<Programas> getListProgramas(int id_secretaria, int id_direccion)
        {
            var programas = new List<Programas>();

            string strSQL = @"
                SELECT a.id_programa, p.programa 
                FROM DIRECCION_X_SECRETARIA a 
                JOIN Programas_publicos p ON p.id_programa = a.id_programa 
                WHERE a.activo = 1 
                  AND a.id_secretaria = @IdSecretaria 
                  AND a.id_direccion = @IdDireccion 
                ORDER BY a.id_programa";

            using (SqlConnection conn = DALBase.GetConnection("Siimva"))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;

                    cmd.Parameters.AddWithValue("@IdSecretaria", id_secretaria);
                    cmd.Parameters.AddWithValue("@IdDireccion", id_direccion);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            programas.Add(new Programas
                            {
                                id_programa = reader.GetInt32(reader.GetOrdinal("id_programa")),
                                nombre = reader.GetString(reader.GetOrdinal("programa"))
                            });
                        }
                    }
                }
            }

            return programas;
        }


        public static List<Programas> getListProgramasById(int id_programa)
        {
            var programas = new List<Programas>();

            string strSQL = @"
        SELECT id_programa, programa
        FROM programas_publicos
        WHERE activo = 1";

            if (id_programa > 0)
                strSQL += " AND id_programa = @IdPrograma";

            strSQL += " ORDER BY id_programa";

            using (SqlConnection conn = DALBase.GetConnection("Siimva"))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;

                if (id_programa > 0)
                    cmd.Parameters.AddWithValue("@IdPrograma", id_programa);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        programas.Add(new Programas
                        {
                            id_programa = reader.GetInt32(reader.GetOrdinal("id_programa")),
                            nombre = reader.GetString(reader.GetOrdinal("programa"))
                        });
                    }
                }
            }

            return programas;
        }





    }


}
