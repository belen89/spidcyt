using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Investigadores_ConsultaInvestigadores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void grillaListadoInvestigadores_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        switch (e.CommandName)
        {
            case "Editar":
                int idInvestigador = Convert.ToInt32(grillaListadoInvestigadores.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
                Session["idInvestigadorAModificar"] = idInvestigador;
                Response.Redirect("~/Vistas/Investigadores/Modificar.aspx");
                break;

            case "Dar de Baja":
                Session["idInvestigadorActual"] = Convert.ToInt32(grillaListadoInvestigadores.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
                Response.Redirect("~/Vistas/Investigadores/Baja.aspx");
                break;

            case "consultar":
                Session["idInvestigadorConsultado"] = Convert.ToInt32(grillaListadoInvestigadores.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
                Response.Redirect("~/Vistas/Investigadores/Consultar.aspx");
                break;

            case "ver timeline":
                Response.Redirect("Perfil/TimelineInvestigador.aspx?idInvestigadorActual=" + Convert.ToInt32(grillaListadoInvestigadores.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));
                break;

            case "Mail":
                
                break;
        }          

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ListadoBecarios.FilterParameters.Clear();
        ListaInvestigadores.FilterParameters.Clear();
   
        ListadoBecarios.FilterParameters.Add(new Parameter("nombre", TypeCode.String ,txtFiltro.Text) );
        ListadoBecarios.FilterParameters.Add(new Parameter("apellido", TypeCode.String, txtFiltro.Text));
        ListadoBecarios.FilterExpression = "nombre like '*{0}*' or apellido like '*{1}*'";
        
        ListaInvestigadores.FilterParameters.Add(new Parameter("nombre", TypeCode.String, txtFiltro.Text));
        ListaInvestigadores.FilterParameters.Add(new Parameter("apellido", TypeCode.String, txtFiltro.Text));
        ListaInvestigadores.FilterExpression = "nombre like '*{0}*' or apellido like '*{1}*'";
    }
    protected void btnVerTodos_Click(object sender, EventArgs e)
    {
        ListadoBecarios.FilterParameters.Clear();
        ListaInvestigadores.FilterParameters.Clear();
        ListadoBecarios.DataBind();
        ListaInvestigadores.DataBind();
    }

    protected void grillaListadoBecarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "editar")
        {
            int idBecario = Convert.ToInt32(grillaListadoBecarios.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            Session["becarioAModificar"] = DAOBecario.get(idBecario);
            Response.Redirect("~/Vistas/Becarios/Alta.aspx");
        }

        if (e.CommandName == "DarDeBaja")
        {

        }
        if (e.CommandName == "ver timeline")
            Response.Redirect("Perfil/TimelineInvestigador.aspx?idInvestigadorActual=" + Convert.ToInt32(grillaListadoBecarios.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));

        
    }

}