using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Retorna al usuario al menu principal tras finalizar el jeugo.
/// </summary>

public class VolverMenu : MonoBehaviour
{
    public cargadorNIvel cargadornivel;



    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            cargadornivel.cargarNivel(0);

        }

    }




}
