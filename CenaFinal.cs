using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static EDUCO.GameVariables;

public class CenaFinal : MonoBehaviour
{
    public GameObject judite;
    public GameObject cameraa;
    public GameObject coroa;
    public GameObject fimPainel;
    public string MenuPrincipal;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            judite.SetActive(true);
            cameraa.SetActive(true);
            coroa.SetActive(true);
            StartCoroutine(UltimaTela());
            EDUCO.GameVariables.Victory = true;
        }
    }
    IEnumerator UltimaTela()
    {
        yield return new WaitForSeconds(10);
		Time.timeScale = 0;
        fimPainel.SetActive(true);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(MenuPrincipal);
    }
}
