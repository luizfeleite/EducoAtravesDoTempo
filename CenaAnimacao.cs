using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenaAnimacao : MonoBehaviour
{
    public GameObject cameraCut;
    public GameObject ObjetoPergunta;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cameraCut.SetActive(true);
            ObjetoPergunta.SetActive(true);
        }
    }
}
