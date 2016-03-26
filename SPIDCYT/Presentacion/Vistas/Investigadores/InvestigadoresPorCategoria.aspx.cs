using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Investigadores_InvestigadoresPorCategoria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ListarInvestigadores")
        {
           Investigadores.SelectParameters[0].DefaultValue = grillaCategoriasNacional.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
           GridViewRow selectRow = grillaCategoriasNacional.Rows[Convert.ToInt32(e.CommandArgument)];           
           lblCategoria.Text = selectRow.Cells[1].Text;      
           grillaInvestigadores.DataBind();
        }
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ListarInvestigadores")
        {
            Investigadores.SelectParameters[0].DefaultValue = grillaCategoriasUTN.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            GridViewRow selectRow = grillaCategoriasUTN.Rows[Convert.ToInt32(e.CommandArgument)];
            lblCategoria.Text = selectRow.Cells[1].Text;
            grillaInvestigadores.DataBind();
        }
    }
}