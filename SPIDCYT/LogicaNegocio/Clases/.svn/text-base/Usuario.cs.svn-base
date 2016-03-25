using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Web.Security;

/// <summary>
/// Representa un Usuario registrado en el sistema
/// </summary>
public class Usuario
{
    private String nombreUsuario;

    public string NOMBREUSUARIO
    {
        get { return nombreUsuario; }
        set { nombreUsuario = value; }
    }

    public Usuario(string nombreUsuario)
    {
        this.nombreUsuario = nombreUsuario;
    }

    public Usuario()
    {
        
    }
    /// <summary>
    /// Devuelve la ubicacion de la imagen de perfil
    /// </summary>
    /// <returns></returns>
    public String obtenerRutaImagen()
    {
        return DAOUsuario.obtenerRutaImagen(this.NOMBREUSUARIO);
    }
    //devuelve la ubicacion del archivo de Curriculum Vitae del usuario
    public string obtenerRutaCurriculum()
    {
        return DAOUsuario.obtenerRutaCurriculum(this.NOMBREUSUARIO);
    }

    public void actualizarFoto(string foto)
    {
        DAOUsuario.actualizarFoto(foto, this.NOMBREUSUARIO);
    }
    /// <summary>
    /// Devuelve el objeto de la clase Persona asociado al usuario
    /// </summary>
    /// <returns></returns>
    public Persona getPersona()
    {
        int idPersona = DAOUsuario.getIDPersona(this.nombreUsuario);
        if (esInvestigador())//si es director o codirector tambien es investigador
        {
            Investigador investigador = DAOInvestigador.get(idPersona);
            return investigador;
        }
        else
        {
            Becario becario = DAOBecario.get(idPersona);
            return becario;
        }        
    }

    /// <summary>
    /// Determina si es Investigador
    /// </summary>
    /// <returns></returns>
    public bool esInvestigador()
    {        
       return DAOUsuario.esInvestigador(this.nombreUsuario);
    }

    /// <summary>
    /// Actualiza el archivo Curriculum Vitae del usuario
    /// </summary>
    /// <param name="curriculum">Ubicación del archivo</param>
    public void actualizarCV(string curriculum)
    {
        DAOUsuario.actualizarCV(curriculum, this.NOMBREUSUARIO);
    }
    /// <summary>
    /// Genera una contraseña a partir de una serie de caracteres permitidos
    /// </summary>
    /// <param name="longitudContrasena">Longitud de la contraseña a generar</param>
    /// <returns>Contraseña generada</returns>
    public static string CrearContrasena(int longitudContrasena)
    {
        string caracteresPermitidos = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789!@$";
        Byte[] randomBytes = new Byte[longitudContrasena];
        char[] caracteres = new char[longitudContrasena];
        int numeroDeCaracteresPermitidos = caracteresPermitidos.Length;

        for (int i = 0; i < longitudContrasena; i++)
        {
            Random randomObj = new Random();
            randomObj.NextBytes(randomBytes);
            caracteres[i] = caracteresPermitidos[(int)randomBytes[i] % numeroDeCaracteresPermitidos];
        }

        return new string(caracteres);
    }
    /// <summary>
    /// Envia el mail de creación de usuario
    /// </summary>
    /// <param name="direccionMail">Direccion de Correo del Destinatario</param>
    /// <param name="nombre">Nombre de la persona asociada al usuario</param>
    /// <param name="contrasena">Contraseña generada</param>
    /// <returns>True si se envió correctamente</returns>
    public static bool enviarMail(string direccionMail, string nombre, string contrasena)
    {
        MailMessage msg = new MailMessage();//"spidcyt@gmail.com",direccionMail);
        SmtpClient client = new SmtpClient("smtp.gmail.com");
        msg.From = new MailAddress("spidcyt@gmail.com", "SPIDCYT");
        msg.Subject = "Activación de Usuario";

        msg.BodyEncoding =  System.Text.Encoding.UTF8;
        msg.Body = nombre + ":";
        msg.Body += Environment.NewLine;
        msg.Body += "Su usuario en SPIDCYT ha sido activado, Puede ingresar al sistema con los siguientes datos:";
        msg.Body += Environment.NewLine;
        msg.Body += Environment.NewLine;
        msg.Body += "   Nombre de Usuario: " + direccionMail;
        msg.Body += Environment.NewLine;
        msg.Body += "   Password: " + contrasena;
        msg.To.Add(direccionMail);
        try
        {
            client.EnableSsl = true;
            client.Send(msg);
            return true;
        }
        catch { return false; }
    }

