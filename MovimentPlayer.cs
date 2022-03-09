using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MovimentPlayer : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rb;
	public bool IsGround = true;
	float jumpForce = 20;
	public SphereCollider col;
	public bool JuditeAndar = true;
	public bool permissao = false;
	public int vidas = 4;
	public bool SemVidas = false;
	public GameObject TelaGameOver;
	public Image Coracao1, Coracao2, Coracao3;
	public bool permAjuste = false;
	public float velocidade = 6;
	public bool vidasT = true;
	public bool jaRespondeu = false;

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
			IsGround = true;
			StartCoroutine(ExampleCoroutine());
			
			StartCoroutine(PerguntaNRespCoroutine(collision));
			
		}
		if(collision.gameObject.tag == "IlhaSafe")
		{
			VidasJudite();
			if(SemVidas == false)
			{
				JuditeAndar = true;
				IsGround = true;
			}
		}
		if(collision.gameObject.tag == "Resposta")
		{
			JuditeAndar = true;
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			IsGround = false;
			jaRespondeu = true;
		}
		if(collision.gameObject.tag == "RespErrada")
		{
			Time.timeScale = 0f;
			JuditeAndar = false;
			TelaGameOver.SetActive(true);
		}
		if(collision.gameObject.tag == "Finish")
		{
			JuditeAndar = false;
		}
		if(collision.gameObject.tag == "IlhaSafe2")
		{
			VidasJudite();
			IsGround = true;
			if(permAjuste == true)
			{
				velocidade = velocidade + 3;
				permAjuste = false;
			}
		}
		if(collision.gameObject.tag == "IlhaSafe3")
		{
			VidasJudite();
			IsGround = true;
			if(permAjuste == true)
			{
				velocidade = velocidade + 5;
				permAjuste = false;
			}
		}
		if(collision.gameObject.tag == "IlhaSafe4")
		{
			VidasJudite();
			IsGround = true;
			if(permAjuste == true)
			{
				velocidade = velocidade + 8;
				jumpForce = jumpForce + 5;
				permAjuste = false;
			}
		}
		if(collision.gameObject.tag == "StopWin")
		{
			permissao = false;
			JuditeAndar = false;
		}
	}
	IEnumerator ExampleCoroutine()
    {
		this.permissao = false;
        yield return new WaitForSeconds(4);
        this.permissao = true;
    }
	IEnumerator PerguntaNRespCoroutine(Collision collision)
    {
        yield return new WaitForSeconds(15);
		if(jaRespondeu == false)
        {
			Time.timeScale = 0f;
			JuditeAndar = false;
			permissao = false;
			TelaGameOver.SetActive(true);
		}
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
