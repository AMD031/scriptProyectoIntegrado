using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// clase que mantine los datos de partida entre carga de esnas haciendo uso
/// del patron siglestone y la funcion DontDestroyOnLoad
/// </summary>
public class GestorGuardarCargar : MonoBehaviour
{
    static DatosPartida datos;
    public static GestorGuardarCargar instance;
    GameObject jugador;

 

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        cargarDatos();
    }

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    public  DatosPartida Datos { get => datos; set => datos = value; }



    /// <summary>
    /// Método que llama al método guardar de la clase guardardatos
    /// </summary>
    /// <param name="datos">datos conjuto de datos para guardar. </param>

    public void guardarDatos(DatosPartida datos)
    {
        Debug.Log("guardando");
        GuardarDatos.Guardar(datos);

    }

    public DatosPartida cargarDatos()
    {
        datos = GuardarDatos.CargarDatos();

        if (datos != null)
        {
            Debug.Log("  x " + datos.Posicion[0] +
                      "  y " + datos.Posicion[1] +
                      "  x " + datos.Posicion[2] +
                      "  Jefe1Muerto " + datos.Jefe1Muerto +
                      "  Jefe2Muerto " + datos.Jefe2Muerto +
                      "  Almajefe1 " + datos.Almajefe1 +
                      "  Almajefe2 " + datos.Almajefe2 +
                      "  Almajefe1colocada " + datos.Almajefe1colocada +
                      "  Almajefe2colocada " + datos.Almajefe2colocada 
                    );
        }


        return datos;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Y))
        {
            Debug.Log("cargar datos pulsando y");
            cargarDatos();
        }


    }
}
