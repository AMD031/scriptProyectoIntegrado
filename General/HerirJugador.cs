using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Clase encargada de disminuir la vida del jugador en relacion a una serie de animaciónes ejecutadas por enemigo.
/// </summary>

public class HerirJugador : MonoBehaviour
{

    private bool atacando = false;
    private Animator anim;   
    private int contador = 0;
    private GameObject enemigo;
    private NavMeshAgent agent;
    private GameObject jugador;
    private Animator animJugador;
    private LogicaPersonaje1 logicaPersonaje;
    private SaludJugador saludJugador;
   // private int contadorElectricidad = 0;
    ControlShader controlShader;
    private int contadoTrigger = 0;
    private int contadorEscudo = 0;


    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        enemigo = GameObject.FindGameObjectWithTag("enemigo");
        logicaPersonaje = jugador.GetComponent<LogicaPersonaje1>();
        saludJugador = jugador.GetComponent<SaludJugador>();
        anim = enemigo.GetComponent<Animator>();
        animJugador = jugador.GetComponent<Animator>();
        agent = enemigo.GetComponent<NavMeshAgent>();
        controlShader = jugador.GetComponent<ControlShader>();

    }


    private void OnCollisionExit(Collision collision)
    {
        contador = 0;
    }

    
   

    private void OnCollisionEnter(Collision collision )
    {

        contador++;



        if (contador == 1 &&
            collision.collider.tag.Equals("escudo") &&
            atacando &&
            contador == 1 &&
            (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Sword And Shield Slash2") ||
             anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Mutant Swiping")) &&
             anim.name.Equals("mutante")
            )
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            anim.SetTrigger("golpeoEscudo");
        }




        if (collision.collider.tag.Equals("Player") && 
            atacando && !collision.collider.tag.Equals("escudo") &&
            !anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Dizzy Idle") &&
            !animJugador.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Head Hit") &&
            contador == 1 &&
            anim.name.Equals("mutante")
            )
        {
        
            if (saludJugador != null)
            {
                logicaPersonaje.estoyAtacando = true;
                saludJugador.TakeDamage(ValoresAtaque.dagnoAtaqueMutanteJugador);
                if (saludJugador.currentHealth > 0)
                {
                    animJugador.SetTrigger("golpeado");
                }
            }
        }


        if ( collision.collider.tag.Equals("escudo") && 
             atacando && contador == 1
             && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Sword And Shield Attack")
             && anim.name.Equals("mutante")
            )
        {
         
            agent.velocity = Vector3.zero;
            agent.speed = 0;
            //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).IsName("ataqueGiro"));
            anim.SetTrigger("mareado");


        }

        //---------hojasAfilada-------------------------

        if (collision.collider.CompareTag("Player") && gameObject.CompareTag("hojaAfilada"))
        {
            saludJugador.TakeDamage(20);
        }

        //---bolapichos
        if (collision.collider.CompareTag("Player") && gameObject.CompareTag("bolaPichos"))
        {
            saludJugador.TakeDamage(20);
        }



    }

    private void OnTriggerEnter(Collider other)
    {


        //---------------------night-----------------------------

        if (atacando &&
            other.CompareTag("escudo") &&
            anim.GetCurrentAnimatorClipInfo(0).Length > 0 &&
            anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Sword And Shield Attack"))
        {

            contadoTrigger++;
            if (contadoTrigger == 1)
            {
                anim.SetTrigger("golpeoEscudo");
            }

      
        }


        if (!other.CompareTag("escudo"))
        {
            if (
                atacando &&
                anim.GetCurrentAnimatorClipInfo(0).Length > 0 &&
                anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Sword And Shield Attack") &&
                gameObject.CompareTag("guadagna") &&
                other.CompareTag("Player")
             )
            {
                contadoTrigger++;
                if ( contadoTrigger == 1)

                {
                    if (saludJugador != null)
                    {
                        saludJugador.TakeDamage(ValoresAtaque.dagnoGuadagnaNightJugador);

                        if (saludJugador.currentHealth > 0)
                        {
                            animJugador.SetTrigger("golpeado");
                        }
                    }
                }

            }
          
        }

        //martillo 
        if (other.CompareTag("Player") && gameObject.CompareTag("Martillo"))
        {
            saludJugador.TakeDamage(10);
        }




    }




    // Simula el daño por electricidad 
    private void OnTriggerStay(Collider other)
    {

        if (saludJugador != null &&
            gameObject.CompareTag("electrico") &&
            other.CompareTag("Player") &&
            anim.name.Equals("mutante")
            )
        {
            //contadorElectricidad++;

            //if (contadorElectricidad % 1 ==0)
            //{
            saludJugador.TakeDamage(ValoresAtaque.dagnoElectricoMutanteJugador);
            //}
            controlShader.colorLineaDisover = new Color(0f, 1f, 9379053f, 1f);
            controlShader.inicarEfectoDisolver = true;
        }


    }



    private void OnTriggerExit(Collider other)
    {
        //contadorElectricidad = 0;
        contadoTrigger = 0;
    }

    public void inicioAtaque()
    {
        atacando = true;
    }

    public void finAtaque()
    {
        atacando = false;

    }






}
