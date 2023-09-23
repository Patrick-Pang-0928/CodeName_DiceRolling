using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PokerSuitEnum
{
	SPADES,
	HEART,
	CLUBS,
	DIAMOND
}


public class Poker : MonoBehaviour
{
	public PokerSuitEnum pokerSuit = PokerSuitEnum.SPADES;
	public uint pokerValue = 1;

	public void CardOpen()
	{
		throw new NotImplementedException();
	}

	public void CardClose()
	{
		throw new NotImplementedException();
	}
}
