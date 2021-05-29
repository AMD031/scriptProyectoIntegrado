using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clase que controla el relleno de uno slider que simula la barra de
/// vida del enemigo.
/// </summary>

public class BarraSaludEnemigo : MonoBehaviour
{

    public Slider slider;
    //public Gradient gradient;
    public Image fill;

  


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        //fill.color = gradient.Evaluate(1f);
    }


    public void SetHealth(int health)
    {
        slider.value = health;
        //fill.color = gradient.Evaluate(slider.normalizedValue);

    }
 
}
