using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Incubados_Modificar : System.Web.UI.Page
{
    Proyecto proyectoIncubadoAModificar;

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
            if (Request.UrlReferrer != null && (Request.UrlReferrer.AbsolutePath == "/Presentacion/Vistas/Incubados/ConsultarProyectos.aspx"))
            {
                //Ejecuto DataBind para poder setearle el SelectedValue
                cargarDllProyectosIncubados();

                //Le seteo el id que viene de Session
                ddlProyectosIncubados.SelectedValue = Session["idProyectoIncubadoAModificar"].ToString();

                //Cargo los Datos del Proyecto en el ABM
                cargarDatosDelProyecto();
            }
            
        }
        else
        {
            proyectoIncubadoAModificar = (Proyecto)Session["proyectoIncubadoAModificar"];
        }
    }

    private void cargarDllProyectosIncubados()
    {
        ddlProyectosIncubados.Items.Add(new ListItem("Seleccione un Proyecto...", "-1"));

        List<Proyecto> proyectos = DAOProyecto.listarTodosLosProyectosWebPublica();
        foreach (Proyecto item in proyectos)
        {
            if (item.esIncubado())
                ddlProyectosIncubados.Items.Add(new ListItem(item.NOMBRECORTO, item.ID.ToString()));
        }

    }

    //Método para cargar los datos del Proyecto
    private void cargarDatosDelProyecto()
    {      
        //Si se seleccionó un Proyecto en el Drop Down List
        if (Convert.ToInt32(ddlProyectosIncubados.SelectedValue) != -1)
        {
            //Busco el Proyecto en la BD
            proyectoIncubadoAModificar = DAOProyecto.get(Convert.ToInt32(ddlProyectosIncubados.SelectedValue));
            Session["proyectoIncubadoAModificar"] = proyectoIncubadoAModificar;

            //Seteo los atributos en la UI
            txtNombreCorto.Text = proyectoIncubadoAModificar.NOMBRECORTO;
            txtNombreLargo.Text = proyectoIncubadoAModificar.NOMBRELARGO;
            txtFechaInicio.Text = proyectoIncubadoAModificar.FECHAINICIO.ToString("dd/MM/yyyy");
            txtFechaFinEstimada.Text = proyectoIncubadoAModificar.FECHAFINESTIMADA.ToString("dd/MM/yyyy");
            txtResumen.Text = proyectoIncubadoAModificar.RESUMEN;

            //Si el Proyecto Tiene un Área de Investigación
            if (proyectoIncubadoAModificar.AREASDEINVESTIGACION != null)
            { ddlAreaDeInvestigacion.SelectedValue = proyectoIncubadoAModificar.AREASDEINVESTIGACION.ID.ToString(); }
            else
            { ddlAreaDeInvestigacion.SelectedValue = "-1";}


            //Vuelvo a habilitar el botón
            btnGuardarLosCambios.Enabled = true;
        }
        else //Si NO se seleccionó un Proyecto en el Drop Down List
        {
            //Limpio la Pantalla
            txtNombreCorto.Text = "";
            txtNombreLargo.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFinEstimada.Text = "";
            txtResumen.Text = "";
            ddlAreaDeInvestigacion.SelectedValue = "-1";
            
            
            //Desabilito el botón para que no guarde porquerías
            btnGuardarLosCambios.Enabled = false;
        }
    }
    
    //Guardar los Cambios en el Proyecto
    protected void btnGuardarLosCambios_Click(object sender, EventArgs e)
    {
            //Actualizo los datos en el objeto
            proyectoIncubadoAModificar.NOMBRECORTO = txtNombreCorto.Text;
            proyectoIncubadoAModificar.NOMBRELARGO = txtNombreLargo.Text;
            proyectoIncubadoAModificar.RESUMEN = txtResumen.Text;
            proyectoIncubadoAModificar.FECHAINICIO = Convert.ToDateTime(txtFechaInicio.Text, new CultureInfo("es-ES"));
            proyectoIncubadoAModificar.FECHAFINESTIMADA = Convert.ToDateTime(txtFechaFinEstimada.Text, new CultureInfo("es-ES"));

            //Si hay seleccionada algún área de investigación, la seteo.
            if (ddlAreaDeInvestigacion.SelectedValue != "-1")
            {
                proyectoIncubadoAModificar.AREASDEINVESTIGACION = DAOAreaDeInvestigacion.get(Convert.ToInt32(ddlAreaDeInvestigacion.SelectedValue));
            }
            
            //Modifico
            try
            {
                proyectoIncubadoAModificar.modificar();
                lblErrorBecarios.Text = "Proyecto Incubado modificado con éxito!";
                lblErrorBecarios.CssClass = "success";
            }
            catch (Exception)
            {
                lblErrorBecarios.Text = "Error al modificar el Proyecto Incubado.";
                lblErrorBecarios.CssClass = "error";
            }            
                   
    }

    //Cuando selecciono distintos proyectos en el DLL
    protected void ddlProyectosIncubados_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarDatosDelProyecto();
    }
}