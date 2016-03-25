using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

public sealed partial class DAORecursoEnProyecto
{
    public static void darDeBajaRecursoEnProyecto(RecursoEnProyecto recursoEnProyecto, int idProyecto)
    {
          
        SqlCommand comando = new SqlCommand();
        using (TransactionScope tran = new TransactionScope())
        {
            try{
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "actualizarRecursoEnProyecto";
                    comando.Parameters.Add(new SqlParameter("@idRecurso", recursoEnProyecto.RECURSO.ID));
                    comando.Parameters.Add(new SqlParameter("@idRecursoEnProyecto", recursoEnProyecto.ID));
                    comando.Parameters.Add(new SqlParameter("@fechaHastaReal", recursoEnProyecto.FECHAHASTAREAL.ToString("MM/dd/yyyy")));
                    comando.Parameters.Add(new SqlParameter("@diasEstimadosDeUso", recursoEnProyecto.DIASESTIMADOSDEUSO));
                    comando.Parameters.Add(new SqlParameter("@fechaDesde", recursoEnProyecto.FECHADESDE));
 
                    Conexion.ejecutarComando(comando);
                    DAORecurso.modificarRecurso(recursoEnProyecto.RECURSO);
                    HistorialDeRecurso historialDeRecurso = DAOHistorialDeRecurso.ultimoProyectoDeRecurso(recursoEnProyecto.RECURSO.ID, idProyecto);
                    historialDeRecurso.FECHAHASTA= recursoEnProyecto.FECHAHASTAREAL;
                    DAOHistorialDeRecurso.terminarHistorialDeRecurso(historialDeRecurso);
                    tran.Complete();   
            }
            catch(Exception)
            {
                tran.Dispose();
            }

        }
    }


    }
