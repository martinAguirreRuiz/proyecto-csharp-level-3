<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage.Master" AutoEventWireup="true" CodeBehind="EdicionArticulo.aspx.cs" Inherits="aplicacion_web.EdicionArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="smImg" runat="server"></asp:ScriptManager>

    <div class="grid-container">

        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="upDatos" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtId" class="form-label">Id</label>
                            <asp:TextBox ID="txtId" runat="server" CssClass="form-control" TextMode="Email" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtCodigo" class="form-label">Código</label>
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtDescripcion" class="form-label">Descripción</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtPrecio" class="form-label">Precio</label>
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtCantidad" class="form-label">Cantidad</label>
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="ddlMarca" class="form-label">Marca</label>
                            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control"></asp:DropDownList>
                            <label for="ddlMarca" class="form-label">Para agregar una marca presiona <a href="Marcas.aspx">aquí</a></label>
                        </div>
                        <div class="mb-3">
                            <label for="ddlCategoria" class="form-label">Categoría</label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
                            <label for="ddlCategoria" class="form-label">Para agregar una categoría presiona <a href="Categorias.aspx">aquí</a></label>
                        </div>
                        <br />
                        <asp:Button ID="btnActDatos" runat="server" Text="Actualizar datos" CssClass="btn btn-primary" OnClick="btnActDatos_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar artículo" CssClass="btn btn-secondary" OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar artículo" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                        <br />
                        <br />
                        <asp:Label ID="lblEliminar" runat="server" Text="Estás seguro que quieres eliminar el artículo?" Visible="false"></asp:Label>
                        <asp:Button ID="btnConfirmar" runat="server" Text="Sí" CssClass="btn btn-dark" onclick="btnConfirmar_Click" Visible="false"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div class="col">
                <div class="mb-3">
                    <label for="txtImagen" class="form-label">Imagen</label>
                    <%--<asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control" AutoPostBack="true"
                    OnTextChanged ="txtUrlImagen_TextChanged"></asp:TextBox>--%>
                    <%--<input type="file" id="txtImagen" runat="server" class="form-control"/>--%>
                    <asp:FileUpload ID="fileImagen" runat="server" CssClass="form-control" />
                    <br />
                    <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="btn btn-primary" AutoPostBack="false" OnClick="btnCargar_Click"/>
                    <label class="lblImg" id="lblImg" runat="server" visible="false">Por favor completa únicamente con archivos ".jpg"</label>
                </div>
                <asp:UpdatePanel ID="upImg" runat="server">
                    <ContentTemplate>
                        <asp:Image ID="imgArticulo" runat="server" CssClass="img-fluid mb-3" ImageUrl="https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg" ImageAlign="Middle" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>



</asp:Content>
