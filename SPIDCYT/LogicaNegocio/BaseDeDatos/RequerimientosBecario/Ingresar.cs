using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAORequerimientosBecario
{


    public static void insertarRequerimientosBecario(RequerimientosBecario requerimientosBecario)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarRequerimientosBecario";
        comando.Parameters.Add("@idProyecto", requerimientosBecario.PROYECTO.ID);
        comando.Parameters.Add("@descripcion", requerimientosBecario.DESCRIPCION);
        comando.Parameters.Add("@nombrePerfil", requerimientosBecario.NOMBREPERFIL);
        comando.Parameters.Add("@habilidadesTecnicas", requerimientosBecario.HABILIDADESTECNICAS);
        Conexion.ejecutarComando(comando);

    }
    
}
