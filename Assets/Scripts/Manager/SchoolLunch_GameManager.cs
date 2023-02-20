using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLunch_GameManager : MonoBehaviour
{
    public static SchoolLunch_GameManager instance;
    public bool isStartGame = false;//게임시작 변수(상태확인)
    public bool isStartTutorial = false;//튜토리얼 변수(상태확인)

    SchoolLunch_NoteManeger theNote;
    SchoolLunch_ComboManager theCombo;
    SchoolLunch_ScoreManager theScore;
    SchoolLunch_EffectManager theEffect;

    void Start()
    {
        isStartTutorial = true;
        instance = this;
        theNote = FindObjectOfType<SchoolLunch_NoteManeger>();
        theCombo = FindObjectOfType<SchoolLunch_ComboManager>();
        theScore = FindObjectOfType<SchoolLunch_ScoreManager>();
        theEffect = FindObjectOfType<SchoolLunch_EffectManager>();
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
