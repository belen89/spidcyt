using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

public sealed partial class DAOProyecto
{
    public static void modificarProyecto(Proyecto proyecto)
    {
        using (TransactionScope tran = new TransactionScope())
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "actualizarProyecto";
                comando.Parameters.Add(new SqlParameter("@idProyecto", proyecto.ID));
                comando.Parameters.Add(new SqlParameter("@nombreCorto", proyecto.NOMBRECORTO));
                comando.Parameters.Add(new SqlParameter("@nombreLargo", proyecto.NOMBRELARGO));
                comando.Parameters.Add(new SqlParameter("@estado", proyecto.ESTADOPROYECTO.ID));
                comando.Parameters.Add(new SqlParameter("@resumen", proyecto.RESUMEN));
                comando.Parameters.Add(new SqlParameter("@fechaFinEstimada", proyecto.FECHAFINESTIMADA));
                comando.Parameters.Add(new SqlParameter("@director", proyecto.DIRECTOR.ID));
                if (proyecto.AREASDEINVESTIGACION != null)
                {
                    comando.Parameters.Add(new SqlParameter("@areaDeInvestigacion", proyecto.AREASDEINVESTIGACION.ID));
                }
                if (proyecto.ASESORCIENTIFICO != null)
                {
                    comando.Parameters.Add(new SqlParameter("@asesorCientifico", proyecto.ASESORCIENTIFICO.ID));
                }
                               
                foreach (ProyectoCategorizado proyectoCategorizado in proyecto.PROYECTOCATEGORIZADO)
                  DAOProyectoCategorizado.actualizarProyectoCategorizado(proyectoCategorizado, proyecto);

                Conexion.ejecutarComando(comando);
                tran.Complete();
            }
            catch (Exception)
            { tran.Dispose(); }
        }
 
    }

    public static void modificarProyectoIncubado(Proyecto proyecto)
    {
        try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "actualizarProyectoIncubado";
                comando.Parameters.Add(new SqlParameter("@idProyecto", proyecto.ID));
                comando.Parameters.Add(new SqlParameter("@nombreCorto", proyecto.NOMBRECORTO));
                comando.Parameters.Add(new SqlParameter("@nombreLargo", proyecto.NOMBRELARGO));
                comando.Parameters.Add(new SqlParameter("@resumen", proyecto.RESUMEN));
                comando.Parameters.Add(new SqlParameter("@fechaInicio", proyecto.FECHAINICIO));
                comando.Parameters.Add(new SqlParameter("@fechaFinEstimada", proyecto.FECHAFINESTIMADA));
                comando.Parameters.Add(new SqlParameter("@areaDeInvestigacion", proyecto.AREASDEINVESTIGACION.ID));                

                Conexion.ejecutarComando(comando);
                
            }
            catch (Exception)
            {  }
        
    }

    internal static void eliminarCategoríaUTN(Proyecto proyecto)
    {
        SqlCommand comando = new SqlCommand();
        comando.Parameters.AddWithValue("@idProyecto", proyecto.ID);
        comando.CommandText = "DELETE FROM [SPIDCYT].[dbo].[TipoProyectoPorProyecto] WHERE idProyecto = @idProyecto AND idTipoProyecto = '1'";
        comando.CommandType = CommandType.Text;
        Conexion.ejecutarComando(comando);
    }

    internal static void eliminarCategoríaConIncentivo(Proyecto proyecto)
    {
        SqlCommand comando = new SqlCommand();
        comando.Parameters.AddWithValue("@idProyecto", proyecto.ID);
        comando.CommandText = "DELETE FROM [SPIDCYT].[dbo].[TipoProyectoPorProyecto] WHERE idProyecto = @idProyecto AND idTipoProyecto = '2'";
        comando.CommandType = CommandType.Text;
        Conexion.ejecutarComando(comando);
    }

    //public static void asociarPresupuesto(int idProyecto, int idPresupuesto)
    //{
    //    SqlCommand comando = new SqlCommand();
    //    comando.CommandType = CommandType.Text;
    //    comando.CommandText = "insert into Proyecto (presupuesto) values (@idPresupuesto) where idProyecto = @idProyecto";
    //    comando.Parameters.Add(new SqlParameter("@idPresupuesto", idPresupuesto));
    //    comando.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
    //    Conexion.ejecutarComando(comando);
    //}

}