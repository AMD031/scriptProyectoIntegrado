using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase encargada de reducir la vida del jugador cuando entra en contacto con particulas.
/// </summary>

public class HerirJugadorParticulas : MonoBehaviour
{
   // public ParticleSystem part;
   private int golpe = 0;
    private int empujoFuego = 0; 
   public ZonaDeDagno zonaDeDagno;
   public SaludJugador saludJugador; 

    void Start()
    {
        // part = GetComponent<ParticleSystem>();

        if (saludJugador == null)
        {
            saludJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<SaludJugador>();
        }
    }



    private void OnParticleTrigger()
    {
     
        if (zonaDeDagno && saludJugador && zonaDeDagno.dentroZona)
        {
            //golpe = 0;
            golpe++;
            if (golpe > 5)
            {
                if (zonaDeDagno.escudoActivo)
                {
                    saludJugador.TakeDamage(-ValoresAtaque.dagnoHechizoNightJugador);
                }

                saludJugador.TakeDamage(ValoresAtaque.dagnoHechizoNightJugador);
                golpe = 0;
            }
        }

     

    }


    private void OnParticleCollision(GameObject other)
    {
        if (gameObject.CompareTag("empujonFuego") && other.CompareTag("Player") && saludJugador)
        {
            //golpe = 0;

            empujoFuego++;
            if (empujoFuego > 1)
            {
          

                saludJugador.TakeDamage(1);
                empujoFuego = 0;
            }


      

        }


    }







}
