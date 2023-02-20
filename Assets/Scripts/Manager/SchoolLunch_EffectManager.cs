using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLunch_EffectManager : MonoBehaviour
{
    [SerializeField]Animator judgementAnimator = null;
    [SerializeField]Animator MoveArmAnimator = null;
    [SerializeField]UnityEngine.UI.Image judgementImage = null;
    [SerializeField]Sprite[] judgementSprite = null;

    int[] judgementRecord = new int[5];
    
    string hit = "Hit";

    public void JudgementEffect(int p_num)//판정효과
    {
        judgementImage.sprite = judgementSprite[p_num];
        judgementAnimator.SetTrigger(hit); //판정 애니메이션 실행
        judgementRecord[p_num]++;      //판정 기록
    }

    public void MoveArmEffect()//학생 클릭하면 밥주는 애니메이션
    {
        MoveArmAnimator.SetTrigger(hit);
    }

    public int[] GetJudgementRecord()//판정기록 내보내기(결과창에서 사용)
    {
        return judgementRecord;
    }

    public void Initialized()//판정기록 리셋
    {
        judgementRecord[0] = 0;
        judgementRecord[1] = 0;
        judgementRecord[2] = 0;
        judgementRecord[3] = 0;
        judgementRecord[4] = 0;
    }
}
