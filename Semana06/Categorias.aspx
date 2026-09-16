<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Semana06.Categorias" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mantenimiento de Categorías</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container mt-5" style="max-width: 650px;">
            <div class="card shadow">
                <div class="card-header bg-primary text-white">
                    <h4 class="mb-0">Mantenimiento de Categorías</h4>
                </div>
                <div class="card-body">
                    <asp:HiddenField ID="hfIdCategoria" runat="server" />

                    <div class="mb-3">
                        <label class="form-label fw-bold">Descripción:</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" MaxLength="100" placeholder="Ingrese el nombre de la categoría"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" 
                            ControlToValidate="txtDescripcion" ErrorMessage="La descripción es obligatoria" 
                            ForeColor="Red" ValidationGroup="vGroup" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </div>

                    <div class="mb-3">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="vGroup" CssClass="btn btn-success me-2" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger me-2" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" CssClass="btn btn-secondary" />
                    </div>

                    <asp:ValidationSummary ID="vsErrores" runat="server" ForeColor="Red" ValidationGroup="vGroup" CssClass="mb-2" />
                    <asp:Label ID="lblMensaje" runat="server" CssClass="fw-bold d-block mb-3"></asp:Label>

                    <div class="table-responsive">
                        <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="idcategoria" OnSelectedIndexChanged="gvCategorias_SelectedIndexChanged"
                            CssClass="table table-striped table-hover table-bordered align-middle">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-sm btn-outline-primary" />
                                </asp:CommandField>
                                <asp:BoundField DataField="idcategoria" HeaderText="ID" />
                                <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <hr />
                    <a href="Default.aspx" class="btn btn-link p-0">← Volver al Menú Principal</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>