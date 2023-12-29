<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="aplicacion_web.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="registro-container">
        <div class="mb-3">
            <label for="txtMarca" class="form-label">Marca Nueva</label>
            <asp:TextBox CssClass="form-control" ID="txtMarca" runat="server"></asp:TextBox>
        </div>

        <asp:Button ID="btnAgregarMarca" runat="server" Text="Agregar Marca" CssClass="btn btn-primary" OnClick="btnAgregarMarca_Click" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
    </div>


</asp:Content>
