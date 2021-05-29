using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Se ejecuta des pues de cargar el nivel y hace cambios en el 
/// escenario según el estado del archivo guardado.
/// </summary>


public class LeerDatosPartida : MonoBehaviour
{
    private GameObject jugador;
    public GestorGuardarCargar gestorGuardarCargar;
    public GameObject almaJefe1;
    public GameObject almajefe2;
    public GameObject portal1;
    public GameObject portal2;
    public GameObject portalFin;
 

    private void Start()
    {
       jugador = GameObject.FindGameObjectWithTag("Player");

        if (gestorGuardarCargar == null)
        {
            gestorGuardarCargar = GameObject.FindGameObjectWithTag("gestorGuardarCargar").GetComponent<GestorGuardarCargar>();
        }

        if (gestorGuardarCargar.Datos == null)
        {
            gestorGuardarCargar.Datos = gestorGuardarCargar.cargarDatos();
           // Debug.Log("Valor x"+gestorGuardarCargar.Datos.Posicion[0]);
        }



       
        if (gestorGuardarCargar.Datos != null && SceneManager.GetActiveScene().buildIndex == 1)
        {
            jugador.transform.position = new Vector3(gestorGuardarCargar.Datos.Posicion[0], gestorGuardarCargar.Datos.Posicion[1], gestorGuardarCargar.Datos.Posicion[2]);
            
            if (gestorGuardarCargar.Datos.Almajefe1colocada)
            {
                almaJefe1.SetActive(true);
            }

            if (gestorGuardarCargar.Datos.Almajefe2colocada)
            {
                almajefe2.SetActive(true);
            }

            if (gestorGuardarCargar.Datos.Almajefe1 || gestorGuardarCargar.Datos.Almajefe1colocada)
            {
                portal1.SetActive(false);
            }

            if (gestorGuardarCargar.Datos.Almajefe2 || gestorGuardarCargar.Datos.Almajefe2colocada)
            {
                portal2.SetActive(false);
            }

        }

    }

    private void Update()
    {
        if (almajefe2.activeSelf == true && almaJefe1.activeSelf == true)
        {
            portalFin.SetActive(true);
        }
    }


}
