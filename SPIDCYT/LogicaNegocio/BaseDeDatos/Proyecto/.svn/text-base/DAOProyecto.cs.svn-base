using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAOProyecto
    {
        private static Proyecto Transformar(DataRow fila)
    {
        if (fila == null) { return null; }
        Proyecto proyecto = new Proyecto();

        proyecto.ID = Convert.ToInt32(fila["idProyecto"]);
        proyecto.NOMBRECORTO = Convert.ToString(fila["nombreCorto"]);
        proyecto.NOMBRELARGO = Convert.ToString(fila["nombreLargo"]);
        proyecto.FECHAINICIO = Convert.ToDateTime(fila["fechaInicio"], new CultureInfo("es-ES"));
        if (fila["fechaFin"] != DBNull.Value)
        { proyecto.FECHAFIN = Convert.ToDateTime(fila["fechaFin"], new CultureInfo("es-ES")); }
        proyecto.ESTADOPROYECTO = DAOEstadoProyecto.get(Convert.ToInt32(fila["estado"]));
        proyecto.RESUMEN = Convert.ToString(fila["resumen"]);
        if (fila["director"] != DBNull.Value)
        { proyecto.DIRECTOR = DAOInvestigador.get(Convert.ToInt32(fila["director"])); }
        proyecto.FECHAFINESTIMADA = Convert.ToDateTime(fila["fechaFinEstimada"], new CultureInfo("es-ES"));
        proyecto.RECURSOS = DAORecursoEnProyecto.listarRecursosActualesEnProyecto(Convert.ToInt32(fila["idProyecto"]));
        proyecto.CODIRECTORES = listarCodirectoresActivosDelProyecto(Convert.ToInt32(fila["idProyecto"]));
        if (proyecto.CODIRECTORES == null)
        { proyecto.CODIRECTORES = new List<Investigador>(); }

        //Tendría que listar TODOS los Integrantes, pero por las dudas comento
        //proyecto.INVESTIGADORES = listarInvestigadoresActivosDelProyecto(Convert.ToInt32(fila["idProyecto"]));
        //if (proyecto.INVESTIGADORES == null)
        //{ proyecto.INVESTIGADORES = new List<Investigador>(); }

        proyecto.INVESTIGADORES = listarInvestigadoresDelProyecto(Convert.ToInt32(fila["idProyecto"]));
        if (proyecto.INVESTIGADORES == null)
        { proyecto.INVESTIGADORES = new List<Investigador>(); }

        proyecto.BECARIOS = listarBecariosActivosDelProyecto(Convert.ToInt32(fila["idProyecto"]));
        if (proyecto.BECARIOS == null)
        { proyecto.BECARIOS = new List<Becario>(); }

        proyecto.PROYECTOCATEGORIZADO = DAOProyectoCategorizado.get(Convert.ToInt32(fila["idProyecto"]));
        if (proyecto.PROYECTOCATEGORIZADO == null)
        { proyecto.PROYECTOCATEGORIZADO = new List<ProyectoCategorizado>(); }
        
        if (fila["areaDeInvestigacion"] != DBNull.Value)
        { proyecto.AREASDEINVESTIGACION = DAOAreaDeInvestigacion.get(Convert.ToInt32(fila["areaDeInvestigacion"])); }

        if (fila["asesorCientifico"] != DBNull.Value)
        { proyecto.ASESORCIENTIFICO = DAOInvestigador.get(Convert.ToInt32(fila["asesorCientifico"])); }

        if (fila["presupuesto"] != DBNull.Value)
        {
            proyecto.PRESUPUESTO = DAOPresupuesto.get(Convert.ToInt32(fila["presupuesto"]));
        }

        if (fila["comentarioDeFinalizacion"] != DBNull.Value)
        {
            proyecto.COMENTARIODEFINALIZACION = Convert.ToString(fila["comentarioDeFinalizacion"]);
        }
        return proyecto;
    }
        
    }
