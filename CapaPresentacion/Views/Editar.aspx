<%@ Page Title="Editar" Language="C#" MasterPageFile="~/CapaPresentacion/MasterPage.master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="InventarioTecnologia.CapaPresentacion.Views.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contenedor-seccion">
        <h2 class="titulo-pagina">Editar Dispositivo</h2>
    </div>

    <div class="contenedor-seccion">
        <asp:HiddenField ID="hfIdDispositivo" runat="server" />
        
        <div class="form-container">
            <div class="form-group">
                <label>Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                    ControlToValidate="txtNombre" ErrorMessage="El nombre es requerido" 
                    CssClass="error" Display="Dynamic" />
            </div>

            <div class="form-group">
                <label>Marca:</label>
                <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvMarca" runat="server" 
                    ControlToValidate="txtMarca" ErrorMessage="La marca es requerida" 
                    CssClass="error" Display="Dynamic" />
            </div>

            <div class="form-group">
                <label>Descripción:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" />
            </div>

            <div class="form-row-dos">
                <div class="form-group">
                    <label>Cantidad:</label>
                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" 
                        ControlToValidate="txtCantidad" ErrorMessage="La cantidad es requerida" 
                        CssClass="error" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revCantidad" runat="server" 
                        ControlToValidate="txtCantidad" ValidationExpression="^\d+$" 
                        ErrorMessage="Ingrese un número entero válido" CssClass="error" Display="Dynamic" />
                </div>

                <div class="form-group">
                    <label>Precio:</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" 
                        ControlToValidate="txtPrecio" ErrorMessage="El precio es requerido" 
                        CssClass="error" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revPrecio" runat="server" 
                        ControlToValidate="txtPrecio" ValidationExpression="^\d+(\.\d{1,2})?$" 
                        ErrorMessage="Ingrese un precio válido (ej: 599.99)" CssClass="error" Display="Dynamic" />
                </div>
            </div>

            <div class="form-group">
                <label>Categoría:</label>
                <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvCategorias" runat="server" 
                    ControlToValidate="ddlCategorias" InitialValue="" 
                    ErrorMessage="Seleccione una categoría" CssClass="error" Display="Dynamic" />
            </div>

            <div class="form-group">
                <label>Estado:</label><br />
                <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" />
            </div>

            <div class="form-botones">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" 
                    OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
                
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                    OnClick="btnCancelar_Click" CssClass="btn btn-secondary" 
                    CausesValidation="false" />
            </div>
        </div>
    </div>
</asp:Content>