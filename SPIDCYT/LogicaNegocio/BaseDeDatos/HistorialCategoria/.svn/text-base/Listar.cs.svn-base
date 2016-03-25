using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


public sealed partial class DAOHistorialCategoria
{

        public static List<HistorialCategoria> listarHistorialCategoriaInvestigador(int idInvestigador)
        {
            SqlCommand comando = new SqlCommand();
            List<HistorialCategoria> listaHistorialCategorias = new List<HistorialCategoria>();

            comando.Parameters.AddWithValue("@idInvestigador", idInvestigador);
            comando.CommandText = "SELECT * FROM HistorialCategoria WHERE investigador = @idInvestigador";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);

            if (tabla.Rows.Count == 0)
                return null;
            else
            {
                for (int i = 0; i < tabla.Rows.Count;i++ )
                {
                    listaHistorialCategorias.Add(Transformar(tabla.Rows[i]));
                    
                }


            }
            return listaHistorialCategorias;
        }

    }
