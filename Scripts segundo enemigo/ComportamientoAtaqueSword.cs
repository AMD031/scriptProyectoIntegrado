using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
///  Cuando este estado se ejecuta se hace visible el objeto guadagna.
/// </summary>

public class ComportamientoAtaqueSword : StateMachineBehaviour
{
    private IAnight ia;
    private ControlShader cs;
    private Rigidbody rb;
    GameObject jugador;
    private NavMeshAgent agent;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ia = animator.GetComponent<IAnight>();
        ia.guadagna.SetActive(true);
        cs = animator.GetComponent<ControlShader>();
        rb = animator.GetComponent<Rigidbody>();
        jugador = ia.Jugador;
        agent = animator.GetComponent<NavMeshAgent>();
      
        

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        agent.velocity = Vector3.zero;
        rb.transform.LookAt(jugador.transform.position);
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
