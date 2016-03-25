using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAORequerimientosBecario
{

    public static void eliminarRequerimientosBecario(int idRequerimientosBecario)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "eliminarRequerimientosBecario";
        comando.Parameters.Add(new SqlParameter("@idRequerimientoBecario", idRequerimientosBecario));
        Conexion.ejecutarComando(comando);
    }
}
