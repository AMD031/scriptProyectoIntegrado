using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Clase que serializa un objeto con los datos de partida.
/// </summary>

[System.Serializable]
public class DatosPartida
{
    //public bool jefeMutanteMuerto;
    float[] posicion;
    bool jefe1Muerto;
    bool jefe2Muerto;
    bool almajefe1;
    bool almajefe2;
    bool almajefe1colocada;
    bool almajefe2colocada;

    public DatosPartida()
    {
    }

    public DatosPartida(
        GameObject jugador
        )
    {
        Jefe1Muerto = false;
        Jefe2Muerto = false;
        Almajefe1 = false;
        Almajefe2 = false;
        Almajefe1colocada = false;
        Almajefe2colocada = false;
        this.Posicion = new float[3];
        this.Posicion[0] = jugador.transform.position.x;
        this.Posicion[1] = jugador.transform.position.y;
        this.Posicion[2] = jugador.transform.position.z;
    }

    public DatosPartida(
        GameObject jugador, 
        bool jefe1Muerto,
        bool jefe2Muerto,
        bool almajefe1,
        bool almajefe2,
        bool almajefe1colocada,
        bool almajefe2colocada
        )
    {
        this.Posicion = new float[3];
        this.Posicion[0] = jugador.transform.position.x;
        this.Posicion[1] = jugador.transform.position.y;
        this.Posicion[2] = jugador.transform.position.z;
        this.jefe1Muerto = jefe1Muerto;
        this.jefe2Muerto = jefe2Muerto;
        this.almajefe1 = almajefe1;
        this.almajefe2 = almajefe2;
        this.almajefe1colocada = almajefe1colocada;
        this.almajefe2colocada = almajefe2colocada;
    }



    public bool Jefe1Muerto { get => jefe1Muerto; set => jefe1Muerto = value; }
    public bool Jefe2Muerto { get => jefe2Muerto; set => jefe2Muerto = value; }
    public bool Almajefe1 { get => almajefe1; set => almajefe1 = value; }
    public bool Almajefe2 { get => almajefe2; set => almajefe2 = value; }
    public bool Almajefe1colocada { get => almajefe1colocada; set => almajefe1colocada = value; }
    public bool Almajefe2colocada { get => almajefe2colocada; set => almajefe2colocada = value; }
    public float[] Posicion { get => posicion; set => posicion = value; }
}
