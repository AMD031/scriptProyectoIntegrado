using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  En este comportamiento se llama a una serie de prefab que relentiza al jugador.
/// </summary>

public class ComportamientoAtaqueMagico2 : StateMachineBehaviour
{
    private IAnight ia;
    private Rigidbody rb;
    private ComportamientoCaminar comportamientoCaminar;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       ia = animator.GetComponent<IAnight>();
       rb = animator.GetComponent<Rigidbody>();
       ia.aura.SetActive(true);
        comportamientoCaminar = animator.GetBehaviour<ComportamientoCaminar>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.ResetTrigger("ataqueMagico2");
        ia.iniciarAtaqueMagico2();
        ia.aura.SetActive(false);

        //----------------
        comportamientoCaminar.ataqueGuadagna = true;
        comportamientoCaminar.contadorAtaqueGuadagna = 0;

              
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
