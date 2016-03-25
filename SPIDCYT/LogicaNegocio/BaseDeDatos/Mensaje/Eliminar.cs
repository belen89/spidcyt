using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOMensaje
{

    public static void eliminarMensaje(string descripcion, int idTablero)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "eliminarMensaje";
        comando.Parameters.Add(new SqlParameter("@idTablero", idTablero));
        comando.Parameters.Add(new SqlParameter("@descripcion", descripcion));
        Conexion.ejecutarComando(comando);
    }

    public static void expirarMensajes(int idTablero)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "expirarMensajes";
        comando.Parameters.Add(new SqlParameter("@idTablero", idTablero));
        Conexion.ejecutarComando(comando);
    }


}