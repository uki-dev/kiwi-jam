//******************************************************
//*Date: 21/07/2018
//******************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
  public Interactable interactable;

  void OnTriggerEnter2D(Collider2D collider)
  {
    Debug.Log("Trigger");
    interactable.Interact();
  }

  void OnTriggerExit2D(Collider2D collider)
  {
    interactable.Interact();
  }
}
