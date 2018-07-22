//******************************************************
//*Date: 21/07/2018
//******************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
  public Sprite pressedSprite;
  public Sprite releasedSprite;

  [SerializeField]
  public UnityEvent pressedEvent;

  [SerializeField]
  public UnityEvent releasedEvent;

  AudioSource audioSource;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    pressedEvent.Invoke();
    GetComponent<SpriteRenderer>().sprite = pressedSprite;
    if(audioSource)
      audioSource.Play();
  }

  void OnTriggerExit2D(Collider2D collider)
  {
    GetComponent<SpriteRenderer>().sprite = releasedSprite;
    releasedEvent.Invoke();
  }
}
