<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="aplicacion_web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <label runat="server" id="lblFav" visible="false">Aún no seleccionaste nada de favoritos!</label>

    <section>
        <div class="dgv-container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="dgvFavoritos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowCommand="dgvFavoritos_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="Quitar de favoritos" CommandName="SelectRow" CommandArgument='<%#Container.DataItemIndex%>' CssClass="btn btn-danger"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
