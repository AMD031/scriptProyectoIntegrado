using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  Instacia un prefab cuando al enemigo se le agota la barra de salud
///  y cambia los datos de la partida actual.
/// </summary>

public class InstaciarAlma : MonoBehaviour
{
    public SaludEnemigo saludEnemigo;
    public GameObject Alma;
     GestorGuardarCargar gestorGuardar;
    public cargadorNIvel cargadorNIvel;
    public string nombre;
    private bool instaciado = false;


    private void Start()
    {

       // gestorGuardar = GameObject.FindGameObjectWithTag("gestorGuardarCargar").GetComponent<GestorGuardarCargar>();
    }

    private void Update()
    {

        if (saludEnemigo.currentHealth <= 0)
        {
            if (nombre.Equals("night"))
            {
                gestorGuardar.Datos.Almajefe2 = true;
                gestorGuardar.Datos.Jefe2Muerto = true;
                gestorGuardar.Datos.Almajefe2colocada = false;
            }

            if (nombre.Equals("mutante"))
            {
                gestorGuardar.Datos.Almajefe1 = true;
                gestorGuardar.Datos.Jefe1Muerto = true;
                gestorGuardar.Datos.Almajefe1colocada = false;
            }

            if (!instaciado)
            {
                instaciado = true;
                Instantiate(Alma, transform.position , Quaternion.identity);

            }

        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && saludEnemigo.currentHealth <= 0)
        {
            cargadorNIvel.cargarNivel(1);
        }




    }





}
