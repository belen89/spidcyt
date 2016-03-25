using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// Representa un Investigador registrado en la Secretaría de Investigación.
/// </summary>
public class Investigador : Persona
{
        private CategoriaInvestigador categoriaUTN;
        private CategoriaInvestigador categoriaNacional;
        private List<HistorialCategoria> historialCategoria;
        private DateTime fechaCategorizacionUTN;
        private DateTime fechaCategorizacionNacional;        

        public List<HistorialCategoria> HISTORIALCATEGORIA
        {
            get { return historialCategoria; }
            set { historialCategoria = value; }
        }
        public CategoriaInvestigador CATEGORIAUTN
        {
            get { return categoriaUTN; }
            set { categoriaUTN = value; }
        }
        public CategoriaInvestigador CATEGORIANACIONAL
        {
            get { return categoriaNacional; }
            set { categoriaNacional = value; }
        }
        public DateTime FECHACATEGORIZACIONUTN
        {
            get { return fechaCategorizacionUTN; }
            set { fechaCategorizacionUTN = value; }
        }
        public DateTime FECHACATEGORIZACIONNACIONAL
        {
            get { return fechaCategorizacionNacional; }
            set { fechaCategorizacionNacional = value; }
        }
        
        /// <summary>
        /// Constructuor por Defecto de la Clase Investigador
        /// </summary>
        public Investigador()
        {
            historialCategoria = new List<HistorialCategoria>();
        }

        /// <summary>
        /// Retorna un objeto Investigador según el ID del mismo.
        /// </summary>
        /// <param name="idInvestigador">ID del Investigador</param>
        /// <returns>Objeto Investigador</returns>
        public static Investigador getInvestigador(int idInvestigador)
        {
            return DAOInvestigador.get(idInvestigador);
        }

        /// <summary>
        /// Guardar un nuevo Investigador con sus proyectos asociados.
        /// </summary>
        /// <param name="investigador"></param>
        /// <param name="proyectosCodirector"></param>
        /// <param name="proyectoInvestigador"></param>
        public static void guardar(Investigador investigador, List<Proyecto> proyectosCodirector, List<Proyecto> proyectoInvestigador)
        {
            DAOInvestigador.insertarInvestigador(investigador,proyectosCodirector, proyectoInvestigador );
        }

