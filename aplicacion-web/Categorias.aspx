<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="aplicacion_web.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="registro-container">
    <div class="mb-3">
        <label for="txtCategoria" class="form-label">Categoria Nueva</label>
        <asp:TextBox CssClass="form-control" ID="txtCategoria" runat="server"></asp:TextBox>
    </div>

    <asp:Button ID="btnAgregarCategoria" runat="server" Text="Agregar Categoría" CssClass="btn btn-primary" OnClick="btnAgregarCategoria_Click" />
    <asp:Button ID="btnCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
</div>


</asp:Content>
