using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOProyectoCategorizado
{
    public static void insertarProyectoCategorizado(ProyectoCategorizado proyectoCategorizado, int idProyecto)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarProyectoCategorizado";
        comando.Parameters.Add(new SqlParameter("@numeroResolucion", proyectoCategorizado.NUMEROREFERENCIA));
        comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
        comando.Parameters.Add(new SqlParameter("@idTipoProyecto", proyectoCategorizado.TIPOPROYECTO.ID));
        Conexion.ejecutarComando(comando);
    }


}
