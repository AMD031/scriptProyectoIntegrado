using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Clase que guarda y carga los datos de la partida del jugador.
/// </summary>

public static class GuardarDatos
{
   /// <summary>
   /// Serializa los datos a partir del objeto que recibe
   /// </summary>
   /// <param name="datosPartida">objecto que contine los datos a serializar</param>
    public static void Guardar(DatosPartida datosPartida)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string ruta = Path.Combine(Application.dataPath, "datosPartida.data");
        FileStream stream = new FileStream(ruta, FileMode.Create);

        //DatosPartida datos = new DatosPartida(new GameObject());
        binaryFormatter.Serialize(stream, datosPartida);
        stream.Close();
    }

    /// <summary>
    /// Carga los datos de partida almacenados en el fichero datosPartida.data
    /// </summary>
    /// <returns>devuelve un objeto con los datos de la partida</returns>
    public static DatosPartida CargarDatos()
    {
        string ruta = Path.Combine(Application.dataPath, "datosPartida.data");
        DatosPartida datos = null;
      
        if (File.Exists(ruta))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(ruta, FileMode.Open);

            datos =  binaryFormatter.Deserialize(stream) as DatosPartida;
            stream.Close();
        }
    /*    else
        {
            Debug.LogError("no hay datos de partida");
        }*/
        return datos;

    }
    


}
