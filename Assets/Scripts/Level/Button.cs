//******************************************************
//*Date: 21/07/2018
//******************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
  [SerializeField]
  public UnityEvent pressed;

  [SerializeField]
  public UnityEvent released;

  void OnTriggerEnter2D(Collider2D collider)
  {
    pressed.Invoke();
    GetComponent<AudioSource>().Play();
  }

  void OnTriggerExit2D(Collider2D collider)
  {
    released.Invoke();
  }
}
