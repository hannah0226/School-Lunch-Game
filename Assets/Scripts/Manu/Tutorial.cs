using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]GameObject Text1 = null;
    [SerializeField]GameObject Text2 = null;
    [SerializeField]GameObject Text3 = null;

    void Update()
    {
        if(GameManager.instance.isStartTutorial)
        {
            Text1.SetActive(true);
        }
    }

    public void Button1()
    {
        Text1.SetActive(false);
        GameManager.instance.isStartTutorial = false;
        Text2.SetActive(true);
    }
    public void Button2()
    {
        Text2.SetActive(false);
        Text3.SetActive(true);
    }
    public void Button3()
    {
        Text3.SetActive(false);
        GameManager.instance.GameStart();
    }
}
