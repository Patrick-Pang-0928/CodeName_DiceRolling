using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceController : MonoBehaviour
{
    [Header("���Ӳ���")]
    public int diceNum = 1;
    public bool isRolling = false;

    private void Update()
    {
        //������������������
        if (!isRolling && Input.GetMouseButtonUp(0))
        {
            RollDice();
        }
    }

    #region ������
    public void RollDice()
    {
        if (isRolling) return;
        else
        {
            isRolling = true;
            StartCoroutine(RollDice_());
        }
    }
    //����Э��������һ��ת����
    IEnumerator RollDice_()
    {
        yield return new WaitForSeconds(0.5f);
        isRolling = false;
        //ÿ����������Ӻ�Ĭ�ϸ�������һ��
        DiceNumRenew();
    }
    #endregion

    #region ��������
    public void DiceNumRenew()
    {
        if (!isRolling)
        {
            //���������1��6���е���һ������
            diceNum = Random.Range(1, 7);
        }
    }
    #endregion

    #region �������
    public int DiceNumCheck()
    {
        return diceNum;
    }
    #endregion
}