using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
	private Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
	public abstract void Init();

	protected void Bind<T>(Type type) where T : UnityEngine.Object
	{
		if (_objects.ContainsKey(type)) { return; }
		string[] name = Enum.GetNames(type);
		UnityEngine.Object[] objects = new UnityEngine.Object[name.Length];
		_objects.Add(typeof(T), objects);

		for (int i = 0; i < name.Length; i++)
		{
			if (typeof(T) == typeof(GameObject))
				objects[i] = Utils.FindChild(gameObject, name[i], true);
			else
				objects[i] = Utils.FindChild<T>(gameObject, name[i], true);
		}
	}

	protected T Get<T>(int idx) where T : UnityEngine.Object
	{
		UnityEngine.Object[]  objs = null;
		if(!_objects.TryGetValue(typeof(T), out objs)) {return null;}
		return objs[idx] as T;
	}
	protected TextMeshProUGUI GetText(int idx) { return Get<TextMeshProUGUI>(idx); }
	protected Image GetImage(int idx) { return Get<Image>(idx); }
	protected Button GetButton(int idx) { return Get<Button>(idx); }

	public static void BindEvent(GameObject go , Action<PointerEventData> action, UIEveneType type)
	{
		UI_EventHandler handler = go.GetorAddComponent<UI_EventHandler>();
		switch (type)
		{
			case UIEveneType.Click:
				handler.Onclick -= action;
				handler.Onclick += action;
				break;
			default:
				break;
		}
	}
}
