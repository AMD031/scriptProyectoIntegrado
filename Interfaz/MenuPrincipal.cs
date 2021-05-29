using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase encargada de de llamar a las acciones 
/// del menú pricipal y mostrar algunos mensajes
/// </summary>
public class MenuPrincipal : MonoBehaviour
{
    public cargadorNIvel cn;
    public MenuAjustes menuAjustes;
    public GameObject mensaje;
    public GameObject mensajeNoHaydatos;
    public GameObject posJugador;
   

    private void Start()
    {
        menuAjustes.cargarAjustes();
        menuAjustes.establecerAjutesCargados();
    }

    /// <summary>
    /// inicia el juego y crea nueva partida.
    /// </summary>
    public void EmpezarJuego()
    {
        DatosPartida datos = GuardarDatos.CargarDatos();
        if (datos == null)
        {
            cn.cargarNivel(1);
        }
        else
        {
            mensaje.SetActive(true);
        }
    }



    /// <summary>
    /// se ejecuta cuando pulsa sobler el botón si genera nuevos datos de partida.
    /// </summary>
    public void botonSiPulsado()
    {
        GuardarDatos.Guardar(new DatosPartida(posJugador));
        mensaje.SetActive(false);
        cn.cargarNivel(1);

    }


    /// <summary>
    /// Muetra un mensaje emergente y lo oculta después de un timepo
    /// </summary>
    public void mostarMensajeNoHaydato()
    {
        gameObject.SetActive(false);
        mensajeNoHaydatos.SetActive(true);
        Invoke("ocultarMensajeNoHaydato",0.5f);
    }

   

    /// <summary>
    /// Se ejecuta cuando pulsa sobler el botón no y oculta el mensaje
    /// </summary>
    public void botonNoPulsado()
    {
        mensaje.SetActive(false);

    }


    /// <summary>
    /// Carga la partida del juego
    /// </summary>

    public  void cargarPartida()
    {
        DatosPartida  datos=  GuardarDatos.CargarDatos();
        if (datos != null)
        {
            cn.cargarNivel(1);
        }
        else
        {
            mostarMensajeNoHaydato();
        }
    }


    /// <summary>
    /// Finaliza la aplicacion
    /// </summary>
    public void SalirJuego()
    {
        Debug.Log("salir");
        Application.Quit();
    }






}
