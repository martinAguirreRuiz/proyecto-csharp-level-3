<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="aplicacion_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article class="article">
        <section class="article-section-1">
            <div class="section-div">
                <p class="section-div-p1">¡Encontrá las mejores marcas!</p>
                <p class="section-div-p2">En Domotech te ofrecemos los mejores productos de las principales marcas de tecnología en el mercado. Todos nuestros productos cuentan con garantía oficial y nosotros te ofrecemos un seguimiento personalizado durante toda tu compra.</p>
                <p class="section-div-p3">Destacados</p>
            </div>
        </section>
        <section>
            <div class="grid-container">
                <div class="row row-cols-1 row-cols-md-4 g-4">
                    <asp:Repeater ID="repCards" runat="server">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card">
                                    <asp:Image ID="imgArticulo" runat="server" ImageUrl='<%# "~/Imagenes/" + Eval("UrlImagen")%>' CssClass="card-img-top" ImageAlign="Middle" OnDataBinding="imgArticulo_DataBinding"/>
                                    <div class="card-body">
                                        <h5 class="card-title" id="miParrafo" runat="server"><%#Eval("Nombre")%></h5>
                                        <p class="card-text">$<%#Eval("Precio")%></p>
                                    </div>
                                    <asp:Button ID="btn" runat="server" Text="Ver" CssClass="btn btn-primary btn-card" OnClick="btn_Click" />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </section>
    </article>
</asp:Content>
