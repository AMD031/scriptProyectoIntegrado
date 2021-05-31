using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// Clase que contiene la logica que permite que el personaje se pueda mover y 
/// realizar la diferentes animaciones
/// </summary>

public class LogicaPersonaje1 : MonoBehaviour
{


    //-----------------------


    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
   // public float fuezaDeSalto = 8f;


    public float x; // valor al pulsar tecla de direccion horizontal 
    public float y; //valor al pulsar tecla de direccion vertical 


    public Camera cam;
    private Animator anim;

    public Rigidbody rb;
    public bool puedoSaltar = true; // permite saber si la animación de caida se puede reproducir
    public float velocidadInicial;
    public float velocidAgachado;

    //cambio de collider
    public CapsuleCollider colpardo;
    public CapsuleCollider colagachado;
    public GameObject cabeza;
    public LogicaCabeza logicaCabeza;
    public bool estoyAgachado; // se vuel ve true cuando el personaje esta agachado

    public bool estoyAtacando;
    public float impulsoDeGolpe = 20f;
    public bool muerto = false;
    //public float borderHorizontales = 0.2f;
    public float velocidadRotacionRaton = 4f; //velocidad a la que se mueve el ratón.

    public float h; // movimiento horizontal del ratón
    public float v; // movimiento vertical del ratón

    //-----------------------------------
    private Disparo disparo;

    // public float speed = 6f;
    // public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    public Transform enemigo;
    public bool enemigoFijado = false; // se usa para establecer si un enmigo esta fijado.
  
    public float rangoFijado = 25; //determina el rango al que se puede fijar un enimigo.


    public CinemachineFreeLook vcam ;
    public CinemachineVirtualCamera vcam2;

    public bool enMovimiento = false;
    public bool relentizado = true;

    public GameObject[] lineasRelentizados;



    void Start()
    {

       // espada.SetActive(false)
        puedoSaltar = true;
        anim = GetComponent<Animator>();
        velocidadInicial = velocidadMovimiento;
        velocidAgachado = velocidadMovimiento * 0.5f;
        disparo = GetComponent<Disparo>();



    }

    /// <summary>
    /// Activa la variable que hace que la camara apunte al enemigo y activa una
    /// lineas que enfatiza que el enemigo está fijado.
    /// </summary>
    private void fijarEnemigo()
    {
        GameObject enemigoEncontrado = GameObject.FindGameObjectWithTag("enemigo");
        if (enemigoEncontrado)
        {
            enemigo = enemigoEncontrado.transform;
            if (enemigo && Vector3.Distance(enemigo.transform.position, transform.position) <= rangoFijado)
             {
                enemigoFijado = !enemigoFijado;
                //enemigo.GetChild(2).gameObject.SetActive(true);
                enemigo.GetComponent<ControlShader>().ponerLineas();
          
            }
        }
           
    }


    /*  public void cambiarVelocidad()
      {
          velocidadMovimiento = velocidadMovimiento * 0.01f;
      }*/

    /// <summary>
    /// Reduce la velocidad del jugador y activa la visualizacion de objecto para enfatizar la
    /// relentización
    /// </summary>

    public void activarRelentizado()
    {
        if (!relentizado)
        {
            relentizado = true;
            velocidadMovimiento = 0.6f;
            lineasRelentizados[0].SetActive(true);
            lineasRelentizados[1].SetActive(true);
            Invoke("desactivarRelentizado", 10f);
        }
     
    }

    /// <summary>
    /// Recupera la velocidad original y se desactiva los objetos asociados.
    /// </summary>

    public void desactivarRelentizado()
    {
 
        relentizado = false;
        velocidadMovimiento = velocidadInicial;
        lineasRelentizados[0].SetActive(false);
        lineasRelentizados[1].SetActive(false);
        

    }


    void FixedUpdate()
    {
        if ( !estoyAtacando &&  !muerto)
        {
            // controla el desplazamiento
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
            transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, 0);
        }

        if (!muerto && !estoyAtacando && !enemigoFijado)
        {
            rotar(h);
        }

