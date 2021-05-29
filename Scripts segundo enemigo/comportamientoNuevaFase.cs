using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inicia la seguda fase de la ia
/// </summary>

public class comportamientoNuevaFase : StateMachineBehaviour
{
    private IAnight ia;
    private Rigidbody rb;
    private bool venenoActivado;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ia = animator.GetComponent<IAnight>();
        rb = animator.GetComponent<Rigidbody>();
        ia.aura2.SetActive(true);
        rb.transform.LookAt(ia.Jugador.transform.position);
       

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {
         
     }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!venenoActivado)
        {
            venenoActivado = true;
            ia.dentroDeLaZona.activarVeneno = true;
        }
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
