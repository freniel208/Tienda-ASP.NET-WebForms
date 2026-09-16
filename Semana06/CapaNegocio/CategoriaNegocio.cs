using System.Data;
using Semana06.CapaDatos;
using Semana06.Entidades;

namespace Semana06.CapaNegocio
{
    public class CategoriaNegocio
    {
        private CategoriaDAO cDao = new CategoriaDAO();

        public DataTable Listar() => cDao.Listar();
        public bool Insertar(Categoria c) => cDao.Insertar(c);
        public bool Actualizar(Categoria c) => cDao.Actualizar(c);
        public bool Eliminar(int id) => cDao.Eliminar(id);
    }
}