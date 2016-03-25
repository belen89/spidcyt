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
/// Representa noticias para mostrar en el perfil de un proyecto.
/// </summary>
public class noticiaJSON
{
    public string id { get; set; }
    public string title { get; set; }
    public string startdate { get; set; }
    public string description { get; set; }
    public string date_display { get; set; }
    public string importance { get; set; }
    public string icon { get; set; }
    public string link { get; set; }

    /// <summary>
    /// Obtiene noticias para un proyecto
    /// </summary>
    /// <param name="idProyecto"></param>
    /// <param name="path"></param>
    public static void noticias(int idProyecto, string path)
    {
        List<noticiaJSON> lista = new List<noticiaJSON>();
        noticiaJSON oNoticiaJson = new noticiaJSON();
        SqlCommand comando = new SqlCommand();
        //string oid, ostartdate, odescription, otitle;

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "noticiasProyecto ";
        comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
        DataTable dt = Conexion.consultar(comando);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
           oNoticiaJson = new noticiaJSON();
           oNoticiaJson.id = i.ToString();
           if(dt.Rows[i]["fecha"].ToString() != string.Empty)
               oNoticiaJson.startdate = Convert.ToDateTime(dt.Rows[i]["fecha"], new CultureInfo("es-ES")).ToString("yyyy-MM-dd hh:mm:ss");
           oNoticiaJson.description = Convert.ToString(dt.Rows[i]["Tipo"]);
           oNoticiaJson.title = Convert.ToString(dt.Rows[i]["Nombre"]);
           oNoticiaJson.link = Convert.ToString(dt.Rows[i]["Link"]);
        
           if (oNoticiaJson.description.CompareTo("Investigador") == 0)
           {
               oNoticiaJson.importance = "40";
               oNoticiaJson.icon = "Client-Female.png";
           }
           if (oNoticiaJson.description.CompareTo("Codirector") == 0)
           {
               oNoticiaJson.importance = "50";
               oNoticiaJson.icon = "Old-Boss.png";
           }
           if (oNoticiaJson.description.CompareTo("Becario") == 0)
           {
               oNoticiaJson.importance = "30";
               oNoticiaJson.icon = "Child-Female.png";
           }
           if (oNoticiaJson.description.CompareTo("Producto") == 0)
           {
               oNoticiaJson.importance = "30";
               oNoticiaJson.icon = "Product-documentation.png";
           }
           if (oNoticiaJson.description.CompareTo("Hito ") == 0)
           {
               oNoticiaJson.importance = "30";
               oNoticiaJson.icon = "Checked-Folder.png";
           }
           
           oNoticiaJson.date_display="days";
           lista.Add(oNoticiaJson);
        }
        serializar(lista, Proyecto.get(idProyecto),  path);
    }
    /// <summary>
    ///  Convierte los datos en JSON
    /// </summary>
    /// <param name="olista"></param>
    /// <param name="proyecto"></param>
    /// <param name="path"></param>
        public static void serializar(List<noticiaJSON> olista, Proyecto proyecto, string path)
        {
            string intro="[{\"id\":\""+proyecto.ID.ToString() + "\",";
            intro+="\"title\":\""+ proyecto.NOMBRECORTO+"\",";
            intro+="\"description\":\""+proyecto.RESUMEN+ "\",";
            intro+="\"focus_date\":\""+DateTime.Today.ToString("yyyy-MM-dd hh:mm:ss")+ "\",";
            intro+="\"timezone\":\"-07:00\",";
            intro+="\"initial_zoom\":\"40\",";
            intro += "\"events\":";
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
            new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(olista);
            guardarArchivo(sJSON,intro, path);
        }
    /// <summary>
    /// Guarda los datos en el directorio especificado
    /// </summary>
    /// <param name="json"></param>
    /// <param name="intro"></param>
    /// <param name="path"></param>
        public static void guardarArchivo(string json, string intro, string path )
        {

            	var jss = new JavaScriptSerializer();
                var dict = jss.Deserialize<dynamic>(json);



            try 
			{
				//Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(path + @"\Test.json");
                sw.WriteLine(intro);
				//Write a line of text
				sw.WriteLine(jss.Serialize(dict));
                sw.WriteLine("}]");
				sw.Close();
			}
			catch(Exception e)
			{
				
			}
			finally 
			{
				
			}
        }

        public static List<noticiaJSON> listarNoticiasTodosProyectos()
        {
            List<noticiaJSON> lista = new List<noticiaJSON>();
            noticiaJSON oNoticiaJson = new noticiaJSON();
            SqlCommand comando = new SqlCommand();
            //string oid, ostartdate, odescription, otitle;

            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "noticiasProyectosPublicas";
            DataTable dt = Conexion.consultar(comando);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                oNoticiaJson = new noticiaJSON();
                oNoticiaJson.id = i.ToString();
                if (dt.Rows[i]["fecha"].ToString() != string.Empty)
                    oNoticiaJson.startdate = Convert.ToDateTime(dt.Rows[i]["fecha"], new CultureInfo("es-ES")).ToString("yyyy-MM-dd hh:mm:ss");
                oNoticiaJson.description = Convert.ToString(dt.Rows[i]["Tipo"]);
                oNoticiaJson.title = Convert.ToString(dt.Rows[i]["Nombre"]);
                oNoticiaJson.link = Convert.ToString(dt.Rows[i]["Proyecto"]);
                lista.Add(oNoticiaJson);
            }
            return lista;
        }
 




    }

