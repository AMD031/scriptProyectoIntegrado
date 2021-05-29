using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;


/// <summary>
/// clase encargada de establecer los ajustes en función de la interación 
/// del usuario con el menú.
/// </summary>

public class MenuAjustes : MonoBehaviour
{
    //referencia a grupos de sonido
    public AudioMixer audioMixer; 
    public AudioMixerGroup musica;

    Resolution[] resolutions;
    //public Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown graficosDropdown;
    public Slider audioMaestro;
    public Slider audioMusica;
    public Slider audioEfectos;
    public Toggle pantallaCompleta;
    Ajustes ajustes;

    private void Start()
    {
        resolutions =  Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        for (int i = 0; i< resolutions.Length; i++)
        {
           options.Add(resolutions[i].width + " x " + resolutions[i].height );
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height
                )
            {
                currentResolutionIndex = i;
            }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        cargarAjustes();
        //establecerAjutesCargados();

    }

    /// <summary>
    /// Cambia los valores a los que ha cargados en el objeto ajustes
    /// </summary>
    public void establecerAjutesCargados()
    {
        resolutions =  Screen.resolutions;
        Resolution resolution = resolutions[ajustes.resolucion];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        QualitySettings.SetQualityLevel(ajustes.calidad);

        audioMixer.SetFloat("volumen", ajustes.audioMaestro);

        audioMixer.SetFloat("musica", ajustes.audioMusica);

        audioMixer.SetFloat("sfx", ajustes.audioEfectos);

        Screen.fullScreen = ajustes.patallaCompleta;
    }


    /// <summary>
    ///   Obtiene el valor del desplegable resolucion y cambia la resolucion
    /// </summary>
    /// <param name="resolutionIndex">indice del array resolusiones</param>
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }




    /// <summary>
    /// Cambia el volumen general
    /// </summary>
    /// <param name="volumen"> nuevo valor del volumen</param>

    public void SetVolumen(float volumen)
    {
        Debug.Log("Molumen maestro" + volumen);
        audioMixer.SetFloat("volumen", volumen);
   
    }


    /// <summary>
    /// Cambia el volumen de la música
    /// </summary>
    /// <param name="volumen">nuevo valor del volumen de la música </param>
    public void SetVolumenMusica(float volumen)
    {
       // Debug.Log("Molumen Musica" + volumen);
        audioMixer.SetFloat("musica", volumen);
    }

    /// <summary>
    ///  Cambia el volumen de la efectos
    /// </summary>
    /// <param name="volumen">nuevo valor del volumen de los efectos</param>

    public void SetVolumenEfectos(float volumen)
    {
        //Debug.Log("Molumen efectos" + volumen);
        audioMixer.SetFloat("sfx", volumen);
    }

    /// <summary>
    /// Establece la calidad
    /// </summary>
    /// <param name="calidadIndice">nuevo valor de la calidad</param>
    public void SetCalidad(int calidadIndice)
    {
        QualitySettings.SetQualityLevel(calidadIndice);
    }



    /// <summary>
    /// Cambia la patalla completa
    /// </summary>
    /// <param name="esPantallaCompleta"> si es true la patalla pasa a ser completa</param>
    public void SePantallaCompleta(bool esPantallaCompleta)
    {
        Screen.fullScreen = esPantallaCompleta;
    }


    /// <summary>
    /// Guarda los ajuetes hechos por el usuario al ser llamado.
    /// </summary>
    public void  GuardarAjustes()
    {
        int resolucion = resolutionDropdown.value;
        int graficos = graficosDropdown.value ;
        float maestro = audioMaestro.value;
        float musica = audioMusica.value;
        float efectos = audioEfectos.value;
        bool pantallaEntera = pantallaCompleta.isOn;
        Ajustes ajustes = new Ajustes(maestro, musica, efectos, resolucion, graficos, pantallaEntera);
        Ajustes.guardarDatos(ajustes);
    }

    



    /// <summary>
    /// Funcion encargada de cargar los valorres guardados en xml.
    /// </summary>
    public void cargarAjustes()
    {
        ajustes =   Ajustes.cargarDatos();
        if (ajustes != null)
        {
            resolutionDropdown.value = ajustes.resolucion;
            graficosDropdown.value = ajustes.calidad;
            audioMaestro.value = ajustes.audioMaestro;
            audioMusica.value = ajustes.audioMusica;
            audioEfectos.value = ajustes.audioEfectos;
            pantallaCompleta.isOn = ajustes.patallaCompleta ;
        }
        else
        {
          ajustes =  valoresPorDefecto();
        }

    }

    /// <summary>
    /// Crea valores por defecto en el caso de que no sean encontrados.
    /// </summary>
    /// <returns>Devuelve un objeto con los valores por defecto</returns>
    private Ajustes valoresPorDefecto()
    {
        audioMaestro.value = 0;
        audioMusica.value = -20;
        audioEfectos.value = 0;
        resolutionDropdown.value = 4;
        graficosDropdown.value = 5;
        pantallaCompleta.isOn = true;
       return new Ajustes(0, -20, 0, 4, 5, true);

    }

    

}
