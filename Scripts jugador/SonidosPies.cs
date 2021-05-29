using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que llama a los sonidos de los pies  haciendo uso del audio manager.
/// </summary>

public class SonidosPies : MonoBehaviour
{
    public LogicaPersonaje1 logicaPersonaje1;
    private AudioManager auidioManger;
    private int contadorDe = 0;
    private int contadorIz = 0;
    //[RequireComponent]
    //public AudioSource sonido;

  


    private void Start()
    {
        auidioManger = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioManager>();
    }


    /// <summary>
    /// Cuando los pies hace contacto con alguna superficie suena el sonido correspondiente
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {

     
        if ( gameObject.tag == "pieIz" /*&&  other.tag == "suelo"  && */ /*logicaPersonaje1.enMovimiento */)
        {
            contadorIz++;

            if (contadorIz == 1)
            {
             //Debug.LogWarning("suena pieIz");
             auidioManger.Play("pisadaIzquierda", AudioManager.JUGADOR, true);
            }

        }
     
        if (gameObject.tag == "pieDe" /*&& other.tag == "suelo"*//* && logicaPersonaje1.enMovimiento*/)
        {
            contadorDe++;
            if (contadorDe == 1)
            {
               //Debug.LogWarning("suena pieDe");
                auidioManger.Play("pisadaDerecha", AudioManager.JUGADOR,true);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        contadorIz = 0;
        contadorDe = 0;
    }


}
