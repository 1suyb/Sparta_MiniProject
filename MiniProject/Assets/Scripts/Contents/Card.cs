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

	private CardGameLogic _logic;

	private Animator anim;
	private AudioSource audioSource;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}
	public void Init(string name,float x, float y)
	{
		this.Name = name;
		front.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"Images/{cardName}");
		this.transform.localPosition = new Vector2(x, y);
		_logic = GameObject.Find("@Logic").GetComponent<CardGameLogic>();
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
		Manager.Instance.SoundM.Play(Sounds.E_CardFlip);
		_logic.MatchedCard(this);
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
