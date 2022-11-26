using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManeger : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;

    int spawn_obj=0;
    int StudentNum = 0;
    Vector3 tfNoteAppear = new Vector3(-1400,60,0);

    EffectManager theEffect;
    ComboManager theComboManager;
    StartBGM theStartBGM;

    public GameObject StudentOHappy;
    public GameObject StudentOSad;
    public GameObject StudentXHappy;
    public GameObject StudentXSad;

    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theComboManager = FindObjectOfType<ComboManager>();
        theStartBGM = FindObjectOfType<StartBGM>();
    }

    void Update()
    {
        if(GameManager.instance.isStartGame)
        {
            if(StudentNum == 0)
                theStartBGM.Invoke("MusicStart",1);
            if(StudentNum <= 83)
            {
                currentTime += Time.deltaTime;
                if(currentTime >= 140d/bpm)
                {
                    if(StudentNum >= 3)
                    {
                        spawn_obj = Random.Range(1,3);
                        if(spawn_obj == 1)   //랜덤수가 1이라면 식판 든 학생 생성
                        {
                            GameObject StudentO = ObjectPool.instance.StudentOQueue.Dequeue();
                            StudentO.transform.localPosition = tfNoteAppear;
                            StudentO.SetActive(true);
                        }                                                                   
                        else   //랜덤수가 2라면 식판 들지 않은 학생 생성
                        {
                            GameObject StudentX = ObjectPool.instance.StudentXQueue.Dequeue();
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

    public void Initialized()
    {
        StudentNum = 0;
        currentTime = 0d;
        spawn_obj=0;
    }

    //학생 누르면 Happy/Sad로 바꾸는 함수들
    public void ChangeStudentOHappy(int x)
    {
        GameObject StudentOHappy = ObjectPool.instance.StudentOHappyQueue.Dequeue();
        StudentOHappy.transform.localPosition = new Vector3(x, 60, 0);
        StudentOHappy.SetActive(true);
        StartCoroutine(DelayTime(StudentOHappy));
        ObjectPool.instance.StudentOHappyQueue.Enqueue(StudentOHappy);
    }
    public void ChangeStudentOSad(int x)
    {
        GameObject StudentOSad = ObjectPool.instance.StudentOSadQueue.Dequeue();
        StudentOSad.transform.localPosition = new Vector3(x, 60, 0);
        StudentOSad.SetActive(true);
        StartCoroutine(DelayTime(StudentOSad));
        ObjectPool.instance.StudentOSadQueue.Enqueue(StudentOSad);
    }
    public void ChangeStudentXHappy(int x)
    {
        GameObject StudentXHappy = ObjectPool.instance.StudentXHappyQueue.Dequeue();
        StudentXHappy.transform.localPosition = new Vector3(x, 60, 0);
        StudentXHappy.SetActive(true);
        StartCoroutine(DelayTime(StudentXHappy));
        ObjectPool.instance.StudentXHappyQueue.Enqueue(StudentXHappy);
    }
    public void ChangeStudentXSad(int x)
    {
        GameObject StudentXSad = ObjectPool.instance.StudentXSadQueue.Dequeue();
        StudentXSad.transform.localPosition = new Vector3(x, 60, 0);
        StudentXSad.SetActive(true);
        StartCoroutine(DelayTime(StudentXSad));
        ObjectPool.instance.StudentXSadQueue.Enqueue(StudentXSad);
    }

    IEnumerator DelayTime(GameObject studentQueue)
    {
        yield return new WaitForSeconds(0.5f);
        studentQueue.SetActive(false);
    }
}
