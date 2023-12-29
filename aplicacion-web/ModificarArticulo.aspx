<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage.Master" AutoEventWireup="true" CodeBehind="ModificarArticulo.aspx.cs" Inherits="aplicacion_web.ModificarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

    <section>
        <div class="dgv-container">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id"/>
                            <asp:BoundField HeaderText="Código" DataField="Codigo" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca" />
                            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                            <asp:CommandField ShowSelectButton="true" HeaderText="Modificar" ButtonType="Button" EditText="Seleccionar" ControlStyle-CssClass="btn btn-primary"/>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar artículo" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
        </div>
    </section>



</asp:Content>
