using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

#region 所有骰面可能性
public enum DiceSideEnum
{
    NumOne = 1,
    NumTwo = 2,
    NumThree = 3,
    NumFour = 4,
    NumFive = 5,
    NumSix = 6,
}
#endregion

public class DiceController : MonoBehaviour
{
    #region 参数设置
    [Header("基础参数")]
    public int diceNum = 6;
    public bool isRolling = false;

    //当前骰子的所有骰面
    [Header("骰面参数")]
    public int currentSideIndex = 5;
    public List<DiceSideEnum> currentSideList = new List<DiceSideEnum>() {
        DiceSideEnum.NumOne,
        DiceSideEnum.NumTwo,
        DiceSideEnum.NumThree,
        DiceSideEnum.NumFour,
        DiceSideEnum.NumFive,
        DiceSideEnum.NumSix,
    };
    //初始骰面为数字6
    DiceSideEnum currentDiceSide = DiceSideEnum.NumSix;
    #endregion

    private void Update()
    {
        //按下鼠标左键：掷骰子
        if (!isRolling && Input.GetMouseButtonUp(0)) {
            RollDice();
        }
    }

    #region 掷骰子
    public void RollDice()
    {
        if (isRolling) return;
        else {
            isRolling = true;
            StartCoroutine(RollDice_());
        }
    }
    //调用协程让骰子一次转个饱
    IEnumerator RollDice_()
    {
        yield return new WaitForSeconds(0.5f);
        isRolling = false;
        //结束播放掷骰子动画后，更新一次当前骰子的骰面
        RenewDiceSideValue();
    }
    #endregion

    #region 更新骰面
    public void RenewDiceSideValue()
    {
        if (!isRolling) {
            //随机获取当前骰子的其中一面
            currentSideIndex = Random.Range(0, currentSideList.Count);
            currentDiceSide = currentSideList[currentSideIndex];
            diceNum = GetDiceNum();
        }
    }
    #endregion

    #region 获取骰面
    public DiceSideEnum GetDiceSideValue()
    {
        return currentDiceSide;
    }

    //若当前骰面为数字1-6，则返回对应的“骰面数值”，否则返回0
    public int GetDiceNum()
    {
        if ((int)GetDiceSideValue() <= 6)
        {
            diceNum = (int)GetDiceSideValue();
        }
        else diceNum = 0;
        return diceNum;
    }
    #endregion
}
