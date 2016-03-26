using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Investigadores_Modificar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath == "/Vistas/Investigadores/ConsultaInvestigadores.aspx")
        {
            int idInvestigadorAModificar = (int)Session["idInvestigadorAModificar"];
            cargarDatosInvestigador(idInvestigadorAModificar);
        }
    }

    //Método para Modificar el Investigador
    protected void btnModificarInvestigador_Click(object sender, EventArgs e)
    {
        //Primero verificamos en la BD si el Legajo existe.
        if(validarLegajo())
        {
            //Obtenemos el Investigador
            Investigador investigadorAModificar = DAOInvestigador.get((int)Session["idInvestigadorAModificar"]);
            
            //Retorna false si el mail existe #CHANCHADA
            bool mailExiste = Persona.checkMailExistente(txtMail.Text, investigadorAModificar.ID);         

            if (mailExiste) //Tiramos error
            {
                lblMail.Text = "Dirección ya registrada en el sistema.";
                lblMail.Visible = true;
            }
            else //Tratamos de ingresar el Investigador
            {
                //Para no ensuciar el if, llenamos los datos en otro método
                investigadorDataBind(investigadorAModificar);

                try
                {
                    investigadorAModificar.modificar();

                }
                catch (Exception ex)
                {
                    lblNotificaciones.CssClass = "error";
                    lblNotificaciones.Text = "Error al Modifiar el Investigador. Por favor vuelva a intentar más tarde.";
                    lblNotificaciones.Visible = true;
                    btnModificarInvestigador.Enabled = false;
                    throw;
                }

                lblMail.Visible = false;
                lblLegajo.Visible = false;
                lblNotificaciones.CssClass = "success";
                lblNotificaciones.Text = "Investigador modificado con éxito!";
                lblNotificaciones.Visible = true;
                btnModificarInvestigador.Enabled = false; 
            }
            
        }
        else //EL legajo ya existe
        {
            lblLegajo.Text = "El Legajo ya existe!";
        }
    }
    
    //Método para Validar el Legajo
    private bool validarLegajo()
    {
        //NOTA: Tenemos en cuenta que Investigadores y Becarios PUEDEN compartir Legajo
        Investigador investigadorEncontrado = DAOInvestigador.buscarInvestigadorPorLegajo(Convert.ToInt32(txtLegajo.Text));
        
        //Si no hay un Investigador, el legajo puede usarse.
        if (investigadorEncontrado == null)
        { 
            return true; //Puedo Modificar
        }
        else
        {
            //Si me encuentra el mismo investigador que estoy modificando
            if (investigadorEncontrado.ID == (int)Session["idInvestigadorAModificar"])
            {                
                return true; //Puedo Modificar
            }
            //Este legajo esta siendo Usado por OTRO Investigador
            else 
            {
                return false; //No puedo modificar
            }
        }
    }

    //Método para Cargarle los Datos al Objeto investigador antes de llamar al insertar
    private bool investigadorDataBind(Investigador investigador)
    {        
        investigador.NOMBRE = txtNombre.Text;
        investigador.APELLIDO = txtApellido.Text;
        investigador.FECHAALTA = Convert.ToDateTime(txtFechaAlta.Text, new CultureInfo("es-ES"));
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

        //Guardo el Legajo para una Validación posterior
        ViewState["legajoInvestigador"] = investigador.LEGAJO;
        return false;
    }

    //Método para cargar el investigador en la página
    private void cargarDatosInvestigador(int idInvestigadorAModificar)
    {
        Investigador investigadorAModificar = DAOInvestigador.get(idInvestigadorAModificar);
        txtApellido.Text = investigadorAModificar.APELLIDO;
        txtFechaAlta.Text = investigadorAModificar.FECHAALTA.ToString("dd/MM/yyyy");


        txtLegajo.Text = investigadorAModificar.LEGAJO.ToString();
        txtMail.Text = investigadorAModificar.MAIL;
        txtNombre.Text = investigadorAModificar.NOMBRE;
        txtTelefono.Text = investigadorAModificar.TELEFONO;
        if (investigadorAModificar.CATEGORIANACIONAL != null)
        {
            ddlCategoriaNacional.SelectedValue = investigadorAModificar.CATEGORIANACIONAL.ID.ToString();
            txtFechaCategorizacionNACIONAL.Text = investigadorAModificar.FECHACATEGORIZACIONNACIONAL.ToString("dd/MM/yyyy");
        }
        if (investigadorAModificar.CATEGORIAUTN != null)
        {
            ddlCategoriaUTN.SelectedValue = investigadorAModificar.CATEGORIAUTN.ID.ToString();
            txtFechaCategorizacionUTN.Text = investigadorAModificar.FECHACATEGORIZACIONUTN.ToString("dd/MM/yyyy");
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
}