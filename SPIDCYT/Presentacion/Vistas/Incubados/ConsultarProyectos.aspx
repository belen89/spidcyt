<%@ Page Title="Consultar Proyectos Incubados" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ConsultarProyectos.aspx.cs" Inherits="Vistas_Consultar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<br />
    <table class="TablaABM" align="center" cellpadding="2" cellspacing="2" style="table-layout: fixed;
        width: 70%;">
        <tr>
            <td class="TitulosTablaABM">
                Consulta de Proyectos Vigentes
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Buscar:
                <asp:TextBox ID="txtFiltro" runat="server" Height="22px" Width="301px"></asp:TextBox>
                &nbsp;<asp:Button ID="btnBuscarProyecto" runat="server" Text="Buscar" OnClick="btnBuscarProyecto_Click"
                    Width="70px" CssClass="ui-button" />
                &nbsp;<asp:Button ID="btnVerTodosProyecto" runat="server" Text="Ver Todos" OnClick="btnVerTodosProyecto_Click"
                    Width="70px" CssClass="ui-button" />
            </td>
        </tr>
        <tr>
            <td>
                <ajaxToolkit:Accordion ID="Accordion1" runat="server" DataSourceID="ListadoProyectos"
                    Width="100%" HeaderCssClass="accordionHeader" ContentCssClass="accordionContent"
                    HeaderSelectedCssClass="accordionHeaderSelected" Style="text-align: justify">
                    <HeaderTemplate>                    
                    <asp:Label ID="Label1" runat="server" Visible="False" Text="Label1"></asp:Label>
                        <%#DataBinder.Eval(Container.DataItem, "nombreCorto")%>                        
                    </HeaderTemplate>
                    <ContentTemplate>
                        <b>Nombre Largo:</b>
                        <br />
                        <%#DataBinder.Eval(Container.DataItem, "nombreLargo")%>
                        <br />
                        <b>Resumen:</b>
                        <br />
                        <%#DataBinder.Eval(Container.DataItem, "resumen")%>
                        <br />
                        <br />
                        <b>Fecha de Inicio:</b>
                        <%#DataBinder.Eval(Container.DataItem, "fechaInicio")%>
                        <br />
                        <b>Fecha de Fin:</b>
                        <%#DataBinder.Eval(Container.DataItem, "fechaFin")%>
                        <br />
                        <b>Fecha de fin Estimada:</b>
                        <%#DataBinder.Eval(Container.DataItem, "fechaFinEstimada")%>
                        <br />
                        <b>Estado del Proyecto:</b>
                        <%#DataBinder.Eval(Container.DataItem, "nombreEstadoProyecto")%>
                        <br />
                        <b>Área de Investigación:</b>
                        <%#DataBinder.Eval(Container.DataItem, "nombreAreaDeInvestigacion")%>
                        <br />
                        <%--<asp:Button ID="btnVerMas" OnClick="btnVerMas_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "idProyecto")%>'
                            runat="server" Text="Ver Mas..." />--%>
                        <asp:Button ID="btnModificar" CssClass="ui-button" OnClick="btnModificar_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "idProyecto")%>'
                            runat="server" Text="Modificar..." />
                        <asp:Button ID="btnFinalizar" OnClick="btnFinalizar_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "idProyecto")%>'
                            runat="server" CssClass="ui-button" Enabled='<%# HttpContext.Current.User.IsInRole("ADMINISTRADOR") %>' Visible='<%# HttpContext.Current.User.IsInRole("ADMINISTRADOR") %>'  Text="Finalizar..." />
                    </ContentTemplate>
                </ajaxToolkit:Accordion>
            </td>
        </tr>
    </table>
    <br />
    <asp:SqlDataSource ID="ListadoProyectos" runat="server" ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>"
        SelectCommand="SELECT Proyecto.idProyecto, Proyecto.nombreLargo, Proyecto.nombreCorto, CONVERT(VARCHAR(10), Proyecto.fechaInicio, 103) as fechaInicio, CONVERT(VARCHAR(10), Proyecto.fechaFin, 103) as fechaFin, Proyecto.resumen, CONVERT(VARCHAR(10), Proyecto.fechaFinEstimada, 103) as fechaFinEstimada, AreaDeInvestigacion.nombre AS nombreAreaDeInvestigacion, EstadoProyecto.nombre AS nombreEstadoProyecto FROM Proyecto INNER JOIN TipoProyectoPorProyecto ON Proyecto.idProyecto = TipoProyectoPorProyecto.idProyecto INNER JOIN TipoProyecto ON TipoProyectoPorProyecto.idTipoProyecto = TipoProyecto.idTipoProyecto INNER JOIN AreaDeInvestigacion ON Proyecto.areaDeInvestigacion = AreaDeInvestigacion.idAreaDeInvestigacion INNER JOIN EstadoProyecto ON Proyecto.estado = EstadoProyecto.idEstadoProyecto WHERE (TipoProyecto.nombre LIKE 'incubado')"
        FilterExpression="nombreCorto like '*{0}*'">
        <FilterParameters>
            <asp:ControlParameter Name="nombreCorto" ControlID="txtFiltro" PropertyName="Text" />
        </FilterParameters>
    </asp:SqlDataSource>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>

