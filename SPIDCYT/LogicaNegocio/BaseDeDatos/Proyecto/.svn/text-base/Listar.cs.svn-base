using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOProyecto
    {
        public static Proyecto get(int idProyecto)
        {
            SqlCommand comando = new SqlCommand();
            
            comando.Parameters.AddWithValue("@idProyecto", idProyecto);
            comando.CommandText = "SELECT * FROM Proyecto WHERE idProyecto = @idProyecto";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);
            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

        public static List<Proyecto> listarTodosLosProyectosWebPublica()
        {
            SqlCommand comando = new SqlCommand();
            List<Proyecto> proyectos = new List<Proyecto>();
            comando.CommandText = "SELECT * FROM Proyecto";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return new List<Proyecto>(); }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                proyectos.Add(get(Convert.ToInt32(tabla.Rows[i]["idProyecto"])));
            }
            return proyectos;
        }

        private static List<Investigador> listarInvestigadoresDelProyecto(int idProyecto)
        {
            SqlCommand comando = new SqlCommand();
            List<Investigador> investigadoresDelProyecto = new List<Investigador>();

            comando.Parameters.AddWithValue("@idProyecto", idProyecto);
            comando.CommandText = "SELECT idInvestigador FROM InvestigadorPorProyecto WHERE idProyecto = @idProyecto";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);
            if (tabla.Rows.Count == 0) { return new List<Investigador>(); }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                investigadoresDelProyecto.Add(DAOInvestigador.get(Convert.ToInt32(tabla.Rows[i]["idInvestigador"])));
            }

            return investigadoresDelProyecto;  
        }


        public static List<Investigador> listarInvestigadoresActivosDelProyecto(int idProyecto)
        {
            SqlCommand comando = new SqlCommand();
            List<Investigador> investigadoresActivosDelProyecto = new List<Investigador>();

            comando.Parameters.AddWithValue("@idProyecto", idProyecto);
            comando.CommandText = "SELECT idInvestigador FROM InvestigadorPorProyecto WHERE idProyecto = @idProyecto AND fechaFin IS NULL";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);
            if (tabla.Rows.Count == 0) { return new List<Investigador>(); }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                investigadoresActivosDelProyecto.Add(DAOInvestigador.get(Convert.ToInt32(tabla.Rows[i]["idInvestigador"])));
            }

            return investigadoresActivosDelProyecto;            
        
        }

        public static List<Investigador> listarCodirectoresActivosDelProyecto(int idProyecto)
        {
            SqlCommand comando = new SqlCommand();
            List<Investigador> codirectoresActivosDelProyecto = new List<Investigador>();

            comando.Parameters.AddWithValue("@idProyecto", idProyecto);
            comando.CommandText = "SELECT idInvestigador FROM CodirectorPorProyecto WHERE idProyecto = @idProyecto AND fechaFin IS NULL";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);
            if (tabla.Rows.Count == 0) { return new List<Investigador>(); }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                codirectoresActivosDelProyecto.Add(DAOInvestigador.get(Convert.ToInt32(tabla.Rows[i]["idInvestigador"])));
            }

            return codirectoresActivosDelProyecto;

        }



        public static List<Becario> listarBecariosActivosDelProyecto(int idProyecto)
        {
            SqlCommand comando = new SqlCommand();
            List<Becario> becariosActivosDelProyecto = new List<Becario>();

            comando.Parameters.AddWithValue("@idProyecto", idProyecto);
            comando.CommandText = "SELECT idBecario FROM BecarioPorProyecto WHERE idProyecto = @idProyecto AND fechaFin IS NULL";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return new List<Becario>(); }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                becariosActivosDelProyecto.Add(DAOBecario.get(Convert.ToInt32(tabla.Rows[i]["idBecario"])));
            }

            return becariosActivosDelProyecto;

        }

        public static List<Proyecto> listarProyectosUsuario(string nombreUsuario)
        {
            SqlCommand comando = new SqlCommand();
            List<Proyecto> proyectosUsuario = new List<Proyecto>();

            comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            comando.CommandText = "select p.idProyecto from Proyecto p, Investigador i, InvestigadorPorProyecto x, Persona t, aspnet_Users u where p.idProyecto = x.idProyecto and i.idInvestigador = x.idInvestigador and i.idInvestigador=t.idPersona and t.usuario=u.UserId and u.UserName = @nombreUsuario";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return new List<Proyecto>(); }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                proyectosUsuario.Add(get(Convert.ToInt32(tabla.Rows[i]["idProyecto"])));
            }
            return proyectosUsuario;
        }        

        public static int obtenerTablero(int idProyecto)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@idProyecto", idProyecto);
            comando.CommandText = "SELECT idTablero FROM Tablero WHERE idProyecto=@idProyecto";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);
            return int.Parse(tabla.Rows[0][0].ToString());
 
        }

        public static int totalDeProyectosActivos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select count(idProyecto) From Proyecto WHERE fechaFin IS NULL";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);
            return Convert.ToInt32(tabla.Rows[0][0]);
        }

 
    }
