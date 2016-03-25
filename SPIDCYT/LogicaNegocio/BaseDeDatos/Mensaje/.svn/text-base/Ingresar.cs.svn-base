using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public sealed partial class DAOMensaje
{
    public static void insertarMensaje(Mensaje mensaje)
    {
        SqlCommand comando = new SqlCommand();
        if (mensaje.DESCRIPCION != string.Empty)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarMensaje";

            comando.Parameters.Add(new SqlParameter("@idTablero", mensaje.TABLERO));
            comando.Parameters.Add(new SqlParameter("@descripcion", mensaje.DESCRIPCION));


            Conexion.ejecutarComando(comando);
        }

    }
}
