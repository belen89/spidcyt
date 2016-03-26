using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Investigadores_Baja : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtFechaDeBaja.Text = DateTime.Today.ToString("dd/MM/yyyy");
            if (Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath == "/Vistas/Investigadores/ConsultaInvestigadores.aspx")
            {
                Investigador investigadorConsultado = DAOInvestigador.get((int)Session["idInvestigadorActual"]);
                lblApellido.Text = investigadorConsultado.APELLIDO;
                lblNombre.Text = investigadorConsultado.NOMBRE;
                lblLegajo.Text = investigadorConsultado.LEGAJO.ToString();
                lblTelefono.Text = investigadorConsultado.TELEFONO;
                lblDireccionDeCorreo.Text = investigadorConsultado.MAIL;
                lblFechaDeAlta.Text = investigadorConsultado.FECHAALTA.ToString("dd/MM/yyyy");

                if (investigadorConsultado.CATEGORIAUTN != null)
                {
                    lblCategoriaUTN.Text = investigadorConsultado.CATEGORIAUTN.NOMBRE;
                    lblFechaCategoriaUTN.Text = investigadorConsultado.FECHACATEGORIZACIONUTN.ToString("dd/MM/yyyy");
                }

                if (investigadorConsultado.CATEGORIANACIONAL != null)
                {
                    lblCategoriaNacional.Text = investigadorConsultado.CATEGORIANACIONAL.NOMBRE;
                    lblFechaCategoriaNacional.Text = investigadorConsultado.FECHACATEGORIZACIONNACIONAL.ToString("dd/MM/yyyy");
                }
            }

        }
    }
    protected void btnDarDeBaja_Click(object sender, EventArgs e)    
    {
        Investigador investigadorConsultado = DAOInvestigador.get((int)Session["idInvestigadorActual"]);

        try
        {
            investigadorConsultado.darDeBaja(Convert.ToDateTime(txtFechaDeBaja.Text, new CultureInfo("es-ES")));
            Response.Redirect("ConsultaInvestigadores.aspx");
        }
        catch (Exception)
        {
            lblNotificaciones.CssClass = "error";
            lblNotificaciones.Text = "Error al Ingresar el Investigador. Por favor vuelva a intentar más tarde.";
        }
        
    }
}