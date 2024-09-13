using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum UIEveneType
{
	Click,
}

public class UI_EventHandler : MonoBehaviour,IPointerClickHandler
{
	public Action<PointerEventData> Onclick { get; set; }

	public void OnPointerClick(PointerEventData eventData)
	{
		Onclick.Invoke(eventData);
	}
}
