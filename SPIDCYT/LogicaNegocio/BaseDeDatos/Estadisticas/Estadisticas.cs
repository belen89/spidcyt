using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


public class Estadisticas
{
    public static void proyectosPorAreaDeInvestigacion(out List<string> labels, out List<int> values, out float promedio)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "proyectosPorAreaDeInvestigacion";

        DataTable dt = Conexion.consultar(comando);
        labels = new List<string>();
        values = new List<int>();
        int proyectos=0;
        foreach (DataRow dr in dt.Rows)
        {
            labels.Add(Convert.ToString(dr[0]));
            values.Add(Convert.ToInt32(dr[1]));
            proyectos += Convert.ToInt32(dr[1]);
        }
        if (labels.Count != 0)
            promedio = proyectos / labels.Count;
        else
            promedio = 0;
    }

    public static void cantidadDeInvestigadoresPorProyectos(out List<string> labels, out List<int> values, out int promedio)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "cantidadDeInvestigadoresPorProyectos";

        DataTable dt = Conexion.consultar(comando);
        labels = new List<string>();
        values = new List<int>();
        int investigadores = 0;
        promedio = 0;
        foreach (DataRow dr in dt.Rows)
        {
            labels.Add(Convert.ToString(dr[0]));
            values.Add(Convert.ToInt32(dr[1]));
            investigadores += Convert.ToInt32(dr[1]);
        }
        if (labels.Count != 0)
            promedio = investigadores / labels.Count;
        else
            promedio = 0;
    }

    public static void proyectosPorAño(out List<string> labels, out List<int> values, out int promedio)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "proyectosPorAño";

        DataTable dt = Conexion.consultar(comando);
        labels = new List<string>();
        values = new List<int>();
        int proyectos = 0;
        promedio = 0;
        foreach (DataRow dr in dt.Rows)
        {
            labels.Add(Convert.ToString(dr[0]));
            values.Add(Convert.ToInt32(dr[1]));
            proyectos += Convert.ToInt32(dr[1]);
        }

        if (labels.Count != 0)
            promedio = proyectos / labels.Count;
        else
            promedio = 0;
    }
}

