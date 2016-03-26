<%@ Page Title="Modificar Proyectos Incubados" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Modificar.aspx.cs" Inherits="Vistas_Incubados_Modificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellpadding="2" class="TablaABM">
        <tr class="TitulosTablaABM">
            <td colspan="2">
                Proyecto INCUBADO a Modificar</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:DropDownList CssClass="ui-button" ID="ddlProyectosIncubados" runat="server" OnSelectedIndexChanged="ddlProyectosIncubados_SelectedIndexChanged"
                    Width="80%" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="TitulosTablaABM">
            <td colspan="2">
                Datos del proyecto</td>
        </tr>
        <tr>
            <td>
                <strong>Nombre Corto:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtNombreCorto" ErrorMessage="El Nombre Corto es un campo obligatorio."
                    ForeColor="Red">*</asp:RequiredFieldValidator>
                </strong>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:TextBox ID="txtNombreCorto" runat="server" Width="90%" MaxLength="300"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Nombre Largo:</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:TextBox ID="txtNombreLargo" runat="server" Rows="4" TextMode="MultiLine" 
                    Width="90%" MaxLength="300"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Fecha de Inicio:</strong><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server" ControlToValidate="txtFechaInicio" ErrorMessage="La Fecha de Inicio es un campo obligatorio."
                    ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtFechaInicio"
                    ErrorMessage="La Fecha de Inicio debe ser una fecha válida." ForeColor="Red"
                    Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
            </td>
            <td style="font-weight: 700">
                Fecha de Fin Estimada:<span class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="La Fecha de Fin Estimada es un campo obligatorio."
                        ForeColor="Red" ControlToValidate="txtFechaFinEstimada">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtFechaFinEstimada"
                        ErrorMessage="La Fecha de Fin Estimada debe ser un fecha válida." ForeColor="Red"
                        Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtFechaInicio"
                        ControlToValidate="txtFechaFinEstimada" ErrorMessage="La Fecha de Fin Estimada debe ser Mayor a la Fecha de Inicio"
                        ForeColor="Red" Operator="GreaterThan">*</asp:CompareValidator>
                </span>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:TextBox ID="txtFechaInicio" runat="server" Width="50%"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server"
                    TargetControlID="txtFechaInicio">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="text-align: center">
                <asp:TextBox ID="txtFechaFinEstimada" runat="server" Width="50%"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFechaFinEstimada_CalendarExtender" runat="server"
                    TargetControlID="txtFechaFinEstimada">
                </ajaxToolkit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="TitulosTablaABM" colspan="2">
                Resumen:
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:TextBox ID="txtResumen" runat="server" Rows="4" TextMode="MultiLine" 
                    Width="90%" MaxLength="1000"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Área de Investigación:
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:DropDownList CssClass="ui-button" ID="ddlAreaDeInvestigacion" runat="server" DataSourceID="AreasDeInvestigación"
                    DataTextField="nombre" DataValueField="idAreaDeInvestigacion" Width="80%">
                </asp:DropDownList>
                <asp:SqlDataSource ID="AreasDeInvestigación" runat="server" ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>"
                    SelectCommand="SELECT -1 as idAreaDeInvestigacion, 'Seleccione un Área de Investigación' as nombre
UNION
SELECT * FROM [AreaDeInvestigacion]"></asp:SqlDataSource>
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnGuardarLosCambios" runat="server" CssClass="ui-button" Text="Guardar los Cambios"
                    OnClick="btnGuardarLosCambios_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="lblErrorBecarios" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
