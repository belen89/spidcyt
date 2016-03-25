using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOEstadoRecurso
{
    public static IEstadoRecurso get(int idEstadoRecurso)
    {
            SqlCommand comando = new SqlCommand();
            
            comando.Parameters.AddWithValue("@idEstadoRecurso", idEstadoRecurso);
            comando.CommandText = "SELECT * FROM EstadoRecurso WHERE idEstadoRecurso = @idEstadoRecurso";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

        public static IEstadoRecurso get(string nombre)
        {
            SqlCommand comando = new SqlCommand();

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.CommandText = "SELECT * FROM EstadoRecurso WHERE nombre = @nombre";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }


           
    }
