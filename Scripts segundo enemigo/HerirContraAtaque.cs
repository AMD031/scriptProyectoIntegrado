using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Resta vida al enemigo cuando un objeto con la etique tab entra
///  en el collider
/// </summary>

public class HerirContraAtaque : MonoBehaviour
{

    public SaludEnemigo SaludEnemigo;



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("contraAtaque"))
        {
            SaludEnemigo.TakeDamage(ValoresAtaque.dagnoContrataqueJugadorNight);
        }

    }



}
