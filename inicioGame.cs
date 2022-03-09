using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inicioGame : MonoBehaviour
{
	public GameObject videoPlayer;
	public GameObject telaPreta;

	void Start()
	{
		telaPreta.SetActive(true);
		videoPlayer.SetActive(true);
		StartCoroutine(VideoCoroutine());
		StartCoroutine(TelaCoroutine());
	}

	IEnumerator VideoCoroutine()
	{
		yield return new WaitForSeconds(8);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	IEnumerator TelaCoroutine()
	{
		yield return new WaitForSeconds(0.5f);
		telaPreta.SetActive(false);
	}
}