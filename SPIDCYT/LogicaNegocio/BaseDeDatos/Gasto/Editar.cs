using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOGasto
{

    public static void cambiarEstado(int idViatico, string estado)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "actualizarEstadoViatico";

        comando.Parameters.Add(new SqlParameter("@idViatico", idViatico));
        comando.Parameters.Add(new SqlParameter("@estado", estado));
        Conexion.ejecutarComando(comando);
    }

    
}