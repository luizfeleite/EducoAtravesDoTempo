﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgPerg : MonoBehaviour
{
    private Collider[] Colisores;
    public float TempoDaImagem;
    public Image ImagemPerg;
    public Text displayContagem;
    public float contagem = 14.0f;
    public bool time = false;

    void Start()
    {
        ImagemPerg.enabled = false;
        Colisores = transform.GetComponentsInChildren<Collider> ();
    }

    void OnTriggerEnter()
    {
        StartCoroutine (EsperarTempo (TempoDaImagem));
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ImagemPerg.enabled = false;
        }
        if(contagem > 0.0f && time == true)
            {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                displayContagem.enabled = false;
            }
              contagem -= Time.deltaTime;
              displayContagem.text = contagem.ToString();
        }
    }
    IEnumerator EsperarTempo(float tempo)
    {
        yield return new WaitForSeconds (tempo);
        time = true;
        ImagemPerg.enabled = true;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ImagemPerg.enabled = false;
            displayContagem.enabled = false;
        }
        foreach (Collider coll in Colisores)
        {
            coll.enabled = false;
        }
        yield return new WaitForSeconds (10.5f);
        ImagemPerg.enabled = false;
        displayContagem.enabled = false;
    }
    
}