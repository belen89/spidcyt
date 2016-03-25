using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOHistorialDeRecurso
{

    public static HistorialDeRecurso get(int idHistorialDeRecurso)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@idHistorialDeRecurso", idHistorialDeRecurso);
        comando.CommandText = "SELECT * FROM HistorialRecurso WHERE idHistorialDeRecurso = @idHistorialDeRecurso";
        
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);
        
        if (tabla.Rows.Count == 0) { return null; }
        return Transformar(tabla.Rows[0]);
    
    }

    public static List<HistorialDeRecurso> listarHistorialDeRecurso(int idRecurso)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@idRecurso", idRecurso);
        comando.CommandText = "SELECT * FROM HistorialRecurso WHERE idRecurso = @idRecurso";

        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        List<HistorialDeRecurso> historial = new List<HistorialDeRecurso>();
        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            historial.Add(Transformar(tabla.Rows[i]));
        }
        return historial;

    }

    public static HistorialDeRecurso ultimoProyectoDeRecurso(int idRecurso, int idProyecto)
    {
        SqlCommand comando = new SqlCommand();
        comando.Parameters.AddWithValue("@idRecurso", idRecurso);
        comando.Parameters.AddWithValue("@idProyecto", idProyecto);
        comando.CommandText = "SELECT * FROM HistorialRecurso WHERE idRecurso = @idRecurso and idProyecto=@idProyecto and fechaHasta IS NULL";

        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);
        if (tabla.Rows.Count == 0) { return null; }
        return Transformar(tabla.Rows[0]);
 
    }
}
