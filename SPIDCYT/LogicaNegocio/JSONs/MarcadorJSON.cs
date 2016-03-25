using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa un marcador de congreso
/// </summary>
public class MarcadorJSON
{
    private int id;
    private decimal lat;
    private decimal lng;
    private string nombreCongreso;
    private string nombreLugar;
    private string link;
    private string descripcion;
    private string fechaDesde;
    private string fechaHasta;


    public int ID
    {
        get { return id; }
        set { id = value; }
    }
    public string FECHAHASTA
    {
        get { return fechaHasta; }
        set { fechaHasta = value; }
    }

    public string FECHADESDE
    {
        get { return fechaDesde; }
        set { fechaDesde = value; }
    }

    public decimal LAT
    {
        get { return lat; }
        set { lat = value; }
    }

    public decimal LNG
    {
        get { return lng; }
        set { lng = value; }
    }

    public string NOMBRECONGRESO
    {
        get { return nombreCongreso; }
        set { nombreCongreso = value; }
    }

    public string NOMBRELUGAR
    {
        get { return nombreLugar; }
        set { nombreLugar = value; }
    }

    public string LINK
    {
        get { return link; }
        set { link = value; }
    }


    public string DESCRIPCION
    {
        get { return descripcion; }
        set { descripcion = value; }
    }
    /// <summary>
    /// Crea un nuevo conreso.
    /// </summary>
    /// <param name="congreso"></param>
    public static void insertarMarcadorCongreso(MarcadorJSON congreso)
    {
        DAOMarcadorJSON.insertarMarcadorCongreso(congreso);
    }
    /// <summary>
    /// Edita un congreso existente.
    /// </summary>
    /// <param name="congreso"></param>
    public static void modificarMarcadorCongreso(MarcadorJSON congreso)
    {
        DAOMarcadorJSON.modificarMarcadorCongreso(congreso);
    }
    /// <summary>
    /// Elimina un congreso existente a partir de us ID.
    /// </summary>
    /// <param name="idCongreso"></param>
    public static void eliminarrMarcadorCongreso(int idCongreso)
    {
        DAOMarcadorJSON.eliminarMarcadorCongreso(idCongreso);
    }
    /// <summary>
    /// Obtiene los congresos del corriente año.
    /// </summary>
    /// <returns></returns>
    public static List<MarcadorJSON> listarCongresosDelAño()
    {
        return DAOMarcadorJSON.listarCongresosDelAño();
    }
    /// <summary>
    /// Obtiene el total de congresos del año. 
    /// </summary>
    /// <returns></returns>
    public static int totalDeCongresosDelAño()
    {
        return DAOMarcadorJSON.totalDeCongresosDelAño();
    }
}
