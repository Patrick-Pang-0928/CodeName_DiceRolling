using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public enum DiceEnum
{
	ONE = 1, 
	TWO = 2, 
	THREE = 3, 
	FOUR = 4, 
	FIVE = 5, 
	SIX = 6,
}


public class Dice : MonoBehaviour
{
	public int diceIndex = 0;

	public List<DiceEnum> dicePointList = new List<DiceEnum>() {
		DiceEnum.ONE,
		DiceEnum.TWO,
		DiceEnum.THREE,
		DiceEnum.FOUR,
		DiceEnum.FIVE,
		DiceEnum.SIX,
	};

	public void Roll()
	{
		diceIndex = Random.Range((int)DiceEnum.ONE, (int)DiceEnum.SIX);
	}

	public DiceEnum GetDiceValue()
	{
		return dicePointList[diceIndex];
	}
}
