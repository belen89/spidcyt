using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

/// <summary>
/// Representa un Proyecto de Investigación.
/// </summary>
public class Proyecto : IEquatable<Proyecto>
    {
        private int id;
        private string nombreCorto;
        private string nombreLargo;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private DateTime fechaFinEstimada;
        private string resumen;
        private Investigador director;
        private Investigador asesorCientifico;
        private List<Investigador> coDirectores;
        private List<Becario> becarios;
        private EstadoProyecto estadoProyecto;
        private List<RecursoEnProyecto> recursos; //hay q castearla a Recurso 
        private List<Producto> productos; //hay q castearla a Producto
        private List<ProyectoCategorizado> proyectoCategorizado;
        private List<Investigador> investigadores;
        private AreaDeInvestigacion areasDeInvestigación;
        private List<Hito> hitos;
        private Tablero tablero;
        private String comentarioDeFinalizacion;
        private Presupuesto presupuesto;

        
           
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Proyecto() 
        {
            coDirectores = new List<Investigador>();
            becarios = new List<Becario>();
            investigadores = new List<Investigador>();
            proyectoCategorizado = new List<ProyectoCategorizado>();
            recursos = new List<RecursoEnProyecto>();
            productos = new List<Producto>();        
        }

        //Popiedades

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string NOMBRELARGO
        {
            get { return nombreLargo; }
            set { nombreLargo = value; }
        }
        public string NOMBRECORTO
        {
            get { return nombreCorto; }
            set { nombreCorto = value; }
        }
        public DateTime FECHAINICIO
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        public DateTime FECHAFIN
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }
        public DateTime FECHAFINESTIMADA
        {
            get { return fechaFinEstimada; }
            set { fechaFinEstimada = value; }
        }
        public string RESUMEN
        {
            get { return resumen; }
            set { resumen = value; }
        }
        public Investigador DIRECTOR
        {
            get { return director; }
            set { director = value; }
        }
        public Investigador ASESORCIENTIFICO
        {
            get { return asesorCientifico; }
            set { asesorCientifico = value; }
        }
        public List<Investigador> CODIRECTORES
        {
            get { return coDirectores; }
            set { coDirectores = value; }
        }
        public List<Becario> BECARIOS
        {
            get { return becarios; }
            set { becarios = value; }
        }
        public EstadoProyecto ESTADOPROYECTO
        {
            get { return estadoProyecto; }
            set { estadoProyecto = value; }
        }
        public List<RecursoEnProyecto> RECURSOS
        {
            get { return recursos; }
            set { recursos = value; }
        }
        public List<Producto> PRODUCTOS
        {
            get { return productos; }
            set { productos = value; }
        }
        public List<ProyectoCategorizado> PROYECTOCATEGORIZADO
        {
            get { return proyectoCategorizado; }
            set { proyectoCategorizado = value; }
        }
        public List<Investigador> INVESTIGADORES
        {
            get { return investigadores; }
            set { investigadores = value; }
        }

        public Presupuesto PRESUPUESTO
        {
            get { return presupuesto; }
            set { presupuesto = value; }
        }

        public List<RequerimientosBecario> REQUERIMIENTOBECARIOS
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        public List<Hito> HITOS
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        public List<Tablero> TABLERO
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        public AreaDeInvestigacion AREASDEINVESTIGACION
        {
            get { return areasDeInvestigación; }
            set { areasDeInvestigación = value; }
        }

        public String COMENTARIODEFINALIZACION
        {
            get { return comentarioDeFinalizacion; }
            set { comentarioDeFinalizacion = value; }
        }

        /// <summary>
        /// Guarda un Proyecto en la Base de Datos.
        /// </summary>
        /// <param name="proyecto"></param>
        public static void guardar(Proyecto proyecto)
        {
            DAOProyecto.insertarProyecto(proyecto);
        }
        /// <summary>
        /// Obtiene un Proyecto de la Base de Datos dependiendo del Id pasado por Parámetro.
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns></returns>
        public static Proyecto get(int idProyecto)
        {
            return DAOProyecto.get(idProyecto);
        }         

        /// <summary>
        /// Obtiene una Lista de todos los Proyectos del Usuario pasado por parámetro
        /// (No debería ser un Método en la clase Usuario?)
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public static List<Proyecto> obtenerProyectosDelUsuario(string nombreUsuario)
        {
            //DataTable tablaProyectosUsuario = DAOProyecto.obtenerTablaProyectosUsuario(nombreUsuario);
            //return tablaProyectosUsuario;
            List<Proyecto> listaProyectosUsuario = DAOProyecto.listarProyectosUsuario(nombreUsuario);
            return listaProyectosUsuario;
        }

        /// <summary>
        /// Obtiene el Objeto Tablero asociado al Proyecto.
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns></returns>
        public static int obtenerTablero(int idProyecto)
        {
            return DAOProyecto.obtenerTablero(idProyecto);
        }
        
        /// <summary>
        /// Compara el objeto con otro Proyecto pasado por parámetro para determinar su igualdad.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
		bool IEquatable<Proyecto>.Equals(Proyecto other)
 		{
            if (this.ID == other.ID)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Inserta el Objeto Proyecto en la Base de Datos.
        /// </summary>
        /// <returns></returns>
        public int insertar()
        {
            this.ESTADOPROYECTO = DAOEstadoProyecto.get("En Desarrollo");

            if (this.esIncubado())
            {
                return DAOProyecto.insertarProyectoIncubado(this);
            }
            else
            {
                return DAOProyecto.insertarProyecto(this);
            }
        }


        /// <summary>
        /// Modifica el Objeto Proyecto en la Base de Datos.
        /// </summary>
        public void modificar()
        {
            if (this.esIncubado())
            {
                DAOProyecto.modificarProyectoIncubado(this);
            }
            else
            {
                DAOProyecto.modificarProyecto(this);
            }
        }
        
        /// <summary>
        /// Agrega un Co-Director con su Fecha de Alta al Proyecto.
        /// </summary>
        /// <param name="coDirectorAInsertar"></param>
        /// <param name="fechaAlta"></param>
        public void agregarCoDirector(Investigador coDirectorAInsertar, DateTime fechaAlta)
        {
            DAOProyecto.insertarCodirectorAProyecto(this.ID, coDirectorAInsertar.ID, fechaAlta);
        }
        
        /// <summary>
        /// Agrega un Investigador con su Fecha de Alta al Proyecto.
        /// </summary>
        /// <param name="investigadorAInsertar"></param>
        /// <param name="fechaAlta"></param>
        public void agregarInvestigador(Investigador investigadorAInsertar, DateTime fechaAlta)
        {
            DAOProyecto.insertarInvestigadorAProyecto(this.ID, investigadorAInsertar.ID, fechaAlta);
        }
        /// <summary>
        /// Agrega un Becario con su Fecha de Alta al Proyecto.
        /// </summary>
        /// <param name="becarioAInsertar"></param>
        /// <param name="fechaAlta"></param>
        public void agregarBecario(Becario becarioAInsertar, DateTime fechaAlta)
        {
            DAOProyecto.insertarBecarioAProyecto(this.ID, becarioAInsertar.ID, fechaAlta);
        }
        /// <summary>
        /// Da de baja a un Co-Director del Proyecto con su Fecha de Baja correspondiente.
        /// </summary>
        /// <param name="coDirectorADarDeBaja"></param>
        /// <param name="fechaBaja"></param>
        public void darDeBajaCoDirector(Investigador coDirectorADarDeBaja, DateTime fechaBaja)
        {
            DAOProyecto.darDeBajaCodirectorPorProyecto(coDirectorADarDeBaja.ID, this.ID, fechaBaja); 
        }
        /// <summary>
        /// Da de baja a un Investigador del Proyecto con su Fecha de Baja correspondiente.
        /// </summary>
        /// <param name="investigadorADarDeBaja"></param>
        /// <param name="fechaBaja"></param>
        public void darDeBajaInvestigador(Investigador investigadorADarDeBaja, DateTime fechaBaja)
        {
            DAOProyecto.darDeBajaInvestigadorPorProyecto(investigadorADarDeBaja.ID, this.ID, fechaBaja);
        }
        /// <summary>
        /// Da de baja a un Becario del Proyecto con su Fecha de Baja correspondiente.
        /// </summary>
        /// <param name="becarioADarDeBaja"></param>
        /// <param name="fechaBaja"></param>
        public void darDeBajaBecario(Becario becarioADarDeBaja, DateTime fechaBaja)
        {
            DAOProyecto.darDeBajaBecarioPorProyecto(becarioADarDeBaja.ID, this.ID, fechaBaja);
        }
        /// <summary>
        /// Determina si un Investigador pasado por parámetro es un investigador del Proyecto.
        /// </summary>
        /// <param name="investigador"></param>
        /// <returns></returns>
        public bool esInvestigadorDelProyecto(Investigador investigador)
        {
            if(this.DIRECTOR.Equals(investigador))
            {
                return true;
            }
            if (this.ASESORCIENTIFICO != null && this.ASESORCIENTIFICO.Equals(investigador))
            {
                return true;
            }
            foreach (Investigador item in CODIRECTORES)
            {
                if (item.Equals(investigador))
                {
                    return true;
                }
            }
            foreach (Investigador item in INVESTIGADORES)
            {
                if (item.Equals(investigador))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Determina si un Becario pasado por parámetro es un beacrio del Proyecto.
        /// </summary>
        /// <param name="becario"></param>
        /// <returns></returns>
        public bool esBecarioDelProyecto(Becario becario)
        {
            foreach (Becario item in this.BECARIOS)
            {
                if (item.Equals(becario))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Da de Baja el Proyecto.
        /// </summary>
        /// <param name="dateTime"></param>
        public void darDeBaja(DateTime dateTime)
        {
            this.ESTADOPROYECTO = DAOEstadoProyecto.obtenerEstadoFinalizado();
            this.FECHAFIN = dateTime;
            DAOProyecto.darDeBajaProyecto(this, dateTime);
        }
        /// <summary>
        /// Finaliza el Proyecto.
        /// </summary>
        /// <param name="fechaFinalizacion"></param>
        public void finalizar(DateTime fechaFinalizacion)
        {
            this.ESTADOPROYECTO = DAOEstadoProyecto.obtenerEstadoFinalizado();
            this.FECHAFIN = fechaFinalizacion;
            DAOProyecto.darDeBajaProyecto(this, fechaFinalizacion);
        }
        /// <summary>
        /// Cancela un Proyecto.
        /// </summary>
        /// <param name="fechaCancelacion"></param>
        public void cancelar(DateTime fechaCancelacion)
        {
            this.ESTADOPROYECTO = DAOEstadoProyecto.obtenerEstadoFinalizado();
            this.FECHAFIN = fechaCancelacion;
            DAOProyecto.darDeBajaProyecto(this, fechaCancelacion);

        }
        
        /// <summary>
        /// Determina si un Proyecto es Incubado o no.
        /// </summary>
        /// <returns></returns>
        public bool esIncubado()
        {
            Boolean esIncubado = false;

            foreach (ProyectoCategorizado item in this.PROYECTOCATEGORIZADO)
            {
                if (item.esIncubado())
                { esIncubado = true; }                
            }

            return esIncubado;
        }
        /// <summary>
        /// Determina si el Proyecto esta Categorizado como UTN.
        /// </summary>
        /// <returns></returns>
        public bool esUTN()
        {
            Boolean esUTN = false;

            foreach (ProyectoCategorizado item in this.PROYECTOCATEGORIZADO)
            {
                if (item.esUTN())
                { esUTN = true; }
            }

            return esUTN;
        }
        /// <summary>
        /// Determina si el Proyecto está Categorizado en Nacional.
        /// </summary>
        /// <returns></returns>
        public bool esConIncentivo()
        {
            Boolean esConIncentivo = false;

            foreach (ProyectoCategorizado item in this.PROYECTOCATEGORIZADO)
            {
                if (item.esConIncentivo())
                { esConIncentivo = true; }
            }

            return esConIncentivo;
        }
        /// <summary>
        /// Retorna el total de Proyectos Activos en el Sistema.
        /// </summary>
        /// <returns></returns>
        public static int totalDeProyectosActivos()
        {
            return DAOProyecto.totalDeProyectosActivos();
        }
        /// <summary>
        /// Retorna el nombre del Área de Investigación en la que esta investigando el Proyecto.
        /// </summary>
        /// <returns></returns>
        public string mostrarNombreAreaDeInvestigación()
        {
            if (this.AREASDEINVESTIGACION != null)
            {
                return AREASDEINVESTIGACION.NOMBRE;
            }
            else
            {
                return "No Asignada";
            }
        }
//public void asociarPresupuesto()
//{
//            DAOProyecto.asociarPresupuesto(this.ID, this.PRESUPUESTO.ID);
//}

        //public void insertarIntegrante(int idIntegrante, DateTime fechaAlta, string rol)
        //{
        //    switch (rol) //Vemos cual Rol se esta ingresando
        //    {
        //        case "Co-Director":
        //            Investigador coDirector = DAOInvestigador.get(idIntegrante);

        //            this.agregarCoDirector(coDirector, fechaAlta);
        //            this.CODIRECTORES.Add(coDirector);                   
        //            break;
        //        case "Investigador":
        //            Investigador investigador = DAOInvestigador.get(idIntegrante);

        //            this.agregarCoDirector(investigador, fechaAlta);
        //            this.CODIRECTORES.Add(investigador);  

        //            break;
        //        case "Becario":
        //            Becario becario = DAOBecario.get(idIntegrante);

        //            this.agregarBecario(becario, fechaAlta);
        //            this.BECARIOS.Add(becario);
        //            break;

        //        default:
        //            break;
        //    }
        //}
        /// <summary>
        /// Determina si una Persona es Integrante de este Proyecto.
        /// Recibe el ID del Integrante como parámetro.
        /// </summary>
        /// <param name="idIntegrante"></param>
        /// <returns></returns>
        public bool esIntegranteDelProyecto(int idIntegrante)
        {
            if (this.DIRECTOR.ID == idIntegrante)
                return true;

            if (this.ASESORCIENTIFICO != null && this.ASESORCIENTIFICO.ID == idIntegrante)
                return true;

            if(this.INVESTIGADORES != null)
                foreach (var item in this.INVESTIGADORES)
                {
                    if (item.ID == idIntegrante)
                        return true;
                }

            if (this.CODIRECTORES != null)
                foreach (var item in this.CODIRECTORES)
                {
                    if (item.ID == idIntegrante)
                        return true;
                }

            if (this.BECARIOS != null)
                foreach (var item in this.BECARIOS)
                {
                    if (item.ID == idIntegrante)
                        return true;
                }

            return false;
        }
        /// <summary>
        /// Devuelve el número de integrantes del Proyecto.
        /// </summary>
        /// <returns></returns>
        public int numeroDeIntegrantes()
        {
            //Siempre tiene un Director
            int integrantes = 1;
            if (this.CODIRECTORES != null)
                integrantes += this.CODIRECTORES.Count();
            if (this.INVESTIGADORES != null)
                integrantes += this.INVESTIGADORES.Count();
            if (this.BECARIOS != null)
                integrantes += this.BECARIOS.Count();
            if (this.ASESORCIENTIFICO != null)
                integrantes += 1;

            return integrantes;            
        }
        
        /// <summary>
        /// Obtiene la Categorización "Con Incentivo" del Proyecto
        /// </summary>
        /// <returns>Devuelve un Objeto ProyectoCategorizado correspondiente a la Categorización "Con Incentivo"</returns>
        public ProyectoCategorizado getCategorizacionConIncentivo()
        {
            if (this.PROYECTOCATEGORIZADO != null)
            {
                foreach (ProyectoCategorizado item in this.PROYECTOCATEGORIZADO)
                {
                    if (item.esConIncentivo())
                        return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Obtiene la Categorización UNT del Proyecto
        /// </summary>
        /// <returns>Devuelve un Objeto ProyectoCategorizado correspondiente a la Categorización "Con Incentivo"</returns>
        public ProyectoCategorizado getCategorizacionUTN()
        {
            if (this.PROYECTOCATEGORIZADO != null)
            {
                foreach (ProyectoCategorizado item in this.PROYECTOCATEGORIZADO)
                {                    
                    if (item.esUTN())
                        return item;
                }
            }
            return null;
        }
        
        /// <summary>
        /// Elimina la Categoría UTN del Proyecto
        /// </summary>
        public void eliminarCategoríaUTN()
        {
            if (this.esUTN())
            {
                DAOProyecto.eliminarCategoríaUTN(this);
            }
        }
        /// <summary>
        /// Elimina la Categoría Con Incentivo del Proyecto
        /// </summary>
        public void eliminarCategoríaConIncentivo()
        {
            if (this.esConIncentivo())
            {
                DAOProyecto.eliminarCategoríaConIncentivo(this);
            }
        }
    }
