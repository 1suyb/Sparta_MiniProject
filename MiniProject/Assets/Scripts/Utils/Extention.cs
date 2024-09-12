using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extention 
{
	public static T GetorAddComponent<T>(this GameObject go) where T : Component
	{
		return Utils.GetorAddComponent<T>(go);
	}
}
