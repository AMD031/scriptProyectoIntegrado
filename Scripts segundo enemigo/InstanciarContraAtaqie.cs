using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// clase que instacia un prefab que simula fuego que baja la barra de vida del 
/// enemigo al entra en contacto con él.
/// </summary>

public class InstanciarContraAtaqie : MonoBehaviour
{
    public GameObject torreFuego;
    public GameObject puntoIntaciatorreFuego;

    // Start is called before the first frame update



   /* public void instaciarBolaFuego()
    {
        Instantiate(bolaFuego, PuntoDisparo.position, Quaternion.Euler(PuntoDisparo.rotation.eulerAngles));
    }
*/


    public void instaciarTorreDeFuego()
    {
     
        if (torreFuego && puntoIntaciatorreFuego)
        {
            Instantiate(torreFuego, puntoIntaciatorreFuego.transform.position, Quaternion.Euler(puntoIntaciatorreFuego.transform.rotation.eulerAngles));
        }
    }

}
