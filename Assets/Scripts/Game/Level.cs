using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
  public Character[] characters;
  public string nextLevel;

  void Awake()
  {
    Game.instance.level = this;
  }
}
