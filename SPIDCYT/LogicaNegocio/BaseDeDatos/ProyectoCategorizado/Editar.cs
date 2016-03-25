using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOProyectoCategorizado
{

    //check si  el proyecto categorizado a cambiado, si es así se modifica el num de referencia, si no exite, es nuevo, entonces lo inserta 
    public static void actualizarProyectoCategorizado(ProyectoCategorizado proyectoCategorizadoNuevo, Proyecto proyecto)
    {
        //La lleno con las Categorías Actuales del Proyecto.
        List<ProyectoCategorizado> categoriasActuales = DAOProyectoCategorizado.get(proyecto.ID);

        //Si no tiene Categorías, Ingreso Directamente
        if (categoriasActuales == null)
        {
            insertarProyectoCategorizado(proyectoCategorizadoNuevo, proyecto.ID);
        }
        //Si Hay alguna Adentro Pregunto...
        else
        {
            //Si el tipo de Proyecto Categorizado que quiero ingresar es UTN
            if (proyectoCategorizadoNuevo.esUTN())
            {
                //Y dentro de las Categorías Actuales existe una UTN, que NO sea igual...
                if (categoriasActuales.Exists(pc => (pc.esUTN() == true
                    && pc.NUMEROREFERENCIA != proyectoCategorizadoNuevo.NUMEROREFERENCIA)))
                {
                    //Actualizo la Categoría
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "actualizarProyectoCategorizado";
                    comando.Parameters.Add(new SqlParameter("@idProyecto", proyecto.ID));
                    comando.Parameters.Add(new SqlParameter("@idTipoProyecto", proyectoCategorizadoNuevo.TIPOPROYECTO.ID));
                    comando.Parameters.Add(new SqlParameter("@numeroResolucion", proyectoCategorizadoNuevo.NUMEROREFERENCIA));
                    Conexion.ejecutarComando(comando);
                }
                //Si NO existe
                else
                {
                    //Entonces la ingreso..
                    insertarProyectoCategorizado(proyectoCategorizadoNuevo, proyecto.ID);
                }

            }
            //Pero si el Proyecto Categorizado que quiero ingresar es Con Incentivo
            else
            {
                //Y dentro de las Categorías Actuales existe una Con Incentivo, que NO sea igual...
                if (categoriasActuales.Exists(pc => (pc.esConIncentivo() == true
                    && pc.NUMEROREFERENCIA != proyectoCategorizadoNuevo.NUMEROREFERENCIA)))
                {
                    //Actualizo la Categoría
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "actualizarProyectoCategorizado";
                    comando.Parameters.Add(new SqlParameter("@idProyecto", proyecto.ID));
                    comando.Parameters.Add(new SqlParameter("@idTipoProyecto", proyectoCategorizadoNuevo.TIPOPROYECTO.ID));
                    comando.Parameters.Add(new SqlParameter("@numeroResolucion", proyectoCategorizadoNuevo.NUMEROREFERENCIA));
                    Conexion.ejecutarComando(comando);
                }
                //Si NO existe
                else
                {
                    //Entonces la ingreso
                    insertarProyectoCategorizado(proyectoCategorizadoNuevo, proyecto.ID);
                }
            }
        }              
    }

 
}