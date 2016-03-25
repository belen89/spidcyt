using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public sealed partial class DAOPresupuesto
{
    public static void insertarPresupuesto(Presupuesto presupuesto, int idProyecto)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarPresupuesto";

        comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
        comando.Parameters.Add(new SqlParameter("@monto", presupuesto.MONTO));
        comando.Parameters.Add(new SqlParameter("@fechaAsignacion", presupuesto.FECHAASIGNACION));
        comando.Parameters.Add(new SqlParameter("@fechaVencimiento", presupuesto.FECHAVENCIMIENTO));
        Conexion.ejecutarComando(comando);
    }


    
}
