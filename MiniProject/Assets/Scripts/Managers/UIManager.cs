using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
	private Stack<UI_Popup> _popup = new Stack<UI_Popup>();
	private int canvasOrder = 10;

	public UI_Popup ShowPopupUI(string path)
	{
		GameObject popup = Resources.Load<GameObject>(path);
		GameObject.Instantiate(popup.gameObject);
		
		canvasOrder++;
		_popup.Push(popup.GetComponent<UI_Popup>());
		return null;
	}

	public void ClosePopupUI()
	{
		if (_popup.Count == 0) { return; }
		UI_Popup popup = _popup.Pop();
		popup.Close();
		canvasOrder--;
		popup = null;
		
	}
	public void SetCanvasOrder(UI_Base ui, bool sorting, int order = 0)
	{
		if (sorting)
		{
			ui.gameObject.GetComponent<Canvas>().sortingOrder = canvasOrder;
			canvasOrder++;
		}
		else
		{
			ui.gameObject.GetComponent<Canvas>().sortingOrder = order;
		}

	}
}
