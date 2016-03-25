using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAORequerimientosBecario
    {
    public static RequerimientosBecario get(int idRequerimientosBecario)
        {
            SqlCommand comando = new SqlCommand();

            comando.Parameters.AddWithValue("@idRequerimientosBecario", idRequerimientosBecario);
            comando.CommandText = "SELECT * FROM RequerimientosBecario WHERE idRequerimientosBecario = @idRequerimientosBecario";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

    

    }
