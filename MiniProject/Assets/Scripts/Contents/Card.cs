using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
	private string cardName;
	public string Name {  get { return cardName; }
		set { 
			cardName = value;
		} 
	}
	[SerializeField] private GameObject front;
	[SerializeField] private GameObject back;
	[SerializeField] private float wattingtime;

	private Animator anim;
	private AudioSource audioSource;

	private void Start()
	{
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}
	public void Init(string name)
	{
		this.Name = name;
		front.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(cardName);
	}
	public void Init(string name,float x, float y)
	{
		this.Name = name;
		front.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(cardName);
		this.transform.localPosition = new Vector2(x, y);
	}
	public void OnMouseOver()
	{
		if (anim != null)
		{
			anim.SetBool("Hover", true);
		}
	}
	public void OnMouseExit()
	{
		if(anim != null)
		{
			anim.SetBool("Hover", false);
		}
	}
	public void CardOpen()
	{
		anim.Play("Flip");
		audioSource.Play();
		if (GameManager.Instance.firstCard == null)
		{
			GameManager.Instance.firstCard = this;
		}
		else if(GameManager.Instance.secondCard == null)
		{
			GameManager.Instance.secondCard = this;
			GameManager.Instance.MatchedCard();
		}
		front.SetActive(true);
		back.SetActive(false);
	}
	public void CardClose()
	{
		Invoke("closing", wattingtime);
	}
	void closing()
	{
		front.SetActive(false);
		back.SetActive(true);
	}

	public void RemoveCard()
	{
		Invoke("removing", wattingtime);
	}
	void removing()
	{
		Destroy(this.gameObject);
	}

}
