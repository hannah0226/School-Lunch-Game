using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLunch_NoteManeger : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;

    int spawn_obj=0;
    int StudentNum = 0;
    Vector3 tfNoteAppear = new Vector3(-1400,60,0);

    SchoolLunch_EffectManager theEffect;
    SchoolLunch_ComboManager theComboManager;
    SchoolLunch_StartBGM theStartBGM;

    public GameObject StudentOHappy;
    public GameObject StudentOSad;
    public GameObject StudentXHappy;
    public GameObject StudentXSad;

    void Start()
    {
        theEffect = FindObjectOfType<SchoolLunch_EffectManager>();
        theComboManager = FindObjectOfType<SchoolLunch_ComboManager>();
        theStartBGM = FindObjectOfType<SchoolLunch_StartBGM>();
    }

    void Update()
    {
        if(SchoolLunch_GameManager.instance.isStartGame)//isStartGame이 true이면 게임 시작
        {
            if(StudentNum == 0)//BGM시작
                theStartBGM.Invoke("MusicStart",1);
            if(StudentNum <= 83)//학생 총 83명까지만 나오도록
            {
                currentTime += Time.deltaTime;
                if(currentTime >= 140d/bpm)//140bpm에 맞춰 학생 출력
                {
                    if(StudentNum >= 3)
                    {
                        spawn_obj = Random.Range(1,3);
                        if(spawn_obj == 1)   //랜덤수가 1이라면 식판 든 학생 생성
                        {
                            GameObject StudentO = SchoolLunch_ObjectPool.instance.StudentOQueue.Dequeue();
                            StudentO.transform.localPosition = tfNoteAppear;
                            StudentO.SetActive(true);
                        }                                                                   
                        else   //랜덤수가 2라면 식판 들지 않은 학생 생성
                        {
                            GameObject StudentX = SchoolLunch_ObjectPool.instance.StudentXQueue.Dequeue();
                            StudentX.transform.localPosition = tfNoteAppear;
                            StudentX.SetActive(true);
                        }                   
                    }                                                                                
                    currentTime -= 140d / bpm;
                    StudentNum++;
                }
            }
        }
        
    }

    public void Initialized()//학생수,시간 모두 초기화(게임 다시시작할 때 사용)
    {
        StudentNum = 0;
        currentTime = 0d;
        spawn_obj=0;
    }

    //학생 누르면 Happy/Sad로 바꾸는 함수들
    public void ChangeStudentOHappy(int x)//식판 든 학생 행복
    {
        GameObject StudentOHappy = SchoolLunch_ObjectPool.instance.StudentOHappyQueue.Dequeue();
        StudentOHappy.transform.localPosition = new Vector3(x, 60, 0);
        StudentOHappy.SetActive(true);
        StartCoroutine(DelayTime(StudentOHappy));
        SchoolLunch_ObjectPool.instance.StudentOHappyQueue.Enqueue(StudentOHappy);
    }
    public void ChangeStudentOSad(int x)//식판 든 학생 슬픔
    {
        GameObject StudentOSad = SchoolLunch_ObjectPool.instance.StudentOSadQueue.Dequeue();
        StudentOSad.transform.localPosition = new Vector3(x, 60, 0);
        StudentOSad.SetActive(true);
        StartCoroutine(DelayTime(StudentOSad));
        SchoolLunch_ObjectPool.instance.StudentOSadQueue.Enqueue(StudentOSad);
    }
    public void ChangeStudentXHappy(int x)//식판 안든 학생 행복
    {
        GameObject StudentXHappy = SchoolLunch_ObjectPool.instance.StudentXHappyQueue.Dequeue();
        StudentXHappy.transform.localPosition = new Vector3(x, 60, 0);
        StudentXHappy.SetActive(true);
        StartCoroutine(DelayTime(StudentXHappy));
        SchoolLunch_ObjectPool.instance.StudentXHappyQueue.Enqueue(StudentXHappy);
    }
    public void ChangeStudentXSad(int x)//식판 안든 학생 슬픔
    {
        GameObject StudentXSad = SchoolLunch_ObjectPool.instance.StudentXSadQueue.Dequeue();
        StudentXSad.transform.localPosition = new Vector3(x, 60, 0);
        StudentXSad.SetActive(true);
        StartCoroutine(DelayTime(StudentXSad));
        SchoolLunch_ObjectPool.instance.StudentXSadQueue.Enqueue(StudentXSad);
    }

    IEnumerator DelayTime(GameObject studentQueue)//행복or슬픔으로 바꾼 학생들 0.5초 뒤 사라지게
    {
        yield return new WaitForSeconds(0.5f);
        studentQueue.SetActive(false);
    }
}
