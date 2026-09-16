using System.Data;
using System.Data.SqlClient;
using Semana06.Entidades;

namespace Semana06.CapaDatos
{
    public class CategoriaDAO
    {
        private Conexion cnn = new Conexion();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = cnn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("usp_Categoria_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public bool Insertar(Categoria c)
        {
            using (SqlConnection cn = cnn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("usp_Categoria_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", c.Descripcion);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Categoria c)
        {
            using (SqlConnection cn = cnn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("usp_Categoria_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcategoria", c.IdCategoria);
                cmd.Parameters.AddWithValue("@descripcion", c.Descripcion);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection cn = cnn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("usp_Categoria_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcategoria", id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}