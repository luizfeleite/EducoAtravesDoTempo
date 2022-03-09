using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class Menu : MonoBehaviour
{
    public string Cena;
    public string Tutorial;
    public GameObject optionsPainel;
    public GameObject controlPainel;
    public GameObject configsPainel;
    public GameObject cretitosPainel;
    private string MenuPrincipal;
    public Slider BarraVolume;
    public Button BotaoSalvarPref;
    public GameObject NomeGame;
    public GameObject Estrela;
    public GameObject Vercao;

    public static bool vitoriaEstrela = false;

    public void StartGame()
    {
        BotaoSalvarPref.onClick = new Button.ButtonClickedEvent();
        SceneManager.LoadScene(Cena);
        Cursor.visible = true;
        Time.timeScale = 1f;
    }
    void Update()
    {
        if(vitoriaEstrela == true)
        {
            Estrela.SetActive(true);
        }
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene(Tutorial);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        // Editor Unity
        //UnityEditor.EditorApplication.isPlaying = false;
        // Jogo Compilado
        Application.Quit();
    }
    public void ShowOptions()
    {
        optionsPainel.SetActive(true);
        NomeGame.SetActive(false);
        Vercao.SetActive(false);
    }

    public void BackToMenu()
    {
        optionsPainel.SetActive(false);
        NomeGame.SetActive(true);
        Vercao.SetActive(true);
    }
    public void ShowControl()
    {
        controlPainel.SetActive(true);
    }
    public void BackToControl()
    {
        controlPainel.SetActive(false);
    }
    public void ShowAudio()
    {
        configsPainel.SetActive(true);
    }
    public void BackToAudio()
    {
        configsPainel.SetActive(false);
    }
    public void ShowCreditos()
    {
        cretitosPainel.SetActive(true);
    }
    public void BackToCreditos()
    {
        cretitosPainel.SetActive(false);
    }
}
