using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOTipoProducto
{
        public static TipoProducto get(int idTipoProducto)
        {
            SqlCommand comando = new SqlCommand();

            comando.Parameters.AddWithValue("@idTipoProducto", idTipoProducto);
            comando.CommandText = "SELECT * FROM TipoProducto WHERE idTipoProducto = @idTipoProducto";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

    }
