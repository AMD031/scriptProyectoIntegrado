using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple script que llama a la escena de fin del juego.
/// </summary>

public class PortalFin : MonoBehaviour
{

    public cargadorNIvel cargadornivel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cargadornivel.cargarNivel(4);
        }
    }




}
