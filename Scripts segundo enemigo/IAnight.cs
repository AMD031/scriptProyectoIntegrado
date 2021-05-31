using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// clase encargada de activar la animaciion de movimiento, llamar efectos del personaje y 
/// guaarda alguanas variables axiliares.
/// </summary>

public class IAnight : MonoBehaviour
{
    public GameObject Jugador;
    private Animator _animator;
    private UnityEngine.AI.NavMeshAgent _agent;
    public HerirJugador hj;
    private SaludJugador saludJugador;
    private SaludEnemigo saludEnemigo;
    //private Rigidbody rb;
    public ControlShader controlShader;

    [HideInInspector]
    public bool perseguirJugador = false;
    public float velocidadAgenteAnterior = 9;

    public GameObject[] puntosJugador;
    public GameObject[] puntos;
    private float tiempoAparecer;
    public bool teleportacionIniciada = false;
    private bool cambiarPosicionLLamado = false;
   // private Animator anim;


    public Vector3 posisionTeleportar;
    public GameObject esferaDagno;
    public GameObject guadagna;
    public GameObject ataqueMagico1;
    public DentroDeLaZona dentroDeLaZona;
    public GameObject aura;
    public GameObject aura2;
    public GeneradorAtaqueMagico2 generadorAtaqueMagico2;
    private bool AnimacionIdle = false;


    public GameObject[] huida;
    public GameObject[] portales;
    public DentroDeLaZona dentrodelazona;

    public bool animacionGiro = false;
    public bool GuadagnaActiva = false;

    private void Awake()
    {
        this._animator = this.GetComponent<Animator>();
        this._agent = this.GetComponent<NavMeshAgent>();
        // _agent.updateRotation = false;
        saludJugador = Jugador.gameObject.GetComponent<SaludJugador>();
        saludEnemigo = gameObject.GetComponent<SaludEnemigo>();
        //rb = gameObject.GetComponent<Rigidbody>();
       // anim = gameObject.GetComponent<Animator>();
        velocidadAgenteAnterior = this._agent.speed;

        
    }

    private void Start()
    {
       AudioManager.instance.Play("jefe2", AudioManager.MUSICA, true);
    }

    private void LateUpdate()
    {
        float speed = this._agent.velocity.magnitude;
        this._animator.SetFloat("velocidadAndar", speed);
    }


    //Detetien la ia del enemigo cuando el jugador esta muerto.
    public void comprobarSalud()
    {
        if (saludJugador.currentHealth <= 0)
        {
            _agent.isStopped = true;
            if (!AnimacionIdle)
            {
                AnimacionIdle = true;
                _animator.SetTrigger("jugadorHaMuerto");
            }
        }

        if (saludEnemigo.currentHealth <= 0)
        {
            _agent.isStopped = true;
            _agent.velocity = Vector3.zero;
        }
    }


    void Update()
    {
       // tiempoAparecer += Time.deltaTime;


        if (teleportacionIniciada)
        {
      
            if (/*tiempoAparecer >= 3f*/ !controlShader.inicarEfectoDesparecer)
            {

               
                transform.position = posisionTeleportar;
                aparecer();

                if (!controlShader.inicarEfectoDesparecer)
                {
                    transform.LookAt(Jugador.transform.position);
                    teleportacionIniciada = false;
                }
            }
        }
  
                if (perseguirJugador)
                {
                    _agent.SetDestination(Jugador.transform.position);
                }
                comprobarSalud();

    }


    // funciones que determina cuando empieza y termina un ataque
    public void iniciarAtaque()
    {
        hj.inicioAtaque();
    }

    public void finAtaque()
    {
        hj.finAtaque();
    }
    // restaura la velocidade de la ia
    public void recuperaVelocidad()
    {
        _agent.speed = velocidadAgenteAnterior;
    }

    public void iniciarAtaqueGuadagna()
    {
        //anim.SetTrigger("ataqueGuadagna");
    }

    // funciones que llaman a efectos asociados con el enmigo

    /// <summary>
    /// Método que hace de puente con la clase controlShader y llama al efecto aparecerGuadagna
    /// </summary>
    public void aparecerGuadagna()
    {
        controlShader.inicarEfectoAparecerGudagna = true;
    }


    /// <summary>
    /// Método que hace de puente con la clase controlShader y llama al efecto desparecerGuadagna
    /// </summary>
    public void desparecerGuadagna()
    {
        controlShader.iniciarEfectoDesaparecerGuadagna = true;
    }



    /// <summary>
    /// Método que hace de puente con la clase controlShader y llama al efecto aparecer
    /// </summary>
    public void aparecer()
    {
        controlShader.iniciarEfectoAparecer = true;
    }

    /// <summary>
    /// Método que llama a una secuencia de instaciación
    /// </summary>
 
    public void iniciarAtaqueMagico2()
    {
        generadorAtaqueMagico2.iniciar = true;
    }

    /// <summary>
    /// Método que hace de puente con la clase controlShader y llama al efecto deparecer
    /// </summary>

    public void desparecer()
    {

        controlShader.inicarEfectoDesparecer = true;
    }

   

    /// <summary>
    /// Desplaza al enemigo a una posición determinada ejecuntado un efeccto.
    /// </summary>
    /// <param name="pos">posición a la que se desea desplazar </param>
    public void  teleportar(Vector3 pos)
    {
      
        if (!teleportacionIniciada && Vector3.Distance(pos, transform.position) >= 0.5f)
        {
            tiempoAparecer = 0;
            desparecer();
            posisionTeleportar = pos;
            teleportacionIniciada = true;
        }

    }


    /// <summary>
    ///  Mueve un collider que se encarga de reducir la barra vida del jugador.
    /// </summary>
    /// <param name="pos"> posición a la que se desea desplazar</param>
    public void moverZonaDagno(Vector3 pos)
    {
        ataqueMagico1.SetActive(true);
        esferaDagno.transform.position = pos;
    }

     /// <summary>
     ///  oculta un objeto asociado a un estado de la animación.
     /// </summary>
    public void detenerAtaqueMagico1()
    {
        ataqueMagico1.SetActive(false);

    }

    public void asignarVelocidad(float velocidad)
    {
        _agent.speed = velocidad;
    }




}
