using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Pone fin a la fase y desactiva algunos prefab
/// </summary>
public class ComportamientoMorir : StateMachineBehaviour
{
    private IAnight ia;
    private SaludEnemigo saludEnemigo;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        saludEnemigo = animator.GetComponent<SaludEnemigo>();
        ia = animator.GetComponent<IAnight>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Desactiva todas la barreras cuando el enemigo muere
        if (saludEnemigo.currentHealth <= 0)
        {

            foreach (GameObject portal in ia.portales)
            {
                portal.SetActive(false);
            }

            ia.dentroDeLaZona.activarVeneno = false;
            ia.aura2.SetActive(false);

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
