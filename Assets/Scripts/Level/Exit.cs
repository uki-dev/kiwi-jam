using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D collider)
  {
    Game.instance.level.Complete();
  }
}
