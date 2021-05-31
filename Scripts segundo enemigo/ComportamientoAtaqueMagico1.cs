using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Comportamiento que llama a la instaciacion de un prefaba que simula un 
/// ataque de fuego autoDirigido.
/// </summary>

public class ComportamientoAtaqueMagico1 : StateMachineBehaviour
{
    private GameObject jugador;
    private IAnight ia;
    private Rigidbody rb;
    private LogicaPersonaje1 logicaJugador;
    private float tiempoPosJugador = 0;
    private bool llamadoPos = false;
    private Vector3 posJugador = Vector3.zero;
    private int contadorAtaque = 0;

    public float GetCurrentAnimatorTime(Animator targetAnim, int layer = 0)
    {
        AnimatorStateInfo animState = targetAnim.GetCurrentAnimatorStateInfo(layer);
        float currentTime = animState.normalizedTime % 1;
        return currentTime;
    }


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        ia = animator.GetComponent<IAnight>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        rb = animator.GetComponent<Rigidbody>();
        // logicaJugador = jugador.GetComponent<LogicaPersonaje1>();
        contadorAtaque = 0;
        tiempoPosJugador = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        ia.perseguirJugador = false;
        tiempoPosJugador += Time.deltaTime;

       // if (tiempoPosJugador > 0.2)
       // {
         
       
            //Se toma la posición del jugador
            if (tiempoPosJugador > 0.1 && tiempoPosJugador < 0.5)
            {
                if (!llamadoPos)
                {
                  llamadoPos = true;
                  posJugador = jugador.transform.position;
                }
            }

             //cantidad de timpo para mover el collider que atrae las particulas.
             if (tiempoPosJugador > 0.5 && posJugador != Vector3.zero)
             {
              ia.moverZonaDagno(posJugador);
              tiempoPosJugador = 0;
              llamadoPos = false;

                rb.transform.LookAt(jugador.transform.position);
                contadorAtaque++;
               // Debug.Log(contadorAtaque);

               //finaliza el ataque 
                if (contadorAtaque == 20)
                {
                    ia.detenerAtaqueMagico1();
                    animator.SetTrigger("ataqueMagico1");
                }

            }





       // }
       

        
       
   }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ia.detenerAtaqueMagico1();
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
