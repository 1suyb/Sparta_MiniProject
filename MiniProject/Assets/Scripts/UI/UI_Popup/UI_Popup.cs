using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
	public override void Init()
	{
		Manager.Instance.UIM.SetCanvasOrder(this, true);
	}

	public virtual void Close()
	{
		Manager.Instance.UIM.ClosePopupUI();
		Object.Destroy(this.gameObject);
	}
}
