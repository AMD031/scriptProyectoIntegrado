using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase encargada de llamar algunos animaciones asocianos a los ataques del personaje, instaciar objetos y 
/// hacer visibles otros.
/// </summary>

public class Disparo : MonoBehaviour
{
    public Transform PuntoDisparo;
    public GameObject bolaFuego;
    public GameObject espada;
    public GameObject escudo;
    private Animator anim;
    private LogicaPersonaje1 logicaPersonaje;



    private void Start()
    {
        anim = GetComponent<Animator>();
        logicaPersonaje = GetComponent<LogicaPersonaje1>();
    }

    public Mana mana;
    
    /// <summary>
    /// Método que se llama cuando la animacion llega un frame concreto y instacia un
    /// objeto
    /// </summary>
    public void instaciarBolaFuego()
    {
        Instantiate(bolaFuego, PuntoDisparo.position, Quaternion.Euler(PuntoDisparo.rotation.eulerAngles));
    }




    /// <summary>
    /// Disminuye el valor de la barra de mana y llama una animacion
    /// </summary>
    public void usarBolaFuego(){

        if(mana.currentMana >= 50)
        {
            mana.cambiarValorMana(50);
            anim.SetTrigger("ataqueFuego");
            logicaPersonaje.estoyAtacando = true;

        }
  
    }

    /// <summary>
    /// Disminuye el valor de la barra de mana y llama una animacion
    /// </summary>
    public void usarEspada()
    {
        if (mana.currentMana >= 30)
        {
            anim.SetTrigger("hechizoEspada");
            logicaPersonaje.estoyAtacando = true;
            espada.SetActive(true);
            mana.cambiarValorMana(30);
        }
      
    }

    /// <summary>
    /// Disminuye el valor de la barra de mana y llama una animacion
    /// </summary>

    public void usarEscudo()
    {
        if (mana.currentMana >= 50)
        {
            anim.SetTrigger("activarEscudo");
            logicaPersonaje.estoyAtacando = true;
            escudo.SetActive(true);
            mana.cambiarValorMana(50);
        }
    
    }



    /// <summary>
    /// Desactiva el objeto escudo
    /// </summary>

    public void quitarEscudo()
    {
        escudo.SetActive(false);
    }

    /// <summary>
    /// Desactiva el objeto espada
    /// </summary>
    public void quitarEspada()
    {
        espada.SetActive(false);
    }

  



}
