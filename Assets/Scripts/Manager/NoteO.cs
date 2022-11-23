using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class NoteO : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float noteSpeed = 400;
    public int startTouchPosition;
    public int endTouchPosition;
    EffectManager theEffect;
    ScoreManager theScoreManager;
    ComboManager theComboManager;
    NoteManeger theNoteManager;

    void OnEnable()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theComboManager = FindObjectOfType<ComboManager>();
        theNoteManager = FindObjectOfType<NoteManeger>();
    }

    void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;                    //학생 오른쪽으로 움직이기
    }

    public void OnPointerClick(PointerEventData eventData)                                       //학생을 눌렀을 때 구역에 따라 판정효과 출력                    
    {
        theEffect.MoveArmEffect();
        int PerfectX1=-50, PerfectX2=50, CoolX1=-100, CoolX2=100, GoodX1=-200, GoodX2=200, BadX1=-400, BadX2=400;     //P,C,G,B 구역 설정
        int PositionX = Mathf.RoundToInt(transform.localPosition.x);
        if(PerfectX1 <= PositionX && PositionX <= PerfectX2)
        {
            theEffect.JudgementEffect(0);
            theScoreManager.IncreaseScore(0);
            Destroy(gameObject);
            theNoteManager.ChangeStudentOHappy(PositionX);
        }
        else if(CoolX1 <= PositionX && PositionX <= CoolX2)
        {
            theEffect.JudgementEffect(1);
            theScoreManager.IncreaseScore(1);
            Destroy(gameObject);
            theNoteManager.ChangeStudentOHappy(PositionX);
        }
        else if(GoodX1 <= PositionX && PositionX <= GoodX2)
        {
            theEffect.JudgementEffect(2);
            theScoreManager.IncreaseScore(2);
            Destroy(gameObject);
            theNoteManager.ChangeStudentOHappy(PositionX);
        }
        else if(BadX1 <= PositionX && PositionX <= BadX2)
        {
            theEffect.JudgementEffect(3);
            theScoreManager.IncreaseScore(3);
            theComboManager.ResetCombo();
            Destroy(gameObject);
            theNoteManager.ChangeStudentOSad(PositionX);
        }
        else
        {
            theEffect.JudgementEffect(4);
            theScoreManager.IncreaseScore(4);
            theComboManager.ResetCombo();
            Destroy(gameObject);
            theNoteManager.ChangeStudentOSad(PositionX);
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        startTouchPosition = Mathf.RoundToInt(transform.localPosition.x);
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
    
    public void OnEndDrag(PointerEventData eventData)                              //스와이프하면 miss뜨도록(식판든 학생이기 때문)
    {
        endTouchPosition = Mathf.RoundToInt(transform.localPosition.x);
        if(endTouchPosition >= startTouchPosition + 100)
        {
            theEffect.JudgementEffect(4);
            theScoreManager.IncreaseScore(4);
            theComboManager.ResetCombo();
            Destroy(gameObject);
            theNoteManager.ChangeStudentOSad(endTouchPosition);
        }
        
    }
    
}
