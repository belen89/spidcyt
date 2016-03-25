<%@ page title="Acerca de nosotros" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="About, App_Web_0uh1qx05" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="Styles/styleDefault2.0.css" rel="stylesheet" type="text/css" />
    <link href="Styles/ie7.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="background" runat="server" ContentPlaceHolderID="MainContent">
    <div id="background">
        <div id="body">
            <div class="featured">
                <ul>
                    <li>
                        <h2>
                            <a href="About.aspx">Secretaría de Promoción de Investigaciones en Ciencia y Tecnología</a></h2>
                        <p>
                            La Secretaría de Promoción de Investigaciones y Desarrollos en Ciencia y Tecnología,
                            tiene por objetivo prioritario, promover todo tipo de actividades de investigación,
                            desarrollo y transferencia en la comunidad académica del Departamento de Ingeniería
                            en Sistemas de Información.
                        </p>
                        ¿Querés conocer más sobre el área de investigación del Departamento de Sistemas
                        de nuestra facultad?
                        <%-- <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Haz click aquí</asp:LinkButton>--%>
                        <br />
                    </li>
                </ul>
            </div>
            <div id="section">
                <div class="footer">
                    <div class="body">
                        <ul class="article">
                            <li class="first">
                                <img src="Images/Default/proyectos.jpg" width="256" height="166" alt="Proyectos"></a>
                                <h2>
                                    <a href="TimelinePublicaProyecto.aspx">Proyectos</a></h2>
                                <p>
                                    <strong><asp:Label ID="lblNumProyectos" runat="server" Text="0"></asp:Label></strong> - Proyectos vigentes en la actualidad.
                                </p>
                                <a href="TimelinePublicaProyecto.aspx" class="readmore">Ver más</a> </li>
                            <li><a href="index.html">
                                <img src="Images/Default/congresos.jpg" width="256" height="166" alt="Congresos"></a>
                                <h2>
                                    <a href="Vistas/MapaParaUsuarios.aspx">Congresos</a></h2>
                                <p>
                                    <strong><asp:Label ID="lblNumCongresos" runat="server" Text="0"></asp:Label></strong> - Congresos durante el corriente año
                                </p>
                                <a href="Vistas/MapaParaUsuarios.aspx" class="readmore">Ver más</a> </li>
                            <li class="last"><a href="index.html">
                                <img src="Images/Default/investigadores.jpg" width="256" height="166" alt="Investigadores"></a>
                                <h2>
                                    <a href="TimelinePublicaInvestigador.aspx">Investigadores</a></h2>
                                <p>
                                   <strong><asp:Label ID="lblNumBecariosInvestigadores" runat="server" Text="0"></asp:Label></strong> - Investigadores y Becarios participando activamente en los proyectos.
                                </p>
                                <a href="TimelinePublicaInvestigador.aspx" class="readmore">Ver más</a> </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- end of body-->
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <div id="footer">
            <div>
                <div class="header">
                    <div style="width: 915px; padding: 1px;" align="center">
                        <table cellpadding="2" cellspacing="0" style="height: 40px; width: 100%; border: solid 2px #000000">
                            <tr>
                                <td valign="middle" class="style4">
                                    <asp:Image ID="imgSlides" runat="server" Height="30px" Width="30px" ImageUrl="Images/News-256.png"
                                        ToolTip="Últimas noticias" />
                                    <ajaxToolkit:SlideShowExtender ID="SlideShowExtender1" AutoPlay="true" ImageTitleLabelID="lblTitle"
                                        ImageDescriptionLabelID="lblImageDescription" Loop="true" NextButtonID="Btn_Next"
                                        PlayButtonID="Btn_Play" PlayButtonText="Play" PreviousButtonID="Btn_Previous"
                                        SlideShowServiceMethod="GetSlides" StopButtonText="Stop" TargetControlID="imgSlides"
                                        runat="server">
                                    </ajaxToolkit:SlideShowExtender>
                                </td>
                                <td class="style5">
                                    <asp:Label ID="lblTitle" runat="server" Font-Bold="true" Font-Size="Medium" />
                                </td>
                                <td class="style4">
                                    <asp:Label ID="lblImageDescription" runat="server" />
                                </td>
                                <td class="style4">
                                    <asp:Button ID="Btn_Previous" runat="server" Text="<<" CssClass="ui-button-slider"
                                        Width="10px" />
                                    <asp:Button ID="Btn_Play" runat="server" Text="Play" CssClass="ui-button-slider"
                                        Width="60px" />
                                    <asp:Button ID="Btn_Next" runat="server" Text=">>" CssClass="ui-button-slider" Width="10px" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
