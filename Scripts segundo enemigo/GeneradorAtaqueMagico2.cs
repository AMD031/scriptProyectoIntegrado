using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que genera una serie de prefab los cuales al entra encontacto con el 
/// jugador relentiza su velocidad.
/// </summary>

public class GeneradorAtaqueMagico2 : MonoBehaviour
{
    public GameObject  prefab;
    public GameObject[] puntos;
    int n = 0;
    public bool iniciar = false;



    private void Update()
    {
        if (iniciar)
        {
            ++n;
            if (n == 3)
            {
                n = 1;
            }
            StartCoroutine("CreateInstacias", n); 
        }
        
    }


    private IEnumerator CreateInstacias(int n)
    {
            iniciar = false;
            for (int i = 1; i < puntos.Length; i++)
            {
                if (i % n == 0)
                {
                    Instantiate(prefab, puntos[i].transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
                    yield return new WaitForSeconds(0.3f);
                    Instantiate(prefab, puntos[i].transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
                    yield return new WaitForSeconds(0.5f);
                    Instantiate(prefab, puntos[i].transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
                    yield return new WaitForSeconds(0.8f);
              }
            }
          
     
      
    }




 }




  



