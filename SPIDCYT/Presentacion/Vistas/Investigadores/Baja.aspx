<%@ Page Title="Baja de Investigadores" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Baja.aspx.cs" Inherits="Vistas_Investigadores_Baja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 124px;
            text-align: right;
            font-weight: bold;
        }
        .style4
        {
            height: 23px;
            text-align: center;
            }
        .style2
        {
            height: 23px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellpadding="2" class="TablaABM">
        <tr>
            <td class="TitulosTablaABM" colspan="2">
                Dar de baja</td>
        </tr>
        <tr>
            <td class="style6">
                Nombre:</td>
            <td>
                <asp:Label ID="lblNombre" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Apellido:</td>
            <td>
                <asp:Label ID="lblApellido" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Teléfono:</td>
            <td>
                <asp:Label ID="lblTelefono" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Dirección de Correo:</td>
            <td>
                <asp:Label ID="lblDireccionDeCorreo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Legajo:</td>
            <td>
                <asp:Label ID="lblLegajo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Fecha de Alta:</td>
            <td>
                <asp:Label ID="lblFechaDeAlta" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TitulosTablaABM" colspan="2">
                Categorias del Investigador</td>
        </tr>
        <tr>
            <td class="style6">
                Categoría UTN:</td>
            <td>
                <asp:Label ID="lblCategoriaUTN" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Fecha Categoría UTN:</td>
            <td>
                <asp:Label ID="lblFechaCategoriaUTN" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Categoría Nacional:</td>
            <td>
                <asp:Label ID="lblCategoriaNacional" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Fecha Categoría Nacional:</td>
            <td class="style2">
                <asp:Label ID="lblFechaCategoriaNacional" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TitulosTablaABM" colspan="2">
                Datos de Baja</td>
        </tr>
        <tr>
            <td class="style6">
                Fecha de Baja:</td>
            <td class="style2">
                <asp:TextBox ID="txtFechaDeBaja" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFechaDeBaja_CalendarExtender" 
                    runat="server" Format="dd/MM/yyyy" TargetControlID="txtFechaDeBaja">
                </ajaxToolkit:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtFechaDeBaja" 
                    ErrorMessage="la Fecha de Baja es Obligatoria." ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ErrorMessage="La Fecha de Baja no es una Fecha Válida." ForeColor="Red" 
                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtFechaDeBaja">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style4" colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td class="style4" colspan="2">
                <asp:Button ID="btnDarDeBaja" runat="server" CssClass="ui-button" 
                    onclick="btnDarDeBaja_Click" Text="Dar de Baja" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="lblNotificaciones" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>
            </td>
        </tr>
    </table>
</asp:Content>

