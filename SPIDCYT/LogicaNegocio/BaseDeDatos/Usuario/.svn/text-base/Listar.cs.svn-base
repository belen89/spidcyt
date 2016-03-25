using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOUsuario
{
    public static string obtenerRutaImagen(string usuario)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@usuario", usuario);
        comando.CommandText = "SELECT foto FROM Persona p, aspnet_Users u WHERE u.UserName = @usuario and u.UserId=p.usuario ";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        return tabla.Rows[0][0].ToString();
    }

    public static string obtenerRutaCurriculum(string usuario)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@usuario", usuario);
        comando.CommandText = "SELECT curriculum FROM Persona p, aspnet_Users u WHERE u.UserName = @usuario and u.UserId=p.usuario ";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        return tabla.Rows[0][0].ToString();
    }

    public static int getIDPersona(string nombreUsuario)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
        comando.CommandText = "SELECT idPersona FROM Persona p, aspnet_Users u WHERE u.UserName = @nombreUsuario and u.UserId=p.usuario ";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return -1; }
        return Convert.ToInt32(tabla.Rows[0][0].ToString());
    }
    public static bool esInvestigador(string nombreUsuario)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@idPersona", getIDPersona(nombreUsuario));
        comando.CommandText = "SELECT idInvestigador FROM Investigador i WHERE idInvestigador = @idPersona ";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return false; }
        return true;
    }
}
