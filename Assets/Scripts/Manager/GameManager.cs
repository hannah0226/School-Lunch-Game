using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isStartGame = false;//게임시작 변수(상태확인)
    public bool isStartTutorial = false;//튜토리얼 변수(상태확인)

    NoteManeger theNote;
    ComboManager theCombo;
    ScoreManager theScore;
    EffectManager theEffect;

    void Start()
    {
        isStartTutorial = true;
        instance = this;
        theNote = FindObjectOfType<NoteManeger>();
        theCombo = FindObjectOfType<ComboManager>();
        theScore = FindObjectOfType<ScoreManager>();
        theEffect = FindObjectOfType<EffectManager>();
    }

    
    public void GameReset()//모든 기록 리셋
    {
        theNote.Initialized();
        theCombo.ResetCombo();
        theScore.Initialized();
        theEffect.Initialized();
        isStartTutorial = true;
    }
    public void GameStart()//게임 시작
    {
        isStartGame = true;
        theScore.ScoreShow();
    }
}
