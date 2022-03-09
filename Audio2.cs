using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]

public class Audio2 : MonoBehaviour
{
    private Collider[] Colisores;
    private AudioSource emissorSom;
    public AudioClip frase7;
    public AudioClip frase8;
    public Image ImagemJ;
    public Image Imagem7;
    public Image Imagem8;
    public bool AudioFrase = true;

    void Start()
    {
        emissorSom = GetComponent<AudioSource> ();
        emissorSom.clip = frase7;
        ImagemJ.enabled = false;
        Imagem7.enabled = false;
        Imagem8.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if(AudioFrase == true)
        {
            StartCoroutine(TempoFrase2());
        }
    }
    IEnumerator TempoFrase2()
    {
        yield return new WaitForSeconds(4);
        AudioFrase = false;
        ImagemJ.enabled = true;
        Imagem7.enabled = true;
        emissorSom.PlayOneShot (emissorSom.clip);
        yield return new WaitForSeconds(13);
        emissorSom.clip = frase8;
        Imagem8.enabled = true;
        Imagem7.enabled = false;
        emissorSom.PlayOneShot (emissorSom.clip);
        yield return new WaitForSeconds(7.5f);
        Imagem8.enabled = false;
        ImagemJ.enabled = false;
    }
}