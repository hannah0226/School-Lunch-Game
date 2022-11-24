using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManeger : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;

    [SerializeField]Vector3 tfNoteAppear = new Vector3(0,0,0);
    [SerializeField]GameObject Note_O = null, Note_X = null;
    //GameObject t_note = null;
    int spawn_obj=0;
    int StudentNum = 0;
    
    EffectManager theEffect;
    ComboManager theComboManager;

    public GameObject StudentOHappy;
    public GameObject StudentOSad;
    public GameObject StudentXHappy;
    public GameObject StudentXSad;

    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theComboManager = FindObjectOfType<ComboManager>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        //일정 시간마다 학생 생성 함수
        if(StudentNum <= 82)
        {
            if(currentTime >= 140d/bpm)
            {
                if(StudentNum >= 2)
                {
                    spawn_obj = Random.Range(1,3);
                    if(spawn_obj == 1)                                                                   //랜덤수가 1이라면 식판 든 학생 생성
                    {
                        GameObject StudentO = Instantiate(Note_O,tfNoteAppear,Quaternion.identity);
                        StudentO.transform.SetParent(this.transform,false);
                    }                                                                   
                    else                                                                                  //랜덤수가 2라면 식판 들지 않은 학생 생성
                    {
                        GameObject StudentX = Instantiate(Note_X,tfNoteAppear,Quaternion.identity);
                        StudentX.transform.SetParent(this.transform,false);
                    }                   
                }                                                                                
                currentTime -= 140d / bpm;
                StudentNum++;
            }
        }
    }

    //화면 밖 학생 파괴 함수
    private void OnTriggerExit2D(Collider2D collision) 
    {
        theEffect.JudgementEffect(4);
        theComboManager.ResetCombo();
        Destroy(collision.gameObject);
    }

    //학생 누르면 Happy/Sad로 바꾸는 함수들
    public void ChangeStudentOHappy(int x)
    {
        GameObject theStudentOHappy = Instantiate(StudentOHappy, new Vector3(x, 0, 0), Quaternion.identity);
        theStudentOHappy.transform.SetParent(this.transform,false);
        Destroy(theStudentOHappy,0.5f);
    }
    public void ChangeStudentOSad(int x)
    {
        GameObject theStudentOSad = Instantiate(StudentOSad, new Vector3(x, 0, 0), Quaternion.identity);
        theStudentOSad.transform.SetParent(this.transform,false);
        Destroy(theStudentOSad,0.5f);
    }
    public void ChangeStudentXHappy(int x)
    {
        GameObject theStudentXHappy = Instantiate(StudentXHappy, new Vector3(x, 0, 0), Quaternion.identity);
        theStudentXHappy.transform.SetParent(this.transform,false);
        Destroy(theStudentXHappy,0.5f);
    }
    public void ChangeStudentXSad(int x)
    {
        GameObject theStudentXSad = Instantiate(StudentXSad, new Vector3(x, 0, 0), Quaternion.identity);
        theStudentXSad.transform.SetParent(this.transform,false);
        Destroy(theStudentXSad,0.5f);
    }
}
