using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// Representa un Becario registrado en el Sistema.
/// </summary>
public class Becario : Persona
{
    private TipoBecario tipoBecario;

    public TipoBecario TIPOBECARIO
    {
        get { return tipoBecario; }
        set { tipoBecario = value; }
    }

    /// <summary>
    /// Guarda un nuevo Becario en la Base de Datos
    /// </summary>
    /// <param name="becario"></param>
    public static void guardar(Becario becario)
    {
        DAOBecario.insertarDatosBecario(becario);
    }

    /// <summary>
    /// Retorna un Becario de la Base de Datos según el ID del Mismo.
    /// </summary>
    /// <param name="idBecario"></param>
    /// <returns></returns>
    public static Becario getBecario(int idBecario)
    {
        return DAOBecario.get(idBecario);
    }
    /// <summary>
    /// Modifica el Becario en la Base de Datos.
    /// </summary>
    /// <param name="becario"></param>
    public static void modificar(Becario becario)
    {
        DAOBecario.actualizarBecario(becario);
    }
    /// <summary>
    /// Heredado de la clase Persona.
    /// Devuelve un String con: Nombre, Apellido, Legajo y Categorias.
    /// Usado para mostrar datos en los DropDownList de la Interfaz.
    /// </summary>
    /// <returns></returns>
    public override String datosParaDll()
    {
        String nombreAMostrar = this.APELLIDO + ", " + this.NOMBRE + " - Legajo: " + this.LEGAJO;
        return nombreAMostrar;
    }
    /// <summary>
    /// Determina si el Becario tiene un Usuario creado o no.
    /// </summary>
    /// <returns></returns>
    public bool tieneUsuarioCreado()
    {
        return DAOBecario.tieneUsuarioCreado(this);
    }
    /// <summary>
    /// Asigna un Usuario al Becario.
    /// </summary>
    public void asignarUsuario()
    {
        DAOBecario.asignarUsuario(this);
    }
    /// <summary>
    /// Guarda el Becario en la Base de Datos
    /// </summary>
    public void guardar()
    {
        DAOBecario.guardarBecario(this);
    }
    /// <summary>
    /// Exporta las actividades del Becario a un archivo PDF.
    /// Retorna True si se pudo exportar con éxito.
    /// </summary>
    /// <returns></returns>
    public bool exportarPDFActividades(string path)
    {
        string proyecto = " ";

        List<Hito> listaActividades = DAOActividadBecario.listarActividadesPorBecario(this.ID);
        if (listaActividades != null)
        {
            String fechaEstimada = "";
            int i = 1;

            string html = "<table>";
            html += "<tr><td style=\"font-size: 15px;\" ><strong><u>Lista de Actividades Realizadas</u></strong></td></tr>"
               + "<tr><td  style=\"border-style: solid; border-width: thin; font-size: 13px;\"><strong>Becario: " +
               this.APELLIDO + ", " + this.NOMBRE + "</strong></td></tr></table>";
               // + "<p>...........................................................................................................................................</p>";

            foreach (Hito actividad in listaActividades)
            {

                if (proyecto.CompareTo(actividad.PROYECTO.NOMBRECORTO) != 0)
                {
                    html += "<p>...........................................................................................................................................</p>";
                    html += "<p><strong>Proyecto: " + actividad.PROYECTO.NOMBRECORTO + "</strong></p>";
                }
                proyecto = actividad.PROYECTO.NOMBRECORTO;
                html += "<br /><p style=\font-size: 10px;\">Actividad: " + actividad.NOMBRE + "</p>";
                html += "<p style=\font-size: 10px;\">Descripción: " + actividad.DESCRIPCION + "</p>";

                foreach (DateTime fecha in actividad.ACTUALIZACIONFECHAACTIVIDAD)
                {

                    fechaEstimada += "<p style=\font-size: 10px;\">-Fecha estimada [" + i + "]: " + fecha.ToShortDateString() + "</p> ";
                    i++;
                }
                html += "<p style=\font-size: 10px;\">Fecha estimada de finalización: " + fechaEstimada + "</p>";

                if (actividad.FECHAFINREAL.ToShortDateString().CompareTo("01/01/0001") != 0)
                    html += "<p style=\font-size: 10px;\">Fecha de finalización: " + actividad.FECHAFINREAL.ToShortDateString() + "</p>";
                else
                    html += "<p style=\font-size: 10px;\">Actividad sin finalizar</p>";
                fechaEstimada = "";
                
            }
            try
            {
                ExportarPDF.generarDocumentoDesdeHTML(html);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        return false;


    }
    /// <summary>
    /// Exporta las Actividades del Becario dependiendo del ID del Proyecto que se le pase por parámetro.
    /// </summary>
    /// <param name="idProyecto"></param>
    /// <returns></returns>
    public bool exportarPDFActividadesPorProyecto(int idProyecto, string path)
    {
        string html = armarHtmlActividadesPorProyecto(idProyecto, this.ID);
        try
        {
            if (html != string.Empty)
            {
                ExportarPDF.generarDocumentoDesdeHTML(html);
                return true;
            }
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }

    }

    /// <summary>
    /// Método para armar el código HTML necesario para listar las actividades
    /// por proyecto por hito de cada Becario.
    /// </summary>
    /// <param name="idHito"></param>
    /// <param name="idBecario"></param>
    /// <returns></returns>
    public static string armarHtmlActividadesPorProyectoPorHito(int idHito, int idBecario)
    {
        Becario becario = getBecario(idBecario);
        string html = "";
        Hito hito = DAOActividadBecario.get(idHito);
        if (hito != null)
        {
            String fechaEstimada = "";
            int i = 1;

            html = "<table>";
            html += "<td  style=\"border-style: solid; border-width: thin; font-size: 15px;\"><strong><u>" +
                becario.APELLIDO + ", " + becario.NOMBRE + "</u></strong></td></tr></table>"
                + "<p>...........................................................................................................................................</p>";

            html += "<p style=\font-size: 10px;\">Actividad: " + hito.NOMBRE + "</p>";
            html += "<p style=\font-size: 10px;\">Descripción: " + hito.DESCRIPCION + "</p>";

            foreach (DateTime fecha in hito.ACTUALIZACIONFECHAACTIVIDAD)
            {

                fechaEstimada += "<p style=\font-size: 10px;\">-Fecha estimada [" + i + "]: " + fecha.ToShortDateString() + "</p> ";
                i++;
            }
            html += "<p style=\font-size: 10px;\">Fecha estimada de finalización: " + fechaEstimada + "</p>";

            if (hito.FECHAFINREAL.ToShortDateString().CompareTo("01/01/0001") != 0)
                html += "<p style=\font-size: 10px;\">Fecha de finalización: " + hito.FECHAFINREAL.ToShortDateString() + "</p>";
            else
                html += "<p style=\font-size: 10px;\">Actividad sin finalizar</p>";
            fechaEstimada = "";
            html += "<p>...........................................................................................................................................</p>";


        }
        return html;
    }

    /// <summary>
    /// Método para armar el código HTML necesario para listar las actividades
    /// por proyecto de cada Becario.
    /// </summary>
    /// <param name="idProyecto"></param>
    /// <param name="idBecario"></param>
    /// <returns></returns>
    public static string armarHtmlActividadesPorProyecto(int idProyecto, int idBecario)
    {
        Becario becario = getBecario(idBecario);
        string html = "";
        List<Hito> listaActividades = DAOActividadBecario.listarActividadesPorBecarioPorProyecto(becario.ID, idProyecto);
        if (listaActividades != null)
        {
            String fechaEstimada = "";
            int i = 1;

            html = "<table>";
            html += "<tr><td style=\"font-size: 15px;\" ><strong><u>Lista de Actividades Realizadas</u></strong></td></tr>"
                + "<tr><td  style=\"border-style: solid; border-width: thin; font-size: 13px;\"><strong>Becario: " +
                becario.APELLIDO + ", " + becario.NOMBRE + "</strong></td></tr>"
                + "<tr><td><strong>Proyecto: " + Proyecto.get(idProyecto).NOMBRECORTO + " </strong></td></tr></table>"
                + "<p>...........................................................................................................................................</p>";

            foreach (Hito actividad in listaActividades)
            {

                html += "<p style=\font-size: 10px;\">Actividad: " + actividad.NOMBRE + "</p>";
                html += "<p style=\font-size: 10px;\">Descripción: " + actividad.DESCRIPCION + "</p>";

                foreach (DateTime fecha in actividad.ACTUALIZACIONFECHAACTIVIDAD)
                {

                    fechaEstimada += "<p style=\font-size: 10px;\">-Fecha estimada [" + i + "]: " + fecha.ToShortDateString() + "</p> ";
                    i++;
                }
                html += "<p style=\font-size: 10px;\">Fecha estimada de finalización: " + fechaEstimada + "</p>";

                if (actividad.FECHAFINREAL.ToShortDateString().CompareTo("01/01/0001") != 0)
                    html += "<p style=\font-size: 10px;\">Fecha de finalización: " + actividad.FECHAFINREAL.ToShortDateString() + "</p>";
                else
                    html += "<p style=\font-size: 10px;\">Actividad sin finalizar</p>";
                fechaEstimada = "";
                html += "<p>...........................................................................................................................................</p>";
            }

        }
        return html;
    }
    /// <summary>
    /// Le asigna un Producto generado al Becario.
    /// </summary>
    /// <param name="idProducto"></param>
    public void asignarProducto(int idProducto)
    {
        DAOBecario.asignarProducto(idProducto, this.ID);
    }
    /// <summary>
    /// Retorna la cantidad de Becarios Activos en el Sistema.
    /// </summary>
    /// <returns></returns>
    public static int totalDeBecariosActivos()
    {
        return DAOBecario.totalDeBecariosActivos();
    }

    public int cantidadDeProyectosEnLosQueParticipoActualmente()
    {
        return proyectosEnLosQueParticipoActualmente().Count();
    }

    private List<Proyecto> proyectosEnLosQueParticipoActualmente()
    {
        List<Proyecto> proyectos = new List<Proyecto>();

        proyectos.AddRange(DAOBecario.listarProyectosActualesComoBecario(this.ID));

        return proyectos;
    }
}