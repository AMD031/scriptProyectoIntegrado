using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que mueve mueve una serie de prefab que reletiza al jugador a la posición en la que él estuviera.
/// </summary>

public class MoverAtaqueMagico2 : MonoBehaviour
{
    Vector3 pos;
    public float velocidad = 100;
    GameObject jugador ;
    LogicaPersonaje1 LogicaPersonaje1;


    private void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        LogicaPersonaje1 = jugador.GetComponent<LogicaPersonaje1>();
    }
    // Start is called before the first frame update
    void Start()
    {
        pos = jugador.transform.position;
        if (velocidad == 0)
        {
            velocidad = 100;
        }

        Invoke("autoDestruir", 20f);

    }



    private void FixedUpdate()
    {   // desplaza los prefab
        float step = velocidad * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, pos, step);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LogicaPersonaje1.activarRelentizado();
            autoDestruir();
        }

    }


    /// <summary>
    /// elimina el prefab
    /// </summary>
    public void autoDestruir()
    {
        GameObject.Destroy(gameObject);
    }

}
