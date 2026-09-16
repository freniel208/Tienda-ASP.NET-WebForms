using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Semana06.CapaNegocio;
using Semana06.Entidades;

namespace Semana06
{
    public partial class Productos : Page
    {
        ProductoNegocio pNeg = new ProductoNegocio();
        CategoriaNegocio cNeg = new CategoriaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombos();
                CargarGrid();
            }
        }

        private void CargarCombos()
        {
            try
            {
                ddlCategoria.DataSource = cNeg.Listar();
                ddlCategoria.DataTextField = "descripcion";
                ddlCategoria.DataValueField = "idcategoria";
                ddlCategoria.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al cargar categorías: " + ex.Message;
            }
        }

        private void CargarGrid()
        {
            try
            {
                gvProductos.DataSource = pNeg.Listar();
                gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al cargar productos: " + ex.Message;
            }
        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = gvProductos.SelectedRow;
            hfIdProducto.Value = gvProductos.DataKeys[fila.RowIndex].Value.ToString();
            txtNombre.Text = Server.HtmlDecode(fila.Cells[2].Text);
            txtPrecio.Text = Server.HtmlDecode(fila.Cells[3].Text);
            txtStock.Text = Server.HtmlDecode(fila.Cells[4].Text);

            if (ddlCategoria.Items.FindByValue(fila.Cells[5].Text) != null)
                ddlCategoria.SelectedValue = fila.Cells[5].Text;

            lblMensaje.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            try
            {
                Producto p = new Producto();
                p.Nombre = txtNombre.Text.Trim();
                p.Precio = decimal.Parse(txtPrecio.Text.Trim());
                p.Stock = int.Parse(txtStock.Text.Trim());
                p.IdCategoria = int.Parse(ddlCategoria.SelectedValue);

                bool ok;
                if (string.IsNullOrEmpty(hfIdProducto.Value))
                {
                    ok = pNeg.Insertar(p);
                    lblMensaje.Text = ok ? "Producto insertado correctamente." : "No se pudo insertar.";
                }
                else
                {
                    p.IdProducto = int.Parse(hfIdProducto.Value);
                    ok = pNeg.Actualizar(p);
                    lblMensaje.Text = ok ? "Producto actualizado correctamente." : "No se pudo actualizar.";
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
            if (string.IsNullOrEmpty(hfIdProducto.Value))
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Seleccione un producto del listado.";
                return;
            }

            try
            {
                int id = int.Parse(hfIdProducto.Value);
                bool ok = pNeg.Eliminar(id);

                lblMensaje.ForeColor = ok ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblMensaje.Text = ok ? "Producto eliminado correctamente." : "No se pudo eliminar.";

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
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            hfIdProducto.Value = "";
            gvProductos.SelectedIndex = -1;
        }
    }
}