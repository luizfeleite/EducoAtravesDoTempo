using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public GameObject Judite;
    public GameObject Coroa;
    public GameObject CameraS;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Judite.SetActive(true);
            Coroa.SetActive(true);
            CameraS.SetActive(true);
            Menu.vitoriaEstrela = true;
        }
    }
}