using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
///  Clase encargada de llamar a la barra de carga del juego
/// </summary>

public class cargadorNIvel : MonoBehaviour
{
    public GameObject pantallaDeCarga;
    public Slider slider;
    public Text textoProgreso;
    public Image[] bgs;

 
    /// <summary>
    /// LLama a una corrutina que realiza una carga asincronica del nivel 
    /// y calcula el porcenta de carga.
    /// </summary>
    /// <param name="escenarioIndice"> indice del escenario que se desea cargar</param>
    public void cargarNivel(int escenarioIndice)
    {
        StartCoroutine("cargaAsincronica", escenarioIndice);
    }




    IEnumerator cargaAsincronica(int escenarioIndice)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(escenarioIndice);
        pantallaDeCarga.SetActive(true);

        foreach (Image imagen in bgs)
        {
            imagen.enabled = true;
        }
 

        while (!op.isDone)
        {
            float progreso = Mathf.Clamp01(op.progress / .9f);

           // Debug.Log(op.progress * 100f+" ");

            slider.value = progreso;

            textoProgreso.text = progreso * 100f + "%";

            yield return null;
        }

    }



}
