<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="aplicacion_web.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="smImg" runat="server"></asp:ScriptManager>
    <div class="grid-container">
        <div class="row">
            <div class="col">
                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtPass" class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    <label for="txtPass" class="form-label">Para cambiar tu contraseña presiona <a href="Pass.aspx">aquí</a></label>
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <%--<div class="mb-3">
                    <label for="txtFecha" class="form-label">Fecha de Nacimiento</label>
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>--%>
                <br />
                <asp:Button ID="btnActDatos" runat="server" Text="Actualizar datos" CssClass="btn btn-primary" OnClick="btnActDatos_Click"/>
                <%--<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger"/>--%>
                <br />
                <br />
                <asp:Button ID="btnAdmin" runat="server" Text="Agregar administrador" CssClass="btn btn-info" OnClick="btnAdmin_Click"/>
                <br />
                <br />
                <asp:Button ID="btnArticulos" runat="server" Text="Modificar artículos" CssClass="btn btn-warning" OnClick="btnArticulos_Click" />
                <br />
                <br />
                <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn btn-danger" OnClick="btnCerrarSesion_Click"/>
            </div>

            <div class="col">
                <div class="mb-3">
                    <label for="txtImagen" class="form-label">Imagen</label>
                    <%--<asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control" AutoPostBack="true"
                        OnTextChanged ="txtUrlImagen_TextChanged"></asp:TextBox>--%>
                    <%--<input type="file" id="txtImagen" runat="server" class="form-control"/>--%>
                    <asp:FileUpload ID="fileImagen" runat="server" CssClass="form-control"/>
                    <br />
                    <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="btn btn-primary" AutoPostBack="false" OnClick="btnCargar_Click"/>
                    <label class="lblImg" id="lblImg" runat="server" visible="false">Por favor completa únicamente con archivos ".jpg"</label>
                </div>
                <asp:UpdatePanel ID="upImg" runat="server">
                    <ContentTemplate>
                        <asp:Image ID="imgPerfil" runat="server" CssClass="img-fluid mb-3" ImageUrl="https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg" ImageAlign="Middle"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
    </div>
    </div>



</asp:Content>
