using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Investigadores_Consultar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath == "/Presentacion/Vistas/Investigadores/ConsultaInvestigadores.aspx")
            {
                Investigador investigadorConsultado = DAOInvestigador.get((int)Session["idInvestigadorConsultado"]);
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
}