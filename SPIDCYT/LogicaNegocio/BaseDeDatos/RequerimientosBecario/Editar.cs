using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

public sealed partial class DAORequerimientosBecario
{
  

    public static void actualizarRequerimientosBecario(RequerimientosBecario requerimientosBecario)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "actualizarRequerimientosBecario";
        comando.Parameters.Add("@idRequerimientosBecario", requerimientosBecario.ID);
        comando.Parameters.Add("@descripcion", requerimientosBecario.DESCRIPCION);
        comando.Parameters.Add("@nombrePerfil", requerimientosBecario.NOMBREPERFIL);
        comando.Parameters.Add("@habilidadesTecnicas", requerimientosBecario.HABILIDADESTECNICAS);
        Conexion.ejecutarComando(comando);
  
    }
}