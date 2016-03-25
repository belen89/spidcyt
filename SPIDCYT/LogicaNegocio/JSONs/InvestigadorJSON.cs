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
/// Permite convertir los datos de los investigadores en una timeline
/// </summary>
public class InvestigadorJSON
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
    /// Arma el time line
    /// </summary>
    /// <param name="idInvestigador">Investigador que desea timeline</param>
    /// <param name="path"> Dirección para guardar el JSON</param>
    public static void noticias(int idInvestigador, string path)
    {
        List<InvestigadorJSON> lista = new List<InvestigadorJSON>();
        InvestigadorJSON oNoticiaJson = new InvestigadorJSON();
        SqlCommand comando = new SqlCommand();
        //string oid, ostartdate, odescription, otitle;
        bool flag = false;
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "TimelineInvestigador ";
        comando.Parameters.Add(new SqlParameter("@idInvestigador", idInvestigador));
        DataTable dt = Conexion.consultar(comando);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            flag = false;
            oNoticiaJson = new InvestigadorJSON();
           oNoticiaJson.id = i.ToString();
           if(dt.Rows[i]["Desde"].ToString() != string.Empty)
               oNoticiaJson.startdate = Convert.ToDateTime(dt.Rows[i]["Desde"], new CultureInfo("es-ES")).ToString("yyyy-MM-dd hh:mm:ss");
           if (dt.Rows[i]["Hasta"].ToString() != string.Empty)
               oNoticiaJson.enddate = Convert.ToDateTime(dt.Rows[i]["Hasta"], new CultureInfo("es-ES")).ToString("yyyy-MM-dd hh:mm:ss");
           oNoticiaJson.description = Convert.ToString(dt.Rows[i]["tipo"]);
           oNoticiaJson.title = Convert.ToString(dt.Rows[i]["nombre"]);
           oNoticiaJson.link = Convert.ToString(dt.Rows[i]["link"]);
        
           if (oNoticiaJson.description.CompareTo("Investigador en Proyecto") == 0)
           {
               oNoticiaJson.importance = "40";
               oNoticiaJson.icon = "Client-Female.png";
               flag = true;
           }
           if (oNoticiaJson.description.CompareTo("Codirector en Proyecto") == 0)
           {
               oNoticiaJson.importance = "50";
               oNoticiaJson.icon = "Old-Boss.png";
               flag = true;
           }
           if (oNoticiaJson.description.CompareTo("Becario en Proyecto") == 0)
           {
               oNoticiaJson.importance = "30";
               oNoticiaJson.icon = "Child-Female.png";
               flag = true;
           }
           if (oNoticiaJson.description.CompareTo("Director en Proyecto") == 0)
           {
               oNoticiaJson.importance = "50";
               oNoticiaJson.icon = "Old-Boss.png";
               flag = true;
           }
           if (oNoticiaJson.description.CompareTo("Nueva categorización") == 0)
           {
               oNoticiaJson.importance = "30";
               oNoticiaJson.icon = "Academic-Hat.png";
               flag = true;
           }
           if (!flag)
           {
               oNoticiaJson.importance = "30";
               oNoticiaJson.icon = "Product-documentation.png";   
           }
           
           oNoticiaJson.date_display="days";
           lista.Add(oNoticiaJson);
        }

        if(Becario.getBecario(idInvestigador)!=null)
            serializar(lista, Becario.getBecario(idInvestigador),  path);
        else
            serializar(lista, Investigador.getInvestigador(idInvestigador), path);
    }
/// <summary>
/// Convierte los datos en JSON
/// </summary>
/// <param name="olista"></param>
/// <param name="investigador"></param>
/// <param name="path"></param>
    public static void serializar(List<InvestigadorJSON> olista, Persona investigador, string path)
        {
            string intro="[{\"id\":\""+investigador.ID.ToString() + "\",";
            intro+="\"title\":\""+ investigador.APELLIDO +" "+ investigador.NOMBRE+"\",";
            intro+="\"description\":\""+investigador.MAIL+ "\",";
            intro+="\"focus_date\":\""+DateTime.Today.ToString("yyyy-MM-dd hh:mm:ss")+ "\",";
            intro+="\"timezone\":\"-07:00\",";
            intro+="\"initial_zoom\":\"25\",";
            intro += "\"events\":";
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
            new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(olista);
            guardarArchivo(sJSON,intro, path);
        }
    /// <summary>
    /// Guarda el archivo en el directorio especificado
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
                StreamWriter sw = new StreamWriter(path + @"\timelineInvestigador.json");
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

 




    }