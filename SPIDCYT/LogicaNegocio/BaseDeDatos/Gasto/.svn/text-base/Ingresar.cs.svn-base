using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public sealed partial class DAOGasto
{
    public static void insertarInsumo(Insumo insumo, int idPresupuesto)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarInsumo";

        comando.Parameters.Add(new SqlParameter("@idPresupuesto", idPresupuesto));
        comando.Parameters.Add(new SqlParameter("@monto", insumo.MONTO));
        comando.Parameters.Add(new SqlParameter("@fecha", insumo.FECHA));
        comando.Parameters.Add(new SqlParameter("@descripcion", insumo.DESCRIPCION));
        Conexion.ejecutarComando(comando);
    }

    public static void insertarViatico(Viatico viatico, int idPresupuesto)
    {
        SqlCommand comando = new SqlCommand();

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarViatico";

        comando.Parameters.Add(new SqlParameter("@idPresupuesto", idPresupuesto));
        comando.Parameters.Add(new SqlParameter("@monto", viatico.MONTO));
        comando.Parameters.Add(new SqlParameter("@fecha", viatico.FECHA));
        comando.Parameters.Add(new SqlParameter("@descripcion", viatico.DESCRIPCION));
        comando.Parameters.Add(new SqlParameter("@liquidante", viatico.LIQUIDANTE.ID));
        Conexion.ejecutarComando(comando);
    }

    
}
