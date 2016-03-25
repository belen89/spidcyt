using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

public sealed partial class DAORecursoEnProyecto
{
    public static void insertarRecursoEnProyecto(RecursoEnProyecto recursoEnProyecto, int idProyecto)
    {
        SqlCommand comando = new SqlCommand();
        using (TransactionScope tran = new TransactionScope())
        {
            try{
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarRecursoEnProyecto";

            comando.Parameters.Add(new SqlParameter("@idRecurso", recursoEnProyecto.RECURSO.ID));
            comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
            comando.Parameters.Add(new SqlParameter("@fechaPedido", recursoEnProyecto.FECHAPEDIDO.ToString("MM/dd/yyyy")));
            comando.Parameters.Add(new SqlParameter("@diasEstimadosDeUso", recursoEnProyecto.DIASESTIMADOSDEUSO));
            Conexion.ejecutarComando(comando);
            DAORecurso.modificarRecurso(recursoEnProyecto.RECURSO);
            tran.Complete();
            }
            catch(Exception)
            {
                tran.Dispose();
            }
        }
        
    }
}
