//******************************************************
//*Date: 21/07/2018
//******************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    AudioSource audio2;
    void Start()
    {
         audio2 = GetComponent<AudioSource>();


    }
    public Interactable interactable;

    void OnTriggerEnter2D(Collider2D collider)
    {
        audio2.Play();
        interactable.Interact();
    }

    void OnTriggerExit2D(Collider2D collider)
    {
    interactable.Interact();
    }
}
