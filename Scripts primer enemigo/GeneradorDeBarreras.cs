using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Se encarga de crear objectos en forma de cilindro de colores rojo o azul
/// </summary>

public class GeneradorDeBarreras : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject roja;
    public GameObject azul;
    public Material material;
    public float tiempoDeGenerado = 2.5f;



    private bool generarBarrera = true;
    public bool para = true;


    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (generarBarrera && !para)
        {
            instanciaBarrera();
            generarBarrera = false;
        }
    }


    private void instanciaBarrera()
    {
        Invoke("crearBarrera", tiempoDeGenerado);
    }


    private void crearBarrera()
    {
        int n = Random.Range(0, 3);
        if ( n == 0 )
        {
            material.SetColor("_Color", Color.red);
            Instantiate(roja, transform.position, Quaternion.identity);
          
        }
        else
        {
            material.SetColor("_Color", Color.blue);
            Instantiate(azul, transform.position, Quaternion.identity);
        }

        
      generarBarrera = true;


    }



}
