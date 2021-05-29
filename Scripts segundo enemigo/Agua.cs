using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  disminuye la barra de vida del jugador al
///  entra en el collider
/// </summary>
public class Agua : MonoBehaviour
{
    public SaludJugador sj;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
         sj.TakeDamage(ValoresAtaque.agua);
        }
    }







}
