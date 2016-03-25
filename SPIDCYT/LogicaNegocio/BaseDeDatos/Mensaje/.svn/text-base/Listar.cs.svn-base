using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOMensaje
{

    public static Mensaje get(int idMensaje)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@idMensaje", idMensaje);
        comando.CommandText = "SELECT * FROM Mensaje WHERE idMensaje = @idMensaje";
        
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);
        
        if (tabla.Rows.Count == 0) { return null; }
        return Transformar(tabla.Rows[0]);
    
    }



    public static List<Mensaje> listarMensajesDeProyecto(int idProyecto)
    {
        List<Mensaje> mensajes = new List<Mensaje>();
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@idProyecto", idProyecto);
        comando.CommandText = "SELECT m.* FROM Tablero t, Mensaje m WHERE t.idProyecto = @idProyecto and m.idTablero=t.idTablero";

        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            mensajes.Add(Transformar(tabla.Rows[i]));
        }
        return mensajes;

    }
}
