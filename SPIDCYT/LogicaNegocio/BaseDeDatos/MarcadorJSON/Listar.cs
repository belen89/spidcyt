using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOMarcadorJSON
{

    public static MarcadorJSON get(int idCongreso)
    {
        SqlCommand comando = new SqlCommand();

        comando.Parameters.AddWithValue("@idCongreso", idCongreso);
        comando.CommandText = "SELECT * FROM Congreso WHERE idCongreso = @idCongreso";
        
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);
        
        if (tabla.Rows.Count == 0) { return null; }
        return Transformar(tabla.Rows[0]);
    
    }

    public static List<MarcadorJSON> listarCongresosDelAño()
    {
        List<MarcadorJSON> congresos = new List<MarcadorJSON>();
        SqlCommand comando = new SqlCommand();

        comando.CommandText = "SELECT * FROM Congreso WHERE year(fechaHasta)=year(getdate()) ";

        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);

        if (tabla.Rows.Count == 0) { return null; }
        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            congresos.Add(Transformar(tabla.Rows[i]));
        }
        return congresos;

    }

    public static int totalDeCongresosDelAño()
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandText = "Select count(idCongreso) FROM Congreso WHERE year(fechaHasta)=year(getdate()) ";
        comando.CommandType = CommandType.Text;
        DataTable tabla = Conexion.consultar(comando);
        return Convert.ToInt32(tabla.Rows[0][0]);
    }

}
