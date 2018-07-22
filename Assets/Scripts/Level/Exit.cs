using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D collider)
  {
    Level.current.Complete();
  }
}
