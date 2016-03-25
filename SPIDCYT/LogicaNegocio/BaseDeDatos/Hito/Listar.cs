using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

public sealed partial class DAOHito
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
        List<DateTime> lista = new List<DateTime>();
        comando.Parameters.AddWithValue("@idHito", idHito);
        comando.CommandText = "Select fechaEstimadaActual FROM ActualizacionFechaHitos WHERE idHito=@idHito";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            lista.Add(Convert.ToDateTime(tabla.Rows[i][0], new CultureInfo("es-ES")));
        }
        return lista;
    }
}
