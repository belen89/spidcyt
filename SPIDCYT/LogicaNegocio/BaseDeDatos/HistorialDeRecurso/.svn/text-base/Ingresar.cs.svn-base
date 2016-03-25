using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public sealed partial class DAOHistorialDeRecurso
{
    public static void insertarHistorialDeRecurso(HistorialDeRecurso historialDeRecurso, int idRecurso)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarHistorialDeRecurso";

        comando.Parameters.Add(new SqlParameter("@idRecurso", idRecurso));
        comando.Parameters.Add(new SqlParameter("@fechaDesde", historialDeRecurso.FECHADESDE));
        comando.Parameters.Add(new SqlParameter("@idProyecto", historialDeRecurso.PROYECTO.ID));

        Conexion.ejecutarComando(comando);


    }
}
