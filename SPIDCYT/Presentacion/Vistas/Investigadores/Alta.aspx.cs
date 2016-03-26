using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Vistas_Investigadores_AltaInvestigador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //PRIMERA VEZ QUE ENTRO A LA PÁGINA
        if (!Page.IsPostBack)
        {
            lblMail.Visible = false;
            lblLegajo.Visible = false;
            lblNotificaciones.Visible = false;
            ddlCategoriaNacional.SelectedValue= "-1";
            ddlCategoriaUTN.SelectedValue = "-1";
        }
        //CUANDO HAGO CLICK EN BOTONES QUE NO SON GUARDAR
        else
        {

        }

    }

    //Método para Guardar el Investigador
    protected void btnGuardarInvestigador_Click(object sender, EventArgs e)
    {
        //Creamamos el Investigador
        Investigador investigador = new Investigador();
        
        //Checkeamos Mail, no tenemos ID, pasamos -1.
        bool mailExiste = Persona.checkMailExistente(txtMail.Text, -1);

        //Primero verificamos que el Mail no esté repetido.
        if (mailExiste)
        {
            lblMail.Text = "Dirección ya registrada en el sistema.";
            lblMail.Visible = true;
        }        
        //Segundo verificamos en la BD si el Legajo existe.
        else if (DAOInvestigador.buscarInvestigadorPorLegajo(Convert.ToInt32(txtLegajo.Text)) == null)
            {                
                try
                {
                    //Para no ensuciar el if, llenamos los datos en otro método
                    investigadorDataBind(investigador);
                    investigador.insertar();

                    lblMail.Visible = false;
                    lblLegajo.Visible = false;
                    lblNotificaciones.CssClass = "success";
                    lblNotificaciones.Text = "Investigador ingresado con éxito!";
                    lblNotificaciones.Visible = true;
                    btnGuardarInvestigador.Enabled = true;
                    limpiarCampos();
                }
                catch (Exception ex)
                {
                    lblNotificaciones.CssClass = "error";
                    lblNotificaciones.Text = "Error al Ingresar el Investigador. Por favor vuelva a intentar más tarde.";
                    lblNotificaciones.Visible = true;
                    btnGuardarInvestigador.Enabled = false;                    
                    throw;
                }                               
            }
            else
            {
                lblLegajo.Text = "El Legajo ya existe!";
                lblLegajo.Visible = true;
            }
    }
      
    //Método para Cargarle los Datos al Objeto investigador antes de llamar al insertar
    private void investigadorDataBind(Investigador investigador)
    {
        investigador.NOMBRE = txtNombre.Text;
        investigador.APELLIDO = txtApellido.Text;
        investigador.FECHAALTA = Convert.ToDateTime(txtFechaAlta.Text, new CultureInfo("es-ES") );
        investigador.LEGAJO = Convert.ToInt64(txtLegajo.Text);
        investigador.MAIL = txtMail.Text;
        investigador.TELEFONO = txtTelefono.Text;

        if (Convert.ToInt32(ddlCategoriaUTN.SelectedValue) != -1)
        {
            CategoriaInvestigador categoriaUTN = DAOCategoriaInvestigador.get(Convert.ToInt32(ddlCategoriaUTN.SelectedValue));
            investigador.CATEGORIAUTN = categoriaUTN;
            investigador.FECHACATEGORIZACIONUTN = Convert.ToDateTime(txtFechaCategorizacionUTN.Text, new CultureInfo("es-ES"));
        }

        if (Convert.ToInt32(ddlCategoriaNacional.SelectedValue) != -1)
        {
            CategoriaInvestigador categoriaNacional = DAOCategoriaInvestigador.get(Convert.ToInt32(ddlCategoriaNacional.SelectedValue));
            investigador.CATEGORIANACIONAL = categoriaNacional;
            investigador.FECHACATEGORIZACIONNACIONAL = Convert.ToDateTime(txtFechaCategorizacionNACIONAL.Text, new CultureInfo("es-ES"));

        }
    }
    
    //Métodos para habilitar el Required Field de las Fechas de Categorizacion
    protected void ddlCategoriaUTN_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlCategoriaUTN.SelectedValue) != -1)
        {
            rfvFechaCategorizacionUTN.Enabled = true;
        }
        else
        {
            rfvFechaCategorizacionUTN.Enabled = false;
            txtFechaCategorizacionUTN.Text = "";
        }
    }
    protected void ddlCategoriaNacional_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlCategoriaNacional.SelectedValue) != -1)
        {
            rfvFechaCategorizacionNACIONAL.Enabled = true;
        }
        else
        {
            rfvFechaCategorizacionNACIONAL.Enabled = false;
            txtFechaCategorizacionNACIONAL.Text = "";
        }
    }

   //limpiar campos
    private void limpiarCampos()
    {
        txtApellido.Text = "";
        txtNombre.Text = "";
        txtTelefono.Text = "";
        txtMail.Text = "";
        txtFechaAlta.Text = "";
        txtFechaCategorizacionNACIONAL.Text = "";
        txtFechaCategorizacionUTN.Text = "";
        ddlCategoriaNacional.SelectedIndex=-1;
        ddlCategoriaUTN.SelectedIndex = -1;
        
    }
}