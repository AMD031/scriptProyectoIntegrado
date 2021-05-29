using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que mantiene el prefab martillo en movimiento.
/// </summary>
public class Trampa2 : MonoBehaviour
{
    public Rigidbody rb;
    public float emujon = 1.0f;
    private float tiempo  = 0;
    public GameObject martillo;




    // Start is called before the first frame update
    private void Awake()
    {
        if (martillo)
        {
            //rb.AddForce(-transform.right * emujon, ForceMode.Impulse);
            rb = martillo.GetComponent<Rigidbody>();
        }
    }


    private void FixedUpdate()
    {
        tiempo += Time.deltaTime;
       
    }




    private void OnTriggerStay(Collider other)
    {
        //añade una fuerza si el gameObject permanece más de 10 segundo.
        if (other.CompareTag("Martillo"))
        {

            if (tiempo >= 10)
            {
                rb.AddForce(-martillo.transform.right * emujon, ForceMode.Impulse);
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Martillo"))
        {
            tiempo = 0;
        }
    }


}
