using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// clase que llama a la reprodución de alguanos sonidos.
/// </summary>
public class SonidosMutante : MonoBehaviour
{
   

    public void  ReproducirCaida()
    {
        AudioManager.instance.Play("caer", AudioManager.MUTANTE, true);
    }


    public void ReproducirCuchilla()
    {
        //AudioManager.instance.Play("golpeCuchilla", AudioManager.MUTANTE, true);
    }

    public void reproducirSonido(string sonido)
    {
        AudioManager.instance.Play(sonido, AudioManager.MUTANTE, true);
    }

}
