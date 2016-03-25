using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOPresupuesto
{
    internal static Presupuesto get(int idPresupuesto)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@idPresupuesto", idPresupuesto);
        comando.CommandText = "SELECT * FROM Presupuesto WHERE idPresupuesto = @idPresupuesto";

        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        return Transformar(tabla.Rows[0]);
    }


    private static List<Gasto> listarGastosDePresupuesto(int idPresupuesto)
    {
        SqlCommand comando = new SqlCommand();
        List<Gasto> lista = new List<Gasto>();
        comando.Parameters.AddWithValue("@idPresupuesto", idPresupuesto);
        comando.CommandText = "Select * FROM Gasto WHERE idPresupuesto=@idPresupuesto";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            lista.Add(DAOGasto.Transformar(tabla.Rows[i]));
        }
        return lista;
    }
    
    //public static List<DateTime> listarActualizacionFechas(int idHito)
    //{
    //    SqlCommand comando = new SqlCommand();
    //    List<DateTime> lista = new List<DateTime>();
    //    comando.Parameters.AddWithValue("@idHito", idHito);
    //    comando.CommandText = "Select fechaEstimadaActual FROM ActualizacionFechaHitos WHERE idHito=@idHito";
    //    comando.CommandType = CommandType.Text;
    //    DataTable tabla = Conexion.consultar(comando);

    //    if (tabla.Rows.Count == 0) { return null; }
    //    for (int i = 0; i < tabla.Rows.Count; i++)
    //    {
    //        lista.Add(Convert.ToDateTime(tabla.Rows[i][0]));
    //    }
    //    return lista;
    //}
}
