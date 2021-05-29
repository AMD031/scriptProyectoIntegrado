using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que se comunica con la clase barar mana y hace uso
/// de sus mentodos para gestionar la barar.
/// </summary>

public class Mana : MonoBehaviour
{
    public int maxMana = 100;
    public int currentMana;
    public BarraMana barraMana;
    public Animator anim;
    //private bool llamado = false;
    public LogicaPersonaje1 logicaPersonaje;
    public float tiempoRecaragaMana = .1f;
    public int CantidadRecargaMana = 1;
   


    private void Awake()
    {
        currentMana = maxMana;
        barraMana.SetMaxMana(maxMana);
        StartCoroutine("recargarMana", CantidadRecargaMana);
    }

 

    /*  private void Update()
     {
        if (Input.GetKeyDown(KeyCode.Space))
         {
             TakeDamage(20);
         }
      }*/





    private void Update()
    {
  /*      if (Input.GetKeyDown(KeyCode.B))
        {
            cambiarValorMana(10);
        }*/
    }

    /// <summary>
    /// Recaga de forma contiunua el mana
    /// </summary>
    /// <param name="mana">cantidad a recargar </param>
    /// <returns></returns>

    private IEnumerator recargarMana(int mana)
    {

        while (true)
        {

            if (currentMana <= maxMana)
            {
                currentMana += mana;
                barraMana.SetMana(currentMana);
            }

            if (currentMana >maxMana)
            {
                currentMana = maxMana;
                barraMana.SetMana(currentMana);
            }
            yield return new WaitForSeconds(tiempoRecaragaMana);

        }
    }


    public void cambiarValorMana(int mana)
    {
        currentMana -= mana;
        barraMana.SetMana(currentMana); 
    }

}
