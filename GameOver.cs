using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject TelaGameOver;
    public string FaseFloresta;
    public string MenuPrincipal;

    void Start()
    {

    }

    void OnTriggerEnter()
    {
        EndGameTela();
        Time.timeScale = 0f;
    }

    void EndGameTela()
    {
        TelaGameOver.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(FaseFloresta);
        Time.timeScale = 1f;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(MenuPrincipal);
    }
}