using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOTipoBecario
    {
        public static TipoBecario get(int idTipoBecario)
        {
            SqlCommand comando = new SqlCommand();
            
            comando.Parameters.AddWithValue("@idTipoBecario", idTipoBecario);
            comando.CommandText = "SELECT * FROM TipoBecario WHERE idTipoBecario = @idTipoBecario";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

    }
