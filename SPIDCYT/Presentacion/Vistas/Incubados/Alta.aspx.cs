using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Vistas_Incubados_AltaIncubado : System.Web.UI.Page
{
    private Proyecto proyectoIncubadoAGuardar;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            proyectoIncubadoAGuardar = new Proyecto();

            //Es Incubado asi que le seteo el tipo Incubado
            ProyectoCategorizado proyectoCategorizado = new ProyectoCategorizado();
            proyectoCategorizado.TIPOPROYECTO = DAOTipoProyecto.get("Incubado");
            proyectoIncubadoAGuardar.PROYECTOCATEGORIZADO.Add(proyectoCategorizado);

            Session["proyectoIncubadoAGuardar"] = proyectoIncubadoAGuardar;
            Session["becariosEnElSistema"] = DAOBecario.listarBecarios();
            cargarBecarios();
        }
        else
        {
            proyectoIncubadoAGuardar = (Proyecto) Session["proyectoIncubadoAGuardar"];
            cargarBecarios();
        }        
    }

    //Cargar los Becarios en el DLL
    private void cargarBecarios()
    {
        ddlBecarios.Items.Clear();
        if ((List<Becario>)Session["becariosEnElSistema"] != null)
        {
            //Por cada Becario en la lista de Becarios del Sistema
            foreach (Becario item in (List<Becario>)Session["becariosEnElSistema"])
            {
                //Si ese Becario no existe en el Proyecto
                if (!proyectoIncubadoAGuardar.esBecarioDelProyecto(item))
                {
                    //Mostralo en el DLL para que se pueda agregar al proyecto
                    ddlBecarios.Items.Add(new ListItem(item.datosParaDll(), item.ID.ToString()));
                }
            }
        }
    }
    //Cargar la Grilla de Becarios
    private void cargarGrillaBecarios()
    {
        grillaBecarios.DataKeyNames = new string[] { "ID" };
        grillaBecarios.DataSource = proyectoIncubadoAGuardar.BECARIOS;
        grillaBecarios.DataBind();

    }
    //Función del Botón Agregar Becario
    protected void btnAgregarBecario_Click(object sender, EventArgs e)
    {
        //Limpiamos el Campo de Error que indica que no hay Becarios Insertados (HARD-CODING)
        lblErrorBecarios.Text = "";

        //Buscamos el ID del Becario seleccionado en el DLL
        int idBecarioAAgregar = Convert.ToInt32(ddlBecarios.SelectedValue);

        //Lo agregamos el Becario seleccionado al proyectoIncubado
        proyectoIncubadoAGuardar.BECARIOS.Add(DAOBecario.get(Convert.ToInt32(ddlBecarios.SelectedValue)));

        //Refrescamos la UI
        cargarGrillaBecarios();
        cargarBecarios();
    }

    //Función del Botón Eliminar Becario 
    protected void grillaBecarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Obtenemos el ID del Becario seleccionado en el DLL
        int idBecario = Convert.ToInt32(grillaBecarios.DataKeys[e.RowIndex].Value);

        //Lo eliminamos del proyecto.
        proyectoIncubadoAGuardar.BECARIOS.Remove(proyectoIncubadoAGuardar.BECARIOS.Find(becario => becario.ID == idBecario));

        //Refrescamos la UI
        cargarGrillaBecarios();
        cargarBecarios();
    }

    //Boton para Dar de Alta el Proyecto
    protected void btnDarDeAltaProyectoIncubado_Click(object sender, EventArgs e)
    {
        //Si no hay ningún Becario Ingresado
        if (grillaBecarios.Rows.Count == 0)
        {
            //Error, no hay que guardar
            lblErrorBecarios.Text = "Debe insertar al menos un Becario en el Proyecto";
            lblErrorBecarios.CssClass = "error";
        }
        else
        {
            //Limpiamos el Campo de Error que indica que no hay Becarios Insertados (HARD-CODING)
            lblErrorBecarios.Text = "";

            //Damos de Alta el nuevo Proyecto
            proyectoIncubadoAGuardar.NOMBRECORTO = txtNombreCorto.Text;
            proyectoIncubadoAGuardar.NOMBRELARGO = txtNombreLargo.Text;
            proyectoIncubadoAGuardar.RESUMEN = txtResumen.Text;
            proyectoIncubadoAGuardar.FECHAINICIO = Convert.ToDateTime(txtFechaInicio.Text, new CultureInfo("es-ES"));
            proyectoIncubadoAGuardar.FECHAFINESTIMADA = Convert.ToDateTime(txtFechaFinEstimada.Text, new CultureInfo("es-ES"));

            //Si se selecciono algun área de investigación
            if (ddlAreaDeInvestigacion.SelectedValue != "-1")
            { proyectoIncubadoAGuardar.AREASDEINVESTIGACION = DAOAreaDeInvestigacion.get(Convert.ToInt32(ddlAreaDeInvestigacion.SelectedValue)); }

            try
            {
                proyectoIncubadoAGuardar.insertar();
                lblErrorBecarios.Text = "Proyecto Incubado ingresado con éxito!";
                lblErrorBecarios.CssClass = "success";
            }
            catch (Exception)
            {
                lblErrorBecarios.Text = "Error al insertar el Proyecto Incubado.";
                lblErrorBecarios.CssClass = "error";
            }          
            
        }
    }
}