using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isStartGame = false;

    NoteManeger theNote;
    ComboManager theCombo;
    ScoreManager theScore;
    EffectManager theEffect;

    void Start()
    {
        isStartGame = true;
        instance = this;
        theNote = FindObjectOfType<NoteManeger>();
        theCombo = FindObjectOfType<ComboManager>();
        theScore = FindObjectOfType<ScoreManager>();
        theEffect = FindObjectOfType<EffectManager>();
    }

    
    public void GameStart()
    {
        theNote.Initialized();
        theCombo.ResetCombo();
        theScore.Initialized();
        theEffect.Initialized();
        isStartGame = true;
    }
}
