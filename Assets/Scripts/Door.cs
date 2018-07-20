using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{

    private bool isOpen = false;

    private void Open(){
        Debug.Log("the door is opening");
    }

    private void Close(){
        Debug.Log("the door is closing");
    }


    public override void Interact()
    {
        base.Interact();

        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }

    }

}
