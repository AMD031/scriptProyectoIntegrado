﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
///   Comportamiento de partida que ejecuta la rutina 
///   que siguira el enimigo al entra en este estado de la animaion.
///   Se usa otro comportamiento de de forma auxiliar.
/// </summary>
public class ComportamientoCaminar : StateMachineBehaviour
{
    private GameObject jugador;
    private IAnight ia;

    private GameObject[] puntosFase1;
    private GameObject[] puntosJugador;


    private Rigidbody rb;
    private float tiempoTeleportacion = 0;
    private int indicePos;
    private LogicaPersonaje1 logicaJugador;
    public bool ataqueGuadagna = false; 
    public bool teleportacionActiva = true;
    private int contadorAtaqueMagico1 = 0;
    public int contadorAtaqueGuadagna = 0;
    public bool ataqueMagico2 = false;
    private int cantidadAtaques = 3;
    SaludEnemigo saludEnemigo;
    private GameObject[] huida;
    NavMeshAgent agent;
    int posHuida = 0;
    private GameObject[] portales;


    /// <summary>
    /// cambia de posicion al azar al enemigo 
    /// </summary>
    private void llamarTeleportacion()
    {
     
        tiempoTeleportacion = 0;
        int n = Random.Range(0, 8);
        ia.teleportar(puntosFase1[n].transform.position);
    }


    /// <summary>
    /// Cambia de posicion al azar del enemigo cerca del jugador
    /// </summary>
    private void teleportarCercaJugador()
    {
       
  
        if (tiempoTeleportacion > 1.5f)
        {
            //Vector3 pos = puntosJugador[0].transform.position;

            int indice = Random.Range(0, 4);
            Vector3 pos = puntosJugador[indice].transform.position;

            ia.teleportar(pos);
            tiempoTeleportacion = 0;

        }


    }

    /// <summary>
    /// Detenien la animacion de perseguir y evita que se desplace.
    /// </summary>

    private void detenerPeseguir()
    {
        ia.perseguirJugador = false;
        agent.speed = 0;
        agent.velocity = Vector3.zero;
    }


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        jugador = GameObject.FindGameObjectWithTag("Player");
        ia = animator.GetComponent<IAnight>();
        puntosFase1 = ia.puntos;
        rb = animator.GetComponent<Rigidbody>();
        jugador.GetComponent<LogicaPersonaje1>();
        puntosJugador = ia.puntosJugador;
        logicaJugador = jugador.GetComponent<LogicaPersonaje1>();
        //contadorAtaqueMagico1 = 0;
        //tiempoTeleportacion = 3;

        portales = ia.portales;
        saludEnemigo = animator.GetComponent<SaludEnemigo>();
        agent = animator.GetComponent<NavMeshAgent>();
        huida = ia.huida;
        //saludEnemigo.currentHealth = 100;

   }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {

     


        tiempoTeleportacion += Time.deltaTime;
        float distancia = Vector3.Distance(rb.transform.position, jugador.transform.position);
       // cambia de posicion al enemigo y realiza un ataque. Cuando el número de ataque llega al máximo 
       // cambia el tipo de ataque.
        if (saludEnemigo.currentHealth > saludEnemigo.maxHealth *0.33)
        {


             // fase de ataque con fuego.
             if (  teleportacionActiva && !ia.teleportacionIniciada && indicePos < puntosFase1.Length && tiempoTeleportacion > 3)
              {
                ia.perseguirJugador = false;
                llamarTeleportacion();
                if (contadorAtaqueMagico1 == cantidadAtaques)
                {
                    cantidadAtaques = Random.Range(0, 5);
                    ///teleportacionActiva = false;
                    //ataqueGuadagna = true;
                    ataqueMagico2 = true;
                    teleportacionActiva = false;

                }
                else
                {
                    contadorAtaqueMagico1++;
                    animator.SetTrigger("ataqueMagico1");
                }
        

              }

              if (indicePos >= puntosFase1.Length)
              {
                 // ia.aparecer();
                  indicePos = 0;
              }


            if (ataqueMagico2 && !ia.teleportacionIniciada)
            {
                animator.SetTrigger("ataqueMagico2");
                ataqueMagico2 = false;
        
            }

            // inicia el ataque con guadaña 
            if (  ataqueGuadagna  && !ia.teleportacionIniciada /* && tiempoTeleportacion > 1.5f*/)
            {

      
                logicaJugador.enemigoFijado = false;

                if (distancia>6)
                {
                    teleportarCercaJugador();

                }


                if (distancia > 2 && distancia < 6  && 
                    !animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Magic Heal") &&
                    !animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Dizzy Idle"))
                {
                    ia.recuperaVelocidad();
                    ia.perseguirJugador = true;
               
                }

                if (distancia <2)
                {
                    detenerPeseguir();
          
                    if (contadorAtaqueGuadagna < 7)
                    {
                        contadorAtaqueGuadagna++;
                        detenerPeseguir();
                        animator.SetTrigger("usarGuadagna");


                    }
                    else
                    {
                        detenerPeseguir();
                        contadorAtaqueMagico1 = 0;
                        ataqueGuadagna = false;
                        teleportacionActiva = true;

                    }

                }






            }

        }
        else
        {
            // Cuando la bara de huida se
            if (!ia.teleportacionIniciada && tiempoTeleportacion > 3 && posHuida < huida.Length  )
            {
                //Debug.Log(huida[posHuida].name);
                ia.teleportar(huida[posHuida].transform.position); 
                tiempoTeleportacion = 0;
                posHuida++;
            }


            if (posHuida > 3)
            {

                agent.SetDestination(huida[3].transform.position);
            }

            if (Vector3.Distance(huida[3].transform.position, rb.transform.position) < 0.5f ) 
            {
                if (!ia.dentroDeLaZona.dentro)
                {
                    portales[0].SetActive(false);
                    logicaJugador.enemigoFijado = false;
                    ia.controlShader.quitarLineas();

                }


                if (ia.dentroDeLaZona.dentro)
                {
                    animator.SetBool("segundaFaseIntro",true);
                    portales[1].SetActive(true);
                    portales[2].SetActive(true);
                    
                }

            }





        }





    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      


   }




    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
