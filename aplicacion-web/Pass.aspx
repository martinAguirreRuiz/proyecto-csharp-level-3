<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage.Master" AutoEventWireup="true" CodeBehind="Pass.aspx.cs" Inherits="aplicacion_web.Pass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="registro-container">
        <div class="mb-3">
            <label for="txtPassActual" class="form-label">Contraseña actual</label>
            <asp:TextBox CssClass="form-control" ID="txtPassActual" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtPassNueva" class="form-label">Contraseña nueva</label>
            <asp:TextBox CssClass="form-control" ID="txtPassNueva" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnActPass" runat="server" Text="Cambiar contraseña" CssClass="btn btn-primary" OnClick="btnActPass_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
    </div>

</asp:Content>
