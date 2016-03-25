using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


public sealed partial class DAOHistorialCategoria
{
    public static void insertarHistorialCategoria(HistorialCategoria historialCategoria, int idInvestigador)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarHistorialCategoria";

        comando.Parameters.Add(new SqlParameter("@categoriaInvestigador", historialCategoria.CATEGORIAINVESTIGADOR.ID));
        comando.Parameters.Add(new SqlParameter("@investigador", idInvestigador));
        comando.Parameters.Add(new SqlParameter("@fechaDesde", historialCategoria.FECHADESDE));
        comando.Parameters.Add(new SqlParameter("@fechaHasta", historialCategoria.FECHAHASTA));

        Conexion.ejecutarComando(comando);
        

    }
}