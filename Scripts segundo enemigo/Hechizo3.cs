using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Clase encargada de instaciar prefab que reduce la barra de vida del jugador usado
///  un rayCast como detonador.
/// </summary>
public class Hechizo3 : MonoBehaviour
{
    public GameObject ejeDeRotacion;
    private bool rotando = false;
    public GameObject fuegoDisparo;
    private float tiempoDisparo = 0f;
    public bool trampaFuego = false; // variable que especifica el tipo de proyectil
    public float tiempoTrampaFuego = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }


   /* private void OnTriggerEnter(Collider other)
    {
  
        if (other.CompareTag("Player"))
        {

           Instantiate(fuegoDisparo, ejeDeRotacion.transform.position, ejeDeRotacion.transform.rotation);

        }


    }*/


    private void FixedUpdate()
    {

     
        tiempoDisparo += Time.deltaTime;
     
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;
     
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * hit.distance, Color.yellow);
            // Debug.Log("Did Hit");
            if (hit.collider.CompareTag("Player"))
            {
                if (tiempoDisparo >= 1.5f)
                {
         
                    if (!trampaFuego)
                    {
                        intanciarDisparo();
                    }
                    else
                    {
                        Invoke("intanciarDisparo", tiempoTrampaFuego);
                    }
                   
                    tiempoDisparo = 0;
                }
                
            }

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * 1000, Color.white);
           // Debug.Log("Did not Hit");
        }

    }


    public void intanciarDisparo()
    {
        Instantiate(fuegoDisparo, ejeDeRotacion.transform.position, ejeDeRotacion.transform.rotation);
     
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
