using System.Data;
using System.Data.SqlClient;
using Semana06.Entidades;

namespace Semana06.CapaDatos
{
    public class ProductoDAO
    {
        private Conexion cnn = new Conexion();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = cnn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("usp_Producto_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public bool Insertar(Producto p)
        {
            using (SqlConnection cn = cnn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("usp_Producto_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                cmd.Parameters.AddWithValue("@stock", p.Stock);
                cmd.Parameters.AddWithValue("@idcategoria", p.IdCategoria);
                cmd.Parameters.AddWithValue("@idestado", p.IdEstado);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Producto p)
        {
            using (SqlConnection cn = cnn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("usp_Producto_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idproducto", p.IdProducto);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                cmd.Parameters.AddWithValue("@stock", p.Stock);
                cmd.Parameters.AddWithValue("@idcategoria", p.IdCategoria);
                cmd.Parameters.AddWithValue("@idestado", p.IdEstado);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection cn = cnn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("usp_Producto_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idproducto", id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable Consultar(string categoria, string estado)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = cnn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("usp_Producto_Consultar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categoria", string.IsNullOrEmpty(categoria) ? (object)System.DBNull.Value : categoria);
                cmd.Parameters.AddWithValue("@estado", string.IsNullOrEmpty(estado) ? (object)System.DBNull.Value : estado);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}