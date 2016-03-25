<%@ page title="Página principal" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="_Default, App_Web_0uh1qx05" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="Styles/style_default.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/styleDefault2.0.css" rel="stylesheet" type="text/css" />
    <link href="Styles/ie7.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div id="background">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="body">
            <div class="featured">
                <ul>
                    <li>
                        <h2 style="background-color: transparent;">
                            <a href="Default.aspx">Secretaría de Promoción de Investigaciones en Ciencia y Tecnología</a></h2>
                        <p>
                            La Secretaría de Promoción de Investigaciones y Desarrollos en Ciencia y Tecnología,
                            tiene por objetivo prioritario, promover todo tipo de actividades de investigación,
                            desarrollo y transferencia en la comunidad académica del Departamento de Ingeniería
                            en Sistemas de Información.
                        </p>
                        <p>
                            ¿Querés conocer más sobre el área de investigación del Departamento de Sistemas
                            de nuestra facultad?
                            <asp:LinkButton ID="lblEstadisticas" runat="server" 
                                OnClick="lblEstadisticas_Click" ForeColor="#FF99FF">Haz click aquí</asp:LinkButton> para ver las estadísticas,
                            o <asp:LinkButton ID="lblTendencias" runat="server" ForeColor="#FF99FF" 
                                onclick="lblTendencias_Click"> aquí</asp:LinkButton> para ver las tendencias de investigación.
                            <br />
                        </p>
                    </li>
                </ul>
            </div>
            <div id="section">
                <div class="footer">
                    <div class="body">
                        <ul class="article">
                            <li class="first">
                                <img src="Images/Default/proyectos.jpg" width="256" height="166" alt="Proyectos"></a>
                                <h2 style="background-color: transparent;">
                                    <a href="TimelinePublicaProyecto.aspx">Proyectos</a></h2>
                                <p>
                                    <strong>
                                        <asp:Label ID="lblNumProyectos" runat="server" Text="0"></asp:Label>&nbsp;</strong>Proyectos vigentes
                                    en desarrollo en la actualidad.</p>
                                <a href="TimelinePublicaProyecto.aspx" class="readmore">Ver más</a> </li>
                            <li><a href="Default.aspx">
                                <img src="Images/Default/congresos.jpg" width="256" height="166" alt="Congresos"></a>
                                <h2 style="background-color: transparent;">
                                    <a href="Vistas/Congresos.aspx">Congresos</a></h2>
                                <p>
                                    <strong>
                                        <asp:Label ID="lblNumCongresos" runat="server" Text="0"></asp:Label>&nbsp;</strong>Congresos relacionados a nuestros proyectos durante el corriente año.<br />
                                </p>
                                <a href="Vistas/Congresos.aspx" class="readmore">Ver más</a> </li>
                            <li class="last"><a href="Default.aspx">
                                <img src="Images/Default/investigadores.jpg" width="256" height="166" alt="Investigadores"></a>
                                <h2 style="background-color: transparent;">
                                    <a href="TimelinePublicaInvestigador.aspx">Investigadores</a></h2>
                                <p>
                                    <strong>
                                        <asp:Label ID="lblNumInvestigadores" runat="server" Text="0"></asp:Label>&nbsp;</strong>Investigadores y <strong>
                                        <asp:Label ID="lblNumBecarios" runat="server" Text="0"></asp:Label>&nbsp;</strong>Becarios participando en los proyectos.
                                </p>
                                <a href="TimelinePublicaInvestigador.aspx" class="readmore">Ver más</a> </li>
                        </ul>
                    </div>
                </div>
                <!-- end of body-->
                <div id="footer">
                    <div>
                        <div class="header">
                            <a href="http://www.frc.utn.edu.ar/">
                                <img class="logo" src="Images/Logo_UTN.png" width="37" height="37" alt="UTN"></a>
                        </div>
                        <div class="body">
                            <ul class="navigation">
                            </ul>
                        </div>
                    </div>
                    <div id="footnote">
                        &copy; Copyright &copy; SPIDCYT
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divNoticias" align="center">
        <ajaxToolkit:SlideShowExtender ID="SlideShowExtender1" AutoPlay="true" ImageTitleLabelID="lblTitle"
            ImageDescriptionLabelID="lblImageDescription" Loop="true" NextButtonID="Btn_Next"
            PlayButtonID="Btn_Play" PlayButtonText="Play" PreviousButtonID="Btn_Previous"
            SlideShowServiceMethod="GetSlides" StopButtonText="Stop" TargetControlID="imgSlides"
            runat="server">
        </ajaxToolkit:SlideShowExtender>
        <ul>
            <li>
                <asp:Label ID="lblTitle" runat="server" Font-Bold="true" Font-Size="Small" /></li>
            <li>
                <asp:Label ID="lblImageDescription" runat="server" /></li>
        </ul>
    </div>
    <div id="divBotones">
        <asp:Button ID="Btn_Previous" runat="server" Text="<<" CssClass="ui-button" Width="30px" />
        <asp:Button ID="Btn_Play" runat="server" Text="Play" CssClass="ui-button" Width="60px" />
        <asp:Button ID="Btn_Next" runat="server" Text=">>" CssClass="ui-button" Width="30px" />
    </div>
    <asp:Image ID="imgSlides" runat="server" Height="0px" Width="0px" ImageUrl="Images/Logo_UTN.png"
        ToolTip="Últimas noticias" Visible="true" />
</asp:Content>
