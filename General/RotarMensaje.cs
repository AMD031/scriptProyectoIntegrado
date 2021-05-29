using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que rota el mensaje hacia la cámara.
/// </summary>

public class RotarMensaje : MonoBehaviour
{
    public Transform cam;


    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
