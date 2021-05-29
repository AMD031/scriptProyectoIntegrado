using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// Estado de entrada de la ia del enemigo y se encarga de llamar
/// las direntes aniamaciones en función de la distacia del jugador.
/// </summary>


public class mutanteCorrer : StateMachineBehaviour
{
    
    Transform juagador;
    //distacia a la que ataque el enemigo con respesto al jugador para ser atacado.
    private float rangoDeAtaque = 2f; 
    // distacia que debe ser superior entre el enemigo y el jugador para efectuar un ataque con salto.
    private float rangoAtaqueConSalto = 7f; 
    // tiempo que debe estar el jugador le lejos de enemigo para que el enmigo salte
    private float timepoAtaqueSalto = 5f;
    //medidor de tiempo lejos 
    private float juagdorlejosTiempo = 0;
    //medidor de tiempo para el ataque
    private float tiempoAtaque = 0;

    Vector3 centro;
    int tipoGolpe = 0;
    //int tipoGolpeGiro = 0;
    Rigidbody rb;
    NavMeshAgent nva;
    SaludEnemigo saludEnemigo;
    IAmutante iamutante;

    bool segundaFase = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       juagador =  GameObject.FindGameObjectWithTag("Player").transform;
       centro =  GameObject.FindGameObjectWithTag("centroZonaJefe1").transform.position;
       saludEnemigo = animator.GetComponent<SaludEnemigo>();
       iamutante = animator.GetComponent<IAmutante>();

        rb = animator.GetComponent<Rigidbody>();
        nva = animator.GetComponent<NavMeshAgent>();
        if (nva.isStopped)
        {
            iamutante.continuarIA();
            //nva.isStopped = false;
           // nva.velocity = unpausedSpeed;
        }

        tipoGolpe = Random.Range(0, 4);



    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {
     
        Vector3 pos = animator.gameObject.transform.position;
        Vector3.Distance(pos, juagador.position);
        float distancia = Vector3.Distance(pos, juagador.position);
        juagdorlejosTiempo += Time.deltaTime;
        tiempoAtaque += Time.deltaTime;


        // cuando la barra de vida del enemigo esta al 25 se activa la segunda fase
        if (saludEnemigo.currentHealth <= (saludEnemigo.maxHealth * 0.25))
        {
            iamutante.perseguirJugador = false;
            segundaFase = true;
            nva.SetDestination(centro);    
        }

        if (segundaFase && Vector3.Distance(centro, rb.transform.position) <= 0.1f)
        {
            //rb.transform.LookAt(juagador);
            animator.SetBool("activarEscudo", true);
            animator.GetComponent<IAmutante>().escudo.SetActive(true);
            iamutante.generadorDeBarreras.para = false;
        }
        else
        {
            animator.SetBool("activarEscudo", false);
        }



        if ( distancia <= rangoDeAtaque)
        {
            juagdorlejosTiempo = 0;
           


            float angel = Vector3.Angle(rb.transform.forward, juagador.position - rb.transform.position);


            //Debug.Log(angel);
      
            // comprueba si el jugador esta en la espalda del enemigo 
            if (Mathf.Abs(angel) > 100 && Mathf.Abs(angel) < 180 & tiempoAtaque > 1f)
            {
               animator.SetTrigger("ataqueGiro");
               tiempoAtaque = 0;
               //nva.isStopped = true;
            }

          

            // comprueba si el jugador esta de frente del enemigo y realiza un ataque
            // aleatorio
            if (Mathf.Abs(angel) < 90 & tiempoAtaque > 0.4f)
            {
                rb.transform.LookAt(juagador);

                if (tipoGolpe >= 0 && tipoGolpe <= 1 )
                {
                    tiempoAtaque = 0;
                    animator.SetTrigger("patada");
                }
                else if (tipoGolpe >= 0 && tipoGolpe <= 2)
                {
                    tiempoAtaque = 0;
                    animator.SetTrigger("ataqueBajo");
                }else
                {
                    tiempoAtaque = 0;
                    animator.SetTrigger("atacar");
                }

                nva.isStopped = true;

            }



        }


        if (distancia > rangoDeAtaque && distancia <= rangoAtaqueConSalto && nva.velocity.magnitude >= 2)
        {

            //float angel = Vector3.Angle(rb.transform.forward, juagador.position - rb.transform.position);
    

            //si el jugador se aleje inicia un ataque con salto.
            if (juagdorlejosTiempo >= timepoAtaqueSalto)
            {
                rb.transform.LookAt(juagador);
                animator.SetTrigger("salta");
                juagdorlejosTiempo = 0;
            }

        }



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("patada");
        animator.ResetTrigger("atacar");
        animator.ResetTrigger("salta");
        animator.ResetTrigger("ataqueGiro");
        animator.ResetTrigger("ataqueGiro2");
        animator.ResetTrigger("ataqueBajo");
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
