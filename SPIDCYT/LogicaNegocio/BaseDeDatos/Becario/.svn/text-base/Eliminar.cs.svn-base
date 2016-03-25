using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOBecario
{
    private static void darDeBajaViejoProyectoABecario(Becario becario, List<Proyecto> proyectosBecarioTotal)
    {
            List<Proyecto> proyectosAntiguos = listarProyectosActualesComoBecario(becario.ID);
            foreach (Proyecto proyectoViejo in proyectosAntiguos)
            {
                if (!proyectosBecarioTotal.Contains(proyectoViejo))
                {
                    DAOProyecto.darDeBajaBecarioPorProyecto(proyectoViejo.ID, becario.ID, DateTime.Today);
                }
            }
      }

    public static void darDeBajaBecario(Becario becario)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "actualizarBecario ";
        comando.Parameters.Add(new SqlParameter("@idBecario", becario.ID));
        comando.Parameters.Add(new SqlParameter("@legajo", becario.LEGAJO));
        comando.Parameters.Add(new SqlParameter("@nombre", becario.NOMBRE));
        comando.Parameters.Add(new SqlParameter("@apellido", becario.APELLIDO));
        comando.Parameters.Add(new SqlParameter("@mail", becario.MAIL));
        comando.Parameters.Add(new SqlParameter("@telefono", becario.TELEFONO));
        comando.Parameters.Add(new SqlParameter("@tipoBecario", becario.TIPOBECARIO.ID));
        comando.Parameters.Add(new SqlParameter("@fechaBaja", becario.FECHABAJA));
        Conexion.ejecutarComando(comando);
    }

}
