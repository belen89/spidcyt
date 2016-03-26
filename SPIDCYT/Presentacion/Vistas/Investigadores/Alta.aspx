<%@ Page Title="Registrar Investigadores" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Alta.aspx.cs" Inherits="Vistas_Investigadores_AltaInvestigador" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style2
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="TablaABM" align="center" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="2" class="TitulosTablaABM">
                Datos Personales
            </td>
        </tr>
        <tr>
            <td>
                <strong>Nombre:</strong>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="El nombre es obligatorio." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <strong>Apellido: </strong>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El apellido es obligatorio."
                    ForeColor="Red" ControlToValidate="txtApellido">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="90%" MaxLength="100"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtApellido" runat="server" Width="90%" MaxLength="100"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Telefono:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtTelefono"
                    ErrorMessage="El Teléfono debe ser un número." ForeColor="Red" 
                    Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator>
            </td>
            <td>
                <strong>Dirección de Correo:</strong><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                    runat="server" ErrorMessage="Dirección de Correo no válida." 
                    ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtMail">*</asp:RegularExpressionValidator>
                <asp:Label ID="lblMail" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server" Width="90%" MaxLength="50"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtMail" runat="server" Width="90%" MaxLength="256"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Legajo:</strong>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El legajo es obligatorio."
                    ForeColor="Red" ControlToValidate="txtLegajo">*</asp:RequiredFieldValidator>
                <asp:Label ID="lblLegajo" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                <strong>Fecha de Alta:</strong>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="La fecha de alta es obligatoria"
                    ForeColor="Red" ControlToValidate="txtFechaAlta">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Fecha de Alta no válida."
                    ForeColor="Red" Type="Date" ControlToValidate="txtFechaAlta" 
                    Operator="DataTypeCheck">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtLegajo" runat="server" Width="90%" MaxLength="8"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtFechaAlta" runat="server" Width="90%"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaAlta_CalendarExtender" runat="server" TargetControlID="txtFechaAlta"
                    Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="TitulosTablaABM" colspan="2">
                Categoria Actual del Investigador
            </td>
        </tr>
        <tr>
            <td>
                Categoría UTN:
            </td>
            <td>
                Categoría NACIONAL:
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList CssClass="ui-button" ID="ddlCategoriaUTN" runat="server" Height="22px" Width="90%" DataSourceID="CategoriaUTN"
                    DataTextField="nombre" DataValueField="idCategoriaInvestigador" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlCategoriaUTN_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList CssClass="ui-button" ID="ddlCategoriaNacional" runat="server" Height="22px" Width="90%"
                    DataSourceID="CategoriasNACIONAL" DataTextField="nombre" DataValueField="idCategoriaInvestigador"
                    OnSelectedIndexChanged="ddlCategoriaNacional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Fecha Categorización UTN:<asp:CompareValidator ID="CompareValidator2" runat="server"
                    ErrorMessage="Fecha de Categorización UTN no válida." ForeColor="Red" 
                    Type="Date" ControlToValidate="txtFechaCategorizacionUTN"
                    Operator="DataTypeCheck">*</asp:CompareValidator>
                <asp:RequiredFieldValidator ID="rfvFechaCategorizacionUTN" runat="server" ControlToValidate="txtFechaCategorizacionUTN"
                    Display="Dynamic" Enabled="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                Fecha Categorización NACIONAL:<asp:CompareValidator ID="CompareValidator4" runat="server"
                    ErrorMessage="Fecha de Categorización Nacional no válida." ForeColor="Red" 
                    Type="Date" ControlToValidate="txtFechaCategorizacionNACIONAL"
                    Operator="DataTypeCheck">*</asp:CompareValidator>
                <asp:RequiredFieldValidator ID="rfvFechaCategorizacionNACIONAL" runat="server" ControlToValidate="txtFechaCategorizacionNACIONAL"
                    Enabled="False" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtFechaCategorizacionUTN" runat="server" Width="90%"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaCategorizacionUTN_CalendarExtender" runat="server"
                    TargetControlID="txtFechaCategorizacionUTN" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:TextBox ID="txtFechaCategorizacionNACIONAL" runat="server" Width="90%"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaCategorizacionNACIONAL_CalendarExtender" runat="server"
                    TargetControlID="txtFechaCategorizacionNACIONAL" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                &nbsp;
                &nbsp;<asp:Label ID="lblNotificaciones" runat="server"></asp:Label>
            &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
                    style="text-align: center" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Button ID="btnGuardarInvestigador" CssClass="ui-button" runat="server" OnClick="btnGuardarInvestigador_Click"
                    Style="text-align: center" Text="Guardar Investigador" Width="184px" Enabled="true" />
                <asp:SqlDataSource ID="CategoriaUTN" runat="server" ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>"
                    SelectCommand="SELECT  '-1' AS idCategoriaInvestigador, 'Sin Categoria' AS nombre UNION ALL SELECT CategoriaInvestigador.idCategoriaInvestigador, CategoriaInvestigador.nombre FROM CategoriaInvestigador INNER JOIN TipoCategoriaInvestigador ON CategoriaInvestigador.tipo = TipoCategoriaInvestigador.idTipoCategoriaInvestigador WHERE (TipoCategoriaInvestigador.nombre LIKE 'UTN') order by nombre">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="CategoriasNACIONAL" runat="server" ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>"
                    SelectCommand="SELECT  '-1' AS idCategoriaInvestigador, 'Sin Categoria' AS nombre UNION ALL SELECT CategoriaInvestigador.idCategoriaInvestigador, CategoriaInvestigador.nombre FROM CategoriaInvestigador INNER JOIN TipoCategoriaInvestigador ON CategoriaInvestigador.tipo = TipoCategoriaInvestigador.idTipoCategoriaInvestigador WHERE (TipoCategoriaInvestigador.nombre LIKE 'NACIONAL') order by nombre">
                </asp:SqlDataSource>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
            </td>
        </tr>
    </table>
</asp:Content>
