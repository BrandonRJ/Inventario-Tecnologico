<%@ Page Title="Listado" Language="C#" MasterPageFile="~/CapaPresentacion/MasterPage.master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="InventarioTecnologia.CapaPresentacion.Views.Listado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="contenedor-seccion">
        <h2 class="titulo-pagina">Listado de Dispositivos</h2>

        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Dispositivo" 
            OnClick="btnNuevo_Click" CssClass="btn btn-nuevo" />
    </div>

    <div class="contenedor-seccion">
        <asp:GridView ID="gvDispositivos" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="IdDispositivo"
            OnRowCommand="gvDispositivos_RowCommand"
            CssClass="tabla-inventario"
            HeaderStyle-CssClass="tabla-header"
            RowStyle-CssClass="tabla-row"
            AlternatingRowStyle-CssClass="tabla-row-alt">

            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Marca" HeaderText="Marca" />
                
                <asp:TemplateField HeaderText="Categoría">
                    <ItemTemplate>
                        <%# Eval("Categoria.NombreCategoria") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                
                <asp:ButtonField CommandName="Editar" Text="Editar" ControlStyle-CssClass="btn-accion edit" />
                <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ControlStyle-CssClass="btn-accion delete" />
            </Columns>

        </asp:GridView>
    </div>

</asp:Content>