using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Base : MonoBehaviour
{
	private Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

	public void Bind<T>(Type type) where T : UnityEngine.Object
	{
		if (_objects.ContainsKey(type)) { return; }
		string[] name = Enum.GetNames(type);
		UnityEngine.Object[] objects = new UnityEngine.Object[name.Length];
		_objects.Add(type, objects);

		for (int i = 0; i < name.Length; i++)
		{
			if (typeof(T) == typeof(GameObject))
				objects[i] = Utils.FindChild(gameObject, name[i], true);
			else
				objects[i] = Utils.FindChild<T>(gameObject, name[i], true);
		}
	}

	public T Get<T>(int idx) where T : UnityEngine.Object
	{
		UnityEngine.Object[]  objs = null;
		if(!_objects.TryGetValue(typeof(T), out objs)) {return null;}
		return objs as T;
	}


}
