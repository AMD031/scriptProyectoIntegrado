using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  Clase que gestiona la barra de salud del personaje
/// </summary>

public class BarraSaludJugador : MonoBehaviour
{

    public Slider slider;// deslizador que mueve la barra
    //public Gradient gradient;
    public Image fill; // relleno de la barra


    /// <summary>
    /// Asigna el malor maximo con el que empieza la barra
    /// </summary>
    /// <param name="mana"> valor maximo de la barra</param>

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        //fill.color = gradient.Evaluate(1f);
    }


    /// <summary>
    /// Cambia el valor actual de la barra
    /// </summary>
    /// <param name="mana"> valor actual de la barra</param>

    public void SetHealth(int health)
    {
        slider.value = health;
        //fill.color = gradient.Evaluate(slider.normalizedValue);

    }
 
}
