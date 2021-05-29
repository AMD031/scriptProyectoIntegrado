using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


/// <summary>
/// Esta clase se encarga de gestionar los sonidos del juego y inicializarlos.
/// </summary>

public class AudioManager : MonoBehaviour
{
   
    //array que contine los diferentes sonidos
    public Sound[] sonidosMutante;
    public Sound[] sonidosJugador;
    public Sound[] musica;
    public Sound[] trampas;

    public static AudioManager instance;
    //Propietario del audio
    public const int JUGADOR = 0;
    public const int MUTANTE = 1;
    public const int TRAMPAS = 3;
    public const int MUSICA = 6;
    //grupo al que pertenece el audio
    private const int GMUSICA = 0;
    private const int GSFX = 1;

    
    public AudioMixerGroup AMGMusica;
    public AudioMixerGroup AMGSFX;



    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        //DontDestroyOnLoad(gameObject);
        iniciarSonidos(sonidosJugador);
        iniciarSonidos(sonidosMutante);
        iniciarSonidos(musica);
        iniciarSonidos(trampas);


    }
    /// <summary>
    /// Recibe una array de sonido y lo asigna a un grupo concreto
    /// </summary>
    /// <param name="sonidos">array de sonidos</param>
    private void iniciarSonidos(Sound[] sonidos)
    {
        foreach (Sound s in sonidos)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            switch (s.grupo)
            {
                case GMUSICA:
                    s.source.outputAudioMixerGroup = AMGMusica;
                    break;

                case GSFX:

                    s.source.outputAudioMixerGroup = AMGSFX;
                    break;


            }

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
          
            //-------
            s.source.dopplerLevel = s.dopplerLevel;
        }

    }

    private void Start()
    {
       
        
    }
    /// <summary>
    /// Reproduce un audio concreto
    /// </summary>
    /// <param name="name">Nombre del audio a reproducir</param>
    /// <param name="propietario">Número que identifica el array donde esta almacenado el audio</param>
    /// <param name="reproducir">Se establece true si quieres se reproduzca y false para detener el audio</param>

    public void Play(string name, int propietario, bool reproducir = true)     
    {
        //Debug.LogWarning(name + " nombre sonido");

        Sound[] sonidos = null;
        switch (propietario)
        {
            case JUGADOR:
                sonidos = sonidosJugador;
            break;

            case MUTANTE:
                sonidos = sonidosMutante;
            break;

            case MUSICA:
                sonidos = musica;
            break;

            case TRAMPAS:
                sonidos = trampas;
            break;

        }

        // Busca el sonido a reproducir y lo reproduce
        Sound s = Array.Find(sonidos, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sonido " + name + " no encontrado");
            return;
        }

        if (reproducir)
        {
            if (!s.source.isPlaying)
            {
               s.source.Play();
            }

        }
        else
        {
            s.source.Stop();
        }
    }



    /// <summary>
    /// 
    /// </summary>
    public void DetenerMusica()
    {
        if (musica != null)
        {
           foreach(Sound sonido in musica)
            {
                sonido.source.Stop();
            }

        }


    }



}
