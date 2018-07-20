using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    
    public Interactable interactable;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    	interactable.Interact();
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
	    interactable.Interact();
    }
}
