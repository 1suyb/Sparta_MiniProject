using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Utils
{
	public static T GetorAddComponent<T>(GameObject go) where T : Component
	{
		if(go == null) { return null; }
		T component = go.GetComponent<T>();
		if (component == null) {
			component = go.AddComponent<T>();
		}
		return component;
	}
	public static T FindChild<T>(GameObject go, string name, bool recursive = false) where T : UnityEngine.Object
	{
		if (go == null) { return null; }
		if (recursive)
		{
			foreach(T component in go.GetComponentsInChildren<T>())
			{
				if (component.name == name || string.IsNullOrEmpty(name)) { return component; }
			}
		}
		else
		{
			foreach (Transform t in go.transform)
			{
				if (t.gameObject.name == name || string.IsNullOrEmpty(name)) { 
					T component =  t.GetComponent<T>(); 
					if (component != null) { return component; }
				}
			}
		}
		return null;
	}

	public static GameObject FindChild(GameObject go, string name, bool recursive = false)
	{
		if (go == null) { return null; }
		if (recursive)
		{
			foreach (Transform component in go.GetComponentsInChildren<Transform>())
			{
				if (component.name == name || string.IsNullOrEmpty(name)) { return component.gameObject; }
			}
		}
		else
		{
			foreach (Transform t in go.transform)
			{
				if (t.gameObject.name == name || string.IsNullOrEmpty(name))
				{
					Transform component = t.GetComponent<Transform>();
					if (component != null) { return component.gameObject; }
				}
			}
		}
		return null;
	}

}
