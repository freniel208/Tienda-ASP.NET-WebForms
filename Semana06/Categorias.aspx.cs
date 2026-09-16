using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Semana06.CapaNegocio;
using Semana06.Entidades;

namespace Semana06
{
    public partial class Categorias : Page
    {
        CategoriaNegocio cNeg = new CategoriaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            try
            {
                gvCategorias.DataSource = cNeg.Listar();
                gvCategorias.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al cargar datos: " + ex.Message;
            }
        }

        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = gvCategorias.SelectedRow;
            hfIdCategoria.Value = gvCategorias.DataKeys[fila.RowIndex].Value.ToString();
            txtDescripcion.Text = Server.HtmlDecode(fila.Cells[2].Text);
            lblMensaje.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            try
            {
                Categoria c = new Categoria();
                c.Descripcion = txtDescripcion.Text.Trim();

                bool ok;
                if (string.IsNullOrEmpty(hfIdCategoria.Value))
                {
                    ok = cNeg.Insertar(c);
                    lblMensaje.Text = ok ? "Categoria insertada correctamente." : "No se pudo insertar.";
                }
                else
                {
                    c.IdCategoria = int.Parse(hfIdCategoria.Value);
                    ok = cNeg.Actualizar(c);
                    lblMensaje.Text = ok ? "Categoria actualizada correctamente." : "No se pudo actualizar.";
                }

                lblMensaje.ForeColor = ok ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                Limpiar();
                CargarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfIdCategoria.Value))
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Seleccione una categoria del listado.";
                return;
            }

            try
            {
                int id = int.Parse(hfIdCategoria.Value);
                bool ok = cNeg.Eliminar(id);

                lblMensaje.ForeColor = ok ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblMensaje.Text = ok ? "Categoria eliminada correctamente." : "No se pudo eliminar (puede tener productos asociados).";

                Limpiar();
                CargarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            lblMensaje.Text = "";
        }

        private void Limpiar()
        {
            txtDescripcion.Text = "";
            hfIdCategoria.Value = "";
            gvCategorias.SelectedIndex = -1;
        }
    }
}