using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]UnityEngine.UI.Text txtScore = null;
    [SerializeField]int increaseScore = 10;
    int currentScore = 0;
    [SerializeField]float[]weight = null;
    [SerializeField]int comboBonouseScore = 10;

    ComboManager theCombo;

    void Start()
    {
        theCombo = FindObjectOfType<ComboManager>();
        txtScore.gameObject.SetActive(false);
        //currentScore = 0;
        //txtScore.text = "0";
    }

    public void Initialized()
    {
        currentScore = 0;
        txtScore.text = "0";
        txtScore.gameObject.SetActive(false);
    }

    public void ScoreShow()
    {
        txtScore.gameObject.SetActive(true);
    }

    public void IncreaseScore(int p_JudgementState)
    {
        //콤보 증가
        theCombo.IncreaseCombo();

        //콤보 가중치 계산
        int t_currentCombo = theCombo.GetCurrentCombo();
        int t_bonouseComboScore = (t_currentCombo/10) * comboBonouseScore;

        //가중치 계산
        int t_increaseScore = increaseScore + t_bonouseComboScore;
        t_increaseScore = (int)(t_increaseScore * weight[p_JudgementState]);

        //점수 반영
        currentScore += t_increaseScore;
        txtScore.text = string.Format("{0:#,##0}", currentScore);
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
