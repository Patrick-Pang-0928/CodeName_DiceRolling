using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceController : MonoBehaviour
{
    [Header("骰子参数")]
    public int diceNum = 1;
    public bool isRolling = false;

    private void Update()
    {
        //按下鼠标左键：掷骰子
        if (!isRolling && Input.GetMouseButtonUp(0))
        {
            RollDice();
        }
    }

    #region 掷骰子
    public void RollDice()
    {
        if (isRolling) return;
        else
        {
            isRolling = true;
            StartCoroutine(RollDice_());
        }
    }
    //调用协程让骰子一次转个饱
    IEnumerator RollDice_()
    {
        yield return new WaitForSeconds(0.5f);
        isRolling = false;
        //每次完成掷骰子后，默认更新骰面一次
        DiceNumRenew();
    }
    #endregion

    #region 更新骰面
    public void DiceNumRenew()
    {
        if (!isRolling)
        {
            //随机掷出【1，6】中的任一个数字
            diceNum = Random.Range(1, 7);
        }
    }
    #endregion

    #region 检测骰面
    public int DiceNumCheck()
    {
        return diceNum;
    }
    #endregion
}