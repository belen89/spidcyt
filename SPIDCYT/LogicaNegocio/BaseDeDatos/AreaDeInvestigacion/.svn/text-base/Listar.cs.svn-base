using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class DAOAreaDeInvestigacion
    {

    public static AreaDeInvestigacion get(int idAreaDeInvestigacion)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@idAreaDeInvestigacion", idAreaDeInvestigacion);
        comando.CommandText = "SELECT * FROM AreaDeInvestigacion WHERE idAreaDeInvestigacion = @idAreaDeInvestigacion";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        return Transformar(tabla.Rows[0]);
    
    }
    }
