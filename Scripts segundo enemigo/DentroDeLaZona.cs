using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DentroDeLaZona : MonoBehaviour
{
    public bool dentro = false;
    public bool activarVeneno = false;
    public SaludJugador saludjugador;
    private int contadorVeneno = 0;
    public GameObject[] venenos;
    public GameObject GeneradorSalud;
    private bool Activado = false;
    public GameObject Hechizo3; 

    /// <summary>
    ///  Activa la generacion de una serie de prefaba que simula item de vida 
    /// </summary>
    public void activarSaludVeneno()
    {
        if (!Activado)
        {
            GeneradorSalud.SetActive(true);
            visualizarVeneno();
            Hechizo3.SetActive(true);
        }

    }


    /// <summary>
    /// Activa una serie de prefab de particula que simula un gas venenoso.
    /// </summary>
    public void visualizarVeneno()
    {
        foreach (GameObject veneno in venenos)
        {
            veneno.SetActive(true);
        }
    }
    /// <summary>
    /// Desactiva una serie de prefab de particula que simula un gas venenoso.
    /// </summary>
    public void quitarVisualizarVeneno()
    {
        foreach (GameObject veneno in venenos)
        {
            veneno.SetActive(false);
            GeneradorSalud.SetActive(false);
            Hechizo3.SetActive(false);
            
        }
    }

 

    private void OnTriggerStay(Collider other)
    {
        //Cada cierto tiempo resta vida al jugador mientras permanece dentro del collider.
        if (other.CompareTag("Player"))
        {
            dentro = true;
            if (activarVeneno )
            {
                activarSaludVeneno();
                contadorVeneno++;
                if (contadorVeneno > 10)
                {
                    saludjugador.TakeDamage(ValoresAtaque.veneno);
                    contadorVeneno = 0;
                }
            }
            else
            {
                Activado = false;
                quitarVisualizarVeneno();
            }

        }


   




    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentro = false;
          //  Debug.Log("fuera zona");
        }
    }






}
