using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// clase que se llama cuando se pasua el juego usando la tecla escape
/// </summary>
public class MenuPasusa : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject menuPausaUI;
    private SaludJugador saludJugador;
    private bool subMenuActivo = false;


    private void Start()
    {
        saludJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<SaludJugador>();
    }

    private void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Escape) && saludJugador.currentHealth > 0 && !subMenuActivo)
        {
            if (JuegoPausado)
            {
                regresar();

            }
            else
            {
                pausa();
            }

        }

    }

    public void submenuActivado()
    {
         subMenuActivo = true; 
    }   

    public void submenuDesactivado()
    {
        subMenuActivo = false;
     }


    /// <summary>
    /// Despausa el juego y esconde el menú de pausa.
    /// </summary>
    public void regresar()
        {
            menuPausaUI.SetActive(false);
            Time.timeScale = 1f;
            JuegoPausado = false;

        }

        /// <summary>
        ///  Pausa el juego y hace visible el menú de pausa
        /// </summary>
        public void pausa()
        {
             menuPausaUI.SetActive(true);
             Time.timeScale = 0f;
             JuegoPausado = true;
        }



        /// <summary>
        ///  Carga el menu pricipal
        /// </summary>
        public void cargarMenu()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
            Debug.Log("menu cargando");
        }


        /// <summary>
        ///  Detiene la ejecución del juego.
        /// </summary>
        public void salirJuego()
        {
           Application.Quit();
           Debug.Log("salir juego");
        }



}
