using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAORecurso
{
    public static void insertarRecurso(Recurso recurso)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarRecurso";

        comando.Parameters.Add(new SqlParameter("@nombre", recurso.NOMBRE));
        comando.Parameters.Add(new SqlParameter("@tipo", recurso.TIPO));
        comando.Parameters.Add(new SqlParameter("@descripcion", recurso.DESCRIPCION));
        comando.Parameters.Add(new SqlParameter("@fechaAlta", recurso.FECHAALTA));
        comando.Parameters.Add(new SqlParameter("@estadoActual", recurso.ESTADOACTUAL.ID));
        Conexion.ejecutarComando(comando);


    }
}
