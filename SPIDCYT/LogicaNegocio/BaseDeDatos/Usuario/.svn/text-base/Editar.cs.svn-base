using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public sealed partial class DAOUsuario
{
    public static void actualizarFoto(string foto, String usuario)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@usuario", usuario);
        comando.Parameters.AddWithValue("@foto", foto);
        comando.CommandText = "UPDATE  Persona SET foto=@foto WHERE mail = @usuario";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        
    }

    public static void actualizarCV(string curriculum, string usuario)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@usuario", usuario);
        comando.Parameters.AddWithValue("@curriculum", curriculum);
        comando.CommandText = "UPDATE  Persona SET curriculum=@curriculum WHERE mail = @usuario";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);


    }
}