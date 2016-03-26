<%@ Page Title="Consulta de Investigadores" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ConsultaInvestigadores.aspx.cs" Inherits="Vistas_Investigadores_ConsultaInvestigadores" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table align="center" cellpadding="2" class="style2">
        <tr>
            <td align="center" class="TitulosTablaABM">
                Administrar Investigadores</td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                Buscar:
            </td>
            <td>
                <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" 
                    Text="Buscar" CssClass="ui-button" />
                &nbsp;<asp:Button ID="btnVerTodos" runat="server" OnClick="btnVerTodos_Click" 
                    Text="Ver Todos" CssClass="ui-button" />
            </td>
        </tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:TabContainer runat="server" ActiveTabIndex="0" Width="100%" 
        Style="text-align: left">
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                <span>Investigadores</span>
            
</HeaderTemplate>
            
            
<ContentTemplate>
                <asp:GridView ID="grillaListadoInvestigadores" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="idInvestigador" DataSourceID="ListaInvestigadores" AllowPaging="True"
                    AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="905px"
                    OnRowCommand="grillaListadoInvestigadores_RowCommand">
<AlternatingRowStyle BackColor="White" />
<Columns>
<asp:BoundField DataField="idInvestigador" HeaderText="idInvestigador" ReadOnly="True"
                            SortExpression="idInvestigador" Visible="False" />
<asp:BoundField DataField="apellido" HeaderText="Apellido" SortExpression="apellido" />
<asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
<asp:BoundField DataField="legajo" HeaderText="Legajo" SortExpression="legajo" />
<asp:BoundField DataField="telefono" HeaderText="Telefono" SortExpression="telefono" />
<asp:BoundField DataField="mail" DataFormatString="<a href=mailto:{0}>{0}</a>" 
                            HtmlEncodeFormatString="False" HeaderText="Mail" SortExpression="Email" />
<asp:BoundField DataField="fechaAlta" HeaderText="Fecha de Alta" SortExpression="fechaAlta"
                            DataFormatString="{0:dd/MM/yyyy}" />
<asp:BoundField DataField="fechaBaja" HeaderText="Fecha de Baja" SortExpression="fechaBaja"
                            DataFormatString="{0:dd/MM/yyyy}" />
<asp:TemplateField ShowHeader="False">
    <ItemTemplate>
                                <asp:ImageButton ID="Button1" runat="server" CausesValidation="false" CommandName="Editar"
                                    Text="Editar" ImageUrl="~/Images/iconos/Blue-Pencil-48.png" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                
                            
</ItemTemplate>

<ControlStyle Height="23px" Width="23px" />
</asp:TemplateField>
<asp:TemplateField ShowHeader="False">
    <ItemTemplate>
                                

                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" 
                                    CommandName="consultar" ImageUrl="~/Images/iconos/icono_lupa.gif" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                
                            
</ItemTemplate>

<ControlStyle Height="23px" Width="23px" />
</asp:TemplateField>
<asp:TemplateField ShowHeader="False">
    <ItemTemplate>
                                

                                <asp:ImageButton ID="Button2" ImageUrl="~/Images/iconos/Deletered-256.png" runat="server"
                                    CausesValidation="false" Visible="true" CommandName="Dar de Baja" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    Text="Dar de Baja" />
                            
</ItemTemplate>

<ControlStyle Height="23px" Width="23px" />
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                                

                                <asp:LinkButton ID="btnVerTimelineInvestigador" runat="server" CausesValidation="false"
                                    CommandName="ver timeline" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    Text="Timeline" />
                            
</ItemTemplate>
</asp:TemplateField>
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

                


                <asp:SqlDataSource ID="ListaInvestigadores" runat="server" ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>"
                    SelectCommand="SELECT Investigador.idInvestigador, Persona.apellido , Persona.nombre , Persona.legajo, Persona.telefono, Persona.mail, Persona.fechaAlta, Persona.fechaBaja FROM Investigador INNER JOIN Persona ON Investigador.idInvestigador = Persona.idPersona ORDER BY Persona.apellido, Persona.nombre"></asp:SqlDataSource>

                

 
            
</ContentTemplate>
            
        
</asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                

                <span>Becarios </span>
                

            
</HeaderTemplate>
            
            
<ContentTemplate>
                

                <asp:GridView ID="grillaListadoBecarios" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="idBecario" DataSourceID="ListadoBecarios" OnRowCommand="grillaListadoBecarios_RowCommand"
                    ForeColor="#333333" GridLines="None" Width="883px" EnableSortingAndPagingCallbacks="True">
                    

                    <AlternatingRowStyle BackColor="White" />
                    

                    <Columns>
                        

                        <asp:BoundField DataField="idBecario" HeaderText="idBecario" ReadOnly="True" SortExpression="idBecario"
                            Visible="False" />
                        

                        <asp:BoundField DataField="apellido" HeaderText="Apellido" SortExpression="apellido" />
                        

                        <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                        

                        <asp:BoundField DataField="legajo" HeaderText="Legajo" SortExpression="legajo" />
                        

                        <asp:BoundField DataField="nombreTipoBecario" HeaderText="Tipo de Becario" SortExpression="nombreTipoBecario" />
                        

                        <asp:BoundField DataField="telefono" HeaderText="Telefono" SortExpression="telefono" />
                        

                        <asp:BoundField DataField="mail" DataFormatString="<a href=mailto:{0}>{0}</a>" 
                            HtmlEncodeFormatString="False" HeaderText="Mail" SortExpression="mail" />
                        

                        <asp:BoundField DataField="fechaAlta" HeaderText="Fecha de Alta" SortExpression="fechaAlta"
                            DataFormatString="{0:d}" />
                        

                        <asp:BoundField DataField="fechaBaja" HeaderText="Fecha de Baja" SortExpression="fechaBaja"
                            DataFormatString="{0:d}" />
                        

                        <asp:ButtonField ButtonType="Image" CommandName="editar" Text="Editar" ImageUrl="~/Images/iconos/Blue-Pencil-48.png">
                            

                            <ControlStyle Height="23px" Width="23px" />
                            

                            <ItemStyle Height="12px" Width="12px" />
                        

                        </asp:ButtonField>
                        

                        <asp:ButtonField ButtonType="Image" Visible="False" CommandName="darDeBaja" 
                            Text="Dar de Baja" ImageUrl="~/Images/iconos/Deletered-256.png">
                            

                            <ControlStyle Height="23px" Width="23px" />
                        

                        </asp:ButtonField>
                        

                        <asp:ButtonField ButtonType="Image" CommandName="consultar" 
                            ImageUrl="~/Images/iconos/icono_lupa.gif">
                        

                        <ControlStyle Height="23px" Width="23px" />
                        

                        </asp:ButtonField>
                        

                        <asp:ButtonField CommandName="ver timeline"
                            Text="Timeline" />
                        

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
                

                <asp:SqlDataSource ID="ListadoBecarios" runat="server" ConnectionString="<%$ ConnectionStrings:SPIDCYTConnectionString %>"
                    SelectCommand="SELECT Becario.idBecario, Persona.apellido, Persona.nombre, Persona.legajo, TipoBecario.nombre AS nombreTipoBecario, Persona.telefono, Persona.mail, Persona.fechaAlta, Persona.fechaBaja FROM Becario INNER JOIN Persona ON Becario.idBecario = Persona.idPersona INNER JOIN TipoBecario ON Becario.tipoBecario = TipoBecario.idTipoBecario">
                    

                </asp:SqlDataSource>
                

            
</ContentTemplate>
            
        
</asp:TabPanel>
    </asp:TabContainer>
</asp:Content>
