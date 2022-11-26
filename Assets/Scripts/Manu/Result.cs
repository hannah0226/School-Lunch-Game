using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField]GameObject goUI = null;
    [SerializeField]GameObject GameClear = null;
    [SerializeField]GameObject GameOver = null;

    [SerializeField]UnityEngine.UI.Text[] txtCount = null;
    [SerializeField]UnityEngine.UI.Text txtScore = null;

    ScoreManager theScore;
    EffectManager theEffect;

    void Start()
    {
        theScore = FindObjectOfType<ScoreManager>();
        theEffect = FindObjectOfType<EffectManager>();
    }

    public void ShowResult()
    {
        goUI.SetActive(true);
        for(int i = 0; i < txtCount.Length; i++)
            txtCount[i].text = "0";
        txtScore.text = "0";

        int[] t_judgement = theEffect.GetJudgementRecord();
        int t_currentScore = theScore.GetCurrentScore();

        for(int i = 0; i < txtCount.Length; i++)
        {
            txtCount[i].text = string.Format("{0:#,##0}", t_judgement[i]);
        }

        txtScore.text = string.Format("{0:#,##0}", t_currentScore);

        if(t_currentScore >= 1000)
            GameClear.SetActive(true);
        else
            GameOver.SetActive(true);
    }

    public void ButtonRestart()
    {
        goUI.SetActive(false);
        GameClear.SetActive(false);
        GameOver.SetActive(false);
        GameManager.instance.GameStart();
    }
}
