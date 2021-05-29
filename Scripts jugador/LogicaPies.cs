using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Se encarga de detectar si hay suelo y amentar la velocidad de caida en caso 
/// de que no haya
/// </summary>

public class LogicaPies : MonoBehaviour
{

    public LogicaPersonaje1 logicaPersonaje1;
    public float distanciaSuelo;
    //public Animator anim;
    public ConstantForce cf;
    public float tiempoEsparaAnimacionCaida = 0.5f;
    float tiempoCaida = 0;




    void Update()
      {

        tiempoCaida += Time.deltaTime;

        RaycastHit hit;


     
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
         {
             Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

             if (hit.distance <= distanciaSuelo  
                && !hit.collider.CompareTag("Player")
                && !hit.collider.CompareTag("pieDe")
                && !hit.collider.CompareTag("pieIz")
                && !hit.collider.CompareTag("pie")
                )
             {
                logicaPersonaje1.puedoSaltar = true;
                tiempoCaida = 0;
                cf.force = new Vector3(0, -5f, 0);
            }
            else
            {
              
                Vector3 z = new Vector3(0, -1, 0);
                cf.force += z;
                if (tiempoCaida >= tiempoEsparaAnimacionCaida)
                {
                    logicaPersonaje1.puedoSaltar = false;
                }
            }
         

         
          

         }
     }




   



    /*    private void OnTriggerStay(Collider other)
        {

            logicaPersonaje1.puedoSaltar = true;

        }

        private void OnTriggerExit(Collider other)
        {

            logicaPersonaje1.puedoSaltar = false;

        }*/
}
