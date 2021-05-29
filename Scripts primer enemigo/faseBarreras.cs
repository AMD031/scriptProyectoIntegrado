using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// comportabiento que desactiva prefab que simulan ser una barrera
/// y que pone fin a la fase cuando al enemigo se le agota la barra de vida.
/// </summary>
public class faseBarreras : StateMachineBehaviour
{
    private SaludEnemigo saludEnemigo;
    private IAmutante iamutante;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        saludEnemigo = animator.GetComponent<SaludEnemigo>();
        iamutante = animator.GetComponent<IAmutante>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //detine la generacion de barreras cuando la salud del enemigo llega a cero
        if (saludEnemigo.currentHealth <= 0)
        {
            animator.GetComponent<IAmutante>().escudo.SetActive(false);
            iamutante.generadorDeBarreras.para = true;
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
