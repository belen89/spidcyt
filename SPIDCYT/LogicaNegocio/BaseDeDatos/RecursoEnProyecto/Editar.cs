using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

public sealed partial class DAORecursoEnProyecto
{

    public static void modificarRecursoEnProyecto(RecursoEnProyecto recursoEnProyecto, bool agregarHistorial)
    {
        
        using (TransactionScope tran = new TransactionScope())
        {
            try{
                    SqlCommand comando = new SqlCommand();

                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "actualizarRecursoEnProyecto";
                    comando.Parameters.Add(new SqlParameter("@idRecurso", recursoEnProyecto.RECURSO.ID));
                    comando.Parameters.Add(new SqlParameter("@idRecursoEnProyecto", recursoEnProyecto.ID));
                    comando.Parameters.Add(new SqlParameter("@fechaDesde", recursoEnProyecto.FECHADESDE));
                    comando.Parameters.Add(new SqlParameter("@diasEstimadosDeUso", recursoEnProyecto.DIASESTIMADOSDEUSO));
        
                    Conexion.ejecutarComando(comando);
                    DAORecurso.modificarRecurso(recursoEnProyecto.RECURSO);
                    if (agregarHistorial)
                    {
                        HistorialDeRecurso historial= new HistorialDeRecurso();
                        historial.FECHADESDE=recursoEnProyecto.FECHADESDE;
                        historial.PROYECTO=Proyecto.get(recursoEnProyecto.obtenerIdDeMiProyecto());
                        DAOHistorialDeRecurso.insertarHistorialDeRecurso(historial, recursoEnProyecto.RECURSO.ID);
                    }
                    tran.Complete();
            }
            catch (Exception)
            {
                tran.Dispose();
            }
        }
    }
}