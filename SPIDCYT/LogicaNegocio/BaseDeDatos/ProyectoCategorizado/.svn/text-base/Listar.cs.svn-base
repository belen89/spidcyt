using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOProyectoCategorizado
{

    public static List<ProyectoCategorizado> get(int idProyecto)
    {
        SqlCommand comando = new SqlCommand();
        Recurso recurso = new Recurso();
        List<ProyectoCategorizado> proyectoCategorizado = new List<ProyectoCategorizado>();
        
        comando.Parameters.AddWithValue("@idProyecto", idProyecto);
        comando.CommandText = "SELECT * FROM TipoProyectoPorProyecto WHERE idProyecto = @idProyecto";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);
        if (tabla.Rows.Count == 0) { return null; }
        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            proyectoCategorizado.Add(Transformar(tabla.Rows[i]));
        }

        return proyectoCategorizado;
    }

    public static ProyectoCategorizado get(int idProyecto, int tipoProyectoCategorizado)
    {
        SqlCommand comando = new SqlCommand();
        Recurso recurso = new Recurso();
        
        comando.Parameters.AddWithValue("@idProyecto", idProyecto);
        comando.Parameters.AddWithValue("@idTipoProyecto", tipoProyectoCategorizado);
        comando.CommandText = "SELECT * FROM TipoProyectoPorProyecto WHERE idProyecto = @idProyecto and idTipoProyecto=@idTipoProyecto";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);
        if (tabla.Rows.Count == 0) { return null; }

            return Transformar(tabla.Rows[0]);
    }
}