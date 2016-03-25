using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOProducto
{
    public static void modificarProducto(Producto producto)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "actualizarProducto";
        comando.Parameters.Add(new SqlParameter("@idProducto", producto.ID));
        comando.Parameters.Add(new SqlParameter("@tipo", producto.TIPO.ID));
        comando.Parameters.Add(new SqlParameter("@descripcion", producto.DESCRIPCION));
        comando.Parameters.Add(new SqlParameter("@titulo", producto.TITULO));
        comando.Parameters.Add(new SqlParameter("@archivo", producto.ARCHIVO));
        comando.Parameters.Add(new SqlParameter("@fechaPublicacion", producto.FECHAPUBLICACION));
        comando.Parameters.Add(new SqlParameter("@link", producto.LINK));    
        Conexion.ejecutarComando(comando);


        }
    }
