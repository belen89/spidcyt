using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOActividadBecario
{
    public static void finalizarHito(Hito hito)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "finalizarActividadBecario";
        comando.Parameters.Add(new SqlParameter("@idHito", hito.ID));
        comando.Parameters.Add(new SqlParameter("@nombre", hito.NOMBRE));
        comando.Parameters.Add(new SqlParameter("@descripcion", hito.DESCRIPCION));
        comando.Parameters.Add(new SqlParameter("@fechaFin", hito.FECHAFINREAL));
        Conexion.ejecutarComando(comando);


    }
    public static void borrarActividadBecario(int idHito)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "borrarActividadBecario";
        comando.Parameters.Add(new SqlParameter("@idHitos", idHito));
        Conexion.ejecutarComando(comando);


    }
}