using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using System.Linq;
public class Board : MonoBehaviour
{
	[SerializeField] private GameObject card;
	[SerializeField] private List<Sprite> sprites = new List<Sprite>();

	public void SetBoard()
	{
		sprites = Manager.Instance.StageM.Sprites;
		sprites.AddRange(sprites);
		int spriteCount = sprites.Count;
		(int width, int height) = FindLargestPair(spriteCount);

		List<Sprite> randomlist = sprites.OrderBy(x => UnityEngine.Random.Range(0, (float)spriteCount)).ToList();
		for (int i = 0; i < spriteCount; i++)
		{
			float x = (i % width) *1.4f + (2.3f-0.7f*(width-2));
			float y = (i / width) * 1.4f + 1.0f;
			GameObject go = Instantiate(card, this.gameObject.transform);
			go.GetComponent<Card>().Init(randomlist[i].name,x,y);
		}
	}

	private (int,int) FindLargestPair(int number)
	{
		int maxA = 1;
		int maxB = number/maxA;
		// 1부터 sqrt(product)까지의 값을 순회
		for (int i = 1; i <= Math.Sqrt(number); i++)
		{
			if (number % i == 0) // i가 product의 약수인지 확인
			{
				int pair = number / i;

				// 두 값의 차이가 가장 작을 때 업데이트
				if (Math.Abs(i - pair) < Math.Abs(maxA - maxB))
				{
					maxA = i;
					maxB = pair;
				}
			}
		}

		return (maxA, maxB);
	}
}
