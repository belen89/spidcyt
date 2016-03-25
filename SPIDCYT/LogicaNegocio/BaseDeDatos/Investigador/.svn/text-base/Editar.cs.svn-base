using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

public sealed partial class DAOInvestigador
{
    public static void actualizarInvestigador(Investigador investigador,  List<Proyecto> proyectosCodirector, List<Proyecto> proyectosInvestigador)
    {
        using(TransactionScope tran = new TransactionScope())
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "actualizarInvestigador ";
                comando.Parameters.Add(new SqlParameter("@idInvestigador", investigador.ID));
                comando.Parameters.Add(new SqlParameter("@legajo", investigador.LEGAJO));
                comando.Parameters.Add(new SqlParameter("@nombre", investigador.NOMBRE));
                comando.Parameters.Add(new SqlParameter("@apellido", investigador.APELLIDO));
                comando.Parameters.Add(new SqlParameter("@mail", investigador.MAIL));
                comando.Parameters.Add(new SqlParameter("@telefono", investigador.TELEFONO));
                comando.Parameters.Add(new SqlParameter("@categoriaNacional", investigador.CATEGORIANACIONAL.ID));
                comando.Parameters.Add(new SqlParameter("@categoriaUTN", investigador.CATEGORIAUTN.ID));
                Conexion.ejecutarComando(comando);
                insertarNuevoProyectoComoInvestiagdor(investigador, proyectosInvestigador);
                insertarNuevoProyectoComoCodirector(investigador, proyectosCodirector);
                darDeBajaViejoProyectoComoCodirector(investigador, proyectosCodirector);
                darDeBajaViejoProyectoComoInvestiagdor(investigador, proyectosInvestigador);
                tran.Complete();
            }
            
            catch(Exception)
            {
                tran.Dispose();
            }
        }
    }
    internal static void asignarUsuario(Investigador investigador)
    {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "asignarUsuarioAPersona";
                comando.Parameters.Add(new SqlParameter("@idPersona", investigador.ID));                
                Conexion.ejecutarComando(comando);                
        
     }

    internal static void reCategorizar(Investigador investigador, HistorialCategoria viejaCategoía)
    {
        using (TransactionScope tran = new TransactionScope())
        {
            try
            {
                //Los datos de la Categoría Actual fueron modificados y es necesario guardar los cambios
                guardarInvestigador(investigador);
                //Insertarmos la vieja categoria dentro de su historial
                if (viejaCategoía != null)
                {
                    DAOHistorialCategoria.insertarHistorialCategoria(viejaCategoía, investigador.ID);
                }
                tran.Complete();
            }

            catch (Exception)
            {
                tran.Dispose();
            }
        }
    }

    internal static void agregarCategoriaAlHistorialDeCategorizacion(Investigador investigador, HistorialCategoria viejaCategoria)
    {
        try
        {
            DAOHistorialCategoria.insertarHistorialCategoria(viejaCategoria, investigador.ID);
        }
        catch (Exception)
        {
            
            throw;
        }
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