        /// <summary>
        /// Retorna True si el Investigador cumple los requisitos de Categoría para ser un Director.
        /// </summary>
        /// <returns></returns>
        public Boolean puedoSerDirector()
        {
            if (this.CATEGORIAUTN != null)
                {
                    if (this.CATEGORIAUTN.habilitaDireccionDeProyectos() || this.CATEGORIAUTN.habilitaDireccionDeProyectosConAsesorCientífico())
                    {
                        return true;
                    }
                }
            else if (this.CATEGORIANACIONAL != null)
            {
                if (this.CATEGORIANACIONAL.habilitaDireccionDeProyectos() || this.CATEGORIANACIONAL.habilitaDireccionDeProyectosConAsesorCientífico())
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Retorna True si el Investigador cumple los requisitos de Categoría para ser un Asesor Científico.
        /// </summary>
        /// <returns></returns>
        public Boolean puedoSerAsesorCientífico()
        {
            if (this.CATEGORIAUTN != null)
            {
                if (this.CATEGORIAUTN.habilitaAsesorCientifico())
                {
                    return true;
                }
            }
            else if (this.CATEGORIANACIONAL != null)
            {
                if (this.CATEGORIANACIONAL.habilitaAsesorCientifico())
                {
                    return true;
                }
            }

            return false;
        }        

        /// <summary>
        /// Retorna True si el Investigador necesita de un Asesor Científico para ser Director.
        /// </summary>
        /// <returns></returns>
        public Boolean necesitoAsesorCientificoParaSerDirector()
        {
         /*
         * Los directores con categoia D o IV necesitan un Asesor Cientifico
         * Hago una chequeo cruzado, para preguntar si alguna de mis categorías me permite.
         * Puede ser que la Categoría NACIONAL no me permita, pero si la UTN.
         * */
            if (this.CATEGORIANACIONAL!= null && this.CATEGORIANACIONAL.habilitaDireccionDeProyectosConAsesorCientífico())
            {
                //Si no tengo Categoría UTN, necesito Asesor
                if (this.CATEGORIAUTN == null)
                {
                    return true;
                }
                //Si tengo y esta NO (!) me habilita a ser Director, necesito Asesor
                else if(!this.CATEGORIAUTN.habilitaDireccionDeProyectos())
                {
                    return true;
                }
                
            }            
            if (this.CATEGORIAUTN != null && this.CATEGORIAUTN.habilitaDireccionDeProyectosConAsesorCientífico())
            {
                //Si no tengo Categoría NACIONAL, necesito Asesor
                if (this.CATEGORIANACIONAL == null)
                {
                    return true;
                }
                //Si tengo y esta NO (!) me habilita a ser Director, necesito Asesor
                else if(!this.CATEGORIANACIONAL.habilitaDireccionDeProyectos())
                {
                    return true;
                }
            }

            //Alguna de mis dos categorías me habilita a ser Director sin necesitar Asesor.
            return false;
        }
        /// <summary>
        /// Retorna True si el Investigador cumple los requisitos de Categoría para ser Co-Director.
        /// </summary>
        /// <returns></returns>
        public bool puedoSerCoDirector()
        {
            //Mismos requisitos para ser Director
            return puedoSerDirector();
        }

        //public DateTime obtenerUltimaFechaCategorizaciónUTN()
        //{
        //    DateTime mayorFechaUTN = new DateTime();
        //    if (historialCategoria != null)
        //    {
        //        foreach (HistorialCategoria item in historialCategoria)
        //        {
        //            if (item.CATEGORIAINVESTIGADOR.TIPO.esUTN())
        //            {
        //                if (mayorFechaUTN == null) { mayorFechaUTN = item.FECHADESDE; }
        //                else if (item.FECHADESDE > mayorFechaUTN) { mayorFechaUTN = item.FECHADESDE; }
        //            }
        //        }
        //    }
            

        //    return mayorFechaUTN;
        //}

        //public DateTime obtenerUltimaFechaCategorizaciónNacional()
        //{
        //    DateTime mayorFechaNacional = new DateTime();
        //    if (historialCategoria != null)
        //    {             
        //        foreach (HistorialCategoria item in historialCategoria)
        //        {
        //            if (item.CATEGORIAINVESTIGADOR.TIPO.esNacional())
        //            {
        //                if (mayorFechaNacional == null) { mayorFechaNacional = item.FECHADESDE; }
        //                else if (item.FECHADESDE > mayorFechaNacional) { mayorFechaNacional = item.FECHADESDE; }
        //            }

        //        }
        //    }

        //    return mayorFechaNacional;
        //}
        
        /// <summary>
        /// Método Heredado de la clase Persona.
        /// Devuelve un String con: Nombre, Apellido, Legajo y Categorias.
        /// Usado para mostrar datos en los DropDownList de la Interfaz.
        /// </summary>
        /// <returns></returns>
        public override String datosParaDll()
        {
            String nombreAMostrar = this.APELLIDO + ", " + this.NOMBRE + " - Legajo: " + this.LEGAJO;

            if (this.CATEGORIAUTN != null && this.CATEGORIANACIONAL != null)
                nombreAMostrar += " - Categoría: " + this.CATEGORIANACIONAL.NOMBRE + "/" + this.CATEGORIAUTN.NOMBRE;
            else if (this.CATEGORIAUTN != null)
                nombreAMostrar += " - Categoría: " + this.CATEGORIAUTN.NOMBRE;
            else if (this.CATEGORIANACIONAL != null)
                nombreAMostrar += " - Categoría: " + this.CATEGORIANACIONAL.NOMBRE;

            return nombreAMostrar;
        }

        /// <summary>
        /// Inserta el objeto Investigador en la Base de Datos.
        /// </summary>
        public void insertar()
        {
            DAOInvestigador.insertarInvestigador(this);
        }
        /// <summary>
        /// Modifica el objeto en la Base de Datos
        /// </summary>
        public void modificar()
        {
            DAOInvestigador.guardarInvestigador(this);
        }
        /// <summary>
        /// Retorna True si el Investigador tiene un Usuario Creado.
        /// </summary>
        /// <returns></returns>
        public bool tieneUsuarioCreado()
        {
           return DAOInvestigador.tieneUsuarioCreado(this);
        }
        /// <summary>
        /// Asigna un usuario al objeto Investigador.
        /// </summary>
        public void asignarUsuario()
        {
            DAOInvestigador.asignarUsuario(this);
        }

        /// <summary>
        /// Método para Re Categorizar un nuevo Investigador
        /// </summary>
        /// <param name="nuevaCategoria"> Categoría del Investigador</param>
        /// <param name="fechaCategorizacion">Fecha en la que categorizó</param>
        public void reCategorizar(CategoriaInvestigador nuevaCategoria, DateTime fechaCategorizacion)
        {
            HistorialCategoria viejaCategoria = null;
            if(nuevaCategoria.esNacional())
            {
                if (this.CATEGORIANACIONAL != null)
                {
                    viejaCategoria = new HistorialCategoria();
                    viejaCategoria.CATEGORIAINVESTIGADOR = this.CATEGORIANACIONAL;
                    viejaCategoria.FECHADESDE = this.FECHACATEGORIZACIONNACIONAL;
                    viejaCategoria.FECHAHASTA = fechaCategorizacion;
                }

                this.CATEGORIANACIONAL = nuevaCategoria;
                this.FECHACATEGORIZACIONNACIONAL = fechaCategorizacion;
            }
            if (nuevaCategoria.esUTN())
            {
                if (this.CATEGORIAUTN != null)
                {
                    viejaCategoria = new HistorialCategoria();
                    viejaCategoria.CATEGORIAINVESTIGADOR = this.CATEGORIAUTN;
                    viejaCategoria.FECHADESDE = this.FECHACATEGORIZACIONUTN;
                    viejaCategoria.FECHAHASTA = fechaCategorizacion;
                }
                this.CATEGORIAUTN = nuevaCategoria;
                this.FECHACATEGORIZACIONUTN = fechaCategorizacion;
            }

            DAOInvestigador.reCategorizar(this, viejaCategoria);
            
        }
        
        /// <summary>
        /// Agrega un nuevo Historial de Categoría al historial del Investigador
        /// </summary>
        /// <param name="viejaCategoria"></param>
        public void agregarCategoriaAlHistorialDeCategorizacion(HistorialCategoria viejaCategoria)
        {
            DAOInvestigador.agregarCategoriaAlHistorialDeCategorizacion(this, viejaCategoria);
        }
        /// <summary>
        /// Asigna un Producto registrado al objeto Investigador.
        /// </summary>
        /// <param name="idProducto"></param>
        public void asignarProducto(int idProducto)
        {
            DAOInvestigador.asignarProducto(idProducto, this.ID);
        }
        /// <summary>
        /// Método estático que devuelve el total de Investigadores Activos en el Sistema.
        /// </summary>
        /// <returns></returns>
        public static int totalDeInvestigadoresActivos()
        {
            return DAOInvestigador.totalDeInvestigadoresActivos();
        }

        /// <summary>
        /// Da de baja un Investigador en el sistema
        /// </summary>
        /// <param name="fechaBaja"></param>
        public void darDeBaja(DateTime fechaBaja)
        {
            this.FECHABAJA = fechaBaja;
            DAOInvestigador.darDeBajaInvestigador(this);
        }

        /// <summary>
        /// Valida si la fecha pasada por parámetro se encuentra incluida dentro de algun
        /// historial de categorización del Investigador.
        /// </summary>
        /// <param name="fechaCategorizacion"></param>
        /// <returns>bool</returns>
        public bool fechaContenidaDentroDeUnaCategorizacion(DateTime fechaCategorizacion, TipoCategoriaInvestigador tipoCategoria)
        {
            //Nos fijamos que no esté incluida en ningun Historial de Categoría
            if (this.HISTORIALCATEGORIA != null)
            {
                foreach (HistorialCategoria item in this.HISTORIALCATEGORIA)
                {
                    if (item.CATEGORIAINVESTIGADOR.TIPO.ID == tipoCategoria.ID)
                        if (item.fechaContenidaDentroDeUnaCategorizacion(fechaCategorizacion))
                            return true;
                }                
            }

            //Nos fijamos que no sea igual a la fecha que categorizó en la Categoría Nacional Actual
            if (this.CATEGORIANACIONAL != null)
            if (tipoCategoria.ID == this.CATEGORIANACIONAL.ID && fechaCategorizacion == this.FECHACATEGORIZACIONNACIONAL)
                return true;

            //Nos fijamos que no sea igual a la fecha que categorizó en la Categoría UTN Actual
            if (this.CATEGORIAUTN != null)
            if (tipoCategoria.ID == this.CATEGORIAUTN.ID && fechaCategorizacion == this.FECHACATEGORIZACIONUTN)
                return true;

            return false;
        }
        /// <summary>
        /// Método que devuelve los Proyectos En Desarrollo en los cuales participa el Investigador
        /// </summary>
        /// <returns>Lista de Proyectos en los que Participa</returns>
        public List<Proyecto> proyectosEnLosQueParticipoActualmente()
        {
            List<Proyecto> proyectos = new List<Proyecto>();

            proyectos.AddRange(DAOInvestigador.listarProyectosActualesComoInvestigador(this.ID));
            proyectos.AddRange(DAOInvestigador.listarProyectosActualesComoCodirector(this.ID));
            proyectos.AddRange(DAOInvestigador.listarProyectosActualesComoDirector(this.ID));

            return proyectos;
        }
        /// <summary>
        /// Método que devuelve el número de Proyectos en los que Participa el Investigador
        /// </summary>
        /// <returns></returns>
        public int cantidadDeProyectosEnLosQueParticipoActualmente()
        {
            return proyectosEnLosQueParticipoActualmente().Count();
        }

}

