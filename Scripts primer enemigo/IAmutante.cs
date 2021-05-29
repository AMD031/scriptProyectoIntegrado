using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Clase que se encarga de desplazar al enemigo ejecutando una animacion de movimiento.
/// </summary>
[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class IAmutante : MonoBehaviour
{
    //private static int ANIMATOR_PARAM_WALK_SPEED = Animator.StringToHash("andarVelocidad");
   
    public GameObject Jugador;
    private Animator _animator;
    private NavMeshAgent _agent;
    public HerirJugador hj;
    public GameObject escudo;
    Material materialEscudo;

    private SaludJugador saludJugador;
    private SaludEnemigo saludEnemigo;
    //private Rigidbody rb;
    public GameObject pfrayos;
    public ControlShader controlShader;
    public bool perseguirJugador = true;
    public GeneradorDeBarreras generadorDeBarreras;
    public float velocidadRecuperacion = 9;
    private float velocidadAgenteAnterior;

    private void Awake()
    {
        this._animator = this.GetComponent<Animator>();
        this._agent = this.GetComponent<NavMeshAgent>();
       // _agent.updateRotation = false;
        saludJugador =  Jugador.gameObject.GetComponent<SaludJugador>();
        saludEnemigo = gameObject.GetComponent<SaludEnemigo>();
        //rb = gameObject.GetComponent<Rigidbody>();

    }

    private void Start()
    {
        AudioManager.instance.Play("jefe1", AudioManager.MUSICA, true);
    }

    private void LateUpdate()
    {
        // cambia la animacion en función de la velocidad del agente.
        float speed = this._agent.velocity.magnitude;
        this._animator.SetFloat("velocidadAndar", speed);      
    }

    //Detetien la ia del enemigo cuando el jugador esta muerto.
    public void comprobarSalud()
    {
        if (saludJugador.currentHealth <= 0)
        {
            _agent.isStopped = true;
            _animator.SetBool("jugadorMuerto", true);
        }

        if (saludEnemigo.currentHealth <= 0)
        {
            _agent.isStopped = true;
        }


    }

    void Update()
    {
        if (perseguirJugador)
        {
          _agent.SetDestination(Jugador.transform.position);
        }
        comprobarSalud();
    }

   //activa la generacion de barreras de la segunda fase del enemigo.
    public void activarGenerardorBarreras()
    {
        generadorDeBarreras.para = !generadorDeBarreras.para;
    }


    
    public void continuarIA()
    {
        _agent.isStopped = false;
    }


 


/*    void rotarAgente()
    {
        Vector3 targetPosition = _agent.pathEndPosition;
        Vector3 targetPoint = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        Vector3 _direction = (targetPoint - transform.position).normalized;

        // Debug.Log(_direction);


        if (_direction != Vector3.zero)
        {
            Quaternion _lookRotation = Quaternion.LookRotation(_direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, 360);
        }

  }*/



    /// <summary>
    /// funcion que se usa para saber si un ataque a iniciado.
    /// </summary>
    public void iniciarAtaque()
    {
        hj.inicioAtaque();
    }

    /// <summary>
    /// // funcion que se usa para saber si un ataque a finalizado.
    /// </summary>
    public void finAtaque()
    {
        hj.finAtaque();
        _agent.velocity = Vector3.zero;

    }
   


    /// <summary>
    /// llama a un efecto 
    /// </summary>
    public  void efectoDisolver()
    {
        controlShader.inicarEfectoDisolver = true;
    }


    /// <summary>
    /// instacia un prefab y detine temporamente al enemigo
    /// </summary>
    public void atacarRayo()
    {
        _agent.velocity = Vector3.zero;
        velocidadAgenteAnterior = _agent.speed;
        _agent.speed = 0;
        Instantiate(pfrayos, transform.position, Quaternion.identity);
        Invoke("recuperaVelocidad", 2f);
    }



    /// <summary>
    /// Restaura la velocidad anterior de la ia
    /// </summary>
    private void recuperaVelocidad()
    {
        _agent.speed = velocidadAgenteAnterior;
    }


    public void asignarVelocidad(float velocidad)
    {
        _agent.speed = velocidad;
    }


}
