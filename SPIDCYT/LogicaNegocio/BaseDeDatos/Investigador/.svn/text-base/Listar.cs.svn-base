using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOInvestigador
    {
        public static Investigador get(int idInvestigador)
        {
            SqlCommand comando = new SqlCommand();
            
            comando.Parameters.AddWithValue("@idInvestigador", idInvestigador);
            comando.CommandText = "SELECT * FROM Persona p, Investigador i WHERE p.idPersona=i.idInvestigador AND p.idPersona = @idInvestigador";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

        public static List<Investigador> listarInvestigadores()
        {
            List<Investigador> investigadores = new List<Investigador>();
            SqlCommand comando = new SqlCommand();

            comando.CommandText = "SELECT * FROM Persona p, Investigador i WHERE p.idPersona=i.idInvestigador AND p.fechaBaja IS NULL";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return new List<Investigador>(); }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                investigadores.Add(Transformar(tabla.Rows[i]));
            }
            return investigadores;
        }

        public static DataTable listarInvestigadoresConCorreo()
        {
           
            SqlCommand comando = new SqlCommand();

            comando.CommandText = "SELECT p.mail, p.apellido + ', ' + p.nombre as nombreCompleto FROM Persona p, Investigador i WHERE p.idPersona=i.idInvestigador AND p.fechaBaja IS NULL order by nombreCompleto";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);
            
            return tabla;
        }

        public static List<Proyecto> listarProyectosActualesComoInvestigador(int idInvestigador)
        {
            SqlCommand comando = new SqlCommand();
            List<Proyecto> proyetosInvestigador = new List<Proyecto>();
            comando.Parameters.AddWithValue("@idInvestigador", idInvestigador);
            comando.CommandText = "SELECT idProyecto FROM InvestigadorPorProyecto where idInvestigador=@idInvestigador and fechaFin IS NULL";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return new List<Proyecto>(); }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                proyetosInvestigador.Add(DAOProyecto.get(Convert.ToInt32(tabla.Rows[i]["idProyecto"])));
            }
            return proyetosInvestigador;
        }

        public static List<Proyecto> listarProyectosActualesComoCodirector(int idCodirector)
        {
            SqlCommand comando = new SqlCommand();
            List<Proyecto> proyetosCodirector= new List<Proyecto>();
            comando.Parameters.AddWithValue("@idCodirector", idCodirector);
            comando.CommandText = "SELECT idProyecto FROM CodirectorPorProyecto where idInvestigador=@idCodirector and fechaFin IS NULL";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return new List<Proyecto>(); }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                proyetosCodirector.Add(DAOProyecto.get(Convert.ToInt32(tabla.Rows[i]["idProyecto"])));
            }
            return proyetosCodirector;
        }

        public static List<Proyecto> listarProyectosActualesComoDirector(int idDirector)
        {
            SqlCommand comando = new SqlCommand();
            List<Proyecto> proyetosDirector = new List<Proyecto>();
            comando.Parameters.AddWithValue("@idDirector", idDirector);
            comando.CommandText = "SELECT idProyecto FROM Proyecto where director=@idDirector and fechaFin IS NULL";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return new List<Proyecto>(); }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                proyetosDirector.Add(DAOProyecto.get(Convert.ToInt32(tabla.Rows[i]["idProyecto"])));
            }
            return proyetosDirector;
        }

        public static List<Investigador> listarInvestigadoresQueCumplenRequisitosDeDirector()
        {
            List<Investigador> investigadores = listarInvestigadores();
            List<Investigador> directores = new List<Investigador>();

            foreach (Investigador item in investigadores)
            {
                if (item.puedoSerDirector())
                {
                    directores.Add(item);
                }
            }

            return directores;        
        }

        public static List<Investigador> listarInvestigadoresQueCumplenRequisitosDeCoDirector()
        {
            //Mismos requisitos que para ser Director
            return listarInvestigadoresQueCumplenRequisitosDeDirector();
        }


        public static List<Investigador> listarInvestigadoresPorCategoría(string categoria)
        {
            List<Investigador> investigadores = listarInvestigadores();
            List<Investigador> investigadoresConCategoría = new List<Investigador>();

            foreach (Investigador item in investigadores)
            {
                if (item.CATEGORIAUTN != null && item.CATEGORIAUTN.NOMBRE == categoria)
                {
                    investigadoresConCategoría.Add(item);
                }
                else if(item.CATEGORIANACIONAL != null && item.CATEGORIANACIONAL.NOMBRE == categoria)
                {
                    investigadoresConCategoría.Add(item);
                }
            }

            return investigadoresConCategoría;
        }

        public static Investigador buscarInvestigadorPorLegajo(int legajo)
        {
            SqlCommand comando = new SqlCommand();

            comando.Parameters.AddWithValue("@legajo", legajo);
            comando.CommandText = "SELECT * FROM Persona p, Investigador i WHERE p.idPersona=i.idInvestigador AND p.legajo=@legajo";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

        public static bool tieneUsuarioCreado(Investigador investigador)
        {
            SqlCommand comando = new SqlCommand();

            comando.Parameters.AddWithValue("@idPersona", investigador.ID );
            comando.CommandText = "SELECT dbo.aspnet_Users.UserId FROM dbo.aspnet_Users, dbo.Persona WHERE dbo.Persona.mail=dbo.aspnet_Users.UserName and dbo.Persona.idPersona= @idPersona";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int totalDeInvestigadoresActivos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select count(idPersona) as 'investigadores' From Persona p, Investigador b where p.idPersona=b.idInvestigador and p.fechaBaja is null";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);
            return Convert.ToInt32(tabla.Rows[0][0]);
        }

        public static DataTable listarInvestigadoresDeProyecto(int idProyecto)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "correosIntegrantesPorProyecto";
            comando.Parameters.AddWithValue("@idProyecto", idProyecto);
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return tabla;
        }
    }
