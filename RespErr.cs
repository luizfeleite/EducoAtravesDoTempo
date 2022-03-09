using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class RespErr : MonoBehaviour
{
    private Collider[] Colisores;
    private AudioSource emissorSom;
    public AudioClip AudioErr;

    void Start()
    {
        emissorSom = GetComponent<AudioSource> ();
        emissorSom.clip = AudioErr;
    }
    void OnTriggerEnter(Collider collision)
    {
        emissorSom.PlayOneShot (emissorSom.clip);
    }
}