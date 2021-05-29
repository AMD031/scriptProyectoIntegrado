using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Clase axuliar usada para detectar cuando el jugador esta dentro de un
///  collider
/// </summary>
public class DectectarCercaBarrera : MonoBehaviour
{
    public bool jugadorCerca;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")){
            jugadorCerca = true;
        }
    }


}
