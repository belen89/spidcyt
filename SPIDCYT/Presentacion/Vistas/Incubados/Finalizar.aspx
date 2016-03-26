<%@ Page Title="Finalizar Proyectos" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Finalizar.aspx.cs" Inherits="Vistas_Incubados_Baja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style3
        {}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table cellpadding="2" class="TablaABM">
        <tr class="TitulosTablaABM">
            <td colspan="2">
                Proyecto a Finalizar:</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:DropDownList CssClass="ui-button" ID="ddlProyectosIncubados" runat="server" 
                    DataSourceID="ProyectosIncubados" DataTextField="nombreCorto" 
                    DataValueField="idProyecto" 
                    onselectedindexchanged="ddlProyectosIncubados_SelectedIndexChanged" 
                    Width="80%" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="ProyectosIncubados" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>" 
                    
                    SelectCommand="SELECT -1 as idProyecto, 'Seleccione un Proyecto a Finalizar' as nombreCorto
UNION
SELECT Proyecto.idProyecto, Proyecto.nombreCorto FROM Proyecto INNER JOIN TipoProyectoPorProyecto ON Proyecto.idProyecto = TipoProyectoPorProyecto.idProyecto INNER JOIN TipoProyecto ON TipoProyectoPorProyecto.idTipoProyecto = TipoProyecto.idTipoProyecto WHERE (TipoProyecto.nombre LIKE 'Incubado')">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr class="TitulosTablaABM">
            <td colspan="2">
                Finalizar proyecto incubado</td>
        </tr>
        <tr>
            <td>
                <strong>Nombre Corto:</strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:TextBox ID="txtNombreCorto" runat="server" Width="90%" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Nombre Largo:</strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:TextBox ID="txtNombreLargo" runat="server" Rows="4" TextMode="MultiLine" 
                    Width="90%" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Fecha de Inicio:</strong></td>
            <td style="font-weight: 700">
                Fecha de Fin Estimada:</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:TextBox ID="txtFechaInicio" runat="server" Width="50%" Enabled="False"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFechaInicio_CalendarExtender" 
                    runat="server" TargetControlID="txtFechaInicio">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="text-align: center">
                <asp:TextBox ID="txtFechaFinEstimada" runat="server" Width="50%" 
                    Enabled="False"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFechaFinEstimada_CalendarExtender" 
                    runat="server" TargetControlID="txtFechaFinEstimada">
                </ajaxToolkit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>
                Resumen:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:TextBox ID="txtResumen" runat="server" Rows="4" TextMode="MultiLine" 
                    Width="90%" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Área de Investigación:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblAreaDeInvestigacion" runat="server"></asp:Label>
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style3">
                <strong>Fecha de Fin:</strong><asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="La Fecha de Fin es un campo obligatorio." ForeColor="Red" 
                    ControlToValidate="txtFechaDeFin">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ErrorMessage="La Fecha de Fin debe ser una fecha válida." ForeColor="Red" 
                    ControlToValidate="txtFechaDeFin" Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:TextBox ID="txtFechaDeFin" runat="server" Width="80%"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFechaDeFin_CalendarExtender" 
                    runat="server" Format="dd/MM/yyyy" TargetControlID="txtFechaDeFin">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <strong>Razon de Finalización:</strong></td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:DropDownList CssClass="ui-button" ID="ddlRazonDeBaja" runat="server" Width="80%">
                    <asp:ListItem>Finalizado</asp:ListItem>
                    <asp:ListItem>Cancelado</asp:ListItem>                    
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Comentarios de Finalización:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:TextBox ID="txtComentarios" runat="server" Rows="4" TextMode="MultiLine" 
                    Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnFinalizar" runat="server" CssClass="ui-button" 
                    Text="Finalizar el Proyecto" onclick="btnGuardarLosCambios_Click" />
                <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>
            </td>
        </tr>
    </table>

</asp:Content>

