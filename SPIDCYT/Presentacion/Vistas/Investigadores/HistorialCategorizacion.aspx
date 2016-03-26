<%@ Page Title="Historial Debug Categorización" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="HistorialCategorizacion.aspx.cs" Inherits="Vistas_Investigadores_HistorialCategorizacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellpadding="2" class="TablaABM">
        <tr>
            <td colspan="2" class="TitulosTablaABM">
                Investigador
            </td>
        </tr>
        <tr>
            <td>
                Investigador:
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblInvestigador" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Categoria UTN Actual:
            </td>
            <td>
                Fecha Categorización UTN:
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCategoriaUTN" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFechaCategoriaUTN" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Categoria NACIONAL Actual:
            </td>
            <td>
                Fecha Categorización NACIONAL:
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCategoriaNACIONAL" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFechaCategoriaNACIONAL" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <p>
    </p>
    <table cellpadding="2" class="TablaABM">
        <tr>
            <td colspan="2" class="TitulosTablaABM">
                Seleccionar una Categoría pasada para agregar al historial.
            </td>
        </tr>
        <tr>
            <td>
                <strong>Categoría:</strong>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList CssClass="ui-button" ID="ddlCategorias" runat="server" Width="90%" DataSourceID="Categorias"
                    DataTextField="nombre" DataValueField="idCategoriaInvestigador">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>Fecha Desde:</b>
            </td>
            <td>
                <b>Fecha Hasta:</b>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtFechaDesde" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" TargetControlID="txtFechaDesde"
                    Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtFechaDesde"
                    ErrorMessage="&quot;Fecha Desde&quot; no es una fecha válida." ForeColor="Red"
                    Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaDesde"
                    ErrorMessage="&quot;Fecha Desde&quot; es un campo obligatorio." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtFechaHasta" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" TargetControlID="txtFechaHasta"
                    Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtFechaHasta"
                    ErrorMessage="&quot;Fecha Hasta&quot; no es una fecha válida." ForeColor="Red"
                    Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtFechaDesde"
                    ControlToValidate="txtFechaHasta" ErrorMessage="&quot;Fecha Hasta&quot; debe ser mayor a &quot;Fecha Desde&quot;."
                    ForeColor="Red" Operator="GreaterThan">*</asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaHasta"
                    ErrorMessage="&quot;Fecha Hasta&quot; es un campo obligatorio." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnAñadirCategoria" runat="server" Text="Añadir Categoría" OnClick="btnAñadirCategoria_Click"
                    CausesValidation="True" CssClass="ui-button" />
                <br />
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>                
            </td>            
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />            
            </td>            
        </tr>
    </table>
    <br />
    <br />
    <table class="TablaABM" cellpadding="2">
        <tr>
            <td class="TitulosTablaABM">
                Historial
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                    Style="text-align: center" Width="100%" AutoGenerateColumns="False" DataSourceID="HistorialCategorias"
                    OnRowCommand="GridView1_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                        <asp:BoundField DataField="fechaDesde" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Desde"
                            SortExpression="fechaDesde" />
                        <asp:BoundField DataField="fechaHasta" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Hasta"
                            SortExpression="fechaHasta" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/iconos/Deletered-256.png"
                            ShowDeleteButton="True">
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
    </table>
    <br />
    <asp:SqlDataSource ID="Categorias" runat="server" ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>"
        SelectCommand="SELECT [idCategoriaInvestigador], [nombre] FROM [CategoriaInvestigador]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="HistorialCategorias" runat="server" ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>"
        SelectCommand="SELECT CategoriaInvestigador.nombre, HistorialCategoria.fechaDesde, HistorialCategoria.fechaHasta FROM CategoriaInvestigador INNER JOIN HistorialCategoria ON CategoriaInvestigador.idCategoriaInvestigador = HistorialCategoria.categoriaInvestigador WHERE (HistorialCategoria.investigador = @idInvestigadorActual) ORDER BY CategoriaInvestigador.nombre, HistorialCategoria.fechaDesde">
        <SelectParameters>
            <asp:SessionParameter Name="idInvestigadorActual" DefaultValue="8" />
        </SelectParameters>
    </asp:SqlDataSource>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
</asp:Content>
