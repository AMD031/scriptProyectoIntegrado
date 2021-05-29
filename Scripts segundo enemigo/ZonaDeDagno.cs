using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Clase auxialiar que se comunica con clase HerirJugadorParticulas.
///  Le dice si el jugador esta detro de un colllider y si tiene activo el objeto escudo.
/// </summary>
public class ZonaDeDagno : MonoBehaviour
{

    public bool dentroZona = false;
    public GameObject escudo;
    public bool escudoActivo;

    private void Update()
    {

        if (escudo.activeSelf)
        {
            escudoActivo = true;
        }
        else
        {
            escudoActivo = false;
        }
        
    }




    private void OnTriggerStay(Collider other)
    {
        if ( other.CompareTag("Player")  )
        {
            dentroZona = true;
        }
      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentroZona = false;
        }

      
        
    }



}
