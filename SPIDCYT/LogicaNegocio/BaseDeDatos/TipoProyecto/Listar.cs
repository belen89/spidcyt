using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOTipoProyecto
    {
        public static TipoProyecto get(int idTipoProyecto)
        {
            SqlCommand comando = new SqlCommand();
            
            comando.Parameters.AddWithValue("@idTipoProyecto", idTipoProyecto);
            comando.CommandText = "SELECT * FROM TipoProyecto WHERE idTipoProyecto = @idTipoProyecto";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

        public static TipoProyecto get(string nombre)
        {
            SqlCommand comando = new SqlCommand();

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.CommandText = "SELECT * FROM TipoProyecto WHERE nombre = @nombre";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

        public static TipoProyecto obtenerConIncentivo()
        {
            return get("Con Incentivo");
        }

        public static TipoProyecto obtenerUTN()
        {
            return get("UTN");
        }

    }
