using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Clase Abstracta para representar una Persona dentro del Sistema
/// </summary>
public abstract class Persona : IEquatable<Persona>
    {
        private int id;
        private string nombre;
        private string apellido;
        private long legajo;
        private string telefono;
        private string mail;
        private Usuario usuario;
        private DateTime fechaBaja;
        private DateTime fechaAlta;    



        //GETTER Y SETTERS 
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
        public string APELLIDO
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public long LEGAJO
        {
            get { return legajo; }
            set { legajo = value; }
        }
        public string TELEFONO
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string MAIL
        {
            get { return mail; }
            set { mail = value; }
        }
        public Usuario USUARIO
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public DateTime FECHABAJA
        {
            get { return fechaBaja; }
            set { fechaBaja = value; }
        }
        public DateTime FECHAALTA
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
        }

        /// <summary>
        /// Compara el objeto Persona con otro pasado por parámetro para determinar su igualdad.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Persona other)
        {
          if (this.ID == other.ID)
                return true;
            else
                return false;        
        }
        /// <summary>
        /// Método abstracto para mostrar los datos básicos de una persona.
        /// </summary>
        /// <returns></returns>
        public abstract String datosParaDll();

    /// <summary>
    /// Comprueba que no exista el mail registrado anteriormente
    /// </summary>
    /// <param name="mail"></param>
    /// <param name="idPersona"></param>
    /// <returns>Devuelve true si el mail no existe. </returns>
        public static bool checkMailExistente(string mail, int idPersona)
        {
            List<Investigador> investigadores = DAOInvestigador.listarInvestigadores();
            foreach (Investigador item in investigadores)
            {
                if (item.MAIL.Equals(mail))
                    if(idPersona == -1) // Si viene -1 es Alta de Persona
                    {
                        return true;
                    }
                else
	                {
                        if (item.ID != idPersona) // Es mail de otra persona
                        return true;
	                }                       
            }

            List<Becario> becarios = DAOBecario.listarBecarios();
            try
            {
                foreach (Becario item in becarios)
                {
                    if (item.MAIL.Equals(mail))
                        if (idPersona == -1) // Si viene -1 es Alta de Persona
                        {
                            return true;
                        }
                        else
                        {
                            if (item.ID != idPersona) // Es mail de otra persona
                                return true;
                        }
                }
            }
            catch (Exception) { }

            return false; //No existe el mail en la BD
        }
    }
