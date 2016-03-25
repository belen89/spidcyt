using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;


public sealed partial class DAOBecario
{
    public static void insertarBecario(Becario becario, List<Proyecto> proyectosBecario)
    {
        using (TransactionScope tran = new TransactionScope())
        {
            try
            {
                int idBecario= insertarDatosBecario(becario);
                foreach (Proyecto proyecto in proyectosBecario)
                    DAOProyecto.insertarBecarioAProyecto(proyecto.ID, idBecario, becario.FECHAALTA);

                tran.Complete();
            }
            catch (Exception) { tran.Dispose(); }
        }
    }

    public static int insertarDatosBecario(Becario becario)
    {
               
            SqlCommand comando = new SqlCommand();

            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarBecario";

            comando.Parameters.Add(new SqlParameter("@legajo", becario.LEGAJO));
            comando.Parameters.Add(new SqlParameter("@nombre", becario.NOMBRE));
            comando.Parameters.Add(new SqlParameter("@apellido", becario.APELLIDO));
            comando.Parameters.Add(new SqlParameter("@mail", becario.MAIL));
            comando.Parameters.Add(new SqlParameter("@telefono", becario.TELEFONO));
            comando.Parameters.Add(new SqlParameter("@fechaAlta", becario.FECHAALTA.ToString("MM/dd/yyyy")));
            comando.Parameters.Add(new SqlParameter("@tipoBecario", becario.TIPOBECARIO.ID));
            Conexion.ejecutarComando(comando);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT IDENT_CURRENT('Persona')";
            return int.Parse(Conexion.consultar(comando).Rows[0][0].ToString());

      


    }
    //de acuerdo a los proyectos listados en el becario se fija cuales son nuevos para insertarlos
    private static void insertarNuevoProyectoABecario(Becario becario, List<Proyecto> proyectosBecarioTotal)
    {
                List<Proyecto> proyectosAntiguos = listarProyectosActualesComoBecario(becario.ID);
                foreach (Proyecto proyectoNuevo in proyectosBecarioTotal)
                {
                    if (!proyectosAntiguos.Contains(proyectoNuevo))
                    {
                        DAOProyecto.insertarBecarioAProyecto(proyectoNuevo.ID, becario.ID, DateTime.Today);
                    }
                }
    }

}
