using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa una palabra que es tendencia en los Proyectos
/// </summary>
public class Tendencia
{
    private double weigth;
    private string text;
    private int count;
    private string link;
    private string color;

    public string COLOR
    {
        get { return color; }
        set { color = value; }
    }

    public double WEIGTH
    {
        get { return weigth; }
        set { weigth = value; }
    }


    public int COUNT
    {
        get { return count; }
        set { count = value; }
    }

    public string TEXT
    {
        get { return text; }
        set { text = value; }
    }

    public string LINK
    {
        get { return link; }
        set { link = value; }
    }
    /// <summary>
    /// Crea lista de tags para los proyectos de un determinado año
    /// </summary>
    /// <param name="año">Año para el cual se crea la lista</param>
    /// <returns>Lista de Tags que son tendencia en el año pasado por parámetro</returns>
    public static List<Tendencia> crearTendencia(int año)
    {
        List<string> lst = DAOTendencia.armarPalabras(año);
        return armarTags(lst);
    }

    public static List<Tendencia> crearTendencia()
    {
        List<string> lst = DAOTendencia.armarPalabras();
        return armarTags(lst);

    }

    public static int tendenciaDePalabra(int año, string palabra)
    {
        List<string> lst = DAOTendencia.armarPalabras(año);
        return armarTags(lst, palabra);

    }

    private static int armarTags(List<string> lst, string palabra)
    {
        if (lst != null)
        {
            int contador = 0;
            var tags = (from l in lst
                        group l by l into g
                        select new { Name = g.Key, Count = g.Count() });
            tags = (from t in tags
                    where t.Name == palabra
                    select t);
            foreach (var tag in tags)
            {
                contador = tag.Count;
            }
            return contador;
        }
        return 0; 

    }

    private static List<Tendencia> armarTags(List<string> lst)
    {
        if (lst != null)
        {
            List<Tendencia> listaTags = new List<Tendencia>();
            Tendencia unTag;
            var tags = (from l in lst
                        group l by l into g
                        select new { Name = g.Key, Count = g.Count() });
            tags = (from t in tags
                    where t.Count != 1
                    select t);
            tags = (from t in tags
                    orderby t.Name descending
                    select t);


            //Minimum Size for Tags, you can set it as per your need
            double minSize = 10;

            //Maximum Size for Tags, you can set it as per your need
            double maxSize = 60;

            //Calculating the step in which increament the fonts
            double steps = (maxSize - minSize) / (double)(tags.Count() / 1.5);

            StringBuilder sb = new StringBuilder();
            foreach (var tag in tags)
            {
                //Calculating the Size
                double size = minSize + ((double)tag.Count - 1) * steps;
                unTag = new Tendencia();
                unTag.weigth = size;
                unTag.text = tag.Name;
                unTag.count = tag.Count;
                unTag.color = dameColor(size);

                listaTags.Add(unTag);

            }

            return listaTags;
        }
        return null;
    }

    private static string dameColor(double size)
    {

        if (size >= 15 && size < 25)
            return "#58ACFA";
        if (size >= 25 && size < 35)
            return "#0174DF";
        if (size >= 35 && size < 45)
            return "#0B2161";
        if (size >= 45 && size <= 60)
            return "#0A0A2A";
        else
            return "#58FAAC";
    }


}
