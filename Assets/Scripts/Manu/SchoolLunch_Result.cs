using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//결과창
public class SchoolLunch_Result : MonoBehaviour
{
    [SerializeField]GameObject goUI = null;
    [SerializeField]GameObject GameClear = null;
    [SerializeField]GameObject GameOver = null;

    [SerializeField]UnityEngine.UI.Text[] txtCount = null;
    [SerializeField]UnityEngine.UI.Text txtScore = null;

    SchoolLunch_ScoreManager theScore;
    SchoolLunch_EffectManager theEffect;

    AudioSource EndingSound;

    void Start()
    {
        theScore = FindObjectOfType<SchoolLunch_ScoreManager>();
        theEffect = FindObjectOfType<SchoolLunch_EffectManager>();
        EndingSound = GetComponent<AudioSource>();
    }

    public void ShowResult()//결과창 보이도록
    {
        EndingSound.Play();
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

        if(t_currentScore >= 1500)
            GameClear.SetActive(true);
        else
            GameOver.SetActive(true);
    }

    public void ButtonRestart()//다시시작 버튼 눌렀을 때
    {
        goUI.SetActive(false);
        GameClear.SetActive(false);
        GameOver.SetActive(false);
        SchoolLunch_GameManager.instance.GameReset();
    }
}
