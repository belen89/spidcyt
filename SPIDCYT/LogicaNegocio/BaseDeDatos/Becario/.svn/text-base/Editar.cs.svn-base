using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

public sealed partial class DAOBecario
{
    public static void actualizarBecario(Becario becario)//, List<Proyecto> proyectosBecario)
    {
        using (TransactionScope tran = new TransactionScope())
        {
            try
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
                Conexion.ejecutarComando(comando);
                //insertarNuevoProyectoABecario(becario, proyectosBecario);
                //darDeBajaViejoProyectoABecario(becario, proyectosBecario);
                tran.Complete();
            }
            catch (Exception)
            {
                tran.Dispose();
            }

        }
    }

    public static void guardarBecario(Becario becario)
    {
        using (TransactionScope tran = new TransactionScope())
        {
            try
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
                Conexion.ejecutarComando(comando);
                tran.Complete();
            }
            catch (Exception)
            {
                tran.Dispose();
            }

        }
    }
    internal static void asignarUsuario(Becario becario)
    {
  
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "asignarUsuarioAPersona";
        comando.Parameters.Add(new SqlParameter("@idPersona", becario.ID));
        Conexion.ejecutarComando(comando);

    }

    internal static void asignarProducto(int idProducto, int idInvestigador)
    {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.Text;
        comando.CommandText = "insert into ProductoPorPersona (idProducto,idPersona) values (@idProducto,@idPersona)";
        comando.Parameters.Add(new SqlParameter("@idPersona", idInvestigador));
        comando.Parameters.Add(new SqlParameter("@idProducto", idProducto));
        Conexion.ejecutarComando(comando);
    }


}