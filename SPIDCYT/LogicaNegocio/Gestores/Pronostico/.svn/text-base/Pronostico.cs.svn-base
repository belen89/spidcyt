using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

/// <summary>
/// Clase pronóstico, esta en cargada de obtener predicciones sobre los valores referenciados. 
/// </summary>
public class Pronostico
{
    private List<double> cantidades;
    private List<string> referencias;
    private double alfa;
    private double beta;
    private List<double> estimadoDeTendencia;
    private List<double> serieSuavizada;
    private List<double> pronosticoParaUnPeriodo;

    public Pronostico() 
    {
        cantidades = new List<double>();
        
        referencias = new List<string>();
        alfa = 0;
        beta = 0;
        estimadoDeTendencia = new List<double>();
        serieSuavizada = new List<double>();
        pronosticoParaUnPeriodo = new List<double>();
    
    
    }
    /// <summary>
    /// Constructor de la clase de Pronóstico
    /// </summary>
    /// <param name="cantidades"> Valores pasados que se utilizaran para construir los valores futuros</param>
    /// <param name="referencias">Valores para armar la tabla de salida, por ejemplo los años o periodos a los que pertencen las cantidades</param>
    /// <param name="alfa">constante de suavización, entre 0 y 1</param>
    /// <param name="beta">constate de suavización para el estimado de la tendencia </param>
    public Pronostico(List<double> cantidades, List<string> referencias, double alfa, double beta)
    {
        this.cantidades = cantidades;
        this.cantidades.Insert(0, 0);
        this.referencias = referencias;
        this.alfa=alfa;
        this.beta=beta;
        this.estimadoDeTendencia = new List<double>(); // T
        this.serieSuavizada = new List<double>(); // L
        this.pronosticoParaUnPeriodo = new List<double>(); //F
    }


    public List<double> CANTIDADES
    {
        get { return cantidades; }
        set { cantidades = value; }
    }
    public List<string> REFERENCIA
    {
        get { return referencias; }
        set { referencias = value; }
    }

    public double ALFA
    {
        get { return alfa; }
        set { alfa = value; }
    }
    public double BETA
    {
        get { return beta; }
        set { beta = value; }
    }
    public List<double> ESTIMADODETENDENCIA
    {
        get { return estimadoDeTendencia; }
        set { estimadoDeTendencia = value; }
    }
    public List<double> SERIESUAVIZADA
    {
        get { return serieSuavizada; }
        set { serieSuavizada = value; }
    }

    /// <summary>
    /// Realiza el pronóstico para los datos brindados
    /// </summary>
    /// <returns>Devuelva una tabla con los cálculos</returns>
    public DataTable pronosticame() 
    {
        //checkear que haya datos suficientes 
        if (cantidades.Count >= 3)
        {
            //cantidades.Insert(0, 0);
            double t;
            double l;
            double f;
            //valores iniciales para l y t, usando como criterio que t será igual a la diferencia de los dos primeros valores reales 
            //y l igual al valor del primer valor real 
            l = cantidades[1];
            t = cantidades[2] - cantidades[1];
            f = 0;
            estimadoDeTendencia.Add(t);
            serieSuavizada.Add(l);
            pronosticoParaUnPeriodo.Add(f);

            for (int i = 0; i < cantidades.Count; i++)
             {
                f = l + t;
                pronosticoParaUnPeriodo.Add(f);
                l = alfa * (cantidades[i]) + (1 - alfa) * (l + t);
                serieSuavizada.Add(l);
                t = beta * (l - serieSuavizada[serieSuavizada.Count - 2]) + (1 - beta) * t;
                estimadoDeTendencia.Add(t);
            }
            f = l + t;
            pronosticoParaUnPeriodo.Add(f);

            DataTable resultado= new DataTable();
            resultado.Columns.Add("Año");
            resultado.Columns.Add("Proyectos Reales");
            resultado.Columns.Add("Pronostico");
            resultado.Columns.Add("Serie suavizada");
            resultado.Columns.Add("Estimacion de tendencia");

            for (int j = 0; j < pronosticoParaUnPeriodo.Count; j++)
            {
                
                if (j == 0)
                    resultado.Rows.Add("-", "-", "-", serieSuavizada[j], estimadoDeTendencia[j]);
                else
                    if (j == (pronosticoParaUnPeriodo.Count - 1))
                        resultado.Rows.Add(Convert.ToInt32(referencias[j - 2]) + 1, "-", pronosticoParaUnPeriodo[j], "-", "-");
                    else
                        resultado.Rows.Add(referencias[j-1], cantidades[j - 1], pronosticoParaUnPeriodo[j], serieSuavizada[j], estimadoDeTendencia[j]);
               
            }


           //return pronosticoParaUnPeriodo;
            return resultado;
        }
        return null;
    }
    /// <summary>
    /// Obtiene los datos para el pronositco de proyectos para el proximo año 
    /// (cantidades y referencias)
    /// </summary>
    /// <returns> devuelve el pronostico con datos de cantidades y referencias cargados.</returns>
    public static Pronostico pronosticoProyectos()
    {
        return DAOPronostico.getPronosticoProyectos();
        
    }
    /// <summary>
    ///  Obtiene los datos para el pronositco de proyectos para el proximo año por área especificada
    /// </summary>
    /// <param name="area">Código del área a pronosticar</param>
    /// <returns></returns>
    public static Pronostico pronosticoProyectosPorArea(int area)
    {
        return DAOPronostico.getPronosticoProyectosPorArea(area);

    }


}

