using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartBGM : MonoBehaviour
{
    AudioSource myAudio;
    Result theResult;
    bool musicStart = false;
    public AudioClip effectSoundO;
    public AudioClip effectSoundX;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        theResult = FindObjectOfType<Result>();
    }

    void Update()
    {
        if(musicStart)
        {
            if (myAudio.isPlaying)
            {
    
            }
            else//노래 끝나면 결과창 보이도록
            {
                theResult.ShowResult();  
                GameManager.instance.isStartGame = false;
                musicStart = false;
            }
        }
    }

    void MusicStart()//노래 시작 함수
    {
        myAudio.Play();
        musicStart = true;
    }

    public void EffectSoundO()//perfect,cool,good 효과음
    {
        myAudio.PlayOneShot(effectSoundO);
    }

    public void EffectSoundX()//bad,miss 효과음
    {
        myAudio.PlayOneShot(effectSoundX);
    }
}
