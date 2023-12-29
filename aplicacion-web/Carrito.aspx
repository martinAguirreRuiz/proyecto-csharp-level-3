<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="aplicacion_web.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <label>Hola, estás en el carrito</label>

    <section>
        <div class="dgv-container">
            <asp:GridView ID="dgvCarrito" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowCommand="dgvCarrito_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:BoundField HeaderText="Cantidad" DataField="CantidadAComprar" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Quitar" CommandName="SelectRow" CommandArgument='<%#Container.DataItemIndex%>' CssClass="btn btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblTotal" runat="server" Text="Total: $"></asp:Label>
            <asp:Button runat="server" ID="btnComprar" CssClass="btn btn-primary" OnClick="btnComprar_Click" Text="Comprar"/>
        </div>
    </section>


</asp:Content>
