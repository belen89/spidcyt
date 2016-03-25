using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public sealed partial class DAOProducto
{
    public static int insertarProducto(Producto producto, int idProyecto)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarProducto";

        comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
        comando.Parameters.Add(new SqlParameter("@tipo", producto.TIPO.ID));
        comando.Parameters.Add(new SqlParameter("@titulo", producto.TITULO));
        comando.Parameters.Add(new SqlParameter("@descripcion", producto.DESCRIPCION));
        comando.Parameters.Add(new SqlParameter("@archivo", producto.ARCHIVO));
        comando.Parameters.Add(new SqlParameter("@fechaPublicacion", producto.FECHAPUBLICACION));
        comando.Parameters.Add(new SqlParameter("@link", producto.LINK));       
        return Conexion.ejecutarComandoDevolviendoID(comando);
        //TRAE ID DEL PRODUCTO CREADO
        //comando.CommandType = CommandType.Text;
        //comando.CommandText = "SELECT SCOPE_IDENTITY()";
        //DataTable table = Conexion.consultar(comando);        
        //return Convert.ToInt32(table.Rows[0][0].ToString());
    }
}
