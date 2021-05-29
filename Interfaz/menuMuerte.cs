using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// clase que gestiona el menú que aparece cuando al jugador de le
/// agota la barra de vida.
/// </summary>
public class menuMuerte : MonoBehaviour
{
    public GameObject menuPausaUI;
    private SaludJugador saludJugador;
    private void Start()
    {
        saludJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<SaludJugador>();
    }


    private void Update()
    {
        if (saludJugador.currentHealth <= 0)
        {
            menuPausaUI.SetActive(true);

        }
        
    }

    /// <summary>
    /// Se llama cunado se pulsa sobre la opción  menú y carga la escena que 
    /// contiene el menú pricipal
    /// </summary>
    public void cargarMenu()
    {
        SceneManager.LoadScene(0);
    }


    /// <summary>
    ///  Se lla ma cuando se pulsa en la opción reintentar
    /// </summary>
    public void reintenar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
