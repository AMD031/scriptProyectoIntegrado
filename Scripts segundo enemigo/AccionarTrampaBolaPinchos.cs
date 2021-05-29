using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Instacia un trampa de pinchos en el juego
/// </summary>
public class AccionarTrampaBolaPinchos : MonoBehaviour
{
    bool creada = false;
    public GameObject bolapichos;
    public Transform [] puntoDisparo;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && !creada)
        {
            creada = true;

            foreach (Transform t in puntoDisparo)
            {
                Instantiate(bolapichos, t.position, Quaternion.identity);
            }
        }
        
    }



}
