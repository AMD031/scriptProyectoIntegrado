using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// En este comportamiento se llama al ataque con guadaña y se hace visible.
/// </summary>

public class ComportamientoIdleSword : StateMachineBehaviour
{
    private IAnight ia;
    private ControlShader cs;
 


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        ia = animator.GetComponent<IAnight>();
        ia.guadagna.SetActive(true);
        cs = animator.GetComponent<ControlShader>();
        if (!ia.GuadagnaActiva)
        {
            ia.GuadagnaActiva = true;
            ia.aparecerGuadagna();
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     

        if (!cs.inicarEfectoAparecerGudagna )
        {
             animator.SetTrigger("ataqueGuadagna");
        }
            
  
 

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.ResetTrigger("ataqueGuadagna");  
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
