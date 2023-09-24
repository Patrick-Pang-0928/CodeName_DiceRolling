using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

#region �������������
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
    #region ��������
    [Header("��������")]
    public int diceNum = 6;
    public bool isRolling = false;

    //��ǰ���ӵ���������
    [Header("�������")]
    public int currentSideIndex = 5;
    public List<DiceSideEnum> currentSideList = new List<DiceSideEnum>() {
        DiceSideEnum.NumOne,
        DiceSideEnum.NumTwo,
        DiceSideEnum.NumThree,
        DiceSideEnum.NumFour,
        DiceSideEnum.NumFive,
        DiceSideEnum.NumSix,
    };
    //��ʼ����Ϊ����6
    DiceSideEnum currentDiceSide = DiceSideEnum.NumSix;
    #endregion

    private void Update()
    {
        //������������������
        if (!isRolling && Input.GetMouseButtonUp(0)) {
            RollDice();
        }
    }

    #region ������
    public void RollDice()
    {
        if (isRolling) return;
        else {
            isRolling = true;
            StartCoroutine(RollDice_());
        }
    }
    //����Э��������һ��ת����
    IEnumerator RollDice_()
    {
        yield return new WaitForSeconds(0.5f);
        isRolling = false;
        //�������������Ӷ����󣬸���һ�ε�ǰ���ӵ�����
        RenewDiceSideValue();
    }
    #endregion

    #region ��������
    public void RenewDiceSideValue()
    {
        if (!isRolling) {
            //�����ȡ��ǰ���ӵ�����һ��
            currentSideIndex = Random.Range(0, currentSideList.Count);
            currentDiceSide = currentSideList[currentSideIndex];
            diceNum = GetDiceNum();
        }
    }
    #endregion

    #region ��ȡ����
    public DiceSideEnum GetDiceSideValue()
    {
        return currentDiceSide;
    }

    //����ǰ����Ϊ����1-6���򷵻ض�Ӧ�ġ�������ֵ�������򷵻�0
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
