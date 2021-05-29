using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// clase que carga un escenario cuando entra dentro de la
/// zona del trigger.
/// </summary>

public class Portal : MonoBehaviour
{
    public cargadorNIvel cn;
    private int contador = 0;
    public int nivelCargar = 2;

    private void OnTriggerEnter(Collider other)
    {
        contador++;
        if (contador ==1)
        {
            cn.cargarNivel(nivelCargar);
        }

    }




}
