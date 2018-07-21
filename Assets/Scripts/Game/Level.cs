using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
  public Character[] characters;

  void Awake()
  {
    Game.instance.level = this;
  }
}