        // Se realiza un cambio de cámara entre libre y fijada al enemigo.
        if (!enemigoFijado)
        {
            vcam.enabled = true;
            vcam2.enabled = false;
            if (!muerto && !estoyAtacando)
            {

                    transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                    cam.transform.eulerAngles.y, transform.eulerAngles.z);
       
            }
        }
        else
        {
            vcam.enabled = false;
            vcam2.enabled = true;
            Vector3 relativePos = enemigo.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);
        }

    }

  
    /// <summary>
    /// Gira al personaje en función del movimiento del ratón
    /// </summary>
    /// <param name="h">Desplazamiento del ratón </param>
    public void rotar(float h)
    {
        Vector3 direction = new Vector3(0, transform.rotation.eulerAngles.y +h, 0);
        Quaternion targetRotation = Quaternion.Euler(direction);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * velocidadRotacionRaton);

    }


    /// <summary>
    ///  Invoca las animaciones en funcion del movimento del ratón
    /// </summary>
    void animMovimientoRaton()
    {


        if ((h > 1 || h < -1) && !estoyAtacando && !estoyAgachado && !muerto)
        {
            anim.SetTrigger("raton");
            anim.SetFloat("RVelX", h * 9);
        }

        if ((h > 1 || h < -1) && !estoyAtacando && estoyAgachado && !muerto)
        {
            anim.SetTrigger("raton");
            anim.SetFloat("RVelX", h * 12);
        }

     

        if (h == 0)
        {
            anim.ResetTrigger("raton");
        }
        //transform.LookAt(enemigo.position);

    }




    // Update is called once per frame
    void Update()
    {
        if (puedoSaltar)
        {
            // Se obtine valores de pulsado de tenclas de movimiento y ratón
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
            h = 10 * Input.GetAxis("Mouse X");
            v = 10 * Input.GetAxis("Mouse Y");
           
        }

        //Si el personaje esta parado se ejecuta la animación.
        if (puedoSaltar && !estoyAtacando &&  y != 1 && y != -1 && x != 1 && x != -1 && !enemigoFijado)
        {
            if (v == 0)
            {
                animMovimientoRaton();
            }
        }


/*        if (x == 0 && y == 0)
        {
            vcam.m_XAxis.m_InputAxisName = "Mouse X";
        }
        else
        {
            vcam.m_XAxis.m_InputAxisName = "";
        }*/




        // Se ejecuta la acciones asociadas a cada tecla.
        if (Input.GetKey(KeyCode.Q) && puedoSaltar && !estoyAtacando && !muerto)
        {
            // escudo.SetActive(true);
            disparo.usarEscudo();
            //estoyAtacando = true;
        }



        if (Input.GetKey(KeyCode.V) && puedoSaltar && !estoyAtacando && !muerto)
        {
            //espada.SetActive(true);

            disparo.usarEspada();


            //estoyAtacando = true;
        }


        if (Input.GetKey(KeyCode.Mouse0) && puedoSaltar && !estoyAtacando && !muerto)
        {
            anim.SetTrigger("golpeo");
            estoyAtacando = true;
        }

        if (Input.GetKey(KeyCode.Mouse1) && puedoSaltar && !estoyAtacando && !muerto)
        {
            anim.SetTrigger("patada");
            estoyAtacando = true;
        }



        if (Input.GetKey(KeyCode.F) && puedoSaltar && !estoyAtacando && !muerto)
        {
            disparo.usarBolaFuego();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            if (!enemigoFijado)
            {
                fijarEnemigo();
            }
            else
            {
                enemigoFijado = false;
                enemigo.GetComponent<ControlShader>().quitarLineas();
            }
        }

   

        //Parametro que llaman a las animaciones de movimento del personaje
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        //Debug.Log(puedoSaltar);
        if (puedoSaltar)
        {
            if (!estoyAtacando)
            {

        /*        if (Input.GetKeyDown(KeyCode.Space) && !enemigoFijado)
                {
                   
                    anim.SetBool("salte", true);
                 

                }*/

                if (Input.GetKeyDown(KeyCode.Space) /*&& enemigoFijado*/)
                {
            
                    float auxx = x;
                    float auxy = y;

                    if (y < -0.1 )
                    {
                        auxy = -1;
                    }

                 
                    anim.SetTrigger("esquiva");
                    anim.SetFloat("VelYRodar", auxy);
                    anim.SetFloat("VelXRodar", auxx);
                   
                }


                if (Input.GetKey(KeyCode.LeftControl))
                {
                    anim.SetBool("agachado", true);
                    if (!relentizado)
                    {
                        velocidadMovimiento = velocidAgachado;
                    }
                 
                    //cambio de collider:
                    colagachado.enabled = true;
                    colpardo.enabled = false;

                    cabeza.SetActive(true);
                    estoyAgachado = true;
                }
                else
                {
                    if (logicaCabeza.contadorDeColisiones <= 0)
                    {
                       
                        anim.SetBool("agachado", false);
                        if (!relentizado)
                        {
                            velocidadMovimiento = velocidadInicial;
                        }
                        //cambio de collider:
                        cabeza.SetActive(false);
                        colagachado.enabled = false;
                        colpardo.enabled = true;
                        estoyAgachado = false;
                    }
                    //
                }
            }

            anim.SetBool("tocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }

    }



    public void EstoyCayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("salte", false);
    }

    /*public void aplicarFuerza()
    {
        rb.AddForce(new Vector3(0, fuezaDeSalto, 0), ForceMode.Impulse);

    }*/





    public void DejeDeGolpear()
    {
        estoyAtacando = false;
 
    }







  


}
