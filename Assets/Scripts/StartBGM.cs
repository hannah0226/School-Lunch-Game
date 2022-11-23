using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBGM : MonoBehaviour
{
    AudioSource myAudio;
    Result theResult;
    bool musicStart = false;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        theResult = FindObjectOfType<Result>();
        Invoke("MusicStart",1);
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
            }
        }
    }

    void MusicStart()
    {
        myAudio.Play();
        musicStart = true;
    }
}
