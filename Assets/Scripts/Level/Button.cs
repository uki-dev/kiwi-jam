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

  AudioSource audioSource;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    pressed.Invoke();
    if(audioSource)
      audioSource.Play();
  }

  void OnTriggerExit2D(Collider2D collider)
  {
    released.Invoke();
  }
}
