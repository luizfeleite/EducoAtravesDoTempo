using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class RespCert : MonoBehaviour
{
    public GameObject IlhaFire;
    private Collider[] Colisores;
    private AudioSource emissorSom;
    public AudioClip AudioAcert;

    void Start()
    {
        emissorSom = GetComponent<AudioSource> ();
        emissorSom.clip = AudioAcert;
    }
    void OnTriggerEnter(Collider other)
    {
        emissorSom.PlayOneShot (emissorSom.clip);
        if(other.gameObject.tag == "Player")
        {
            IlhaFire.SetActive(true);
        }
    }
}