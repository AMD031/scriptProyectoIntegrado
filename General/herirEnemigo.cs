using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase en cargada de dismunir la barra de vida del enimigo en relación a algunas animaciones de jugador
/// </summary>

public class herirEnemigo : MonoBehaviour
{
    private LogicaPersonaje1 logicaPersonaje;
    private Animator anim;
    // private bool golpeado = false;
    private int contador = 0; 


    private void Awake()
    {
      logicaPersonaje =  gameObject.GetComponentInParent<LogicaPersonaje1>();
      anim = gameObject.GetComponentInParent<Animator>();
      
    }


    private void OnTriggerEnter(Collider other)
    {
        contador++;

        //Interacción jefe mutante 
        if (other.tag.Equals("enemigo") && 
            contador == 1 &&
            anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Mma Kick") &&
            gameObject.tag.Equals("pie") &&
            other.GetComponent<SaludEnemigo>().name.Equals("mutante")
        )
        {
            if (logicaPersonaje.estoyAtacando)
            {
             
                 
                other.GetComponent<SaludEnemigo>().TakeDamage(ValoresAtaque.dagnoPatadaJugadorMutante);
            }
        }


        if (other.tag.Equals("enemigo") &&
            contador == 1 &&
            anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Cross Punch") &&
            gameObject.tag.Equals("pugno") &&
            other.GetComponent<SaludEnemigo>().name.Equals("mutante")
        )
        {
            if (logicaPersonaje.estoyAtacando)
            {
                other.GetComponent<SaludEnemigo>().TakeDamage(ValoresAtaque.dagnoPugnoJugadorMutante);
            }
        }



        if (other.tag.Equals("enemigo") &&
          contador == 1 &&
          anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Sword And Shield Attack") &&
          gameObject.tag.Equals("espada") &&
          other.GetComponent<SaludEnemigo>().name.Equals("mutante")
        )
        {
            if (logicaPersonaje.estoyAtacando)
            {
                other.GetComponent<SaludEnemigo>().TakeDamage(ValoresAtaque.dagnoPugnoJugadorMutante);
            }
        }

        //interacion jefe night------------------------------------------------------

        if (other.tag.Equals("enemigo") &&
        contador == 1 &&
        anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Mma Kick") &&
        gameObject.tag.Equals("pie") &&
        other.GetComponent<SaludEnemigo>().name.Equals("night")
    )
        {
            if (logicaPersonaje.estoyAtacando)
            {
                other.GetComponent<SaludEnemigo>().TakeDamage(ValoresAtaque.dagnoPatadaJugadorMutante);
            }
        }


        if (other.tag.Equals("enemigo") &&
            contador == 1 &&
            anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Cross Punch") &&
            gameObject.tag.Equals("pugno") &&
            other.GetComponent<SaludEnemigo>().name.Equals("night")
        )
        {
            if (logicaPersonaje.estoyAtacando)
            {
                other.GetComponent<SaludEnemigo>().TakeDamage(ValoresAtaque.dagnoPugnoJugadorMutante);
            }
        }



        if (other.tag.Equals("enemigo") &&
          contador == 1 &&
          anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Sword And Shield Attack") &&
          gameObject.tag.Equals("espada") &&
          other.GetComponent<SaludEnemigo>().name.Equals("night")
        )
        {
            if (logicaPersonaje.estoyAtacando)
            {
                other.GetComponent<SaludEnemigo>().TakeDamage(ValoresAtaque.dagnoPugnoJugadorMutante);
            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        contador = 0;
    }











}
