using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  Clase que hereda StateMachineBehaviour y que cuando termina una animación en la que esta asociada una instacia
///  de esta clase desactiva algunos objectos
/// </summary>
public class ComportamientoAtaqueJugador : StateMachineBehaviour
{
    private LogicaPersonaje1 logicaPersonaje;
    private Disparo disparo;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        logicaPersonaje = animator.GetComponent<LogicaPersonaje1>();
        disparo = animator.GetComponent<Disparo>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        disparo.quitarEspada();
        disparo.quitarEscudo();
        logicaPersonaje.DejeDeGolpear();
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
