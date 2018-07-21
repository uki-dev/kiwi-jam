using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public SpriteRenderer door;
    public Sprite openDoor;
    public Sprite doorClosed;

    private bool isOpen = false;

    private void Open(){
        isOpen = true;
        Debug.Log("the door is opening");
    }

    private void Close(){
        isOpen = false;
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
