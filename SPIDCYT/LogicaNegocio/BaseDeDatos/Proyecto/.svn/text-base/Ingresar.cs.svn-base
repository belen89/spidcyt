using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

public sealed partial class DAOProyecto
{

    //Insertar un Proyecto UTN o Con Incentivo
    public static int insertarProyecto(Proyecto proyecto)
    {
        int idProyecto;
        using(TransactionScope tran = new TransactionScope())
        {
            try
            {
                idProyecto = insertarDatosProyecto(proyecto);
                foreach (ProyectoCategorizado proyectoCategorizado in proyecto.PROYECTOCATEGORIZADO)
                    DAOProyectoCategorizado.insertarProyectoCategorizado(proyectoCategorizado, idProyecto);
                tran.Complete();
            }
            catch { 
                tran.Dispose();
                return -1;
            }
         }
        return idProyecto;        
    }

    //Insertar un Proyecto Incubado
    public static int insertarProyectoIncubado(Proyecto proyecto)
    {
        int idProyecto;
        using (TransactionScope tran = new TransactionScope())
        {
            try
            {
                idProyecto = insertarDatosProyectoIncubado(proyecto);
                foreach (Becario becario in proyecto.BECARIOS)
                      insertarIntegranteAIncubado(idProyecto, becario.ID, proyecto.FECHAINICIO);

                foreach (ProyectoCategorizado proyectoCategorizado in proyecto.PROYECTOCATEGORIZADO)
                    DAOProyectoCategorizado.insertarProyectoCategorizado(proyectoCategorizado, idProyecto);
                tran.Complete();
            }
            catch
            {
                tran.Dispose();
                return -1;
            }
        }
        return idProyecto;        

    }

