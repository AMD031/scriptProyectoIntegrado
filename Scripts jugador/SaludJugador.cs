using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Clase que controla la barra de salud del jugador.
/// </summary>
public class SaludJugador : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public BarraSaludJugador barraSaludJugador;
    public Animator anim;
    //private bool llamado = false;
    public LogicaPersonaje1 logicaPersonaje;
    private bool muerto =false;




    private void Awake()
    {
     
        currentHealth = maxHealth;
        barraSaludJugador.SetMaxHealth(maxHealth);

    }


    private void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(10);
        }*/
    }


    /// <summary>
    /// Método encargado de disminuir la vida actual del jugador.
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {

       
        currentHealth -= damage;
        barraSaludJugador.SetHealth(currentHealth);
    

        if (currentHealth <= 0)
        {
            morir();
        }
        
        /* if (currentHealth <= 0 && !llamado)
        {
            Invoke("morir", 0.2f);
        }*/
    }


    void morir()
    {
        if (!muerto)
        {
            muerto = true;
            logicaPersonaje.muerto = true;
            //anim.SetTrigger("Muerto");
            anim.SetBool("sinVida", true);

        }
      
         
     }




}
