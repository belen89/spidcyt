using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOProducto
{

    public static Producto get(int idProducto)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@idProducto", idProducto);
        comando.CommandText = "SELECT * FROM Producto WHERE idProducto = @idProducto";
        
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);
        
        if (tabla.Rows.Count == 0) { return null; }
        return Transformar(tabla.Rows[0]);
    
    }
}
