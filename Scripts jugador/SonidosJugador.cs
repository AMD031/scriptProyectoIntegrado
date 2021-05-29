using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosJugador : MonoBehaviour
{

    AudioManager auidioManger;
    private void Start()
    {
        auidioManger = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioManager>();
    }


    /*    public void reproducirPisadaDerecha()
        {
            AudioManager.instance.Play("pisadaDerecha", AudioManager.JUGADOR,true);
        }

        public void reproducirPisadaIzquierda()
        {

            AudioManager.instance.Play("pisadaIzquierda", AudioManager.JUGADOR,true);
        }*/

    public void reproducirSonido(string sonido)
    {

        auidioManger.Play(sonido, AudioManager.JUGADOR,true);
     
    }

}
