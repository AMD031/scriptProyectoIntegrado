using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Si hay un objeto sobre la cabeza de le personaje permanece agachado.
/// </summary>


public class LogicaCabeza : MonoBehaviour
{

    public int contadorDeColisiones = 0;




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstaculo")
        {
           contadorDeColisiones++;   
        }
    }

    private void OnTriggerExit(Collider other)
    {
     
       contadorDeColisiones--;
    }




}
