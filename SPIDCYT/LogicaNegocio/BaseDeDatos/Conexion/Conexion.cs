using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public sealed class Conexion
    {
        private static Conexion instance = null;
        private Conexion() { }

        /// <summary>
        /// Singleton de Base de Datos
        /// </summary>
        /// <returns></returns>
        public static Conexion getInstance()
        {
            if (instance == null)
            {
                instance = new Conexion();
            }
            return instance;
        }
        /// <summary>
        /// Para establcer la Conexion Con la Base de Datos
        ///  
        /// </summary>    
        public SqlConnection conexionBD
        {
            get
            {
                return new SqlConnection( ConfigurationManager.ConnectionStrings["SPIDCYTConnectionString"].ConnectionString);
            }
        }

        public static DataTable consultar(SqlCommand comando)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SPIDCYTConnectionString"].ConnectionString))
            {
                connection.Open();
                comando.Connection = connection;
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
        
        }

        public static void ejecutarComando(SqlCommand comando)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SPIDCYTConnectionString"].ConnectionString))
            {
                connection.Open();
                comando.Connection = connection;
                comando.ExecuteNonQuery();
            }

        }

        public static int ejecutarComandoDevolviendoID(SqlCommand comando)
        {
            using (SqlConnection connection =new SqlConnection( ConfigurationManager.ConnectionStrings["SPIDCYTConnectionString"].ConnectionString))
            {
                connection.Open();
                comando.Connection = connection;
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }
    }
