using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;
/// <summary>
///  Clase encargada de cargar y guardar los ajuste hechos en el menu de opciones.
/// </summary>

public class Ajustes 
{

    //valores que se guardarán en el fichero xml
    [XmlAttribute("audioMaestro")]
    public float audioMaestro;

    [XmlAttribute("audioMusica")]
    public float audioMusica;

    [XmlAttribute("audioEfectos")]
    public float audioEfectos;

    [XmlAttribute("resolucion")]
    public int resolucion;

    [XmlAttribute("calidad")]
    public int calidad;

    [XmlAttribute("pantallaCompleta")]
    public bool patallaCompleta;

    public Ajustes()
    {
    }

    public Ajustes(float audioMaestro, float audioMusica, float audioEfectos, int resolucion, int calidad, bool patallaCompleta)
    {
        this.audioMaestro = audioMaestro;
        this.audioMusica = audioMusica;
        this.audioEfectos = audioEfectos;
        this.resolucion = resolucion;
        this.calidad = calidad;
        this.patallaCompleta = patallaCompleta;
    }

    /// <summary>
    /// Guarda los ajustes realizados en el menú
    /// </summary>
    /// <param name="ajustes"> recibe objeto de tipo ajustes </param>
    public static void guardarDatos(Ajustes ajustes)
    {
        XmlSerializer serializer = new XmlSerializer(ajustes.GetType());
        FileStream stream = new FileStream(Path.Combine(Application.dataPath, "ajustes.xml"),
        FileMode.Create);
        Debug.Log(Application.persistentDataPath);
        serializer.Serialize(stream, ajustes);
        stream.Close();
        
    }

    /// <summary>
    /// Carga los ajuste guardados en el fichero ajustes.xml
    /// </summary>
    /// <returns> devuleve un objeto que contien los ajutes guardados.</returns>

    public static Ajustes cargarDatos()
    {
        Ajustes ajutes = null;
        if (File.Exists(Path.Combine(Application.dataPath, "ajustes.xml")))
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Ajustes));
            FileStream stream = new FileStream(Path.Combine(Application.dataPath, "ajustes.xml"), FileMode.Open);
            ajutes = serializer.Deserialize(stream) as Ajustes;

           /* string ruta = Application.dataPath;
            Debug.Log(ruta);
            Debug.Log(ajutes.audioEfectos);
            Debug.Log(ajutes.audioMaestro);
            Debug.Log(ajutes.audioMusica);
            Debug.Log(ajutes.calidad);
            Debug.Log(ajutes.patallaCompleta);*/

            stream.Close();
        }

        return ajutes;
    }



}
