using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Consultar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnVerMas_Click(object sender, EventArgs e)
    {
        //Guardo el ID del Proyecto Incubado en la Session.
        Session["idProyectoConsultado"] = ((Button)sender).CommandArgument.ToString();
        Response.Redirect("~/Vistas/Proyectos/VerDatosProyecto.aspx");
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        //Guardo el ID del Proyecto Incubado en la Session.
        Session["idProyectoIncubadoAModificar"] = Convert.ToInt32(((Button)sender).CommandArgument.ToString());
        Response.Redirect("~/Vistas/Incubados/Modificar.aspx");
    }
    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        //Guardo el ID del Proyecto Incubado en la Session.
        Session["idProyectoIncubadoAFinalizar"] = Convert.ToInt32(((Button)sender).CommandArgument.ToString());
        Response.Redirect("~/Vistas/Incubados/Finalizar.aspx");
    }

    protected void btnBuscarProyecto_Click(object sender, EventArgs e)
    {
        ListadoProyectos.FilterParameters.Add(new Parameter("nombreCorto", TypeCode.String, txtFiltro.Text));
        ListadoProyectos.FilterExpression = "nombreCorto like '*{0}*'";

    }
    protected void btnVerTodosProyecto_Click(object sender, EventArgs e)
    {
        ListadoProyectos.FilterParameters.Clear();
        ListadoProyectos.FilterExpression = "";
        ListadoProyectos.DataBind();
    }
}