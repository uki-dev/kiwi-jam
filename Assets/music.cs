using System.Collections;
using System.Collections.Generic;
//******************************************************
//*Date: 22/07/2018
//******************************************************
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class music : MonoBehaviour {
    

    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
    }
    void Update()
    {
        if (true)//!audio.isPlaying && audio.clip.isReadyToPlay)
        {
           
        }
    }

}
