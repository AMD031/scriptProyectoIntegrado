using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaludEnemigo : MonoBehaviour
{
    public int maxHealth = 500; // cantidad máxima de salud
    public int currentHealth; // salud actual 
    public BarraSaludEnemigo barraSaludEnemigo;
    public Animator anim;
    private bool llamado = false; // variable booleane que se usa para que le método morir se llame una sola vez
    //public LogicaPersonaje1 logicaPersonaje;
    public AudioManager gestoraudio;



    private void Start()
    {

        currentHealth = /*10*/ maxHealth;
        barraSaludEnemigo.SetMaxHealth(maxHealth);
    }


    private void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.Z))
        {
      
            TakeDamage(10);
        }*/

    }

    /// <summary>
    /// Reduce la barra de vida
    /// </summary>
    /// <param name="damage">cantida a reducir de la barra </param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        barraSaludEnemigo.SetHealth(currentHealth);

        if (currentHealth <= 0 && !llamado)
        {
            morir();
        }

        /* if (currentHealth <= 0 && !llamado)
        {
            Invoke("morir", 0.2f);
        }*/
    }

    /// <summary>
    ///  Es llamado cuando la barrade salud del enemigo se agota. Detine la música y llama a la
    ///  animación de muerte
    /// </summary>

    void morir()
    {
        llamado = true;

        if (gameObject.name.Equals("mutante"))
        {
          gestoraudio.Play("jefe1", AudioManager.MUSICA, false);
        }

        if (gameObject.name.Equals("night"))
        {
           gestoraudio.Play("jefe2", AudioManager.MUSICA, false);
        }

        anim.SetTrigger("Muerto");
        // logicaPersonaje.muerto = true;
        //Destroy(gameObject);
        //  SceneManager.LoadScene("perder");
    }




}
