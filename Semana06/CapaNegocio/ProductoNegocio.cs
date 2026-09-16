using System.Data;
using Semana06.CapaDatos;
using Semana06.Entidades;

namespace Semana06.CapaNegocio
{
    public class ProductoNegocio
    {
        private ProductoDAO pDao = new ProductoDAO();

        public DataTable Listar() => pDao.Listar();
        public bool Insertar(Producto p) => pDao.Insertar(p);
        public bool Actualizar(Producto p) => pDao.Actualizar(p);
        public bool Eliminar(int id) => pDao.Eliminar(id);
        public DataTable Consultar(string cat, string est) => pDao.Consultar(cat, est);
    }
}