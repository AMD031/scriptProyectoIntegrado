using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hace girar una serie de prefab a una velicidad y cadidad de águlos concreta. 
/// </summary>

public class EjeRotacionHechizo3 : MonoBehaviour
{
    public float anguloGiro = 1;
    public float velocidadGiro = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.Play("engranaje", AudioManager.TRAMPAS, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.Play("engranaje", AudioManager.TRAMPAS, false);
        }
    }


    private bool rotando = false;

    public void rotar(float angulo, float velocidad)
    {
        if (!rotando)
        {
            Vector3 direction = new Vector3(0, transform.rotation.eulerAngles.y + angulo, 0);
            Quaternion targetRotation = Quaternion.Euler(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * velocidad);
        }
        rotando = false;
    }

    private void FixedUpdate()
    {
        rotar(anguloGiro, velocidadGiro);
    }


}
