using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOMarcadorJSON
{

    public static void eliminarMarcadorCongreso( int idCongreso)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "eliminarCongreso";
        comando.Parameters.Add(new SqlParameter("@idCongreso", idCongreso));

        Conexion.ejecutarComando(comando);
    }



}