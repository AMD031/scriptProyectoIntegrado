using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShader : MonoBehaviour
{
    public  Material materialLineas;
    public  Material materialEfectoDisolver;
    public  Material materialBarrera;

    public float grosorLineaFijado = 0.02f;
    public Color colorLineaFijado = Color.red;

    public float grosorLineaDisolver = 0.05f;
    public Color colorLineaDisover = new Color(0f, 1f, 9379053f, 1f);

    public bool puedePonerLinea = true;
  

    [HideInInspector]
    public bool iniciarEfectoAparecer = false;

    [HideInInspector]
    public bool inicarEfectoDesparecer = false;

    [HideInInspector]
    public bool inicarEfectoDisolver = false;

    [HideInInspector]
    public bool inicarEfectoBarrera = false;



    public Material[] materialesGuadagna;

    [HideInInspector]
    public bool inicarEfectoAparecerGudagna = false;

    [HideInInspector]
    public bool iniciarEfectoDesaparecerGuadagna = false;

    //--------------------------
    private bool llamadoDesaparecer = false;
    private bool llamadoAparecer = false;
    private bool llamadoEfectoBarrera = false;
    private bool llamadoDesaparecerGuadagna = false;
    private bool llamadoAparecerGuadagna = false;
 
    private void Start()
    {
        //conjuto de condiciones que llama a los diferentes efectos
        if (materialBarrera)
        {
            materialBarrera.SetFloat("_FresnelPower", 5f);
        }


        if (materialEfectoDisolver)
        {
            materialEfectoDisolver.SetColor("_EdgeColor", colorLineaDisover);
            materialEfectoDisolver.SetFloat("_Cutoff", 0);
        }

        if (materialLineas)
        {
            materialLineas.SetFloat("_OutlineWidth", 0);
        }


        if (materialesGuadagna.Length > 0 &&
            materialesGuadagna[0] &&
            materialesGuadagna[1] &&
            materialesGuadagna[2] )
        {
            materialesGuadagna[0].SetFloat("_Cutoff", 1);
            materialesGuadagna[1].SetFloat("_Cutoff", 1);
            materialesGuadagna[2].SetFloat("_Cutoff", 1);
        }


        


    }



    private void Update()
    {
        //serie de condiciones que llama a los recpetivos efectos. 

        if (inicarEfectoBarrera && materialBarrera)
        {
            StartCoroutine("efectoDesaparecerBarrera");
        }

        if (inicarEfectoDisolver && materialEfectoDisolver)
        {
            StartCoroutine("efectoDisolver");
            
        }

        if (inicarEfectoDesparecer)
        {
            StartCoroutine("efectoDesparecer");
        }

        if (iniciarEfectoAparecer)
        {
            StartCoroutine("efectoAparecer");
        }

        if (inicarEfectoAparecerGudagna &&
            materialesGuadagna[0] &&
            materialesGuadagna[1] &&
            materialesGuadagna[2]       )
        {
  
            StartCoroutine("efectoAparecerGuadagna");
        }


        if (iniciarEfectoDesaparecerGuadagna &&
            materialesGuadagna[0] &&
            materialesGuadagna[1] &&
            materialesGuadagna[2])
        {
            StartCoroutine("efectoDesaparecerGuadagna");
        }


    }



    /// Método que accede a la malla del Guadagna para simular ha iniciado una teleportación y que para
    /// ello se accede a las propiedad de un shader.
    IEnumerator efectoDesaparecerGuadagna()
    {

        if (!llamadoDesaparecerGuadagna)
        {
            llamadoDesaparecerGuadagna = true;
            for (float i = 0; i <= 10f; i += 1f)
            {

                materialesGuadagna[0].SetFloat("_Cutoff", i / 10);
                materialesGuadagna[1].SetFloat("_Cutoff", i / 10);
                materialesGuadagna[2].SetFloat("_Cutoff", i / 10);

                yield return new WaitForSeconds(0.1f);

                if (i == 10)
                {
                    llamadoDesaparecerGuadagna = false;
                }
            }

            materialEfectoDisolver.SetFloat("_Cutoff", 1);
            iniciarEfectoDesaparecerGuadagna = false;


        }

    }



    /// <summary>
    /// Método que accede a la malla del Guadagna para simular ha finalizado una teleportación y que para
    /// ello se accede a las propiedad de un shader.
    /// </summary>
    IEnumerator efectoAparecerGuadagna()
    {

        if (!llamadoAparecerGuadagna)
        {
            llamadoAparecerGuadagna = true;
            for (float i = 10; i >= 0; i -= 5f)
            {
          
                materialesGuadagna[0].SetFloat("_Cutoff", i / 10);
                materialesGuadagna[1].SetFloat("_Cutoff", i / 10);
                materialesGuadagna[2].SetFloat("_Cutoff", i / 10);

                yield return new WaitForSeconds(0.1f);

                if (i == 0)
                {
                    llamadoAparecerGuadagna = false;
                }
            }

            materialEfectoDisolver.SetFloat("_Cutoff", 0);
            inicarEfectoAparecerGudagna = false;


        }

    }

    /// <summary>
    /// Método que accede a la malla del enemigo para simular que ha iniciado una teleportación y
    /// ello se accede a las propiedad de un shader.
    /// </summary>
    IEnumerator efectoDesparecer()
    {
      

        if (!llamadoDesaparecer)
        {
            llamadoDesaparecer = true;
            
            SkinnedMeshRenderer mr = GetComponentInChildren<SkinnedMeshRenderer>();
            Material[] mats = mr.materials;

            mats[0] = materialEfectoDisolver;
            mats[1] = materialEfectoDisolver;
            mr.materials = mats;

            for (float i = 0; i <= 10f; i += 1f)
            {
            
                materialEfectoDisolver.SetFloat("_Cutoff", i / 10);
                yield return new WaitForSeconds(0.1f);

                if (i  == 10)
                {
                    llamadoDesaparecer  = false;
                }
            }

            materialEfectoDisolver.SetFloat("_Cutoff", 1);
            inicarEfectoDesparecer = false;

        
        }
          
        


    }

    /// <summary>
    /// Método que accede a la malla del enemigo para simular que ha finalizado
    /// una teleportación
    /// </summary>
 
    IEnumerator efectoAparecer()
    {
        if (!llamadoAparecer)
        {
            llamadoAparecer = true;
            SkinnedMeshRenderer mr = GetComponentInChildren<SkinnedMeshRenderer>();
            Material[] mats = mr.materials;

            mats[0] = materialEfectoDisolver;
            mats[1] = materialEfectoDisolver;
            mr.materials = mats;

            for (float i = 10; i >= 0; i -= 1f)
            {
               
                materialEfectoDisolver.SetFloat("_Cutoff", i / 10);
                yield return new WaitForSeconds(.1f);

                if (i == 0)
                {
                   llamadoAparecer = false;
                }
            }


            materialEfectoDisolver.SetFloat("_Cutoff", 0);
            iniciarEfectoAparecer = false;

            mats[0] = materialLineas;
            mats[1] = materialEfectoDisolver;
            mr.materials = mats;

        }
    }



    /// <summary>
    ///  Inicia un efecto de que simula desvanecer
    /// </summary>

    IEnumerator efectoDesaparecerBarrera()
    {
        if (!llamadoEfectoBarrera)
        {
            llamadoEfectoBarrera = true;

            for (float i = 10; i > 0f; i -= 0.3f)
            {
                materialBarrera.SetFloat("_FresnelPower", i);

                if (i <= 0)
                {
                    llamadoEfectoBarrera = false;
                }

                yield return null;
            }


        inicarEfectoBarrera = false;

        }
    }




    /// <summary>
    /// Efecto usado para simular la electricidad acceciendo a la malla.
    /// </summary>


    IEnumerator efectoDisolver()
    {
        materialEfectoDisolver.SetFloat("_EdgeWidth", grosorLineaDisolver);
        materialEfectoDisolver.SetColor("_EdgeColor", colorLineaDisover);   
        for (int b = 0; b < 2; b++)
        {
            for (float i = 0; i < 1f; i+= 0.1f)
            {
                 
                materialEfectoDisolver.SetFloat("_Cutoff", i);
                yield return new WaitForSeconds(.1f);
            }

        }
        materialEfectoDisolver.SetFloat("_Cutoff", 0);
        inicarEfectoDisolver = false;
    }




    /// <summary>
    /// Método encargada de poner outline al enemigo
    /// </summary>
    public void ponerLineas()
    {
        if (puedePonerLinea)
        {
            materialLineas.SetColor("_OutlineColor", colorLineaFijado);
            materialLineas.SetFloat("_OutlineWidth", grosorLineaFijado);

        }

    }

    /// <summary>
    /// Método encargada de quitar outline al enemigo
    /// </summary>
    public void quitarLineas()
    {
        if (puedePonerLinea)
        {
             materialLineas.SetFloat("_OutlineWidth", 0);
        }
    }







}
