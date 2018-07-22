using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
  public static Game instance = null;

  void Awake()
  {
    if (!instance)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
      Destroy(gameObject);
  }

  public void GameOver()
  {
  }
}