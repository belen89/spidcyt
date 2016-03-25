using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public sealed partial class DAOActividadBecario
{
    public static void insertarHito(Hito hito)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarActividadBecario";

        comando.Parameters.Add(new SqlParameter("@idProyecto", hito.PROYECTO.ID));
        comando.Parameters.Add(new SqlParameter("@idBecario", hito.BECARIO.ID));
        comando.Parameters.Add(new SqlParameter("@nombre", hito.NOMBRE));
        comando.Parameters.Add(new SqlParameter("@descripcion", hito.DESCRIPCION));
        comando.Parameters.Add(new SqlParameter("@fechaEstimada", hito.FECHAESTIMADA));
        Conexion.ejecutarComando(comando);

    }
}
