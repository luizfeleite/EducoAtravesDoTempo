using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaFinal : MonoBehaviour
{
    public GameObject fimPainel;
    public string MenuPrincipal;

    void Update()
    {
        Time.timeScale = 0;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(MenuPrincipal);
    }
}
