using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public sealed partial class DAOHito
{
    public static void insertarHito(Hito hito, int idProyecto)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarHito";

        comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
        comando.Parameters.Add(new SqlParameter("@nombre", hito.NOMBRE));
        comando.Parameters.Add(new SqlParameter("@descripcion", hito.DESCRIPCION));
        comando.Parameters.Add(new SqlParameter("@fechaEstimada", hito.FECHAESTIMADA));
        Conexion.ejecutarComando(comando);

    }
}
