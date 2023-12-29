<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage.Master" AutoEventWireup="true" CodeBehind="AgregarAdmin.aspx.cs" Inherits="aplicacion_web.AgregarAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="registro-container">
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox CssClass="form-control" TextMode="Email" ID="txtEmail" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtPass" class="form-label">Contraseña</label>
            <asp:TextBox CssClass="form-control" TextMode="Password" ID="txtPass" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtPass2" class="form-label">Confirmar contraseña</label>
            <asp:TextBox CssClass="form-control" TextMode="Password" ID="txtPass2" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-primary" OnClick="btnCrear_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
    </div>


</asp:Content>
