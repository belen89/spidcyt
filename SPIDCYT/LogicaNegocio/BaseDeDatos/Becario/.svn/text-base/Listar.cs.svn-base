using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOBecario
    {
        public static Becario get(int idBecario)
        {
            SqlCommand comando = new SqlCommand();

            comando.Parameters.AddWithValue("@idBecario", idBecario);
            comando.CommandText = "SELECT * FROM Persona p, Becario b WHERE p.idPersona=b.idBecario AND p.idPersona = @idBecario";
            comando.CommandType = CommandType.Text;
 
            DataTable tabla = Conexion.consultar(comando);
            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

        public static List<Becario> listarBecarios()
        {
            List<Becario> investigadores = new List<Becario>();
            SqlCommand comando = new SqlCommand();

            comando.CommandText = "SELECT * FROM Persona p, Becario b WHERE p.idPersona=b.idBecario AND p.fechaBaja IS NULL";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                investigadores.Add(Transformar(tabla.Rows[i]));
            }
            return investigadores;
        }

        public static List<Proyecto> listarProyectosActualesComoBecario(int idBecario)
        {
            SqlCommand comando = new SqlCommand();
            List<Proyecto> proyetosBecario = new List<Proyecto>();
            comando.Parameters.AddWithValue("@idBecario", idBecario);
            comando.CommandText = "SELECT idProyecto FROM BecarioPorProyecto where idBecario=@idBecario and fechaFin IS NULL";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                proyetosBecario.Add(DAOProyecto.get(Convert.ToInt32(tabla.Rows[i]["idProyecto"])));
            }
            return proyetosBecario;
        }

        public static bool tieneUsuarioCreado(Becario becario)
        {
            SqlCommand comando = new SqlCommand();

            comando.Parameters.AddWithValue("@idPersona", becario.ID);
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

        public static int totalDeBecariosActivos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select count(idPersona) as 'becarios' From Persona p, Becario b where p.idPersona=b.idBecario and p.fechaBaja is null";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);
            return Convert.ToInt32(tabla.Rows[0][0]);
        }

        public static Becario buscarBecarioPorLegajo(int legajo)
        {
            SqlCommand comando = new SqlCommand();

            comando.Parameters.AddWithValue("@legajo", legajo);
            comando.CommandText = "SELECT * FROM Persona p, Becario b WHERE p.idPersona=b.idBecario AND p.legajo=@legajo";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

    }
