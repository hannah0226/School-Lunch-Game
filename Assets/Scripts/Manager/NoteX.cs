using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NoteX : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public float noteSpeed = 400;
    public float startTouchPosition;
    public float endTouchPosition;
    EffectManager theEffect;
    ScoreManager theScoreManager;
    ComboManager theComboManager;
    NoteManeger theNoteManager;

    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theComboManager = FindObjectOfType<ComboManager>();
        theNoteManager = FindObjectOfType<NoteManeger>();
    }

    void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        startTouchPosition = transform.localPosition.x;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        int PerfectX1=-50, PerfectX2=50, CoolX1=-100, CoolX2=100, GoodX1=-200, GoodX2=200, BadX1=-400, BadX2=400;
        int PositionX = Mathf.RoundToInt(transform.localPosition.x);
        endTouchPosition = transform.localPosition.x;
        if(endTouchPosition >= startTouchPosition + 100)
        {
            if(PerfectX1 <= PositionX && PositionX <= PerfectX2)
            {
                theEffect.JudgementEffect(0);
                theScoreManager.IncreaseScore(0);
                theNoteManager.ChangeStudentXHappy(PositionX);
            }
            else if(CoolX1 <= PositionX && PositionX <= CoolX2)
            {
                theEffect.JudgementEffect(1);
                theScoreManager.IncreaseScore(1);
                theNoteManager.ChangeStudentXHappy(PositionX);
            }
            else if(GoodX1 <= PositionX && PositionX <= GoodX2)
            {
                theEffect.JudgementEffect(2);
                theScoreManager.IncreaseScore(2);
                theNoteManager.ChangeStudentXHappy(PositionX);
            }
            else if(BadX1 <= PositionX && PositionX <= BadX2)
            {
                theEffect.JudgementEffect(3);
                theScoreManager.IncreaseScore(3);
                theComboManager.ResetCombo();
                theNoteManager.ChangeStudentXSad(PositionX);
            }
            else
            {
                theEffect.JudgementEffect(4);
                theScoreManager.IncreaseScore(4);
                theComboManager.ResetCombo();
                theNoteManager.ChangeStudentXSad(PositionX);
            }
            ObjectPool.instance.StudentXQueue.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int PositionX = Mathf.RoundToInt(transform.localPosition.x);
        theEffect.JudgementEffect(4);
        theScoreManager.IncreaseScore(4);
        theComboManager.ResetCombo();
        ObjectPool.instance.StudentXQueue.Enqueue(gameObject);
        gameObject.SetActive(false);
        theNoteManager.ChangeStudentXSad(PositionX);
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        theEffect.JudgementEffect(4);
        theComboManager.ResetCombo();
        ObjectPool.instance.StudentXQueue.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
}
