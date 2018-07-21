using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExiting : MonoBehaviour {

    AudioSource audio_exit_success;
    void Start()
    {
        if (GetComponent<AudioSource>()){
            audio_exit_success = GetComponent<AudioSource>();
        }

    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (audio_exit_success){
            audio_exit_success.Play();
        }


        GameManager.instance.GoNextLevel();
    }


}
