using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOHistorialDeRecurso
{
    public static void terminarHistorialDeRecurso(HistorialDeRecurso historialDeRecurso)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "terminarHistorialDeRecurso";
        comando.Parameters.Add(new SqlParameter("@idHistorialRecurso", historialDeRecurso.ID));
        comando.Parameters.Add(new SqlParameter("@fechaHasta", historialDeRecurso.FECHAHASTA));

        Conexion.ejecutarComando(comando);


    }
}