using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLunch_Tutorial : MonoBehaviour
{
    [SerializeField]GameObject Text1 = null;
    [SerializeField]GameObject Text2 = null;
    [SerializeField]GameObject Text3 = null;

    void Update()
    {
        if(SchoolLunch_GameManager.instance.isStartTutorial)
        {
            Text1.SetActive(true);//튜토리얼 1페이지
        }
    }

    public void Button1()//click버튼 누르면 2페이지 보이게
    {
        Text1.SetActive(false);
        SchoolLunch_GameManager.instance.isStartTutorial = false;
        Text2.SetActive(true);
    }
    public void Button2()//click버튼 누르면 3페이지 보이게
    {
        Text2.SetActive(false);
        Text3.SetActive(true);
    }
    public void Button3()//click버튼 누르면 게임 시작
    {
        Text3.SetActive(false);
        SchoolLunch_GameManager.instance.GameStart();
    }
}
