using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

public sealed partial class DAOInvestigador
{
    public static void insertarInvestigador(Investigador investigador, List<Proyecto> proyectosCodirector, List<Proyecto> proyectoInvestigador)
    {
        using (TransactionScope tran = new TransactionScope())
        {
            try
            {
                int idInvestigador = insertarInvestigador(investigador);
                foreach (Proyecto proyecto in proyectoInvestigador)
                    DAOProyecto.insertarInvestigadorAProyecto(proyecto.ID, idInvestigador, investigador.FECHAALTA);
                foreach (Proyecto proyecto in proyectosCodirector)
                    DAOProyecto.insertarCodirectorAProyecto(proyecto.ID, idInvestigador, investigador.FECHAALTA);
                tran.Complete();
            }
            catch (Exception) { tran.Dispose(); }
        }
    }
    public static int insertarInvestigador(Investigador investigador )
    {

        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarInvestigador";
        comando.Parameters.Add(new SqlParameter("@legajo", investigador.LEGAJO));
        comando.Parameters.Add(new SqlParameter("@nombre", investigador.NOMBRE));
        comando.Parameters.Add(new SqlParameter("@apellido", investigador.APELLIDO));
        comando.Parameters.Add(new SqlParameter("@mail", investigador.MAIL));
        comando.Parameters.Add(new SqlParameter("@telefono",investigador.TELEFONO));
        comando.Parameters.Add(new SqlParameter("@fechaAlta", investigador.FECHAALTA));
        
        
        if (investigador.CATEGORIANACIONAL != null)
        {
            comando.Parameters.Add(new SqlParameter("@categoriaNacional", investigador.CATEGORIANACIONAL.ID));
            comando.Parameters.Add(new SqlParameter("@fechaCategorizacionNacional", investigador.FECHACATEGORIZACIONNACIONAL));
        }
        if (investigador.CATEGORIAUTN != null)
        {
            comando.Parameters.Add(new SqlParameter("@fechaCategorizacionUTN", investigador.FECHACATEGORIZACIONUTN));
            comando.Parameters.Add(new SqlParameter("@categoriaUTN", investigador.CATEGORIAUTN.ID));
        }
        Conexion.ejecutarComando(comando);

        comando.CommandType = CommandType.Text;
        comando.CommandText = "SELECT IDENT_CURRENT('Persona')";
        int idInvestigador =  int.Parse(Conexion.consultar(comando).Rows[0][0].ToString());

        //Insertar el Historial de Categoría ya que es responsabilidad del INVESTIGADORE
        foreach (HistorialCategoria item in investigador.HISTORIALCATEGORIA)
        {
            DAOHistorialCategoria.insertarHistorialCategoria(item, idInvestigador);
        }

        return idInvestigador;

    }

    public static void guardarInvestigador(Investigador investigador)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "actualizarInvestigador";
        comando.Parameters.Add(new SqlParameter("@idInvestigador", investigador.ID));
        comando.Parameters.Add(new SqlParameter("@legajo", investigador.LEGAJO));
        comando.Parameters.Add(new SqlParameter("@nombre", investigador.NOMBRE));
        comando.Parameters.Add(new SqlParameter("@apellido", investigador.APELLIDO));
        comando.Parameters.Add(new SqlParameter("@mail", investigador.MAIL));
        comando.Parameters.Add(new SqlParameter("@telefono", investigador.TELEFONO));

        if (investigador.CATEGORIANACIONAL != null)
        {
            comando.Parameters.Add(new SqlParameter("@categoriaNacional", investigador.CATEGORIANACIONAL.ID));
            comando.Parameters.Add(new SqlParameter("@fechaCategorizacionNacional", investigador.FECHACATEGORIZACIONNACIONAL));
        }
        if (investigador.CATEGORIAUTN != null)
        {
            comando.Parameters.Add(new SqlParameter("@fechaCategorizacionUTN", investigador.FECHACATEGORIZACIONUTN));
            comando.Parameters.Add(new SqlParameter("@categoriaUTN", investigador.CATEGORIAUTN.ID));
        }       
        Conexion.ejecutarComando(comando);        
    }

    //Se fija que proyectos nuevos se han agregado al investigador de acuerdo a los que tenia antes almacenados en la base de datos 
    private static void insertarNuevoProyectoComoCodirector(Investigador investigador, List<Proyecto> proyectosCodirector)
    {
        List<Proyecto> proyectosCodirectorAntiguos = listarProyectosActualesComoCodirector(investigador.ID);

        foreach (Proyecto proyectoNuevo in proyectosCodirector)
        {
            if (!proyectosCodirectorAntiguos.Contains(proyectoNuevo))
            {
                DAOProyecto.insertarCodirectorAProyecto(proyectoNuevo.ID, investigador.ID, DateTime.Today);
            }
        }
    }

    private static void insertarNuevoProyectoComoInvestiagdor(Investigador investigador, List<Proyecto> proyectosInvestigador)
    {
        List<Proyecto> proyectosInvestigadorAntiguos = listarProyectosActualesComoInvestigador(investigador.ID);
        foreach (Proyecto proyectoNuevo in proyectosInvestigador)
        {
            if (!proyectosInvestigadorAntiguos.Contains(proyectoNuevo))
            {
                DAOProyecto.insertarInvestigadorAProyecto(proyectoNuevo.ID, investigador.ID, DateTime.Today);
            }
        }
    }
}
