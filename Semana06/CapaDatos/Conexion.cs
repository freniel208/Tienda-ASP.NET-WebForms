using System.Data.SqlClient;

namespace Semana06.CapaDatos
{
    public class Conexion
    {
        private string sCnn = "data source=.; initial catalog=Tienda; Integrated Security=True";

        public SqlConnection GetConexion()
        {
            return new SqlConnection(sCnn);
        }
    }
}