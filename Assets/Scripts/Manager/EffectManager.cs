using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField]Animator judgementAnimator = null;
    [SerializeField]Animator MoveArmAnimator = null;
    [SerializeField]UnityEngine.UI.Image judgementImage = null;
    [SerializeField]Sprite[] judgementSprite = null;

    int[] judgementRecord = new int[5];
    
    string hit = "Hit";

    public void JudgementEffect(int p_num)
    {
        judgementImage.sprite = judgementSprite[p_num];
        judgementAnimator.SetTrigger(hit);
        judgementRecord[p_num]++;                             //판정 기록
    }

    public void MoveArmEffect()
    {
        MoveArmAnimator.SetTrigger(hit);
    }

    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }
}
