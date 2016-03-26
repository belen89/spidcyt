using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Incubados_Baja : System.Web.UI.Page
{
    Proyecto proyectoIncubadoAFinalizar;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Si no es SECRETARIO o ADMINISTRADOR que solo pueda Finalizar su Proyecto
        if (!Page.User.IsInRole("SECREATRIO") && !Page.User.IsInRole("ADMINISTRADOR"))
        {
            ddlProyectosIncubados.Enabled = false;
        }

        if (!Page.IsPostBack)
        {
            //Si vengo de Consultar
            if (Request.UrlReferrer != null && (Request.UrlReferrer.AbsolutePath == "/Vistas/Incubados/Consultar.aspx"))
            {
                //Ejecuto DataBind() para poder setearle el SelectedValue
                ddlProyectosIncubados.DataBind();

                //Pongo como opción seleccionada en el DDL el proyecto que traigo de Consultar
                ddlProyectosIncubados.SelectedValue = Session["idProyectoIncubadoAFinalizar"].ToString();
                cargarDatosDelProyecto();
            }
        }
        else
        {
            proyectoIncubadoAFinalizar = (Proyecto)Session["proyectoIncubadoAModificar"];
        }
    }

    private void cargarDatosDelProyecto()
    {
        //Si se seleccionó un Proyecto en el DropDown List
        if (Convert.ToInt32(ddlProyectosIncubados.SelectedValue) != -1)
        {
            //Busco el Proyecto en la BD
            proyectoIncubadoAFinalizar = DAOProyecto.get(Convert.ToInt32(ddlProyectosIncubados.SelectedValue));
            Session["proyectoIncubadoAModificar"] = proyectoIncubadoAFinalizar;

            //Seteo los atributos en la UI
            txtNombreCorto.Text = proyectoIncubadoAFinalizar.NOMBRECORTO;
            txtNombreLargo.Text = proyectoIncubadoAFinalizar.NOMBRELARGO;
            txtFechaInicio.Text = proyectoIncubadoAFinalizar.FECHAINICIO.ToString("dd/MM/yyyy");
            txtFechaFinEstimada.Text = proyectoIncubadoAFinalizar.FECHAFINESTIMADA.ToString("dd/MM/yyyy");
            txtResumen.Text = proyectoIncubadoAFinalizar.RESUMEN;
            lblAreaDeInvestigacion.Text = proyectoIncubadoAFinalizar.AREASDEINVESTIGACION.NOMBRE;

            //Vuelvo a habilitar el botón
            btnFinalizar.Enabled = true;
        }
        else //Si NO se seleccionó un Proyecto en el DropDown List
        {
            //Limpio la UI
            txtNombreCorto.Text = "";
            txtNombreLargo.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFinEstimada.Text = "";
            txtResumen.Text = "";
            lblAreaDeInvestigacion.Text = "";

            //Ponemos en False el botón para que no guarde cagadas.
            btnFinalizar.Enabled = false;
        }
        
    }

    protected void btnGuardarLosCambios_Click(object sender, EventArgs e)
    {
        proyectoIncubadoAFinalizar.COMENTARIODEFINALIZACION = txtComentarios.Text;

        if (ddlRazonDeBaja.SelectedValue == "Finalizado")
        {
            proyectoIncubadoAFinalizar.finalizar(Convert.ToDateTime(txtFechaDeFin.Text, new CultureInfo("es-ES")));
        }
        else //Es una Cancelación
        {
            proyectoIncubadoAFinalizar.cancelar(Convert.ToDateTime(txtFechaDeFin.Text, new CultureInfo("es-ES")));
        }
    }

    protected void ddlProyectosIncubados_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Al cambiar el Valor Seleccionado en el DLL, se refrescan los datos en la UI
        cargarDatosDelProyecto();           
    }
}