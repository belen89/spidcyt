using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

public sealed partial class DAOProyecto
{
    public static void darDeBajaProyecto(Proyecto proyecto)
    {
        //else procedimiento alamacenado da de baja la participacion de los integrantes 

        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "darDeBajaProyecto";
        comando.Parameters.Add(new SqlParameter("@idProyecto", proyecto.ID));
        comando.Parameters.Add(new SqlParameter("@nombreCorto", proyecto.NOMBRECORTO));
        comando.Parameters.Add(new SqlParameter("@nombreLargo", proyecto.NOMBRELARGO));
        comando.Parameters.Add(new SqlParameter("@estado", proyecto.ESTADOPROYECTO.ID));
        comando.Parameters.Add(new SqlParameter("@resumen", proyecto.RESUMEN));
        comando.Parameters.Add(new SqlParameter("@fechaFinEstimada", proyecto.FECHAFINESTIMADA));
        comando.Parameters.Add(new SqlParameter("@fechaFin", proyecto.FECHAFIN));
        comando.Parameters.Add(new SqlParameter("@comentarioDeFinalizacion", proyecto.COMENTARIODEFINALIZACION));
        Conexion.ejecutarComando(comando);
 
    }

    internal static void darDeBajaProyecto(Proyecto proyecto, DateTime fechaDeBaja)
    {
        using (TransactionScope tran = new TransactionScope())
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "darDeBajaProyecto";
                comando.Parameters.Add(new SqlParameter("@idProyecto", proyecto.ID));
                comando.Parameters.Add(new SqlParameter("@nombreCorto", proyecto.NOMBRECORTO));
                comando.Parameters.Add(new SqlParameter("@nombreLargo", proyecto.NOMBRELARGO));
                comando.Parameters.Add(new SqlParameter("@estado", proyecto.ESTADOPROYECTO.ID));
                comando.Parameters.Add(new SqlParameter("@resumen", proyecto.RESUMEN));
                comando.Parameters.Add(new SqlParameter("@fechaFinEstimada", proyecto.FECHAFINESTIMADA));
                comando.Parameters.Add(new SqlParameter("@fechaFin", fechaDeBaja));
                comando.Parameters.Add(new SqlParameter("@comentarioDeFinalizacion", proyecto.COMENTARIODEFINALIZACION));
                Conexion.ejecutarComando(comando);

                foreach (Investigador item in proyecto.INVESTIGADORES)
                {
                    darDeBajaInvestigadorPorProyecto(item.ID, proyecto.ID, fechaDeBaja);
                }

                foreach (Investigador item in proyecto.CODIRECTORES)
                {
                    darDeBajaCodirectorPorProyecto(item.ID, proyecto.ID, fechaDeBaja);
                }

                foreach (Becario item in proyecto.BECARIOS)
                {
                    darDeBajaBecarioPorProyecto(item.ID, proyecto.ID, fechaDeBaja);
                }

                tran.Complete();
            }
            catch (Exception)
            {
                tran.Dispose();
            }
        }
    }

    public static void darDeBajaInvestigadorPorProyecto(int idInvestigador, int idProyecto, DateTime fechaFin)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "darDeBajaInvestigadorPorProyecto";
        comando.Parameters.Add(new SqlParameter("@idInvestigador", idInvestigador));
        comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
        comando.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
        Conexion.ejecutarComando(comando);
 
    }
    public static void darDeBajaCodirectorPorProyecto(int idCodirector, int idProyecto, DateTime fechaFin)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "darDeBajaCodirectorPorProyecto";
        comando.Parameters.Add(new SqlParameter("@idInvestigador", idCodirector));
        comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
        comando.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
        Conexion.ejecutarComando(comando);

    }
    public static void darDeBajaBecarioPorProyecto(int idBecario, int idProyecto, DateTime fechaFin)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "darDeBajaBecarioPorProyecto";
        comando.Parameters.Add(new SqlParameter("@idBecario", idBecario));
        comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
        comando.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
        Conexion.ejecutarComando(comando);

    }

    //Los siguientes tres métodos se fijan si existen los becarios-inv.codirectores y si es así 
    private static void darDeBajaViejoBecarioPorProyecto(Proyecto proyecto, List<Becario> becariosProyectoTotal)
    {
        List<Becario> becariosAntiguos = listarBecariosActivosDelProyecto(proyecto.ID);
        foreach (Becario becario in becariosAntiguos)
        {
            if (!becariosProyectoTotal.Contains(becario))
            {
                DAOProyecto.darDeBajaBecarioPorProyecto(proyecto.ID, becario.ID, DateTime.Today);
            }
        }
    }
    private static void darDeBajaViejoInvestigadorPorProyecto(Proyecto proyecto, List<Investigador> investigadoresProyectoTotal)
    {
        List<Investigador> investigadoresAntiguos = listarInvestigadoresActivosDelProyecto(proyecto.ID);
        foreach (Investigador investigador in investigadoresAntiguos)
        {
            if (!investigadoresProyectoTotal.Contains(investigador))
            {
                DAOProyecto.darDeBajaInvestigadorPorProyecto(proyecto.ID, investigador.ID, DateTime.Today);
            }
        }
    }
    private static void darDeBajaViejoCodirectorPorProyecto(Proyecto proyecto, List<Investigador> codirectoresProyectoTotal)
    {
        List<Investigador> codirectoresAntiguos = listarCodirectoresActivosDelProyecto(proyecto.ID);
        foreach (Investigador codirector in codirectoresAntiguos)
        {
            if (!codirectoresProyectoTotal.Contains(codirector))
            {
                DAOProyecto.darDeBajaCodirectorPorProyecto(proyecto.ID, codirector.ID, DateTime.Today);
            }
        }
    }
}