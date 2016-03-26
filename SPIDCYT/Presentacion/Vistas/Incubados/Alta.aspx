<%@ Page Title="Registrar Proyectos Incubados" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Alta.aspx.cs" Inherits="Vistas_Incubados_AltaIncubado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style2
        {
            font-weight: normal;
        }
    .style3
    {
        height: 23px;
        text-align: center;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellpadding="2" class="TablaABM">
        <tr class="TitulosTablaABM">
            <td colspan="2">
                Datos proyecto incubado</td>
        </tr>
        <tr>
            <td>
                <strong>Nombre Corto:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="txtNombreCorto" 
                    ErrorMessage="El Nombre Corto es un campo obligatorio." ForeColor="Red">*</asp:RequiredFieldValidator>
                </strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:TextBox ID="txtNombreCorto" runat="server" Width="90%" Rows="300"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Nombre Largo:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:TextBox ID="txtNombreLargo" runat="server" Rows="4" TextMode="MultiLine" 
                    Width="90%" MaxLength="300"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Fecha de Inicio:</strong><asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaInicio" 
                    ErrorMessage="La Fecha de Inicio es un campo obligatorio." ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="txtFechaInicio" 
                    ErrorMessage="La Fecha de Inicio debe ser una fecha válida." ForeColor="Red" 
                    Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
            </td>
            <td style="font-weight: 700">
                Fecha de Fin Estimada:<span class="style2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="La Fecha de Fin Estimada es un campo obligatorio." 
                    ForeColor="Red" ControlToValidate="txtFechaFinEstimada">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                    ControlToValidate="txtFechaFinEstimada" 
                    ErrorMessage="La Fecha de Fin Estimada debe ser un fecha válida." 
                    ForeColor="Red" Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator3" runat="server" 
                    ControlToCompare="txtFechaInicio" ControlToValidate="txtFechaFinEstimada" 
                    ErrorMessage="La Fecha de Fin Estimada debe ser Mayor a la Fecha de Inicio" 
                    ForeColor="Red" Operator="GreaterThan" Type="Date">*</asp:CompareValidator>
                </span></td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:TextBox ID="txtFechaInicio" runat="server" Width="50%"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFechaInicio_CalendarExtender" 
                    runat="server" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="text-align: center">
                <asp:TextBox ID="txtFechaFinEstimada" runat="server" Width="50%"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFechaFinEstimada_CalendarExtender" 
                    runat="server" TargetControlID="txtFechaFinEstimada" Format="dd/MM/yyyy">
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
                    Width="90%" MaxLength="1000"></asp:TextBox>
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
                <asp:DropDownList CssClass="ui-button" ID="ddlAreaDeInvestigacion" runat="server" 
                    DataSourceID="AreasDeInvestigación" DataTextField="nombre" 
                    DataValueField="idAreaDeInvestigacion" Width="80%">
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
            <td>
                <strong>Becarios del Proyecto:</strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:DropDownList CssClass="ui-button" ID="ddlBecarios" runat="server" Width="80%">
                </asp:DropDownList>
            </td>
            <td style="text-align: center">
                <asp:Button ID="btnAgregarBecario" runat="server" CssClass="ui-button" 
                    onclick="btnAgregarBecario_Click" Text="Agregar Becario" 
                    CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:GridView ID="grillaBecarios" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" 
                    onrowdeleting="grillaBecarios_RowDeleting" style="text-align: center" 
                    Width="90%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                        <asp:BoundField DataField="APELLIDO" HeaderText="Apellido" />
                        <asp:BoundField DataField="LEGAJO" HeaderText="Legajo" />
                        <asp:CommandField ButtonType="Image" 
                            DeleteImageUrl="~/Images/iconos/Deletered-256.png" ShowDeleteButton="True">
                        <ControlStyle Height="23px" Width="23px" />
                        </asp:CommandField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
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
                <asp:Button ID="btnDarDeAltaProyectoIncubado" runat="server" CssClass="ui-button" 
                    Text="Dar De Alta Proyecto Incubado" 
                    onclick="btnDarDeAltaProyectoIncubado_Click" />
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
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

