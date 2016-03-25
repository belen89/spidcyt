using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public sealed partial class DAOPronostico
    {

    private static Pronostico Transformar(DataTable tabla)
    {
        Pronostico pronostico = new Pronostico();
        List<double> cantidades = new List<double>();
        List<string> referencias = new List<string>();
        for (int i = 0; i < tabla.Rows.Count; i++)
            cantidades.Add(Convert.ToDouble(tabla.Rows[i][1]));
        for (int i = 0; i < tabla.Rows.Count; i++)
            referencias.Add(Convert.ToString(tabla.Rows[i][0]));
        pronostico.CANTIDADES = cantidades;
        pronostico.REFERENCIA = referencias;
        return pronostico;    
    }

    }
