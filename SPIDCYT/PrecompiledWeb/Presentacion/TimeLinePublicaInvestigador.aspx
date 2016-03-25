<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="TimeLinePublicaInvestigador, App_Web_0uh1qx05" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/style_default.css" rel="stylesheet" type="text/css" />
    <link href="Styles/cssTimeLine/aristo/jquery-ui-1.8.5.custom.css" rel="stylesheet"
        type="text/css" />
    <link href="Styles/cssTimeLine/Timeglider.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/jquery-ui.js" type="text/javascript" charset="utf-8"></script>
    <!-- FRIEND LIBS -->
    <script src="js/underscore-min.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/backbone-min.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/jquery.global.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/jquery.tmpl.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/ba-debug.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/ba-tinyPubSub.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/jquery.mousewheel.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/jquery.ui.ipad.js" type="text/javascript" charset="utf-8"></script>
    <!-- TIMEGLIDER -->
    <script src="js/timeglider/TG_Date.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/timeglider/TG_Org.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/timeglider/TG_Timeline.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/timeglider/TG_TimelineView.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/timeglider/TG_Mediator.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/timeglider/timeglider.timeline.widget.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            var tld = "timeline";

            var tg1 = $("#placement").timeline({
                "min_zoom": 10,
                "max_zoom": 50,
       
                "data_source": "/Presentacion/timelinePublicaInvestigador.json"
            });


            $("#toggle").click(function () {
                if (tld == "timeline") {
                    $("#placement").css({ "display": "none" });
                    $(".timeline-table").css({ "display": "block" });
                    tld = "table";
                } else {
                    $("#placement").css({ "display": "block" });
                    $(".timeline-table").css({ "display": "none" });

                    tld = "timeline";
                }

            });


        }); // end document-ready
	
    </script>
    <style>
        #placement
        {
            width: 900px;
            margin: auto 10px auto auto;
            height: 600px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <table align="center">
        <tr>
            <td class="TituloNoticia" align="center" style="width: 900px;">
                <asp:Label ID="lblProyecto"  runat="server" Font-Size="Large" 
                    Text="Secretaría de Promoción de Investigaciones en Ciencia y Tecnología - Investigadores" 
                    style="color: #FFFFFF; font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
        </tr>
    </table>
    <div id='placement' align="left">
    </div>
    <div >
    <br />
        <table style="border: thin solid #C0C0C0; width: 900px;" align="center">
        <thead><tr><th colspan="8" align="left">Referencias:</th></tr></thead>
            <tr>
                <td style="border: thin solid #C0C0C0">
                    <asp:Image ID="imgProyecto" runat="server" ImageUrl="~/js/timeglider/icons/research.png" Width="40" Height="40"></asp:Image>
                </td>
                <td style="border: thin solid #C0C0C0">
                Nuevo Proyecto 
                </td>
                <td style="border: thin solid #C0C0C0">
                    <asp:Image ID="imgProducto" runat="server" ImageUrl="~/js/timeglider/icons/Product-documentation.png" Width="40" Height="40"></asp:Image>
                </td>
                <td style="border: thin solid #C0C0C0">
                Nuevo Producto
                </td>
                <td style="border: thin solid #C0C0C0">
                    <asp:Image ID="imgInvestigador" runat="server" ImageUrl="~/js/timeglider/icons/Client-Female.png" Width="40" Height="40"></asp:Image>
                </td>
                <td style="border: thin solid #C0C0C0">
                Nuevo Investigador 
                </td>
                <td style="border: thin solid #C0C0C0">
                    <asp:Image ID="imgBecario" runat="server" ImageUrl="~/js/timeglider/icons/Child-Female.png" Width="40" Height="40"></asp:Image>
                </td>
                <td style="border: thin solid #C0C0C0">
                Nuevo Becario
                </td>

            </tr>
        </table>
    </div>
</asp:Content>

