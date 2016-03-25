using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa un Tipo de Categoría en la que puede categorizar un Investigador.
/// Categorias:
/// # UTN
/// # Nacional
/// </summary>
    public class TipoCategoriaInvestigador
    {
        private int id;
        private string nombre;
        private string descripcion;


        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }



        /// <summary>
        /// Determina si es Nacional
        /// </summary>
        /// <returns></returns>
        internal bool esNacional()
        {
            if (this.NOMBRE == "Nacional")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determina si es UTN
        /// </summary>
        /// <returns></returns>
        internal bool esUTN()
        {
            if (this.NOMBRE == "UTN")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Método para determinar si el Tipo de Categoría está siendo usado.
        /// Para no eliminar los que están en uso.
        /// </summary>
        /// <param name="idTipoCategoriaInvestigador"></param>
        /// <returns></returns>
        public static bool estaEnUso(int idTipoCategoriaInvestigador)
        {
            List<Investigador> investigadores = DAOInvestigador.listarInvestigadores();
            TipoCategoriaInvestigador tipoCategoriaInvestigador = DAOTipoCategoriaInvestigador.get(idTipoCategoriaInvestigador);
            
            //Si algún Investigador está usando la Categoría, return true.
            foreach (Investigador item in investigadores)
            {
                if (item.CATEGORIANACIONAL != null && tipoCategoriaInvestigador.esNacional())
                {
                    return true;
                }
                if (item.CATEGORIAUTN != null && tipoCategoriaInvestigador.esUTN())
                {
                    return true;
                }
            }

            //Ningun Investigador está usando la Categoría.
            return false;
        }
    }

