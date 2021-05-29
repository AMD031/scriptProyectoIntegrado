using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarInidcador : MonoBehaviour
{
    private Transform jugador;
    private Transform cam;
    private void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }


    private void FixedUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }



}
