using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

public sealed partial class DAOInvestigador
{

    public static void darDeBajaInvestigador(Investigador investigador)
    {

        using (TransactionScope tran = new TransactionScope())
        {
            try
            {
                //El PROCEDIMIENTO ALMACENADO da de baja tambien a su aprticipacion los proyectos como Investigador y como Co-Director   
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "darDeBajaInvestigador";
                comando.Parameters.Add(new SqlParameter("@idInvestigador", investigador.ID));
                comando.Parameters.Add(new SqlParameter("@legajo", investigador.LEGAJO));
                comando.Parameters.Add(new SqlParameter("@nombre", investigador.NOMBRE));
                comando.Parameters.Add(new SqlParameter("@apellido", investigador.APELLIDO));
                comando.Parameters.Add(new SqlParameter("@mail", investigador.MAIL));
                comando.Parameters.Add(new SqlParameter("@telefono", investigador.TELEFONO));
                comando.Parameters.Add(new SqlParameter("@fechaBaja", investigador.FECHABAJA));
                Conexion.ejecutarComando(comando);

                tran.Complete();
            }
            catch (Exception)
            {
                tran.Dispose();
                throw;
            }
        }
        
        
    }

    //Se fija que proyectos viejos se han eliminado de la lista nueva que trae el investigador de acuerdo a los que tenia antes almacenados en la base de datos 
    private static void darDeBajaViejoProyectoComoCodirector(Investigador investigador, List<Proyecto> proyectosCodirectorTotal)
    {
        List<Proyecto> proyectosCodirectorAntiguos = listarProyectosActualesComoCodirector(investigador.ID);

        foreach (Proyecto proyectoViejo in proyectosCodirectorAntiguos)
        {
            if (!proyectosCodirectorTotal.Contains(proyectoViejo))
            {
                DAOProyecto.darDeBajaCodirectorPorProyecto(proyectoViejo.ID, investigador.ID, DateTime.Today);
            }
        }
    }

    private static void darDeBajaViejoProyectoComoInvestiagdor(Investigador investigador, List<Proyecto> proyectosInvestigadorTotal)
    {
        List<Proyecto> proyectosInvestigadorAntiguos = listarProyectosActualesComoInvestigador(investigador.ID);

        foreach (Proyecto proyectoViejo in proyectosInvestigadorTotal)
        {
            if (!proyectosInvestigadorTotal.Contains(proyectoViejo))
            {
                DAOProyecto.darDeBajaInvestigadorPorProyecto(proyectoViejo.ID, investigador.ID, DateTime.Today);
            }
        }
    }
}
