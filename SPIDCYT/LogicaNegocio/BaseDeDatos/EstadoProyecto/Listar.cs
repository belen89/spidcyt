using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOEstadoProyecto
    {
        public static EstadoProyecto get(int idEstadoProyecto)
        {
            SqlCommand comando = new SqlCommand();
            
            comando.Parameters.AddWithValue("@idEstadoProyecto", idEstadoProyecto);
            comando.CommandText = "SELECT * FROM EstadoProyecto WHERE idEstadoProyecto = @idEstadoProyecto";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

        public static EstadoProyecto get(string nombre)
        {
            SqlCommand comando = new SqlCommand();

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.CommandText = "SELECT * FROM EstadoProyecto WHERE nombre = @nombre";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

        public static EstadoProyecto obtenerEstadoFinalizado()
        {
            return get("Finalizado");
        }

        public static EstadoProyecto obtenerEstadoCancelado()
        {
            return get("Cancelado");
        }
           
    }
