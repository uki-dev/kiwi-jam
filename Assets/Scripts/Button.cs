using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
	public Interactable interactable;

  void OnTriggerEnter(Collider other)
  {
		interactable.Interact();
  }

  void OnTriggerExit(Collider other)
  {
		interactable.Interact();
  }
}
