using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceAnimations : MonoBehaviour
{
    public Animator anim;
    public DiceController diceController;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        diceController = GetComponent<DiceController>();
    }

    private void Update()
    {
        Set_Animation();
    }

    public void Set_Animation()
    {
        anim.SetInteger("diceNum", diceController.diceNum);
        anim.SetBool("isRolling", diceController.isRolling);
    }
}
