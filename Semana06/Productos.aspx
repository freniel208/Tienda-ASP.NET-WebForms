<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Semana06.Productos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mantenimiento de Productos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container mt-5 mb-5" style="max-width: 800px;">
            <div class="card shadow">
                <div class="card-header bg-primary text-white">
                    <h4 class="mb-0">Mantenimiento de Productos</h4>
                </div>
                <div class="card-body">
                    <asp:HiddenField ID="hfIdProducto" runat="server" />

                    <div class="mb-3">
                        <label class="form-label fw-bold">Nombre / Descripción:</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="100" placeholder="Ej. Laptop HP 15"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                            ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio" 
                            ForeColor="Red" ValidationGroup="vGroup" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </div>

                    <div class="row g-3 mb-3">
                        <div class="col-md-4">
                            <label class="form-label fw-bold">Precio:</label>
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="0.00"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" 
                                ControlToValidate="txtPrecio" ErrorMessage="El precio es obligatorio" 
                                ForeColor="Red" ValidationGroup="vGroup" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label class="form-label fw-bold">Stock:</label>
                            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" placeholder="0"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvStock" runat="server" 
                                ControlToValidate="txtStock" ErrorMessage="El stock es obligatorio" 
                                ForeColor="Red" ValidationGroup="vGroup" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label class="form-label fw-bold">Categoría:</label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="mb-3">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="vGroup" CssClass="btn btn-success me-2" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger me-2" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" CssClass="btn btn-secondary" />
                    </div>

                    <asp:ValidationSummary ID="vsErrores" runat="server" ForeColor="Red" ValidationGroup="vGroup" CssClass="mb-2" />
                    <asp:Label ID="lblMensaje" runat="server" CssClass="fw-bold d-block mb-3"></asp:Label>

                    <div class="table-responsive">
                        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="idproducto" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged"
                            CssClass="table table-striped table-hover table-bordered align-middle">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-sm btn-outline-primary" />
                                </asp:CommandField>
                                <asp:BoundField DataField="idproducto" HeaderText="ID" />
                                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="precio" HeaderText="Precio" />
                                <asp:BoundField DataField="stock" HeaderText="Stock" />
                                <asp:BoundField DataField="idcategoria" HeaderText="ID Cat" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <hr />
                    <div class="d-flex justify-content-between">
                        <a href="Default.aspx" class="btn btn-link p-0">← Volver al Menú Principal</a>
                        <a href="Categorias.aspx" class="btn btn-link p-0">Ir a Categorías →</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
