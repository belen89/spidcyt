﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOActividadBecario
{

    public static void modificarHito(Hito hito)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "actualizarActividadBecario";

        comando.Parameters.Add(new SqlParameter("@idHito", hito.ID));
        comando.Parameters.Add(new SqlParameter("@nombre", hito.NOMBRE));
        comando.Parameters.Add(new SqlParameter("@descripcion", hito.DESCRIPCION));
        comando.Parameters.Add(new SqlParameter("@fechaEstimada", hito.FECHAESTIMADA));
        Conexion.ejecutarComando(comando);

    }
}