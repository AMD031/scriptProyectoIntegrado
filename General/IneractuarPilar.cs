using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// clase encargada de permitir que el jugador interactue con los pilares del escenario nexo y establece algunos mensajes.
/// </summary>
public class IneractuarPilar : MonoBehaviour
{
    public GameObject jugador;
    public GameObject pilarJefe1;
    public GameObject pilarJefe2;
    public Animator anim;
    public GestorGuardarCargar gestorGuardarCargar;
    bool interactuarPilar1;
    bool interactuarPilar2;
    public GameObject alma1;
    public GameObject alma2;
    public LogicaPersonaje1 logicaPersonaje;
    public GameObject mensaje1;
    public GameObject mensaje2;
    public TMPro.TMP_Text textoMensaje1;
    public TMPro.TMP_Text textoMensaje2;

    private void Start()
    {
        textoMensaje1.text = "Pulsa E para interactura.";
        textoMensaje2.text = "Pulsa E para interactuar.";
    }


    void Update() {

        if(gestorGuardarCargar.Datos != null)
        {

            if (!gestorGuardarCargar.Datos.Almajefe1 && !gestorGuardarCargar.Datos.Almajefe1colocada)
            {
                textoMensaje1.text = "No tienes nada para colocar.";
            }

            if (!gestorGuardarCargar.Datos.Almajefe2 && !gestorGuardarCargar.Datos.Almajefe2colocada)
            {
                textoMensaje2.text = "No tienes nada para colocar.";
            }

            if (gestorGuardarCargar.Datos.Almajefe1colocada) {
                textoMensaje1.text = "";
            }

            if(gestorGuardarCargar.Datos.Almajefe2colocada)
            {
                textoMensaje2.text = "";
            }

            if (Input.GetKey(KeyCode.E) &&
                interactuarPilar1)
            {
                logicaPersonaje.estoyAtacando = true;
                gestorGuardarCargar.Datos.Almajefe1 = false;
                gestorGuardarCargar.Datos.Almajefe1colocada = true;
                anim.SetTrigger("Rezar");
                interactuarPilar1 = false;
                alma1.SetActive(true);


                Debug.Log("interacion finalizada " + gestorGuardarCargar.Datos.Almajefe1 + "  "
                          + gestorGuardarCargar.Datos.Almajefe1colocada);
            }
            if (Input.GetKey(KeyCode.E) &&
                interactuarPilar2)
            {
                logicaPersonaje.estoyAtacando = true;
                gestorGuardarCargar.Datos.Almajefe2 = false;
                gestorGuardarCargar.Datos.Almajefe2colocada = true;
                anim.SetTrigger("Rezar");
                interactuarPilar2 = false;
                alma2.SetActive(true);

                Debug.Log("interacion finalizada 2" + gestorGuardarCargar.Datos.Almajefe2 + "  "
                       + gestorGuardarCargar.Datos.Almajefe2colocada);
            }

      





        }





    }

    private void OnTriggerEnter(Collider other)
    {
        //pilar 1 
        if (gameObject.CompareTag("pilar1") && other.CompareTag("Player"))
        {
            Debug.LogWarning("cerca pilar 1");
            Debug.Log(" Almajefe1colocada " + gestorGuardarCargar.Datos.Almajefe1colocada +
                      "  Almajefe1 "        + gestorGuardarCargar.Datos.Almajefe1);

            mensaje1.SetActive(true);
            if (gestorGuardarCargar.Datos != null)
            {
                if (!gestorGuardarCargar.Datos.Almajefe1colocada &&
                    gestorGuardarCargar.Datos.Almajefe1)
                {
                    interactuarPilar1 = true;
                    mensaje1.SetActive(true);
                }
                else
                {
                    interactuarPilar1 = false;
                }
            }

        }


        //pilar 2
        if (gameObject.CompareTag("pilar2") && other.CompareTag("Player"))
        {
            Debug.LogWarning("cerca pilar 2");
            Debug.Log(" Almajefe1colocada " + gestorGuardarCargar.Datos.Almajefe1colocada +
                      "  Almajefe2 " + gestorGuardarCargar.Datos.Almajefe1);

            mensaje2.SetActive(true);
            if (gestorGuardarCargar.Datos != null)
            {
                if (!gestorGuardarCargar.Datos.Almajefe2colocada &&
                    gestorGuardarCargar.Datos.Almajefe2)
                {
                 
                    interactuarPilar2 = true;
                }
                else
                {
                    interactuarPilar2 = false;
                }
            }

        }


    }

    private void OnTriggerExit(Collider other)
    {
        interactuarPilar1 = false;
        interactuarPilar2 = false;
        mensaje1.SetActive(false);
        mensaje2.SetActive(false);
        textoMensaje1.text = "Pulsa E para interactura.";
        textoMensaje2.text = "Pulsa E para interactuar.";

    }


}
