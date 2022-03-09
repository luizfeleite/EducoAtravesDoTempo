using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]

public class Audio1 : MonoBehaviour
{
    private Collider[] Colisores;
    private AudioSource emissorSom;
    public AudioClip frase1;
    public AudioClip frase2;
    public AudioClip frase3;
    public AudioClip Frase4;
    public AudioClip Frase5;
    public AudioClip Frase6;
    public Image ImagemJ;
    public Image ImagemJ2;
    public Image Imagem1;
    public Image Imagem2;
    public Image Imagem3;
    public Image Imagem4;
    public Image Imagem5;
    public Image Imagem6;
    public Image PressCont;
    public bool P = false;
    public bool AudioFrase = true;

    void Start()
    {
        emissorSom = GetComponent<AudioSource> ();
        emissorSom.clip = frase1;
        ImagemJ.enabled = false;
        ImagemJ2.enabled = false;
        Imagem1.enabled = false;
        Imagem2.enabled = false;
        Imagem3.enabled = false;
        Imagem4.enabled = false;
        Imagem5.enabled = false;
        Imagem6.enabled = false;
        PressCont.enabled = false;
    }
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && P == true)
		{
			PressCont.enabled = false;
            P = false;
		}
    }
    void OnTriggerEnter(Collider other)
    {
        if(AudioFrase == true)
        {
            emissorSom.PlayOneShot (emissorSom.clip);
            StartCoroutine(TempoFrase());
            ImagemJ.enabled = true;
            Imagem1.enabled = true;
        }
    }
    IEnumerator TempoFrase()
    {
        AudioFrase = false;
        yield return new WaitForSeconds(5);
        emissorSom.clip = frase2;
        yield return new WaitForSeconds(1);
        Imagem2.enabled = true;
        Imagem1.enabled = false;
        emissorSom.PlayOneShot (emissorSom.clip);
        yield return new WaitForSeconds(11);
        Imagem3.enabled = true;
        Imagem2.enabled = false;
        emissorSom.clip = frase3;
        emissorSom.PlayOneShot (emissorSom.clip);
        yield return new WaitForSeconds(8);
        Imagem3.enabled = false;
        Imagem4.enabled = true;
        emissorSom.clip = Frase4;
        emissorSom.PlayOneShot (emissorSom.clip);
        yield return new WaitForSeconds(6.5f);
        emissorSom.clip = Frase5;
        emissorSom.PlayOneShot (emissorSom.clip);
        Imagem4.enabled = false;
        Imagem5.enabled = true;
        emissorSom.PlayOneShot (emissorSom.clip);
        yield return new WaitForSeconds(13);
        emissorSom.clip = Frase6;
        Imagem6.enabled = true;
        Imagem5.enabled = false;
        emissorSom.PlayOneShot (emissorSom.clip);
        ImagemJ.enabled = false;
        ImagemJ2.enabled = true;
        yield return new WaitForSeconds(3);
        ImagemJ2.enabled = false;
        Imagem6.enabled = false;
        PressCont.enabled = true;
        P = true;
    }
}