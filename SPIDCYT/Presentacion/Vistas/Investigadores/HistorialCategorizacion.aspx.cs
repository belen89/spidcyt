using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Investigadores_HistorialCategorizacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Session["investigadorActual"] = DAOInvestigador.get(Convert.ToInt32(Session["idInvestigadorActual"]));
            Session["investigadorActual"] = DAOInvestigador.get(8);

            lblInvestigador.Text = ((Investigador)Session["investigadorActual"]).datosParaDll();
            if (((Investigador)Session["investigadorActual"]).CATEGORIANACIONAL != null)
            {
                lblCategoriaNACIONAL.Text = ((Investigador)Session["investigadorActual"]).CATEGORIANACIONAL.NOMBRE;

                lblFechaCategoriaNACIONAL.Text = ((Investigador)Session["investigadorActual"]).FECHACATEGORIZACIONNACIONAL.ToString("dd/MM/yyyy");
            }
            if (((Investigador)Session["investigadorActual"]).CATEGORIAUTN != null)
            {
                lblCategoriaUTN.Text = ((Investigador)Session["investigadorActual"]).CATEGORIAUTN.NOMBRE;
                lblFechaCategoriaUTN.Text = ((Investigador)Session["investigadorActual"]).FECHACATEGORIZACIONUTN.ToString("dd/MM/yyyy");
            }
        }
    }

    protected void btnAñadirCategoria_Click(object sender, EventArgs e)
    {
            CategoriaInvestigador viejaCategoria = DAOCategoriaInvestigador.get(Convert.ToInt32(ddlCategorias.SelectedValue));
            DateTime fechaCategorizacion = Convert.ToDateTime(txtFechaDesde.Text, new CultureInfo("es-ES"));
            DateTime fechaFinCategoría = Convert.ToDateTime(txtFechaHasta.Text, new CultureInfo("es-ES"));
            
            Investigador investigador = (Investigador)Session["investigadorActual"];

            /*
             * Si alguna de las fechas está incluida dentro de algún historial, es una fecha NO válida.
             * Es para validar el ingreso de datos
             * Ejemplo: Categorice D mientras estaba como categoría C.
             */

            //Fecha de Categorización no puede estar dentro de un rango
            if (investigador.fechaContenidaDentroDeUnaCategorizacion(fechaCategorizacion, viejaCategoria.TIPO))
            {
                lblError.Text = "Fecha de Inicio no Válida. El investigador pertenecía a otra categoría en ese momento.";
                return;
            }

            //Fecha de Categorización no puede estar dentro de un rango
            if (investigador.fechaContenidaDentroDeUnaCategorizacion(fechaFinCategoría, viejaCategoria.TIPO))
            {
                lblError.Text = "Fecha de Fin no Válida. El investigador pertenecía a otra Categoría (Para ese Tipo de Categoría) en ese momento.";
                return;
            }
        
            HistorialCategoria historialCategoria = new HistorialCategoria();
            historialCategoria.CATEGORIAINVESTIGADOR = viejaCategoria;
            historialCategoria.FECHADESDE = fechaCategorizacion;
            historialCategoria.FECHAHASTA = fechaFinCategoría;

            try
            {
                investigador.agregarCategoriaAlHistorialDeCategorizacion(historialCategoria);
            }
            catch (Exception ex)
            {
                Session["mensajeError"] = ex.Message;
                Response.Redirect("~/Vistas/Error.aspx");
                throw;
            }
            

            lblError.Text = "";
            GridView1.DataBind();       
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}