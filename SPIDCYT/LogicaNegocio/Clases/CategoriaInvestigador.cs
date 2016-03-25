using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa la Categoría de un Investigador.
/// Categorías UTN: A B C D E F G
/// Categorías Nacional: 5 4 3 2 1
/// </summary>
    public class CategoriaInvestigador
    {
        private int id;
        private TipoCategoriaInvestigador tipo;
        private string nombre;
        private string descripcion;

        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public TipoCategoriaInvestigador TIPO
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value; }
        }
        

        /// <summary>
        /// Obtiene una Categoría según el ID pasado por parámetro
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        internal static CategoriaInvestigador getCategoria(int idCategoria)
        {
            return DAOCategoriaInvestigador.get(idCategoria);
        }
        /// <summary>
        /// Determina si la Categoría habilita a un Investigador a ser director de Proyectos.
        /// </summary>
        /// <returns></returns>
        public bool habilitaDireccionDeProyectos()
        {
            if (this.NOMBRE == "A Orientación Ciencias de la Ingeniería y Tecnologías" || this.NOMBRE == "B Orientación Ciencias de la Ingeniería y Tecnologías" || this.NOMBRE == "C Orientación Ciencias de la Ingeniería y Tecnologías" || this.NOMBRE == "1" || this.NOMBRE == "2" || this.NOMBRE == "3")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Determina si la Categoría habilita a un Investigador a ser Asesor Científico.
        /// </summary>
        /// <returns></returns>
        public bool habilitaAsesorCientifico()
        {
            return habilitaDireccionDeProyectos();
        }
        /// <summary>
        /// Determina si la Categoría habilita a un Investigador a ser Director de Proyecto con la condición
        /// de tener un asesor científico.
        /// </summary>
        /// <returns></returns>
        public bool habilitaDireccionDeProyectosConAsesorCientífico()
        {
            if (this.NOMBRE == "D Ambas Orientaciones" || this.NOMBRE == "4")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determina si esta es una categoría del Nacional.
        /// </summary>
        /// <returns></returns>
        internal bool esNacional()
        {
            if (this.TIPO.esNacional())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determina es una categoría UTN.
        /// </summary>
        /// <returns></returns>
        internal bool esUTN()
        {
            if (this.TIPO.esUTN())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determina si la Categoría está en uso.
        /// Para validar que no se eliminen Categorias usadas por Investigadores
        /// </summary>
        /// <param name="idCategoriaInvestigador"></param>
        /// <returns></returns>
        public static bool estaEnUso(int idCategoriaInvestigador)
        {
            List<Investigador> investigadores = DAOInvestigador.listarInvestigadores();            
            //Si algún INvestigador está usando la Categoría, return true.
            foreach (Investigador item in investigadores)
            {
                if (item.CATEGORIANACIONAL != null && item.CATEGORIANACIONAL.ID == idCategoriaInvestigador)
                {
                    return true;
                }
                if (item.CATEGORIAUTN != null && item.CATEGORIAUTN.ID == idCategoriaInvestigador)
                {
                    return true;
                }
            }

            //Ningun Investigador está usando la Categoría.
            return false;
        }
    }

