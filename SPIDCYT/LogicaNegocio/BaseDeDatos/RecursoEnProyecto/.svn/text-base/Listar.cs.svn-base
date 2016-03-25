using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;



public sealed partial class DAORecursoEnProyecto
    {
    public static RecursoEnProyecto get(int idRecursoEnProyecto)
        {
            SqlCommand comando = new SqlCommand();
            Recurso recurso = new Recurso();

            comando.Parameters.AddWithValue("@idRecursoEnProyecto", idRecursoEnProyecto);
            comando.CommandText = "SELECT * FROM RecursoEnProyecto WHERE idRecursoEnProyecto = @idRecursoEnProyecto";

            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);

        }

    public static List<RecursoEnProyecto> listarRecursosActualesEnProyecto(int idProyecto)
    {
        SqlCommand comando = new SqlCommand();
    
        List<RecursoEnProyecto> recursos= new List<RecursoEnProyecto>();
        comando.Parameters.AddWithValue("@idProyecto", idProyecto);
        comando.CommandText = "SELECT * FROM RecursoEnProyecto WHERE idProyecto = @idProyecto and fechaHastaReal IS NULL ";

        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            recursos.Add(Transformar(tabla.Rows[i]));
        }
        return recursos;

    }

    public static int obtenerIdDeMiProyecto(int idRecursoEnProyecto)
    {
        SqlCommand comando = new SqlCommand();
        comando.Parameters.AddWithValue("@idRecursoEnProyecto", idRecursoEnProyecto);
        comando.CommandText = "SELECT idProyecto FROM RecursoEnProyecto WHERE idRecursoEnProyecto = @idRecursoEnProyecto";

        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);
        if (tabla.Rows.Count == 0) { return 0; }
          return  Convert.ToInt32(tabla.Rows[0][0]);
    }

    public static List<RecursoEnProyecto> listarTodos()
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandText = "SELECT * FROM RecursoEnProyecto ";
        List<RecursoEnProyecto> recursosEnProyecto = new List<RecursoEnProyecto>();
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            recursosEnProyecto.Add( Transformar(tabla.Rows[i]));
        }
        return recursosEnProyecto;
    }
}

