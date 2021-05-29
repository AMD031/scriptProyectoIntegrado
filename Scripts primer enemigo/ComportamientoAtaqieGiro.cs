using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoAtaqieGiro : StateMachineBehaviour
{
/*    Light[] luces;
    Light luzAtaque;*/

     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


/*
        luces = animator.GetComponentsInChildren<Light>();
        Debug.LogWarning(luces.Length);
        foreach (Light luz in luces){

            if (luz.CompareTag("luzAtaque"))
            {
                luzAtaque = luz;
            }

        }*/



    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {
   /*     if (luzAtaque)
        {

          luzAtaque.enabled = true;
            Time.timeScale = 0.5f;
        }*/
     }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
     override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {

  /*      if (luzAtaque)
        {
           luzAtaque.enabled = false;
       
        }*/


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
