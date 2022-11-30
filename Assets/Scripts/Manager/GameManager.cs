using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isStartGame = false;
    public bool isStartTutorial = false;

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

    
    public void GameReset()
    {
        theNote.Initialized();
        theCombo.ResetCombo();
        theScore.Initialized();
        theEffect.Initialized();
        isStartTutorial = true;
    }
    public void GameStart()
    {
        isStartGame = true;
    }
}
