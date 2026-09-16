using System.Data;
using System.Data.SqlClient;

namespace Semana06.CapaDatos
{
    public class EstadoDAO
    {
        private Conexion cnn = new Conexion();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = cnn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("usp_Estado_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}