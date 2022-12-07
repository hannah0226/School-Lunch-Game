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
            else
            {
                theResult.ShowResult();  
                GameManager.instance.isStartGame = false;
                musicStart = false;
            }
        }
    }

    void MusicStart()
    {
        myAudio.Play();
        musicStart = true;
    }

    public void EffectSoundO()
    {
        myAudio.PlayOneShot(effectSoundO);
    }

    public void EffectSoundX()
    {
        myAudio.PlayOneShot(effectSoundX);
    }
}
