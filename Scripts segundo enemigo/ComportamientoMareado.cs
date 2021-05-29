using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



/// <summary>
/// Comportamiento que controla la cantidad de tiempo que está reprodución la animadión mareado.
/// </summary>


public class ComportamientoMareado : StateMachineBehaviour
{
    float tiempo = 0;
    SaludEnemigo saludEnemigo;
    IAmutante iamutante;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        saludEnemigo = animator.GetComponent<SaludEnemigo>();
        iamutante = animator.GetComponent<IAmutante>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {

        tiempo += Time.deltaTime;
   
        if (tiempo > 1 || saludEnemigo.currentHealth <= saludEnemigo.maxHealth * 0.33)
        {
            animator.SetTrigger("finMareado");
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tiempo = 0;
        iamutante.asignarVelocidad(iamutante.velocidadRecuperacion);
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
