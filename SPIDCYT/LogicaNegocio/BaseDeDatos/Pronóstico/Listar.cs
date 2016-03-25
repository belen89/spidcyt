using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOPronostico
{

    public static Pronostico getPronosticoProyectos()
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.Text;
        comando.CommandText = "SELECT * FROM ProyectosParaPronosticos";

        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }

        Pronostico pronostico = Transformar(tabla);
        return armarPronostico(pronostico);

    }
    public static Pronostico getPronosticoProyectosPorArea(int area)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.Add(new SqlParameter("@idArea", area));
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "ProyectosParaPronosticoPorArea";
        
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }

        Pronostico pronostico = Transformar(tabla);
        return armarPronostico(pronostico);

    }
    /// <summary>
    /// Método que completa los periodos con cantidad 0.
    /// </summary>
    /// <param name="pronostico">pronostico con datos de base de datos</param>
    /// <returns>Devuelve nulo si la información es insuficiente, y el pronostico completado con los años faltantes en caso de que lo sea</returns>
    private static Pronostico armarPronostico(Pronostico pronostico)
    {
        int actual = DateTime.Now.Year - 9;

        Pronostico nuevo = new Pronostico();
        List<string> referencias = new List<string>();
        List<double> cantidades = new List<double>();
        Dictionary<string, double> refCant = new Dictionary<string, double>();

        //devuelve null porque la informacion es insuficiente para armar un pronostico. 
        if (pronostico.CANTIDADES.Count < 3)
            return null;

        for (int i = 0; i < pronostico.REFERENCIA.Count; i++)
            refCant.Add(pronostico.REFERENCIA[i], pronostico.CANTIDADES[i]);

        for (int i = 0; i < 10; i++)
        {
            if (!refCant.ContainsKey(actual.ToString()))
                refCant.Add(actual.ToString(), 0);
            actual++;
        }

        var orderedValues = refCant
            .OrderBy(kv => kv.Key)
            .Select(kv => kv.Value);

        foreach (KeyValuePair<string, double> par in refCant.OrderBy(key => key.Key))
        {
            referencias.Add(par.Key);
            cantidades.Add(par.Value);
        }

        nuevo.CANTIDADES = cantidades;
        nuevo.REFERENCIA = referencias;
        return nuevo;
    }
}
