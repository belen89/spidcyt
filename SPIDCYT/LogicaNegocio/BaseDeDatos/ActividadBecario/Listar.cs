using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

public sealed partial class DAOActividadBecario
{
    public static Hito get(int idHito)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@idHitos", idHito);
        comando.CommandText = "SELECT * FROM Hitos WHERE idHitos = @idHitos";
        
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);
        
        if (tabla.Rows.Count == 0) { return null; }
        return Transformar(tabla.Rows[0]);
    
    }

    public static List<DateTime> listarActualizacionFechas(int idHito)
    {
        SqlCommand comando = new SqlCommand();
        List<DateTime> lista= new List<DateTime>();
        comando.Parameters.AddWithValue("@idHito", idHito);
        comando.CommandText="Select fechaEstimadaActual FROM ActualizacionFechaHitos WHERE idHito=@idHito";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            lista.Add(Convert.ToDateTime(tabla.Rows[i][0], new CultureInfo("es-ES")));
        }
        return lista;
    }

    public static List<Hito> listarActividadesPorBecario(int idBecario)
    {
        SqlCommand comando = new SqlCommand();
        List<Hito> listaActividades = new List<Hito>();
        comando.Parameters.AddWithValue("@idBecario", idBecario);
        comando.CommandText = "SELECT * FROM Hitos WHERE idBecario = @idBecario";

        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            listaActividades.Add(Transformar(tabla.Rows[i]));
        }
        return listaActividades;

    }

    public static List<Hito> listarActividadesPorBecarioPorProyecto(int idBecario, int idProyecto)
    {
        SqlCommand comando = new SqlCommand();
        List<Hito> listaActividades = new List<Hito>();
        comando.Parameters.AddWithValue("@idBecario", idBecario);
        comando.Parameters.AddWithValue("@idProyecto", idProyecto);
        comando.CommandText = "SELECT * FROM Hitos WHERE idBecario = @idBecario and idProyecto=@idProyecto";

        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            listaActividades.Add(Transformar(tabla.Rows[0]));
        }
        return listaActividades;

    }

    /*********************validador de rango de fecha para actividad ***********************/

    public static bool validarRangoDeFecha(DateTime fechaActvidad, int idProyecto, int idBecario)
    {
        SqlCommand comando = new SqlCommand();
        
        comando.Parameters.AddWithValue("@idBecario", idBecario);
        comando.Parameters.AddWithValue("@idProyecto", idProyecto);
        comando.Parameters.AddWithValue("@fechaActividad", fechaActvidad);
        comando.CommandText = "SELECT * FROM BecarioPorProyecto WHERE idBecario=@idBecario and ";
        comando.CommandText += "idProyecto=@idProyecto and fechaInicio < @fechaActividad and ";
        comando.CommandText += "(fechaFin > @fechaActividad or fechaFin IS NULL)";
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0)
            return false; //no hay rango válido de fecha
        else
            return true; // hay rango válido de fecha

 
    }


}
