using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOTendencia
{
    public static string get()
    {
        SqlCommand comando = new SqlCommand();
        string texto = "";
        comando.CommandText = "listaNubeDeTags";

        comando.CommandType = CommandType.StoredProcedure;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }

        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            texto += Transformar(tabla.Rows[i]) + " ";
        }
        return texto;
    }

    public static string get(int año)
    {
        SqlCommand comando = new SqlCommand();
        string texto = "";
        comando.CommandText = "listaNubeDeTags";
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.AddWithValue("@año", año);
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }

        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            texto += Transformar(tabla.Rows[i]) + " ";
        }
        return texto;
    }

    public static List<string> armarPalabras()
    {
        string texto = get();
        return seleccionarPalabras(texto);
    }

    public static List<string> armarPalabras(int año)
    {
        string texto = get(año);
        return seleccionarPalabras(texto);
    }

    private static List<string> seleccionarPalabras(string texto)
    {
        List<string> listaPalabras = new List<string>();

        char[] caracteresDelimitadores = { ' ', ',', '.', ':', '\t' };
        string[] palabras = null; ;

        if (texto != null)
        {
            palabras = texto.Split(caracteresDelimitadores);


            //[] listaNegra = {"LA", "LAS", "CON", "EL", "DE", "EN", "CON", "COMO", "DEL", "SI", "NO", "ELLOS", "Y"};

            foreach (string s in palabras)
                if (s.ToUpper() != "Y" && s.ToUpper() != "CON" && s.ToUpper() != "DE" && s.ToUpper() != "EL" &&
                    s.ToUpper() != "LA" && s.ToUpper() != "LAS" && s.ToUpper() != "DEL" && s.ToUpper() != "COMO" && s.ToUpper() != "UN"
                    && s.ToUpper() != "SI" && s.ToUpper() != "NO" && s.ToUpper() != "ELLOS" && s.ToUpper() != "CUANDO" && s.ToUpper() != "LOS"
                    && s.ToUpper() != "EN" && s.ToUpper() != "A" && s.ToUpper() != "O" && s != string.Empty)
                    listaPalabras.Add(s);

            return listaPalabras;

        }
        return null; 
        
    }

}
