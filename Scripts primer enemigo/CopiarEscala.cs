using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase auxiliar usada para copia la escala de otro prefab
/// </summary>

public class CopiarEscala : MonoBehaviour
{
    public GameObject barrera;

    private void FixedUpdate()
    {
        {
            transform.position = barrera.transform.position;
            transform.localScale = barrera.transform.localScale;
            transform.rotation = barrera.transform.rotation;
        }


    }
}
