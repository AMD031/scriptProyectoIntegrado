using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
///  Contine los diferentes valores que se desean guardar de un sonido
/// </summary>

[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;
    [Range(0f,1f)]
    public float volume;
    [Range(0f, 3f)]
    public float pitch;

    [Range(0f, 5f)]
    public float dopplerLevel;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

    [Range(0, 12)]
    public int grupo;




}
