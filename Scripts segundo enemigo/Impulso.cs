using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Alplica una catidad de fuerza a un prefab
/// </summary>

public class Impulso : MonoBehaviour
{
    Rigidbody rb;
    public float fuerza = 20f;
  

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody>();
        rb.AddForce(-Vector3.forward ,ForceMode.Impulse);
        Invoke("autoDestruir", 100f); 
    }

    public void autoDestruir()
    {
        Destroy(gameObject);
    }
   

   
}
