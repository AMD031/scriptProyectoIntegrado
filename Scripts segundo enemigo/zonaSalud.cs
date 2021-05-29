using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// clase encargada de instaciar powerup en un agulo diferenta cada vez que
/// el jugador entra en contacto con uno.
/// </summary>

public class zonaSalud : MonoBehaviour
{
    public SaludJugador saludjugador;
    public GameObject puntoGiro;


    public void rotar(float angulo)
    {
        Vector3 direction = new Vector3(0, puntoGiro.transform.rotation.eulerAngles.y + angulo, 0);
        Quaternion targetRotation = Quaternion.Euler(direction);
        puntoGiro.transform.rotation = targetRotation;
        gameObject.SetActive(true);
    }

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Player"))
            {
              if(saludjugador.currentHealth <= 100)
              {
                saludjugador.TakeDamage(-10);
              }
              gameObject.SetActive(false);
              rotar(40);
            }

        }




}
