using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;



public sealed partial class DAORecurso
    {
        public static Recurso get(int idRecurso)
        {
            SqlCommand comando = new SqlCommand();
            Recurso recurso = new Recurso();

            comando.Parameters.AddWithValue("@idRecurso", idRecurso);
            comando.CommandText = "SELECT * FROM Recurso WHERE idRecurso = @idRecurso";

            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);

        }

        public static List<Recurso> listarTodos()
        {
            SqlCommand comando = new SqlCommand();
            List<Recurso> recursos = new List<Recurso>();

             comando.CommandText = "SELECT * FROM Recurso ";

            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                recursos.Add(Transformar(tabla.Rows[i]));
            }
            return recursos;

        }

        public static List<Recurso> listarTodos(IEstadoRecurso estado)
        {
            SqlCommand comando = new SqlCommand();
            List<Recurso> recursos = new List<Recurso>();

            comando.Parameters.AddWithValue("@estadoActual", estado.ID);
            comando.CommandText = "SELECT * FROM Recurso WHERE estadoActual=@estadoActual";

            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                recursos.Add(Transformar(tabla.Rows[i]));
            }
            return recursos;

        }

        public static Proyecto miProyectoActual(int idRecurso)
        {
            SqlCommand comando = new SqlCommand();
            Recurso recurso = new Recurso();

            comando.Parameters.AddWithValue("@idRecurso", idRecurso);
            comando.CommandText = "SELECT rp.idProyecto FROM Recurso r, RecursoEnProyecto rp WHERE r.idRecurso = @idRecurso and r.idRecurso=rp.idRecurso and rp.fechaHastaReal IS NOT NULL";

            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return DAOProyecto.get(Convert.ToInt32(tabla.Rows[0][0]));

        }

    
    }

