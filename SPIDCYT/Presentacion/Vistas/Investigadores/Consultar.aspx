<%@ Page Title="Consulta de Investigadores" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Consultar.aspx.cs" Inherits="Vistas_Investigadores_Consultar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 23px;
        }
        .style3
        {
        }
        .style4
        {
            height: 23px;
            width: 159px;
            text-align: right;
            font-weight: bold;
        }
        .style6
        {
            width: 159px;
            text-align: right;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellpadding="2" class="TablaABM">
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
            <td class="style4">
                Fecha Categoría Nacional:</td>
            <td class="style2">
                <asp:Label ID="lblFechaCategoriaNacional" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TitulosTablaABM" colspan="2">
                Proyectos en los que participo</td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                <asp:GridView ID="grillaProyectos" runat="server" Width="100%" 
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="Proyectos" 
                    ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="idProyecto" HeaderText="idProyecto" ReadOnly="True" 
                            SortExpression="idProyecto" Visible="False" />
                        <asp:BoundField DataField="Rol" HeaderText="Rol" ReadOnly="True" 
                            SortExpression="Rol" />
                        <asp:BoundField DataField="nombreCorto" HeaderText="Nombre Corto" 
                            ReadOnly="True" SortExpression="nombreCorto" />
                        <asp:BoundField DataField="fechaInicio" HeaderText="Fecha Inicio" 
                            ReadOnly="True" SortExpression="fechaInicio" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="fechaFin" HeaderText="Fecha Fin" ReadOnly="True" 
                            SortExpression="fechaFin" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="nombre" HeaderText="Estado" ReadOnly="True" 
                            SortExpression="nombre" />
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
                <asp:SqlDataSource ID="Proyectos" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>" 
                    SelectCommand="mostrarProyectosPorInvestigador" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="idPersona" SessionField="idInvestigadorConsultado" 
                            Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

