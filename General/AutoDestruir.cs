using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// clase auxiliar que destruye un gameobject en un tiempo determinado
/// </summary>

public class AutoDestruir : MonoBehaviour
{
    public float tiempo = 3f;

    private void Start()
    {
        Invoke("autodestruir", tiempo);
    }


    private void autodestruir()
    {
        GameObject.Destroy(gameObject);
    }


}