    /// <summary>
    /// Método para enviar un mail con un Mensaje pasado por parámetro.
    /// </summary>
    /// <param name="direccionMail">Dirección de Correo del Destinatario</param>
    /// <param name="nombre">Nombre del Destinatario</param>
    /// <param name="subject">Subject del Mail</param>
    /// <param name="mensaje">Mensaje a ser enviado</param>
    public static void enviarMensajePorMail(string direccionMail, string nombre, string subject, string mensaje)
    {
        MailMessage msg = new MailMessage();//"spidcyt@gmail.com",direccionMail);
        SmtpClient client = new SmtpClient("smtp.gmail.com");
        msg.From = new MailAddress("spidcyt@gmail.com", "SPIDCYT");
        msg.Subject = subject;

        msg.BodyEncoding = System.Text.Encoding.UTF8;
        msg.Body = nombre + ":";
        msg.Body += Environment.NewLine;
        msg.Body += mensaje;
        msg.Body += Environment.NewLine;
        msg.Body += Environment.NewLine;
        msg.Body += "Saludos Cordiales, ";
        msg.Body += Environment.NewLine;
        msg.Body += "Secretaría de Promoción de Investigaciones y Desarrollo en Ciencia y Tecnología.";
        msg.To.Add(direccionMail);
        try
        {
            client.EnableSsl = true;
            client.Send(msg);
        }
        catch { }
    }
    /// <summary>
    /// Genera una contraseña nueva para un usuario y envía un mail con la misma
    /// </summary>
    /// <param name="nombreUsuario">Usuario al que se le reestablecerá la contraseña</param>
    /// <returns></returns>
    public static string reestablecerContrasena(string nombreUsuario)
    {
        string contrasena = CrearContrasena(8);
        enviarMensajePorMail(nombreUsuario, nombreUsuario, "Nueva contraseña", "Ha solicitado reestablecer su contraseña, podrá ingresar al sistema con la siguiente: " + contrasena);
        return contrasena; 
    }
    /// <summary>
    /// Devuelve una cadena con formato HTML que permite su exportación a PDF
    /// </summary>
    /// <param name="tablaActividadUsuarios">Tabla con datos de los usuarios registrados en el sistema</param>
    /// <returns></returns>
    public static string armarHtmlActividadUsuarios(System.Data.DataTable tablaActividadUsuarios)
    {

        string html = "";

            html = "<table>";
            html += "<td  style=\"border-style: solid; border-width: thin; font-size: 15px;\"> <strong><u>Usuarios Registrados en el Sistema</u></strong></td></tr></table>"
                + "<p> </p>";

            

            html += "<table border=\"1\"; bordercolor=\"#000000\";>";
            html += "<tr>";

            html += "<td style=\"font-size: 10px;\"> <b>Apellido</b>";
            html += "</td>";

            html += "<td style=\"font-size: 10px;\"><b>Nombre</b>";
            html += "</td>";

            html += "<td style=\"font-size: 10px;\"><b>Rol</b>";
            html += "</td>";

            html += "<td style=\"font-size: 10px;\"><b>Email</b>";
            html += "</td>";

            html += "<td style=\"font-size: 10px;\"><b>Fecha de Creación</b>";
            html += "</td>";

            //html += "<td style=\font-size: 6px;\"><b>Ultimo inicio de sesión</b>";
            //html += "</td>";

            //html += "<td style=\font-size: 6px;\"><b>Ultimo cambio de contraseña</b>";
            //html += "</td>";

            //html += "<td style=\font-size: 6px;\"><b>Intentos fallidos de contraseña</b>";
            //html += "</td>";

            html += "</tr>";

            for(int i=0; i<tablaActividadUsuarios.Rows.Count;i++)
            {
                html+="<tr>";                
               
                html+="<td style=\"font-size: 6px;\">" + tablaActividadUsuarios.Rows[i][0].ToString();
                html+="</td>";

                html += "<td style=\"font-size: 6px;\">" + tablaActividadUsuarios.Rows[i][1].ToString();
                html += "</td>";

                html += "<td style=\"font-size: 6px;\">" + tablaActividadUsuarios.Rows[i][2].ToString();
                html += "</td>";

                html += "<td style=\"font-size: 6px;\">" + tablaActividadUsuarios.Rows[i][3].ToString();
                html += "</td>";

                html += "<td style=\"font-size: 6px;\">" + tablaActividadUsuarios.Rows[i][4].ToString();
                html += "</td>";

                //html += "<td style=\font-size: 3px;\">" + tablaActividadUsuarios.Rows[i][5].ToString();
                //html += "</td>";

                //html += "<td style=\font-size: 3px;\">" + tablaActividadUsuarios.Rows[i][6].ToString();
                //html += "</td>";

                //html += "<td style=\font-size: 3px;\">" + tablaActividadUsuarios.Rows[i][7].ToString();
                //html += "</td>";

                html += "</tr>";
                    
            }
            html += "</table>";
            html += "<p style=\"font-size: 10px;\">Cantidad de usuarios: " + tablaActividadUsuarios.Rows.Count + "</p>";

            
            html += "<p>...........................................................................................................................................</p>";
                
        return html;
    }


   

    
}


