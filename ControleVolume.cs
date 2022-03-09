﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class ControleVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10 (sliderValue) * 20 );
    }
}