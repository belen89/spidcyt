<%@ Page Title="Investigadores por Categoría" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="InvestigadoresPorCategoria.aspx.cs" Inherits="Vistas_Investigadores_InvestigadoresPorCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style2
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellpadding="2" class="TablaABM">
        <tr class="TitulosTablaABM">
            <td colspan="2">
                Listado de Investigadores de la Secretaria
            </td>
        </tr>
        <tr>
            <td>
                <b>Total Investigadores Nacional</b>
            </td>
            <td>
                <b>Total Investigadores UTN</b>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:GridView ID="grillaCategoriasNacional" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" DataSourceID="CantidadInvestigadoresNacional" ForeColor="#333333"
                    GridLines="None" OnRowCommand="GridView2_RowCommand" DataKeyNames="idCategoriaInvestigador">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="idCategoriaInvestigador" HeaderText="idCategoriaInvestigador"
                            SortExpression="idCategoriaInvestigador" InsertVisible="False" ReadOnly="True"
                            Visible="False" />
                        <asp:BoundField DataField="Categoría" HeaderText="Categoría" SortExpression="Categoría" />
                        <asp:BoundField DataField="Investigadores" HeaderText="Investigadores" ReadOnly="True"
                            SortExpression="Investigadores" />
                        <asp:ButtonField ButtonType="Image" CommandName="ListarInvestigadores" ImageUrl="~/Images/iconos/icono_lupa.gif"
                            Text="Botón">
                            <ControlStyle Height="23px" Width="23px" />
                        </asp:ButtonField>
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
                    <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>
                    <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>
                    <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>
                    <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </td>
            <td class="style2">
                <asp:GridView ID="grillaCategoriasUTN" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" DataSourceID="CantidadInvestigadoresUTN" ForeColor="#333333"
                    GridLines="None" DataKeyNames="idCategoriaInvestigador" OnRowCommand="GridView3_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="idCategoriaInvestigador" HeaderText="idCategoriaInvestigador"
                            SortExpression="idCategoriaInvestigador" InsertVisible="False" ReadOnly="True"
                            Visible="False" />
                        <asp:BoundField DataField="Categoría" HeaderText="Categoría" SortExpression="Categoría" />
                        <asp:BoundField DataField="Investigadores" HeaderText="Investigadores" ReadOnly="True"
                            SortExpression="Investigadores" />
                        <asp:ButtonField ButtonType="Image" CommandName="ListarInvestigadores" ImageUrl="~/Images/iconos/icono_lupa.gif"
                            Text="Botón">
                            <ControlStyle Height="23px" Width="23px" />
                        </asp:ButtonField>
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
    </table>
    <p>
    </p>
    <table cellpadding="2" class="TablaABM">
        <tr>
            <td class="TitulosTablaABM">
                &nbsp;Investigadores CATEGORIA:
                <asp:Label ID="lblCategoria" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grillaInvestigadores" runat="server" AutoGenerateColumns="False"
                    DataSourceID="Investigadores" Width="100%" CellPadding="4" ForeColor="#333333"
                    GridLines="None" AllowPaging="True" AllowSorting="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="apellido" HeaderText="Apellido" 
                            SortExpression="apellido" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" 
                            SortExpression="nombre" />
                        <asp:BoundField DataField="mail" DataFormatString="<a href=mailto:{0}>{0}</a>" 
                            HtmlEncodeFormatString="False" HeaderText="Mail" SortExpression="mail" />
                        <asp:BoundField DataField="legajo" HeaderText="Legajo" 
                            SortExpression="legajo" />
                        <asp:BoundField DataField="telefono" HeaderText="Telefono" 
                            SortExpression="telefono" />
                        <asp:BoundField DataField="fechaAlta" HeaderText="Fecha de Alta" 
                            SortExpression="fechaAlta" DataFormatString="{0:dd/MM/yyyy}" />
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
            <td>
                <asp:SqlDataSource ID="Categorias" runat="server" ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>"
                    SelectCommand="SELECT [idCategoriaInvestigador], [nombre] FROM [CategoriaInvestigador]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="Investigadores" runat="server" ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>"
                    SelectCommand="SELECT Persona.apellido, Persona.nombre, Persona.mail, Persona.legajo, Persona.telefono, Persona.fechaAlta FROM Persona INNER JOIN Investigador ON Persona.idPersona = Investigador.idInvestigador WHERE (Investigador.categoriaNacional = @categoria) OR (Investigador.categoriaUTN = @categoria)
ORDER BY Persona.apellido">
                    <SelectParameters>
                        <asp:Parameter Name="categoria" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="CantidadInvestigadoresNacional" runat="server" ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>"
                    SelectCommand="SELECT ci.idCategoriaInvestigador, ci.nombre AS Categoría, COUNT(ci.nombre) AS Investigadores FROM Investigador AS inv INNER JOIN CategoriaInvestigador AS ci ON inv.categoriaNacional = ci.idCategoriaInvestigador GROUP BY ci.nombre, ci.idCategoriaInvestigador">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="CantidadInvestigadoresUTN" runat="server" ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>"
                    SelectCommand="SELECT ci.idCategoriaInvestigador, ci.nombre AS Categoría, COUNT(ci.nombre) AS Investigadores FROM Investigador AS inv INNER JOIN CategoriaInvestigador AS ci ON inv.categoriaUTN = ci.idCategoriaInvestigador GROUP BY ci.nombre, ci.idCategoriaInvestigador">
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
