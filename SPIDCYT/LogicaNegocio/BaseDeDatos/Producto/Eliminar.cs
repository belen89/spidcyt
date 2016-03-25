using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOProducto
{
    public static void eliminarProducto(int idProducto)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "borrarProducto";
        comando.Parameters.Add(new SqlParameter("@idProducto", idProducto));
        Conexion.ejecutarComando(comando);


    }
}