using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Globalization;
/// <summary>
/// Esta clase es utilizada para serialziar los JSON para armar las timelines públicas.
/// </summary>
public class PublicoJSON
{

    public string id { get; set; }
    public string title { get; set; }
    public string startdate { get; set; }
    public string enddate { get; set; }
    public string description { get; set; }
    public string date_display { get; set; }
    public string importance { get; set; }
    public string icon { get; set; }
    public string link { get; set; }
   

    /// <summary>
    /// Este método permite listar todas los elementos de las timelines publicas
    /// </summary>
    /// <param name="path">dirección absoluta del servidor web</param>
    public static void noticias( string path)
    {
        List<PublicoJSON>  listaProyecto = new List<PublicoJSON>(); 
        List<PublicoJSON> listaInvestigador = new List<PublicoJSON>();
        List<PublicoJSON> listaBecario = new List<PublicoJSON>();

        PublicoJSON oNoticiaJson = new PublicoJSON();
        SqlCommand comando = new SqlCommand();
        //string oid, ostartdate, odescription, otitle;
        bool flag = false;
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "timelineProyectosPublica";
       
        DataTable dt = Conexion.consultar(comando);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            flag = false;
            oNoticiaJson = new PublicoJSON();
            oNoticiaJson.id = i.ToString();
            if (dt.Rows[i]["fechaDesde"].ToString() != string.Empty)
                oNoticiaJson.startdate = Convert.ToDateTime(dt.Rows[i]["fechaDesde"], new CultureInfo("es-ES")).ToString("yyyy-MM-dd hh:mm:ss");
            if (dt.Rows[i]["fechaHasta"].ToString() != string.Empty)
                oNoticiaJson.enddate = Convert.ToDateTime(dt.Rows[i]["fechaHasta"], new CultureInfo("es-ES")).ToString("yyyy-MM-dd hh:mm:ss");
            oNoticiaJson.description = Convert.ToString(dt.Rows[i]["tipo"]);
            oNoticiaJson.title = Convert.ToString(dt.Rows[i]["Nombre"]); ;
            oNoticiaJson.link = Convert.ToString(dt.Rows[i]["link"]);
            oNoticiaJson.date_display = "days";
            if (oNoticiaJson.description.CompareTo("Investigador") == 0)
            {
                oNoticiaJson.importance = "40";
                oNoticiaJson.icon = "Client-Female.png";
                listaInvestigador.Add(oNoticiaJson);
                flag = true;
            }

            else if (oNoticiaJson.description.CompareTo("Becario") == 0)
            {
                oNoticiaJson.importance = "40";
                oNoticiaJson.icon = "Child-Female.png";
                listaBecario.Add(oNoticiaJson);
                flag = true;
            }
            else if (oNoticiaJson.description.CompareTo("Proyecto") == 0)
            {
                oNoticiaJson.importance = "40";
                oNoticiaJson.icon = "research.png";
                listaProyecto.Add(oNoticiaJson);
                flag = true;
            }

            if (!flag)
            {
                oNoticiaJson.importance = "30";
                oNoticiaJson.icon = "Product-documentation.png";
                listaProyecto.Add(oNoticiaJson);
            }

           
        }
             serializar(listaProyecto, path, "timelinePublicaProyeto");
             serializar(listaBecario, path, "timelinePublicaBecario");
             serializar(listaInvestigador, path, "timelinePublicaInvestigador");
    }

    /// <summary>
    /// Método que crea e JSON correspondiente a cada elemento de la timeline pública
    /// </summary>
    /// <param name="olista">lista de objetos a serializar</param>
    /// <param name="path">dirección absoluta del servidor web a guardar</param>
    /// <param name="nombreArchivo">nombre del archivo </param>
    public static void serializar(List<PublicoJSON> olista, string path,string nombreArchivo)
    {
        string intro = "[{\"id\":\"" + "X" + "\",";
        intro += "\"title\":\"" + "Secretaría de Promoción de Investigación y Desarollo en Ciencia y Tecnología"  +  "\",";
        intro += "\"description\":\"" + "La Secretaría de Promoción de Investigaciones y Desarrollos en Ciencia y Tecnología, tiene por objetivo prioritario, promover todo tipo de actividades de investigación, desarrollo y transferencia en la comunidad académica del Departamento de Ingeniería en Sistemas de Información." + "\",";
        intro += "\"focus_date\":\"" + DateTime.Today.ToString("yyyy-MM-dd hh:mm:ss") + "\",";
        intro += "\"timezone\":\"-07:00\",";
        intro += "\"initial_zoom\":\"35\",";
        intro += "\"image\":\"Images/Logo_UTN.png\",";
        intro += "\"events\":";

        System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
        new System.Web.Script.Serialization.JavaScriptSerializer();
        string sJSON = oSerializer.Serialize(olista);
        guardarArchivo(sJSON, intro, path, nombreArchivo);
    }

    /// <summary>
    /// Crea el archivo .jSOn que despues permitirá cargar la timeline
    /// </summary>
    /// <param name="json">objeto serializado</param>
    /// <param name="intro">Cabecera de la timeline</param>
    /// <param name="path">dirección absoluta del servidor web</param>
    /// <param name="nombreArchivo">nombre del archivo </param>
    public static void guardarArchivo(string json, string intro, string path, string nombreArchivo)
    {

        var jss = new JavaScriptSerializer();
        var dict = jss.Deserialize<dynamic>(json);



        try
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter(path + @"\"+nombreArchivo+".json");
            sw.WriteLine(intro);
            //Write a line of text
            sw.WriteLine(jss.Serialize(dict));
            sw.WriteLine("}]");
            sw.Close();
        }
        catch (Exception e)
        {

        }
        finally
        {

        }
    }






}