using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que aplica una fuerza segun el lado del objeto martillo con el que
/// el jugador interactue
/// </summary>

public class LadosTrampa : MonoBehaviour
{
    public Trampa2 trampa;

 


    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name.Equals("b") && other.CompareTag("Player") )
        {
            trampa.rb.AddForce(trampa.martillo.transform.right * trampa.emujon, ForceMode.Impulse);
        }

        if (gameObject.name.Equals("a") && other.CompareTag("Player"))
        {
            trampa.rb.AddForce(-trampa.martillo.transform.right * trampa.emujon, ForceMode.Impulse);
        }


    }


}
