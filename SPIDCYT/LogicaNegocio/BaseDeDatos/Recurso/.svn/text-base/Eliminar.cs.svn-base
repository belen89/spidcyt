using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAORecurso
{
    public static void darDeBajaRecurso(Recurso recurso)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "darDeBajaRecurso";

        comando.Parameters.Add(new SqlParameter("@idRecurso", recurso.ID));
        comando.Parameters.Add(new SqlParameter("@fechaBaja", recurso.FECHABAJA));
        comando.Parameters.Add(new SqlParameter("@idEstadoActual", recurso.ESTADOACTUAL.ID));
        Conexion.ejecutarComando(comando);


    }
}