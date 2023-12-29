<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="aplicacion_web.Articulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section-articulo">
        <div class="section-articulo-container">
            <%--Acá va la imagen--%>
            <asp:Image ID="imgArticulo" runat="server" CssClass="imgArticulo"/>
        </div>
        <div class="section-articulo-container">
            <%--Acá va la descripción y todo eso--%>
            <h2 id="nombreArticulo" runat="server">
                Nombre del producto
            </h2>
            <asp:Button ID="btnFav" runat="server" Text="Añadir a favoritos" CssClass="btn btn-warning" OnClick="btnFav_Click"/>
            <asp:Button ID="btnNoFav" runat="server" Text="Quitar de favoritos" CssClass="btn btn-danger" Enabled="false" OnClick="btnNoFav_Click" />
            <h6 id="precioArticulo" runat="server">
                Precio
            </h6>
            <p id="descArticulo" runat="server"></p>
            <p id="cuotasArticulo" runat="server"></p>
            <div>
                <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" Text="1" CssClass="form-control txtCantidad" min="1"></asp:TextBox>
                <p id="stockArticulo" runat="server"></p>
                <asp:Button ID="btnCarrito" runat="server" Text="Añadir al carrito" CssClass="btn btn-primary btnCarrito" OnClick="btnCarrito_Click"/>
            </div>
            <p>Tus datos están seguros</p>
            <p>Todos los medios de pago</p>
            <p>Envíos a todo el país</p>
        </div>
    </section>
</asp:Content>
