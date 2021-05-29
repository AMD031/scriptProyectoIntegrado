using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// clase encargada de generar prefab que cambia de tamaño simulando una barrera
/// </summary>
public class Barrera : MonoBehaviour
{
    [Range(0, 1)]
    public int tipo = 0;
    public const int tipoFuego = 0;
    public const int tipoFisico = 1;

    private float z = 1;
    private float x = 1;
    private float y = 1;

    //public float tiempoCrearInstancia = 1.5f;
    public float tiempoDeVida =20f;
    public float tiempoDeEsperaCrecer = 10f;

    //cantidad de aumento de los x y z de del objeto barrera
    public float aumentoDimesionX = 0.05f;
    public float aumentoDimesionZ = 0.05f;
    GameObject jugador;

    //variable que contiene efectos.
    ControlShader controlShaderJugador;
    ControlShader controlShaderBarrera;
    LogicaPersonaje1 logicaJugador;
    private SaludEnemigo saludenemigo;
    private int contador = 0;
    private Image patada;
    private Image fuego;
    private GameObject canvas;
    private Vector3 nuevaEscala;

    public DectectarCercaBarrera dectectarCercaBarrera;


    private void Awake()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;
    }
    private void Start()
    {
        Invoke("autoDestroir", 30f);
        jugador =  GameObject.FindGameObjectWithTag("Player");
        controlShaderJugador = jugador.GetComponent<ControlShader>();
        controlShaderBarrera = GetComponent<ControlShader>();
        logicaJugador = jugador.GetComponent<LogicaPersonaje1>();
        saludenemigo = GameObject.FindGameObjectWithTag("enemigo").GetComponent<SaludEnemigo>();
        GameObject canvas =  GameObject.FindGameObjectWithTag("barraSaludJugador");
        
        

        foreach (Image i in canvas.GetComponentsInChildren<Image>())
        {
            if (i.name.Equals("imageFuego"))
            {
                fuego = i;
            }

            if (i.name.Equals("imagenPatada"))
            {
                patada = i;
            }

        }

        //Debug.Log(patada);

    }

    private void Update()
    {

        // hace visible las imgen cuando el jugador esta cerca de la barrera
        if (tipo == tipoFuego && dectectarCercaBarrera.jugadorCerca)
        {
            fuego.enabled = true;
        }


        // hace visible las imgen cuando el jugador esta cerca de la barrera
        if (tipo == tipoFisico && dectectarCercaBarrera.jugadorCerca)
        {
            patada.enabled = true;

        }

    }




    private void OnTriggerEnter(Collider other)
    {

        //Disminuye la barra de salud al entrar en contacto con el.
        if (!gameObject.tag.Equals("cercaBarrera") && other.tag.Equals("Player"))
        {

            if (tipo == tipoFuego)
            {

                controlShaderJugador.colorLineaDisover = Color.red;
                controlShaderJugador.inicarEfectoDisolver = true;
              
                jugador.GetComponent<SaludJugador>().TakeDamage(ValoresAtaque.dagnoBarreraMutanteJugador);
              
                autoDestroir();
            }

            if (tipo == tipoFisico )
            {

                controlShaderJugador.colorLineaDisover = Color.blue;
                if (!logicaJugador.estoyAtacando)
                {
                    controlShaderJugador.inicarEfectoDisolver = true;
                    jugador.GetComponent<SaludJugador>().TakeDamage(ValoresAtaque.dagnoBarreraMutanteJugador);
                    autoDestroir();
                }

            }


        }

        //-------------------destruye la barrera al ser golpeado por un objeto con la etiqueta de bola de fuego------------------
        if (!gameObject.tag.Equals("cercaBarrera") && other.tag.Equals("bolaFuego"))
        {
            if (tipo == tipoFuego)
            {
                other.GetComponent<Collider>().enabled = false;
                saludenemigo.TakeDamage(ValoresAtaque.dagnoBarreraMutanteJugador);
                gameObject.GetComponent<ControlShader>().inicarEfectoBarrera = true;
                Invoke("autoDestroir", 0.8f);
            }

        }
        //-------------------destruye la barrera al ser golpeado por un objeto con la etiqueta de pie------------------
        if ( (!gameObject.tag.Equals("cercaBarrera") && other.tag.Equals("pie")) && logicaJugador.estoyAtacando)
        {
            if (tipo == tipoFisico)
            {

                contador++;
                if (contador == 1)
                {
                    saludenemigo.TakeDamage(ValoresAtaque.dagnoBarreraMutanteJugador);
                }
                gameObject.GetComponent<ControlShader>().inicarEfectoBarrera = true;
                Invoke("autoDestroir", 0.5f);
            }

        }

    }



    private void FixedUpdate()
    {
        StartCoroutine("crecer");      
    }

   


    /// <summary>
    /// Corrutina que cambia el tamaño de la barrera
    /// </summary>

    IEnumerator crecer()
    {
       yield return new WaitForSeconds(tiempoDeEsperaCrecer);

        nuevaEscala = new Vector3(x += aumentoDimesionX, y, z += aumentoDimesionZ);
        transform.localScale = nuevaEscala;
        
    }

    /// <summary>
    /// Desactiva la imagen asociada a la barrera y elimina el objeto padre 
    /// </summary>
    private void  autoDestroir()
    {
        if (tipo == tipoFuego)
        {
            fuego.enabled = false;
        }
        else
        {
            patada.enabled = false;
        }

        GameObject.Destroy(gameObject.transform.parent.gameObject);
    }




}
