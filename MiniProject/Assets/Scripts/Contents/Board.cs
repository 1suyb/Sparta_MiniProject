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
	[SerializeField] private SpriteList sprites = new SpriteList();

	private void Start()
	{
		SetBoard();
	}
	private void SetBoard()
	{
		sprites = StageManager.Instance.StageSprites;
		GameManager.Instance.cardCount = sprites.list.Count;

		int spritesCount = sprites.list.Count;
		(int width, int height) = FindLargestPair(spritesCount);
		List<Sprite> randomlist = sprites.list.OrderBy(x => UnityEngine.Random.Range(0, 7f)).ToList();
		for (int i = 0; i < spritesCount; i++)
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
		// 1���� sqrt(product)������ ���� ��ȸ
		for (int i = 1; i <= Math.Sqrt(number); i++)
		{
			if (number % i == 0) // i�� product�� ������� Ȯ��
			{
				int pair = number / i;

				// �� ���� ���̰� ���� ���� �� ������Ʈ
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
