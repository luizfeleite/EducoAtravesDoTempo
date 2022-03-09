using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorMov : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rb;
	public bool IsGround = true;
	float jumpForce = 20;
	public SphereCollider col;
	public bool JuditeAndar = true;
	public bool permissao = false;
	public int vidas = 5;
	public bool SemVidas = false;
	public GameObject TelaGameOver;
	public Image Coracao1, Coracao2, Coracao3;
	public bool permAjuste = false;
	public float velocidade = 6;
	public bool vidasT = true;
    public float tempo = 1.0f;
	public bool C1 = false;
	public bool Gatilho1 = true;
	public bool Gatilho2 = true;
	public bool tut1 = true;
	public bool tut2 = true;
	public GameObject TelaFimTut;

    void Start()
    {
		permAjuste = true;
		JuditeAndar = true;
		Coracao1.enabled = true;
		Coracao2.enabled = true;
		Coracao3.enabled = true;
        rb = GetComponent<Rigidbody>();
		col = GetComponent<SphereCollider>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

		Andar();

		if(permissao == true && Input.GetKeyDown(KeyCode.Space) && IsGround == true)
		{
			JuditeAndar = true;
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			IsGround = false;
		}
		if(vidas == 0)
		{
			JuditeAndar = false;
			SemVidas = true;
			TelaGameOver.SetActive(true);
			IsGround = false;
		}
		if(vidas == 2)
		{
			Coracao3.enabled = false;
		}
		if(vidas == 1)
		{
			Coracao2.enabled = false;
		}
		if(vidas == 0)
		{
			Coracao1.enabled = false;
		}
		if(Input.GetKeyDown(KeyCode.Space) && C1 == true)
		{
			JuditeAndar = true;
			C1 = false;
			tut1 = false;
		}
	}
    private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "IsGround")
		{
			IsGround = true;
		}
		if(collision.gameObject.tag == "Pergunta")
		{
			JuditeAndar = false;
			StartCoroutine(ExampleCoroutine());
			StartCoroutine(PerguntaNRespCoroutine(collision));
		}
		if(collision.gameObject.tag == "IlhaSafe")
		{
			if(tut1 == true)
			{
				JuditeAndar = false;
			}
			else
			{
				JuditeAndar = true;
			}
            IsGround = true;
			if(Gatilho1 == true)
			{
				StartCoroutine(TempoAudio());	
				Gatilho1 = false;
			}
		}
		if(collision.gameObject.tag == "TG1")
		{
			if(tut2 == true)
			{
				JuditeAndar = false;
			}
			else
			{
				JuditeAndar = true;
			}
            IsGround = true;
			if(Gatilho2 == true)
			{
				StartCoroutine(TempoAudio2());	
				Gatilho2 = false;
			}
		}
		if(collision.gameObject.tag == "Resposta")
		{
			TelaFimTut.SetActive(true);
			Time.timeScale = 0f;
		}
		if(collision.gameObject.tag == "RespErrada")
		{
			JuditeAndar = false;
			TelaGameOver.SetActive(true);
		}
	}
	IEnumerator ExampleCoroutine()
    {
		this.permissao = false;
        yield return new WaitForSeconds(24.5f);
        this.permissao = true;
		IsGround = true;
    }
    IEnumerator TempoAudio()
    {
		this.JuditeAndar = false;
        yield return new WaitForSeconds(47.2f);
		C1 = true;
    }
	IEnumerator TempoAudio2()
    {
		this.JuditeAndar = false;
        yield return new WaitForSeconds(20.5f);
    }
	IEnumerator PerguntaNRespCoroutine(Collision collision)
    {
        yield return new WaitForSeconds(35.5f);
		collision.gameObject.SetActive(false);
		yield return new WaitForSeconds(1);
		collision.gameObject.SetActive(true);
    }
	public void VidasJudite()
	{
		if(vidasT == true)
		{
			vidas = vidas - 1;
		}
		if(SemVidas == false)
		{
			JuditeAndar = true;
			IsGround = true;
		}
	}
	private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "IlhaFinal")
        {
            JuditeAndar = false;
			vidasT = false;
        }
    }
	public void Andar()
	{
		if(JuditeAndar == true)
			{
                    
                    transform.Translate(-transform.forward * (Time.deltaTime * speed * velocidade));

					if(Input.GetKeyDown(KeyCode.Space) && IsGround == true)
					{
						rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
						IsGround = false;
					}
					if (Input.GetKey(KeyCode.RightArrow))
					{
						transform.position -= new Vector3(10 * speed * Time.deltaTime, 0, 0);
					}
					if (Input.GetKey(KeyCode.LeftArrow))
					{
						transform.position += new Vector3(10 * speed * Time.deltaTime, 0, 0);
					}
			}	
	}
}
