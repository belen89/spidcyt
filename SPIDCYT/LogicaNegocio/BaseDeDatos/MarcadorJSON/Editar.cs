using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

public sealed partial class DAOMarcadorJSON
{
    public static void modificarMarcadorCongreso(MarcadorJSON congreso)
    {

        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "modificarCongreso";

        comando.Parameters.Add(new SqlParameter("@idCongreso", congreso.ID));
        comando.Parameters.Add(new SqlParameter("@descripcion", congreso.DESCRIPCION));
        comando.Parameters.Add(new SqlParameter("@nombreLugar", congreso.NOMBRELUGAR));
        comando.Parameters.Add(new SqlParameter("@nombreCongreso", congreso.NOMBRECONGRESO));
        comando.Parameters.Add(new SqlParameter("@fechaDesde", Convert.ToDateTime(congreso.FECHADESDE, new CultureInfo("es-ES"))));
        comando.Parameters.Add(new SqlParameter("@fechaHasta", Convert.ToDateTime(congreso.FECHAHASTA, new CultureInfo("es-ES"))));
        comando.Parameters.Add(new SqlParameter("@lat", congreso.LAT));
        comando.Parameters.Add(new SqlParameter("@lng", congreso.LNG));
        comando.Parameters.Add(new SqlParameter("@link", congreso.LINK));
        Conexion.ejecutarComando(comando);
    }
}