using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
///  Simple mensaje que apunta al jugador y muestra un texto.
/// </summary>

public class MensajeGuardado : MonoBehaviour
{
    public GameObject mensaje;
    public Transform cam;
    public GestorGuardarCargar gestorGuardarCargar;
    private bool dentroZonaGuardado = false;
    public GameObject jugador;
    public GameObject imagenGuardado;

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

   


    private void Update()
    {
        if(Vector3.Distance(jugador.transform.position, transform.position) <= 2)
        {
            dentroZonaGuardado = true;
        }
        else
        {
            dentroZonaGuardado = false;
        }

        if (dentroZonaGuardado)
        {
 
            dentroZonaGuardado = true;
            mensaje.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                gestorGuardarCargar.guardarDatos(new DatosPartida(jugador));
            }
        }
        else
        {
            dentroZonaGuardado = false;
            mensaje.SetActive(false);
        }

        if (Input.GetKey(KeyCode.H))
        {
            gestorGuardarCargar.guardarDatos(new DatosPartida(
            jugador, //posicion jugador
            false,   // jefe1 muerto
            false,   // jefe2 muerto
            false,   // tiene alame jefe1
            false,   // tiene alma  jefe2
            false,   // alama1colocada
            false)); // alma 2colocada 
        }

        

        // al pulsal e intenta guarda los datos de la partida.
        if (dentroZonaGuardado && Input.GetKey(KeyCode.E))
        {
            Debug.Log("intentando guardar");


            if (gestorGuardarCargar.Datos != null)
            {
                imagenGuardado.SetActive(true);

                Time.timeScale = 0;
                gestorGuardarCargar.Datos.Posicion[0] = jugador.transform.position.x;
                gestorGuardarCargar.Datos.Posicion[1] = jugador.transform.position.y;
                gestorGuardarCargar.Datos.Posicion[2] = jugador.transform.position.z;
                gestorGuardarCargar.guardarDatos(gestorGuardarCargar.Datos);

                Invoke("restuaraPantalla", 0.4f);

                Time.timeScale = 1;

            }
            else
            {
                gestorGuardarCargar.guardarDatos(new DatosPartida(jugador));
            }

        }

        
        
        


    }
    /// <summary>
    /// Quita el mensaje de guardado de la pantalla.
    /// </summary>
    void restuaraPantalla()
    {
      
        imagenGuardado.SetActive(false);
    }


}