    //Método para insertar un nuevo Integrante a un Proyecto Incubado
    private static void insertarIntegranteAIncubado(int idProyecto, int idIntegrante, DateTime fechaAlta)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarIntegranteAIncubado";
        comando.Parameters.Add(new SqlParameter("@idPersona", idIntegrante));
        comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
        comando.Parameters.Add(new SqlParameter("@fechaInicio", fechaAlta.ToString("MM/dd/yyyy")));
        Conexion.ejecutarComando(comando);
    }

    //Métodos para Insertar un Nuevo Proyecto UTN o Con Incentivo
    public static int insertarDatosProyecto(Proyecto proyecto)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarProyecto";

        comando.Parameters.Add(new SqlParameter("@nombreCorto", proyecto.NOMBRECORTO));
        comando.Parameters.Add(new SqlParameter("@nombreLargo", proyecto.NOMBRELARGO));
        comando.Parameters.Add(new SqlParameter("@estado", proyecto.ESTADOPROYECTO.ID));
        comando.Parameters.Add(new SqlParameter("@resumen", proyecto.RESUMEN));
        comando.Parameters.Add(new SqlParameter("@fechaFinEstimada", proyecto.FECHAFINESTIMADA));
        comando.Parameters.Add(new SqlParameter("@fechaInicio", proyecto.FECHAINICIO));        
        comando.Parameters.Add(new SqlParameter("@director", proyecto.DIRECTOR.ID));        

        if (proyecto.AREASDEINVESTIGACION != null)
        {
            comando.Parameters.Add(new SqlParameter("@areaDeInvestigacion", proyecto.AREASDEINVESTIGACION.ID));
        }
        
        if (proyecto.ASESORCIENTIFICO != null)
        {
            comando.Parameters.Add(new SqlParameter("@asesorCientifico", proyecto.ASESORCIENTIFICO.ID));
        }

        Conexion.ejecutarComando(comando);
        comando.CommandType= CommandType.Text;
        comando.CommandText = "SELECT IDENT_CURRENT('Proyecto')";
        return int.Parse(Conexion.consultar(comando).Rows[0][0].ToString());       

    }

    //Métodos para Insertar un Proyecto Incubado
    public static int insertarDatosProyectoIncubado(Proyecto proyecto)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "insertarProyectoIncubado";

        comando.Parameters.Add(new SqlParameter("@nombreCorto", proyecto.NOMBRECORTO));
        comando.Parameters.Add(new SqlParameter("@nombreLargo", proyecto.NOMBRELARGO));
        comando.Parameters.Add(new SqlParameter("@estado", proyecto.ESTADOPROYECTO.ID));
        comando.Parameters.Add(new SqlParameter("@resumen", proyecto.RESUMEN));
        comando.Parameters.Add(new SqlParameter("@fechaFinEstimada", proyecto.FECHAFINESTIMADA));
        comando.Parameters.Add(new SqlParameter("@fechaInicio", proyecto.FECHAINICIO));
        comando.Parameters.Add(new SqlParameter("@areaDeInvestigacion", proyecto.AREASDEINVESTIGACION.ID));

        Conexion.ejecutarComando(comando);
        comando.CommandType = CommandType.Text;
        comando.CommandText = "SELECT IDENT_CURRENT('Proyecto')";
        return int.Parse(Conexion.consultar(comando).Rows[0][0].ToString());
    }
    
    //Métodos para insertar los Integrantes de un Proyecto
    public static void insertarInvestigadorAProyecto(int idProyecto, int idInvestigador, DateTime fecha)
    {   
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarInvestigadorAProyecto";
            comando.Parameters.Add(new SqlParameter("@idInvestigador", idInvestigador));
            comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
            comando.Parameters.Add(new SqlParameter("@fechaInicio", fecha.ToString("MM/dd/yyyy")));
            Conexion.ejecutarComando(comando);
     
    }
    public static void insertarCodirectorAProyecto(int idProyecto, int idCodirector, DateTime fecha)
    {   
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarCodirectorAProyecto";
            comando.Parameters.Add(new SqlParameter("@idInvestigador", idCodirector));
            comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
            comando.Parameters.Add(new SqlParameter("@fechaInicio", fecha.ToString("MM/dd/yyyy")));
            Conexion.ejecutarComando(comando);
        
    }
    public static void insertarBecarioAProyecto(int idProyecto,  int idBecario, DateTime fecha)
    { 
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarBecarioAProyecto";
            comando.Parameters.Add(new SqlParameter("@idBecario", idBecario));
            comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
            comando.Parameters.Add(new SqlParameter("@fechaInicio", fecha.ToString("MM/dd/yyyy")));
            Conexion.ejecutarComando(comando);
        

    }

    //Métodos para Modificar los Proyectos, si ya existen los investigadores, no los añade.
    //de acuerdo a los becarios listados en el proyecto se fija cuales son nuevos para insertarlos
    private static void insertarNuevoBecarioAProyecto(Proyecto proyecto, List<Becario> becariosProyectoTotal)
    {
        List<Becario> becariosAntiguos = listarBecariosActivosDelProyecto(proyecto.ID);
        foreach (Becario becario in becariosProyectoTotal)
        {
            if (!becariosAntiguos.Contains(becario))
            {
                DAOProyecto.insertarBecarioAProyecto(proyecto.ID, becario.ID, DateTime.Today);
            }
        }
    }
    private static void insertarNuevoInvestigadorAProyecto(Proyecto proyecto, List<Investigador> investigadoresProyectoTotal)
    {
        List<Investigador> investigadoresAntiguos = listarInvestigadoresActivosDelProyecto(proyecto.ID);
        foreach (Investigador investigador in investigadoresProyectoTotal)
        {
            if (!investigadoresAntiguos.Contains(investigador))
            {
                DAOProyecto.insertarInvestigadorAProyecto(proyecto.ID, investigador.ID, DateTime.Today);
            }
        }
    }
    private static void insertarNuevoCodirectorAProyecto(Proyecto proyecto, List<Investigador> codirectoresProyectoTotal)
    {
        List<Investigador> codirectoresAntiguos = listarCodirectoresActivosDelProyecto(proyecto.ID);
        foreach (Investigador codirector in codirectoresProyectoTotal)
        {
            if (!codirectoresAntiguos.Contains(codirector))
            {
                DAOProyecto.insertarCodirectorAProyecto(proyecto.ID, codirector.ID, DateTime.Today);
            }
        }
    }

 }
